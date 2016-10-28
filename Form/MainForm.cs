﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Net;
using System.Collections;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using Shell32;

namespace FilmCollection
{
    public partial class MainForm : Form
    {
        RecordCollection _videoCollection = new RecordCollection();     // Доступ к коллекции
        TreeViewColletion _treeViewColletion = new TreeViewColletion(); // Доступ к коллекции

        FileInfo fsInfo = null;     // Поле для нового файла, добавляемого в базу

        int FindCount { get; set; }                 // счетчик найденных строк
        public List<int> dgvSelected { get; set; }  // индексы найденных строк

        #region Главная форма (Main)

        public MainForm()                           //Конструктор формы
        {
            InitializeComponent();                  // Создание и отрисовка элементов
            this.MinimumSize = new Size(800, 600);  // Установка минимального размера формы

            dgvTableRec.AutoGenerateColumns = false;    // Отключение автоматического заполнения таблицы
            dgvTableActors.AutoGenerateColumns = false; // Отключение автоматического заполнения таблицы

            dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона
            dgvTableRec.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста

            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию
            dgvSelected = new List<int>();          // хранение поисковых индексов

            // Создание списка на основе перечисления
            foreach (var item in Enum.GetValues(typeof(CategoryVideo_Rus)))
            { cBoxTypeVideo.Items.Add(item); }

            foreach (var item in Enum.GetValues(typeof(GenreVideo_Rus)))
            { cBoxGenre.Items.Add(item); }

            foreach (var item in Enum.GetValues(typeof(Country_Rus)))
            {
                cBoxCountry.Items.Add(item);
                cBoxCountryActor.Items.Add(item);
                tscCountryFilter.Items.Add(item);
            }
        }

        private void T_Tick(object sender, EventArgs e)     // таймер для селекта MainForm_Load
        {
            timerLoad.Enabled = false;
            treeFolder.SelectedNode = null;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }

        private void Main_Load(object sender, EventArgs e)              // Загрузка формы
        {
            FormLoad();
        }

        private void Main_Close(object sender, FormClosingEventArgs e)  // Закрытие формы или выход
        {
            FormClose(e);
        }

        private void FormLoad()
        {
            if (File.Exists(RecordOptions.BaseName))    // Если база создана, то загружаем
            {
                try
                {
                    _videoCollection = RecordCollection.Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    BackupBase();   // на всякий случай делаем бэкап
                    return;
                }

                if (_videoCollection.VideoList.Count > 0)
                {
                    tssLabel.Text = "Коллекция из " + _videoCollection.VideoList.Count.ToString() + " элементов";
                    PepareRefresh();
                    CreateTree();
                }
                timerLoad.Enabled = true;               // Исключение раннего селекта treeFolder и фильтра dataGridView1
            }
            LoadFormVisualEffect();
            Form_Tooltip();
        }

        private void Form_Tooltip()     // Всплывающая подсказка
        {
            toolinfo.SetToolTip(btnFileNameEdit, "Разблокировать для переименования файла");
        }

        private void FormClose(FormClosingEventArgs e)    // обработка события Close()
        {
            DialogResult dialog = MessageBox.Show("Вы уверены что хотите выйти из программы?",
                                                  "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            _videoCollection.Save();
            SaveFormVisualEffect();
        }

        private void LoadFormVisualEffect()
        {
            //#region Восстановление состояния главной формы
            //string switch_on = _videoCollection.Options.FormState;
            //switch (switch_on)
            //{
            //    case "Normal": WindowState = FormWindowState.Normal; break;
            //    case "Minimized": WindowState = FormWindowState.Minimized; break;
            //    case "Maximized": WindowState = FormWindowState.Maximized; break;
            //    default: WindowState = FormWindowState.Maximized; break;
            //}
            //#endregion

            //#region Восстановление состояния сплиттеров
            //scMain.SplitterDistance = _videoCollection.Options.scMainSplitter;
            //scTabFilm.SplitterDistance = _videoCollection.Options.scTabFilmSplitter;
            //#endregion

            //#region Восстановление состояния ширины колонок
            //DataGridViewColumnCollection columns = dgvTable.Columns;
            //char[] delimiterChars = { ',' };
            //string text = _videoCollection.Options.ColumnsWidth;
            //if (text != null && text != "")
            //{
            //    string[] words = text.Split(delimiterChars);
            //    for (int i = 0; i < words.Length; i++)
            //    {
            //        columns[i].Width = Convert.ToInt32(words[i]);
            //    }
            //}
            //#endregion
        }

        private void SaveFormVisualEffect()
        {
            // Сохранение состояния главной формы
            _videoCollection.Options.FormState = this.WindowState.ToString();
            #region Сохранение состояния сплиттеров
            _videoCollection.Options.scMainSplitter = scMain.SplitterDistance;
            _videoCollection.Options.scTabFilmSplitter = scTabFilm.SplitterDistance;
            #endregion

            //#region Сохранение ширины колонок
            //DataGridViewColumnCollection columns = dgvTable.Columns;
            //_videoCollection.Options.ColumnsWidth = "";
            //for (int i = 0; i < columns.Count - 2; i++)
            //{
            //    if (i < columns.Count - 3)
            //    {
            //        _videoCollection.Options.ColumnsWidth = _videoCollection.Options.ColumnsWidth + columns[i].Width + ",";
            //    }
            //    else
            //    {
            //        _videoCollection.Options.ColumnsWidth = _videoCollection.Options.ColumnsWidth + columns[i].Width;
            //    }
            //}
            //#endregion
        }

        #endregion


        #region Обработка файла базы

        private void CreateBase()       // Создание файла базы
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.Description = "Укажите расположение файлов мультимедиа:";
            fbDialog.ShowNewFolderButton = false;

            if (File.Exists(RecordOptions.BaseName)) // Если база есть, то запрашиваем удаление
            {
                DialogResult result = MessageBox.Show("Выполнить удаление текущей базы ?",
                                                      "Удаление базы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) BackupBase();
                File.WriteAllText(RecordOptions.BaseName, string.Empty); // Затираем содержимое файла базы
                _videoCollection.clearRecordID();
                _videoCollection.ClearVideo();  // очищаем коллекцию
                treeFolder.Nodes.Clear();       // очищаем иерархию
                dgvTableRec.ClearSelection();   // выключаем селекты таблицы
                PepareRefresh();                // сбрасываем старые значения таблицы
            }
            else // Если базы нет, то создаем пустой файл базы
            {
                File.Create(RecordOptions.BaseName).Close(); // создание файла и закрытие дескриптора (Объект FileStream)
            }

            DialogResult dialogStatus = fbDialog.ShowDialog();  // Запрашиваем новый каталог с коллекцией видео

            if (dialogStatus == DialogResult.OK)
            {
                tsProgressBar.Visible = true;
                tsProgressBar.ForeColor = Color.FromArgb(255, 0, 0);
                tsProgressBar.BackColor = Color.FromArgb(150, 0, 0);

                string folderName = fbDialog.SelectedPath;         //Извлечение имени папки

                DialogResult CheckfolderName = MessageBox.Show("Источником фильмотеки выбран каталог: " + folderName, "Создание фильмотеки (" + folderName + ")",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (CheckfolderName == DialogResult.Cancel) CreateBase();

                DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки

                if (directory.Exists)
                {
                    _videoCollection.Options.Source = directory.FullName;   // Сохранение каталога фильмов

                    List<string> ext = new List<string> { ".avi", ".mkv", ".mp4", ".wmv", ".webm", ".rm", ".mpg", ".flv" };
                    var myFiles = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(s => ext.Contains(Path.GetExtension(s.ToString())));

                    foreach (FileInfo file in myFiles)
                        CreateRecordObject(file, null);
                }

                _videoCollection.Save();
                MessageBox.Show(_videoCollection.VideoList.Count.ToString());
                FormLoad();
            }
        }

        private void UpdateBase()       // Добавить обновление базы
        {
            if (_videoCollection.Options.Source == "" && _videoCollection.Options.Source == null)  // Если есть информация о корневой папки коллекции
            {
                MessageBox.Show("Необходимо создать базу данных.");
            }
            else
            {
                try
                {
                    DirectoryInfo directory = new DirectoryInfo(_videoCollection.Options.Source);

                    if (directory.Exists)   // проверяем наличие папки коллекции
                    {
                        for (int i = 0; i < _videoCollection.VideoList.Count; i++)
                            _videoCollection.VideoList[i].Visible = false;

                        foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                        {
                            Record record = new Record();
                            record.FileName = file.Name;                            // полное название файла (film.avi)
                            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)

                            if (!RecordExist(record)) CreateRecordObject(file, record); // если файла нет в коллекции, создаем
                        }

                        _videoCollection.Save();    // если все прошло гладко, то сохраняем в файл базы
                        FormLoad();                 // и перегружаем главную форму
                        MessageBox.Show("Сведения о файлах в каталоге \"" + directory + "\" обновлены!");
                    }
                    else
                        MessageBox.Show("Каталог " + directory + " не обнаружен!");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void CreateRecordObject(FileInfo file, Record record)
        {
            if (record == null)
            {
                record = new Record();
                record.FileName = file.Name;                            // полное название файла (film.avi)
                record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
            }

            string name_1 = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length); // название без расширения (film)
            string name_2 = Regex.Replace(name_1, @"[0-9]{4}", string.Empty);       // название без года
            string name_f = Regex.Replace(name_2, @"[a-zA-Z_.'()]", string.Empty);  // название без символов                       
            name_f = name_f.Trim();                         // название без пробелов вначале и конце
            record.Name = (name_f != "") ? name_f : name_1;

            //выделяем только 4 идущие подряд цифры
            foreach (Match m in Regex.Matches(name_1, @"\b[\d]{4}\b"))
                if (m.Value != "") record.Year = Convert.ToInt32(m.Value);

            record.Visible = true;
            record.Extension = file.Extension.Trim('.');            // расширение файла (avi)
            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
            record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                    // if (-1 != file.DirectoryName.Substring(dlinna).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
            _videoCollection.Add(record);
        }

        private bool RecordExist(Record record)
        {
            foreach (Record rec in _videoCollection.VideoList)// проверяем, есть ли файл в коллекции
            {
                if (rec.Equals(record))
                {
                    rec.Visible = true;
                    return true;    // если файл есть
                }
            }
            return false;           // иначе файла нет файл есть
        }


        private void BackupBase()       // Резервная копия базы
        {
            if (File.Exists(RecordOptions.BaseName)) // если есть, что бэкапить...
            {
                try
                {   // создаем бэкап
                    string FileBase = Path.GetFileNameWithoutExtension(RecordOptions.BaseName)
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss")
                        + Path.GetExtension(RecordOptions.BaseName);

                    File.Copy(RecordOptions.BaseName, FileBase);

                    MessageBox.Show("Создана резервная копия базы:\n" + FileBase + " ");
                }
                catch (IOException copyError)
                {   // если не можем создать бэкап, то ругаемся
                    MessageBox.Show(copyError.Message);
                }
            }
        }

        #endregion


        #region Главное меню

        private void CreateBase_Click(object sender, EventArgs e)
        {
            CreateBase();
        }

        private void UpdateBase_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void BackupBase_Click(object sender, EventArgs e)
        {
            BackupBase();
        }

        private void btnRecoveryBase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Текущая база будет удалена");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Сформировать отчет в формате HTML и открыть его в браузере по умолчанию 
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        #endregion

        #region Обработка DataGridView

        #region Контекстное меню для DataGridView

        private void AddRec_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            if (isRecTab()) NewRecord_Dialog();
            else NewActor();
        }

        private bool isRecTab()
        {
            return (tabControl2.SelectedIndex == 0) ? true : false;
            //if (tabControl2.SelectedIndex == 0) return true;
            //return false;
        }

        private void NewActor()
        {
            MessageBox.Show("Test");
        }

        private void EditRec_Click(object sender, EventArgs e)                 // Изменение записи
        {
            panelEdit.BringToFront();
        }

        private void DeleteRec_Click(object sender, EventArgs e)
        {
            if (isRecTab())
            {
                DeleteRec();
            }
            else
            {
                DeleteActor();
            }
        }

        private void DeleteRec()
        {
            Record record = GetSelectedRecord();
            DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + record.Name + "\" ?",
                                                  "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                _videoCollection.Remove(record);
                _videoCollection.Save();
                dgvTableRec.ClearSelection();
                PepareRefresh();
            }
        }

        private void DeleteActor()
        {
            Actor act = GetSelectedActor();

            DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + act.FIO + "\" ?",
                                                  "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                _videoCollection.Remove(act);
                _videoCollection.Save();
                dgvTableRec.ClearSelection();
                PepareRefresh();
            }
        }

        private void OLD_Add_rec(object sender, EventArgs e)        // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Add(form.rec);
                _videoCollection.Save();
                PepareRefresh();
            }
        }

        private void OLD_Change_rec(object sender, EventArgs e)     // Изменить запись
        {
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                PepareRefresh();      //Должно быть обновление вместо фильтра
            }
        }

        private DataGridView GetDgv()
        {
            return (tabControl2.SelectedIndex == 0) ? dgvTableRec : dgvTableActors;
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)    // Проверка селекта строки перед открытием меню
        {   //contextMenu.Items[4].Enabled = false;

            TabMenu.Enabled = false;    // Блокировка меню
            DataGridView dgv = GetDgv();
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1) TabMenu.Enabled = true; // Разблокировка меню
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при клике выполняется выбор строки и открывается меню
        {
            FindNextButton_Lock();
            if (e.Button == MouseButtons.Right)
            {
                try { GetMenuDgv(e); }
                catch (Exception Ex) { MessageBox.Show(Ex.Message); }
            }
        }

        private void GetMenuDgv(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                GetDgv().CurrentCell = GetDgv().Rows[e.RowIndex].Cells[e.ColumnIndex];
                GetDgv().Rows[e.RowIndex].Selected = true;
                GetDgv().Focus();
                GetDgv().ContextMenuStrip = TabMenu;
                //if (e.ColumnIndex > -1 && e.RowIndex > -1) dgvTable.CurrentCell = dgvTable[e.ColumnIndex, e.RowIndex];
            }
            else
            {
                dgvTableRec.ContextMenuStrip = null;
                dgvTableRec.ClearSelection();
            }
        }

        private void cFind_Click(object sender, EventArgs e)    // Поиск
        {
            panelFind.BringToFront();
        }
        #endregion

        private void Filter(object sender, EventArgs e)     // При выборе фильтра > сброс фильтра по дереву и таблице
        {
            dgvTableRec.ClearSelection();
            dgvTableActors.ClearSelection();
            PepareRefresh();
        }

        private void dgvTableRec_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)    // Сортировка по колонке
        {
            PepareRefresh(e.ColumnIndex);
        }

        private void PepareRefresh() => PepareRefresh("", false);
        private void PepareRefresh(int column) => PepareRefresh("", false, column);
        private void PepareRefresh(string nodeName, bool flag) => PepareRefresh(nodeName, flag, -1);
        private void PepareRefresh(string nodeName, bool flag, int column)
        {
            List<Record> filtered = _videoCollection.VideoList;

            filtered = filtered.FindAll(v => v.Visible == !cbIsVisible.Checked);
            filtered = Filter(filtered, tscbTypeFilter.SelectedIndex);

            if (nodeName != "" && nodeName != "Фильмотека")
            {
                filtered = (!flag)
                            ? filtered.FindAll(v => v.Path == _videoCollection.Options.Source + Path.DirectorySeparatorChar + nodeName)
                            : filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + nodeName));
            }

            Sort(filtered, tscbSort.SelectedIndex);
            if (column > -1) Sort(filtered, column);

            RefreshTable(filtered);
            Sort_Actor();
        }

        private static List<Record> Filter(List<Record> filtered, int switch_filter)    // фильтр по категориям
        {
            return filtered = (switch_filter != 0) ? filtered.FindAll(v => v.Category == (CategoryVideo)(switch_filter - 1)) : filtered;
        }

        private static void Sort(List<Record> filtered, int switch_sort)// Сортировка по столбцам
        {
            switch (switch_sort)
            {
                case 0: filtered.Sort(Record.CompareByName); break;
                case 1: filtered.Sort(Record.CompareByCatalog); break;
                case 2: filtered.Sort(Record.CompareByYear); break;
                case 3: filtered.Sort(Record.CompareByCountry); break;
                case 4: filtered.Sort(Record.CompareByGenre); break;
                case 5: filtered.Sort(Record.CompareByCategory); break;
                case 6: filtered.Sort(Record.CompareByTime); break;
                case 7: filtered.Sort(Record.CompareByFileName); break;
                default: break;
            }
        }

        private void Sort_Actor()
        {
            List<Actor> filteredAct = _videoCollection.ActorList;
            if (tscCountryFilter.SelectedIndex > -1)
            {
                filteredAct = filteredAct.FindAll(a => a.Country == (Country_Rus)tscCountryFilter.SelectedIndex);
            }

            dgvTableActors.DataSource = null;
            dgvTableActors.DataSource = filteredAct;

            // список актеров
            chkActorList.Items.Clear();
            foreach (Actor item in _videoCollection.ActorList)
            {
                chkActorList.Items.Add(item);
            }
        }

        private void RefreshTable(List<Record> filtered)
        {
            Record selected = GetSelectedRecord();  // получение выбранной строки
            if (selected != null) SelectRecord(dgvTableRec, selected);

            try
            {
                dgvTableRec.DataSource = null;
                dgvTableRec.DataSource = filtered;

                // отображаем другой шрифт и цвет для удаленных записей
                if (dgvTableRec.RowCount > 0)
                {
                    foreach (DataGridViewRow row in dgvTableRec.Rows)
                        if ((row.DataBoundItem as Record).Visible == false)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Silver;
                            row.DefaultCellStyle.Font = new Font(dgvTableRec.Font, FontStyle.Strikeout);
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectRecord(DataGridView dgv, Record record)
        {
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
                if ((row.DataBoundItem as Record).Name == record.Name)
                {
                    row.Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
        }


        private void SelectRecord_Info(object sender, EventArgs e)  // Отражение информации в карточке
        {
            panelView.BringToFront();               // Отображение панели описания

            // Предоставляет данные выбранной записи
            Record record = GetSelectedRecord();
            if (record != null)
            {
                // Панель описания
                tbfName.Text = record.Name;
                tbfDesc.Text = record.Description;
                tbfYear.Text = Convert.ToString(record.Year);

                GetPic(record);

                // Панель редактирования
                tbName.Text = record.Name;
                mtbYear.Text = Convert.ToString(record.Year);
                numericTime.Value = record.Time;
                tbDescription.Text = record.Description;
                tbFileName.Text = record.FileName;

                cBoxTypeVideo.SelectedIndex = ((int)record.Category);
                cBoxGenre.SelectedIndex = ((int)record.GenreVideo);
                cBoxCountry.SelectedIndex = ((int)record.Country);

                // поиск актеров по id
                chkActorSelect.Items.Clear();

                try
                {
                    foreach (int actorID in record.ActorID)
                    {
                        foreach (var item in _videoCollection.ActorList.FindAll(v => v.Id == actorID))
                        {

                            chkActorSelect.Items.Add(item);

                            //string[] arr = new string[3];
                            //arr[0] = item.Name;
                            //arr[1] = item.Year.ToString();
                            //arr[2] = item.Id.ToString();

                            //ListViewItem itm = new ListViewItem(arr);
                            //listViewFilm.Items.Add(itm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string GetFilename(string name) => Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "" + name + ".jpg");
        //{
        //    return Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "" + name + ".jpg");
        //}

        private void GetPic(Record record)
        {
            string filename = GetFilename(record.Pic);
            if (File.Exists(filename))
            {
                Image image = Image.FromFile(filename);
                if (image.Height > 300)
                    pbImage.Image = image.GetThumbnailImage(300 * image.Width / image.Height, 300, null, IntPtr.Zero);
                else
                    pbImage.Image = image;
            }
            else
                pbImage.Image = null;
        }

        private Record GetSelectedRecord()  // получение выбранной записи в dgvTable
        {
            DataGridView dgv = dgvTableRec;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Record record = null;
                if (dgv.SelectedRows[0].DataBoundItem is Record) record = dgv.SelectedRows[0].DataBoundItem as Record;
                if (record != null) return record;
            }
            return null;
        }

        private void SelectActor_Info(object sender, EventArgs e)  // Отражение информации в карточке актеров
        {
            // Предоставляет данные выбранной записи
            Actor act = GetSelectedActor();
            if (act != null)
            {
                //// Панель описания
                //tbfName.Text = record.Name;
                //tbfDesc.Text = record.Description;
                //tbfYear.Text = Convert.ToString(record.Year);

                // Панель редактирования
                tbFIO.Text = act.FIO;
                maskDateOfBirth.Text = act.DateOfBirth;
                maskDateOfDeath.Mask = "";
                maskDateOfDeath.Text = act.DateOfDeath;
                cBoxCountryActor.SelectedIndex = ((int)act.Country);

                listViewFilm.Items.Clear();

                try
                {
                    foreach (int recID in act.VideoID)
                    {
                        foreach (var item in _videoCollection.VideoList.FindAll(v => v.Id == recID))
                        {
                            string[] arr = new string[3];
                            arr[0] = item.Name;
                            arr[1] = item.Year.ToString();
                            arr[2] = item.Id.ToString();

                            ListViewItem itm = new ListViewItem(arr);

                            listViewFilm.Items.Add(itm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Actor GetSelectedActor()  // получение выбранной записи в dgvTableActor
        {
            DataGridView dgv = dgvTableActors;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Actor act = null;
                if (dgv.SelectedRows[0].DataBoundItem is Actor) act = dgv.SelectedRows[0].DataBoundItem as Actor;
                if (act != null) return act;
            }
            return null;
        }

        private void ResetFilter_Click(object sender, EventArgs e)
        {
            PepareRefresh();
            dgvTableRec.ClearSelection(); // сброс селекта
            dgvTableActors.ClearSelection();

            tscbTypeFilter.SelectedIndex = 0;
            tscbSort.SelectedIndex = -1;

            tscCountryFilter.SelectedIndex = -1;


            tbName.Text = "";
            numericTime.Value = 0;
            tbDescription.Text = "";
            tbFileName.Text = "";

            panelView.BringToFront();   // Отображение панели описания
            //cBoxGenre.SelectedIndex = 0;
            //cBoxTypeVideo.SelectedIndex = 0;
            //cBoxCountry.SelectedIndex = 0;
        }


        #endregion


        #region Панель редактирования (panelEdit)
        private void FileNameEdit_Unlock(object sender, EventArgs e)  // Разблокировка поля имени файла
        {
            tbFileName.Enabled = true;
            btnFileNameEdit.Enabled = false;    // блокировка кнопки разблокировки :)
            UserModifiedChanged(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e) => NewRecord_Dialog(); // Создание элемента
        //{
        //    NewRecord_Dialog();
        //}

        private void btnSave_Click(object sender, EventArgs e) => SaveRecord();  // Сохранение нового или измененного элемента
        //{
        //    SaveRecord();
        //}

        private void btnCancel_Click(object sender, EventArgs e) => CancelRecord();// Отмена редактирования
        //{
        //    CancelRecord();
        //}

        private void NewRecord_Dialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = _videoCollection.Options.Source;
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.Filter = "Все файлы (*.*)|*.*";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
                NewRecord(fileDialog.FileName);
        }

        private void NewRecord(string FileName)
        {
            FileInfo fInfo = new FileInfo(FileName);
            string strFilePath = fInfo.DirectoryName;
            if (!strFilePath.StartsWith(_videoCollection.Options.Source))
            {
                MessageBox.Show("Файл не принадлежит источнику коллекции " + _videoCollection.Options.Source);
                return; // Выходим из метода
            }

            Record record = new Record();
            record.FileName = fInfo.Name;
            record.Path = fInfo.DirectoryName;

            foreach (Record item in _videoCollection.VideoList)
            {
                if (item.Equals(record))
                {
                    MessageBox.Show("Файл " + record.FileName + " уже есть в базе!");
                    return; // Выходим из метода
                }
            }


            //chkActorList.Items.Clear();
            //foreach (Actor item in _videoCollection.ActorList)
            //{
            //    chkActorList.Items.Add(item.FIO);
            //}

            // Заполняем поля
            tbName.Text = fInfo.Name.Remove(fInfo.Name.LastIndexOf(fInfo.Extension), fInfo.Extension.Length);
            //tbYear.Text = "";
            //tbCountry.Text = "";
            numericTime.Value = 0;
            tbDescription.Text = "";
            tbFileName.Text = fInfo.Name;
            cBoxGenre.SelectedIndex = -1;
            cBoxTypeVideo.SelectedIndex = -1;
            cBoxCountry.SelectedIndex = -1;

            fsInfo = fInfo;             // если все хорошо, то передаем объект

            panelEdit.BringToFront();   // показываем панель редактирования

            dgvTableRec.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева

            panelEdit_Button_Unlock();          // разблокировка кнопок

            FileNameDisabled();
        }

        private void SaveRecord()
        {
            GenreVideo genre;
            CategoryVideo category;
            Country_Rus country;
            char[] charsToTrim = { '.' };

            country = (Country_Rus)cBoxCountry.SelectedIndex;
            genre = (GenreVideo)cBoxGenre.SelectedIndex;
            category = (CategoryVideo)cBoxTypeVideo.SelectedIndex;

            if (fsInfo != null)
                SaveRecord_New(genre, category, country, charsToTrim);      // если новый объект
            else
                SaveRecord_Select(genre, category, country, charsToTrim);   // если выбранный объект 

            panelEdit_Lock();    // блокировка панели
        }

        private void SaveRecord_Select(GenreVideo genre, CategoryVideo category, Country_Rus country, char[] charsToTrim)
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                record.Name = tbName.Text;
                record.Year = Convert.ToInt32(mtbYear.Text);
                record.Country = country;
                record.Time = (int)numericTime.Value;
                record.Category = category;
                record.GenreVideo = genre;
                record.Description = tbDescription.Text;
                if (record.FileName != tbFileName.Text)
                {
                    File.Move(record.Path + Path.DirectorySeparatorChar + record.FileName,
                              record.Path + Path.DirectorySeparatorChar + tbFileName.Text);
                    record.FileName = tbFileName.Text;
                    record.Extension = Path.GetExtension(record.Path + Path.DirectorySeparatorChar + tbFileName.Text).Trim(charsToTrim);
                }
                else
                {
                    record.FileName = tbFileName.Text;
                }

                GetActorID(record);

                _videoCollection.Save();
            }
        }

        private void SaveRecord_New(GenreVideo genre, CategoryVideo category, Country_Rus country, char[] charsToTrim)
        {
            Record record = new Record();

            record.Id = _videoCollection.getRecordID();
            record.FileName = fsInfo.Name;
            record.Path = fsInfo.DirectoryName;
            record.DirName = fsInfo.Directory.Name;
            record.Extension = fsInfo.Extension.Trim(charsToTrim);
            record.Name = tbName.Text;
            record.Year = Convert.ToInt32(mtbYear.Text);
            record.Country = country;
            record.Time = (int)numericTime.Value;
            record.Category = category;
            record.GenreVideo = genre;
            record.Description = tbDescription.Text;

            GetActorID(record);

            _videoCollection.Add(record);
            _videoCollection.Save();

            fsInfo = null;
        }

        private void GetActorID(Record record)
        {
            foreach (Actor _actorID in chkActorSelect.Items)
            {
                if (_actorID != null) record.ActorID.Add(_actorID.Id);
            }
        }

        private void UserModifiedChanged(object sender, EventArgs e)    // Срабатывает при изменении любого поля
        {
            //if (fsInfo == null) dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Gold;   // подсветка редактируемой строки в таблице
            if (fsInfo == null) dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Salmon;
            panelEdit_Button_Unlock();  // разблокировка кнопок
            dgvTableRec.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева
        }

        private void cbTypeFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = true;
        }

        private void btnFindNext_Click(object sender, EventArgs e) => FindNext();
        //{
        //    FindNext();
        //}

        private void tabControl_ResetFindStatus_Click(object sender, EventArgs e) => ResetFind();
        //{
        //    ResetFind();
        //}

        private void btnFindReset_Click(object sender, EventArgs e) => ResetFind();
        //{
        //    ResetFind();
        //}

        private void mtbYear_Validating(object sender, CancelEventArgs e)   // Проверка корректности вводимого года
        {
            if (!mtbYear.MaskCompleted) MessageBox.Show("Неверно указан год!");
        }

        #region Управление блокировками

        private void CancelRecord()    // Отмена редактирования в panelEdit
        {
            fsInfo = null;
            panelEdit_Lock();    // блокировка кнопок панели редактирования
        }

        private void panelEdit_Lock()    //Блокировка кнопок
        {
            tbName.Modified = false;        // возвращаем назад статус изменения поля
            mtbYear.Modified = false;       // возвращаем назад статус изменения поля  
            tbDescription.Modified = false; // возвращаем назад статус изменения поля

            treeFolder.Enabled = true;      // Разблокировка дерева
            dgvTableRec.Enabled = true;     // Разблокировка таблицы
            dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

            PepareRefresh();  // перезагрузка таблицы

            FileNameEnabled();

            panelEdit_Button_Lock();

            panelView.BringToFront();   // показать панель сведений
        }

        private void panelEdit_Button_Lock()
        {
            btnCancel.Visible = false;  // "Отмена" - скрыть
            btnSave.Visible = false;  // "Сохранить" - скрыть
        }

        private void panelEdit_Button_Unlock()
        {
            btnCancel.Visible = true;   // Разблокировать клавишу "Отмена"
            btnSave.Visible = true;    // Блокировать клавишу "Сохранить"
        }

        private void FileNameEnabled()
        {
            btnFileNameEdit.Enabled = true;     // Замок "Имя файла" - деблокировать
            tbFileName.Enabled = false;         // "Имя файла" - блокировать
        }

        private void FileNameDisabled()
        {
            btnFileNameEdit.Enabled = false;    // Замок "Имя файла" - блокировать
            tbFileName.Enabled = false;         // "Имя файла" - разблокировать
        }

        #endregion

        #endregion


        #region панель поиска (panelFind)
        private void ResetFind()
        {
            tbFind.Text = "";
            FindStatusLabel.Text = "";
            cbTypeFind.SelectedIndex = -1;
            btnFind.Enabled = false;

            dgvSelected.Clear();
            dgvTableRec.ClearSelection();
            FindNextButton_Lock();
        }

        private void FindNextButton_Lock()  //блокировка кнопки поиска следующего элемента
        {
            FindCount = 0;
            btnFindNext.Enabled = false;
        }

        private void Find_Click(object sender, EventArgs e)  // Поиск
        {
            switch (cbTypeFind.SelectedIndex)
            {
                case 0: Find(0); break; // поиск по названию
                case 1: Find(2); break; // поиск по году
                default: MessageBox.Show("Укажите критерий поиска!"); break;
            }
        }

        private void Find(int cell)
        {
            try
            {
                string regReplace = tbFind.Text.Replace("*", "");//замена вхождения * 
                Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);

                dgvTableRec.ClearSelection();
                dgvTableRec.MultiSelect = true;    // Требуется для выбора всех строк

                int i = 0;

                foreach (DataGridViewRow row in dgvTableRec.Rows)
                {
                    if (regex.IsMatch(row.Cells[cell].Value.ToString()))
                    {
                        i++;
                        dgvSelected.Add(row.Cells[cell].RowIndex);
                        row.Selected = true;
                        //break; //Требуется для выбора одно строки
                    }
                }
                if (i == 0) MessageBox.Show("Элементов не найдено!");
                if (i > 0) FindStatusLabel.Text = "Найдено " + i + " элементов.";
                if (i > 1) btnFindNext.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FindNext()
        {
            if (FindCount < dgvSelected.Count)
            {
                dgvTableRec.ClearSelection();
                if (dgvSelected.Count > 0) dgvTableRec.FirstDisplayedScrollingRowIndex = dgvSelected[FindCount];

                foreach (DataGridViewRow row in dgvTableRec.Rows)
                {
                    if (row.Index == dgvSelected[FindCount]) row.Selected = true;
                }
                FindCount++;
            }
            if (!(FindCount < dgvSelected.Count)) FindCount = 0;
        }
        #endregion


        #region Панель просмотра

        private void Play_Click(object sender, EventArgs e)  // запуск файла
        {
            Record record = GetSelectedRecord();
            string _file = (record.Path + Path.DirectorySeparatorChar + record.FileName);
            if (File.Exists(_file))
            {
                Process.Start(_file);
            }
            else
            {
                MessageBox.Show("Отсутствует файл: " + _file);
            }
        }

        #endregion


        #region Обработка меню дерева (treeFolder)


        private void CreateTree()       // Построение дерева
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(RecordOptions.BaseName);                // Получения файла базы
            int SourceLength = _videoCollection.Options.Source.Length;  // Получение длинны пути

            XmlNodeList nodeList = doc.GetElementsByTagName("Path");        // Чтение элементов "Path"

            treeFolder.Nodes.Clear();                                       // Очистка дерева

            var paths = new List<string>();                                 // Создание списка
            paths.Add("Фильмотека");

            foreach (XmlNode node in nodeList)                              // Заполнение списка для формирования дерева
            {
                try
                {
                    string temp = "";
                    if (node.ChildNodes[0].Value.Length > SourceLength)     // длинна патча, не должна превышать полного пути к директории
                        if (-1 != node.ChildNodes[0].Value.Substring(SourceLength).IndexOf(Path.DirectorySeparatorChar))
                        {
                            temp = node.ChildNodes[0].Value.Substring(SourceLength + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                            //if (temp.Length != 0) paths.Add(node.ChildNodes[0].Value.Substring(SourceLength + 1));
                            if (temp.Length != 0)
                            {
                                string tt = node.ChildNodes[0].Value.Substring(SourceLength + 1);
                                if (!paths.Exists(x => x == tt)) paths.Add(tt);
                            }
                        }
                }
                catch (NullReferenceException e)
                {
                    MessageBox.Show(e.Message + " " + node.Name + " - не заполнен!");
                }
            }

            PopulateTreeView(treeFolder, paths, Path.DirectorySeparatorChar, paths.Count);
            //treeFolder.AfterSelect += treeFolder_AfterSelect;
            // TreeFast(paths);
        }

        private void TreeFastT(IEnumerable<string> paths)
        {
            // подумать об использовании анонимного класса!
            int pathCount = 0;
            Catalog emp = new Catalog();
            foreach (string path in paths)
            {
                string[] PathD = path.Split(Path.DirectorySeparatorChar);
                if (PathD.Length == 1)  // Корневые папки без поддиректорий
                {
                    emp.Name = PathD[0];
                    emp.ParentId = (int?)null; // родителя нет

                    if (_treeViewColletion.Employees.Count < 1) // если коллекции нет, создаем элемент
                    {
                        emp.nodeId = pathCount;
                        _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
                        pathCount++;
                    }
                    else
                    {
                        bool isElement = false; // элемента нет

                        for (int i = 0; i < _treeViewColletion.Employees.Count; i++)
                        {
                            if (_treeViewColletion.Employees[i].Equals(emp))
                            { // если есть то выводим инфу и будем использовать его id
                                //MessageBox.Show("Объект " + emp.Name + " есть в базе под номером: " + emp.nodeId);
                                // emp.ParentId = id;
                                isElement = true;
                                break;
                            }
                        }
                        if (!isElement) // если элемента нет, то создаем                       
                        //if (!_treeViewColletion.Employees.Exists(x => x == emp))
                        {
                            emp.nodeId = pathCount;
                            _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
                            pathCount++;
                        }
                    }
                }
                else // папки с поддиректориями
                {
                    List<int> parent = new List<int>();

                    for (int i = 0; i < PathD.Length; i++)
                    {
                        emp.Name = PathD[i];
                        //emp.ParentId = (i != 0) ? (i - 1) : (int?)null;
                        if (i == 0)
                        {
                            emp.ParentId = (int?)null;
                        }
                        else
                        {
                            //Employee emps = new Employee(); // ВЫЧИСЛЯЕТСЯ ID родителя
                            //emps = _treeViewColletion.Employees.Find(x => x.Name == PathD[i - 1]);
                            // emp.ParentId = emps.nodeId;
                            emp.ParentId = parent[i - 1];
                        }

                        if (_treeViewColletion.Employees.Count < 1) // если коллекции нет, создаем элемент
                        {
                            parent.Add(pathCount);  // добавили id родителя List<int> parent 
                            emp.nodeId = pathCount;
                            _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
                            pathCount++;
                        }
                        else
                        {
                            // Проверяем наличие элемента
                            bool isElement = false; // элемента нет

                            for (int j = 0; j < _treeViewColletion.Employees.Count; j++)
                            {
                                if (_treeViewColletion.Employees[j].Equals(emp))
                                { // если есть то выводим инфу и будем использовать его id
                                  //MessageBox.Show("Объект " + emp.Name + " есть в базе под номером: " + emp.nodeId);

                                    // !!!!Неправильно выбирается элемент!!!! .Берется текущий id вместо id того который в базе.

                                    Catalog emps = _treeViewColletion.Employees.Find(x => emp.Name == x.Name && emp.ParentId == x.ParentId);
                                    if (emps != null) { parent.Add(emps.nodeId); }
                                    //isElement = true;
                                    // добавили id родителя List<int> parent 
                                    break;
                                }
                            }
                            if (!isElement) // если элемента нет, то создаем                       
                            {
                                parent.Add(pathCount);  // добавили id родителя List<int> parent 
                                emp.nodeId = pathCount;

                                _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
                                pathCount++;
                            }
                            //if (!_treeViewColletion.Employees.Exists(x => x == emp))
                            //{
                            //    emp.nodeId = pathCount;
                            //    _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
                            //    pathCount++;
                            //}
                        }
                    }



                }
            }

            MessageBox.Show(_treeViewColletion.Employees.Count.ToString());
            // Define functions needed by the load method
            Func<Catalog, int> getId = (x => x.nodeId);
            Func<Catalog, int?> getParentId = (x => x.ParentId);
            Func<Catalog, string> getDisplayName = (x => x.Name);


            // Load items into TreeViewFast
            treeViewFast1.LoadItems(_treeViewColletion.Employees, getId, getParentId, getDisplayName);
        }

        private void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator, int count)  // Построение дерева
        {
            //Employee emp = new Employee();

            //foreach (string path in paths)
            //{
            //    string[] PathD = path.Split(pathSeparator);
            //    if (PathD.Length == 1)
            //    {
            //        emp.Name = PathD[0];
            //        emp.ParentId = (int?)null;

            //        if (_treeViewColletion.Employees.Count > 0)
            //        {
            //            for (int e = 0; e < _treeViewColletion.Employees.Count; e++)
            //            {
            //                if (!_treeViewColletion.Employees[e].Equals(emp))
            //                {
            //                    emp.nodeId = pathCount;
            //                    _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
            //                    pathCount++;
            //                    //break;
            //                }
            //                //return;
            //            }
            //        }
            //        else
            //        {
            //            emp.nodeId = pathCount;
            //            _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
            //            pathCount++;
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < PathD.Length; i++)
            //        {
            //            emp.Name = PathD[i];
            //            emp.ParentId = (i != 0) ? (i - 1) : (int?)null;

            //            //emp.Parent = (i != 0) ? PathD[i - 1] : ""; // сокращенная нотация if (i != 0) { emp.Parent =  PathD[i - 1]} ...
            //            if (_treeViewColletion.Employees.Count > 0)
            //            {
            //                for (int e = 0; e < _treeViewColletion.Employees.Count; e++)
            //                {
            //                    if (!_treeViewColletion.Employees[e].Equals(emp))
            //                    {
            //                        emp.nodeId = pathCount;
            //                        _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
            //                        pathCount++;
            //                        //break;
            //                        //return;
            //                    }

            //                    //return;
            //                }
            //                // foreach (Employee item in _treeViewColletion.Employees)
            //                // {
            //                //if(!item.Equals(emp)) _treeViewColletion.Add(emp);   // если нет в списке то добавляем
            //                //if (!item.Equals(emp))
            //                //{
            //                //    emp.nodeId = pathCount;
            //                //    //_treeViewColletion.Add(emp);
            //                //    _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
            //                //    pathCount++;
            //                //    return;
            //                //}
            //                // }
            //            }
            //            else
            //            {
            //                emp.nodeId = pathCount;
            //                _treeViewColletion.Add(emp.nodeId, emp.ParentId, emp.Name);
            //                pathCount++;
            //            }
            //            //emp = null;
            //        }
            //    }
            //}






            //for (int i = PathD.Length; i > 0; i--)
            //{
            //    Employee emp = new Employee();
            //    emp.Name = PathD[i];
            //    emp.Parent = (i != 0) ? PathD[i - 1] : ""; // сокращенная нотация if (i != 0) { emp.Parent =  PathD[i - 1]} ...

            //    foreach (Employee item in _treeViewColletion.Employees)
            //    {
            //        if (!item.Equals(emp)) _treeViewColletion.Add(emp);   // если нет в списке то добавляем
            //    }
            //}







            //tsProgressBar.Maximum = count;
            int cc = 0;
            TreeNode lastNode = null;
            string subPathAgg;

            foreach (string path in paths)
            {
                cc++;
                //tsProgressBar.Value = cc;
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        lastNode = (lastNode == null) ? treeView.Nodes.Add(subPathAgg, subPath) : lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null;
            }
        }


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e) // Команда при клике по строке
        {
            PepareRefresh(e.Node.FullPath, false);     // обновление на основе полученной ноды
            textBox4.Text = e.Node.Text;
        }

        private void treeFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeFolder.SelectedNode = treeFolder.GetNodeAt(e.X, e.Y);
                if (treeFolder.SelectedNode != null) // && treeFolder.SelectedNode.Parent == null)
                {
                    TreeMenu.Show(treeFolder, e.Location);
                }
            }
        }

        private void сCollapseAll_Click(object sender, EventArgs e)
        {
            treeFolder.CollapseAll();
        }

        private void сExpandAll_Click(object sender, EventArgs e)
        {
            treeFolder.ExpandAll();
        }

        private void cExpandSelectNode_Click(object sender, EventArgs e)
        {
            treeFolder.SelectedNode.ExpandAll();
        }

        private void cShowSelcetNodeAllFiles_Click(object sender, EventArgs e)
        {
            PepareRefresh(treeFolder.SelectedNode.FullPath, true);     // обновление на основе полученной ноды
        }



        #endregion


        #region Обработка актеров

        private void btnMoveUp_Click(object sender, System.EventArgs e)
        {
            int index = chkActorList.SelectedIndices[0];
            if (index != 0)
            {
                ArrayList list = new ArrayList();
                CheckedListBox cb = new CheckedListBox();
                cb.Items.AddRange(chkActorList.Items);
                for (int i = 0; i < chkActorList.CheckedItems.Count; i++)
                {
                    cb.SetItemCheckState(cb.Items.IndexOf(chkActorList.CheckedItems[i]), CheckState.Checked);
                }
                list.AddRange(chkActorList.Items);
                ArrayList newlist = new ArrayList(list);
                newlist[index] = list[index - 1];
                newlist[index - 1] = list[index];
                chkActorList.Items.Clear();
                chkActorList.Items.AddRange((string[])newlist.ToArray(typeof(string)));
                for (int i = 0; i < cb.CheckedItems.Count; i++)
                {
                    chkActorList.SetItemCheckState(chkActorList.Items.IndexOf(cb.CheckedItems[i]), CheckState.Checked);
                }
                chkActorList.SelectedItem = chkActorList.Items[index - 1];
            }
        }

        private void btnMoveDown_Click(object sender, System.EventArgs e)
        {
            int index = chkActorList.SelectedIndices[0];
            if (index != chkActorList.Items.Count - 1)
            {
                CheckedListBox cb = new CheckedListBox();
                cb.Items.AddRange(chkActorList.Items);
                for (int i = 0; i < chkActorList.CheckedItems.Count; i++)
                {
                    cb.SetItemCheckState(cb.Items.IndexOf(chkActorList.CheckedItems[i]), CheckState.Checked);
                }
                ArrayList list = new ArrayList();
                list.AddRange(chkActorList.Items);
                ArrayList newlist = new ArrayList(list);
                newlist[index] = list[index + 1];
                newlist[index + 1] = list[index];
                chkActorList.Items.Clear();
                chkActorList.Items.AddRange((string[])newlist.ToArray(typeof(string)));
                for (int i = 0; i < cb.CheckedItems.Count; i++)
                {
                    chkActorList.SetItemCheckState(chkActorList.Items.IndexOf(cb.CheckedItems[i]), CheckState.Checked);
                }
                chkActorList.SelectedItem = chkActorList.Items[index + 1];
            }
        }


        private void btnAdd_SelectActor_Click(object sender, EventArgs e)
        {
            if (chkActorList.CheckedItems.Count > 0)
            {
                foreach (var item in chkActorList.CheckedItems)
                {
                    if (!chkActorSelect.Items.Contains(item))
                    {
                        chkActorSelect.Items.Add(item);
                    }
                }
                UserModifiedChanged(sender, e);
            }
        }

        private void btnRemove_SelectActor_Click(object sender, System.EventArgs e)
        {
            if (chkActorSelect.SelectedItems.Count > 0)
            {
                chkActorSelect.Items.Remove(chkActorSelect.SelectedItem);
                UserModifiedChanged(sender, e);
            }
        }

        private void btnNewActor_Click(object sender, EventArgs e)
        {
            tbFIO.Text = "";
            maskDateOfBirth.Text = "";
            maskDateofDeath_RecoveryState();
            checkBox1.Checked = false;
            cBoxCountryActor.SelectedIndex = -1;
            tbFilmFind.Text = "";
            listViewFilm.Clear();
            lvSelectRecord.Items.Clear();
        }

        private void btnSaveActor_Click(object sender, EventArgs e)
        {

            Country_Rus country = (Country_Rus)cBoxCountryActor.SelectedIndex;
            Actor actor = new Actor();
            actor.FIO = tbFIO.Text;
            foreach (Actor item in _videoCollection.ActorList)
            {
                if (item.Equals(actor))
                {
                    MessageBox.Show("\"" + actor.FIO + "\" уже есть в списке актеров!");
                    return; // Выходим
                }
            }

            //try
            //{
            //    string[] dateComponents = maskDateOfBirth.Text.Split('.');
            //    string month = dateComponents[0].Trim();
            //    string day = dateComponents[1].Trim();
            //    string year = dateComponents[2].Trim();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            actor.DateOfBirth = maskDateOfBirth.Text;
            actor.DateOfDeath = maskDateOfDeath.Text;
            actor.Country = country;
            actor.Id = _videoCollection.getActorID();

            foreach (ListViewItem eachItem in listViewFilm.Items)
            {
                actor.VideoID.Add(Convert.ToInt32(eachItem.SubItems[2].Text));
            }

            _videoCollection.Add(actor);
            _videoCollection.Save();
            PepareRefresh();
        }

        private void checkLive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                maskDateOfDeath.Mask = "";
                maskDateOfDeath.Text = "По настоящее время";
                maskDateOfDeath.Enabled = false;
            }
            else
            {
                maskDateofDeath_RecoveryState();
            }
        }

        private void maskDateofDeath_RecoveryState()
        {
            maskDateOfDeath.Enabled = true;
            maskDateOfDeath.Text = "";
            maskDateOfDeath.Mask = "00/00/0000";
        }

        private void tbFilmFind_TextChanged(object sender, EventArgs e)
        {
            lvSelectRecord.Items.Clear();

            try
            {
                string regReplace = tbFilmFind.Text.Replace("*", "");   //замена вхождения * 
                Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);

                foreach (DataGridViewRow row in dgvTableRec.Rows)
                {
                    if (regex.IsMatch(row.Cells[0].Value.ToString()))
                    {
                        Record record = null;
                        if (row.DataBoundItem is Record) record = row.DataBoundItem as Record;
                        if (record != null) lvSelectRecord_add(record.Name, record.Year, record.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvSelectRecord_add(string name, int year, int id)
        {
            string[] arr = new string[3];
            arr[0] = name;
            arr[1] = year.ToString();
            arr[2] = id.ToString();

            ListViewItem itm = new ListViewItem(arr);
            lvSelectRecord.Items.Add(itm);
        }

        private void lvSelectRecord_DoubleClick(object sender, EventArgs e)
        {
            if (lvSelectRecord.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvSelectRecord.SelectedItems)
                {
                    listViewFilm.Items.Add((ListViewItem)item.Clone());
                }
            }
        }

        private void listViewFilm_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listViewFilm.SelectedItems)
            {
                listViewFilm.Items.Remove(eachItem);
            }
        }


        #endregion













        #region Обработка постеров

        //получение веб-страницы
        public static string GetHtmlPageText(string url)
        {
            WebClient client = new WebClient();
            using (Stream data = client.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(data))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        private void graber_Pic_Click(object sender, EventArgs e)
        {
            FindCinema(textBox1.Text);
        }


        //выполнение поиска
        private void FindCinema(string text)
        {
            power("https://afisha.mail.ru/search/?q=" + text, text);
        }


        private void power(string web, string name)
        {
            ParseForPic(GetHtmlPageText(web), name);
            ParseForInfo(GetHtmlPageText(web), name);
        }


        // afisha.mail.ru/search/?q=полевые+огни&region_id=70
        // <a href="/cinema/movies/730486_polevye_ogni/" class="searchitem__item__pic__img" style="background-image:url(https://pic.afisha.mail.ru/7087162/)"></a>

        //private void ParseForPic(string web, string name)
        private void ParseForPic(string sourcestring, string name)
        {
            tbResult.Text = "";
            MatchCollection mc = Regex.Matches(sourcestring, @"(<a href.*?searchitem__item__pic__img.*?>.*?</a>)", RegexOptions.IgnoreCase);

            for (int i = 0; i < mc.Count; i++)
            {
                tbResult.AppendText(mc[i].ToString() + "\r\n");
                string PicWeb = "";
                string[] subStrings = mc[i].ToString().Split('"', '(', ')');
                for (int y = 0; y < subStrings.Length; y++)
                {
                    if (subStrings[y] == "background-image:url")
                    {
                        ++y;
                        if (subStrings[y].Contains("http"))
                        {
                            PicWeb = subStrings[y];
                            break;
                        }
                    }
                }

                if (PicWeb != "")
                {
                    tbResult.AppendText("pic = " + PicWeb);
                    DownloadPic(PicWeb, name);
                    return;
                }
            }
        }

        private void DownloadPic(string PicWeb, string Pic)
        {
            try
            {
                if (PicWeb.Contains("http"))
                {
                    string TempPath = Path.Combine(Path.GetTempPath(), "" + Pic + ".jpg");

                    using (WebClient webClient = new WebClient())
                        webClient.DownloadFile(PicWeb, GetFilename(Pic));
                    //{
                    //    webClient.DownloadFile(PicWeb, TempPath);
                    //}
                    //File.Copy(TempPath, GetFilename(Pic), true);



                    //  webClient.DownloadFile(PicWeb, GetFilename(Pic));
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + " Скачать изображение не удалось!");
            }
            // string result = Path.GetTempPath();
            //MessageBox.Show(Path.GetTempPath());
            //return Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "" + name + ".jpg");

        }



        // <a href="/cinema/movies/730486_polevye_ogni/" class="searchitem__item__pic__img" style="background-image:url(https://pic.afisha.mail.ru/7087162/)"></a>
        // afisha.mail.ru + /cinema/movies/730486_polevye_ogni/
        // <div class="movieabout__info__descr__txt" itemprop="description"><p>Осень 1944 года, японцы отступают с&nbsp;Филиппин.ине».</p></div>          

        private void ParseForInfo(string sourcestring, string name)
        {
            MatchCollection mc = Regex.Matches(sourcestring,
                                            @"(<a href=.*?searchitem__item__pic__img.*?>.*?</a>)", RegexOptions.IgnoreCase);

            for (int i = 0; i < mc.Count; i++)
            {
                tbResult.AppendText(mc[i].ToString() + "\r\n");
                string Link_txt = "";
                string[] subStrings = mc[i].ToString().Split('"', '(', ')');
                for (int y = 0; y < subStrings.Length; y++)
                {
                    if (subStrings[y] == "<a href=")
                    {
                        ++y;
                        Link_txt = subStrings[y];
                        break;
                    }
                }

                if (Link_txt != "")
                {
                    tbResult.AppendText("ссылка на фильм = " + Link_txt);
                    GetInfo("https://afisha.mail.ru" + Link_txt);
                    return;
                }
            }
        }

        private void GetInfo(string link)
        {
            textBoxWeb.Text = "";
            string sourcestring = GetHtmlPageText(link);

            MatchCollection mc = Regex.Matches(sourcestring,
                                            @"(<div class=\""movieabout__info__descr__tx.*?>.*?</p>)", RegexOptions.IgnoreCase);

            foreach (Match m in mc)
            {
                string str = m.ToString();
                str = Regex.Replace(str, "&nbsp;", " ");
                str = Regex.Replace(str, "&mdash;", "-");
                str = Regex.Replace(str, "&laquo;", "\"");
                str = Regex.Replace(str, "&raquo;", "\"");
                str = Regex.Replace(str, "<span>", "");
                str = Regex.Replace(str, "</span>", "");
                str = Regex.Replace(str, "<br/>", "");
                str = Regex.Replace(str, "<span class=\"_reachbanner_\">", "");

                try
                {
                    str = str.Remove(str.LastIndexOf("</p>"), str.Length - str.LastIndexOf("</p>"));
                    str = str.Remove(0, str.LastIndexOf("<p>") + 3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                textBoxWeb.Text += str;
            }
        }






        #endregion

        private void graberAll_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < _videoCollection.VideoList.Count; i++)
            for (int i = 0; i < 50; i++)
            {
                //Regex my_reg = new Regex("[0-9]+");
                // string out_string = my_reg.Replace(_videoCollection.VideoList[i].Name, "");

                //FindCinema(_videoCollection.VideoList[i].Name)
                //s = Regex.Replace(s, "[^0-9.]", "");

                // удалить все цифры
                //var output = Regex.Replace(_videoCollection.VideoList[i].Name, @"[\d-]", string.Empty);
                //vудалить все цифры и точки
                //var output = Regex.Replace(_videoCollection.VideoList[i].Name, @"[\d-.]", string.Empty);
                //vудалить все что не цифры и не буквы, кроме тире
                //var output = Regex.Replace(_videoCollection.VideoList[i].Name, @"[^a-zA-Z0-9 -]", string.Empty);

                //удаление всех латинских букв, цифр, подчеркивания, точки, скобок
                //var output = Regex.Replace(_videoCollection.VideoList[i].Name, @"[a-zA-Z0-9_.()]", string.Empty);

                // Удаление всех латинских букв, цифр, подчеркивания, точки, скобок
                //string output = Regex.Replace(_videoCollection.VideoList[i].Name, @"[a-zA-Z0-9_.()]", string.Empty);


                string output2 = Regex.Replace(_videoCollection.VideoList[i].Name, @"[a-zA-Z_.()]", string.Empty);
                string output = Regex.Replace(output2, @"[0-9]{4}", string.Empty);
                output = output.Trim(); //убираем пробелы вначале и конце
                MessageBox.Show(output);
                //if (_videoCollection.VideoList[i].Pic == "" && _videoCollection.VideoList[i].Description == "")
                //{
                //    WebQuery(output, _videoCollection.VideoList[i]);
                //}
            }

        }


        //выполнение поиска
        private void WebQuery(string text, Record rec)
        {
            string web = "https://afisha.mail.ru/search/?q=" + text;
            string name = text;

            GetPic(GetHtmlPageText(web), name, rec);
            GetText(GetHtmlPageText(web), name, rec);

        }


        private void GetPic(string sourcestring, string name, Record rec)
        {
            tbResult.Text = "";
            MatchCollection mc = Regex.Matches(sourcestring, @"(<a href.*?searchitem__item__pic__img.*?>.*?</a>)", RegexOptions.IgnoreCase);

            for (int i = 0; i < mc.Count; i++)
            {
                tbResult.AppendText(mc[i].ToString() + "\r\n");
                string PicWeb = "";
                string[] subStrings = mc[i].ToString().Split('"', '(', ')');
                for (int y = 0; y < subStrings.Length; y++)
                {
                    if (subStrings[y] == "background-image:url")
                    {
                        ++y;
                        if (subStrings[y].Contains("http"))
                        {
                            PicWeb = subStrings[y];
                            break;
                        }
                    }
                }

                if (PicWeb != "")
                {
                    tbResult.AppendText("pic = " + PicWeb);
                    DownPic(PicWeb, name);
                    //rec.Pic = name + ".jpg";
                    rec.Pic = name;
                    return;
                }
            }
        }

        private void DownPic(string PicWeb, string Pic)
        {
            try
            {
                if (PicWeb.Contains("http"))
                {
                    using (WebClient webClient = new WebClient())
                        webClient.DownloadFile(PicWeb, GetFilename(Pic));
                }
            }
            catch (Exception Ex) { MessageBox.Show("Загрузить изображение не удалось: " + Ex.Message); }
        }


        private void GetText(string sourcestring, string name, Record rec)
        {
            MatchCollection mc = Regex.Matches(sourcestring,
                                            @"(<a href=.*?searchitem__item__pic__img.*?>.*?</a>)", RegexOptions.IgnoreCase);

            for (int i = 0; i < mc.Count; i++)
            {
                tbResult.AppendText(mc[i].ToString() + "\r\n");
                string Link_txt = "";
                string[] subStrings = mc[i].ToString().Split('"', '(', ')');
                for (int y = 0; y < subStrings.Length; y++)
                {
                    if (subStrings[y] == "<a href=")
                    {
                        ++y;
                        Link_txt = subStrings[y];
                        break;
                    }
                }

                if (Link_txt != "")
                {
                    tbResult.AppendText("ссылка на фильм = " + Link_txt);
                    DownInfo("https://afisha.mail.ru" + Link_txt, rec);
                    return;
                }
            }
        }

        private void DownInfo(string link, Record rec)
        {
            textBoxWeb.Text = "";
            string sourcestring = GetHtmlPageText(link);

            MatchCollection mc = Regex.Matches(sourcestring,
                                            @"(<div class=\""movieabout__info__descr__tx.*?>.*?</p>)", RegexOptions.IgnoreCase);

            foreach (Match m in mc)
            {
                string str = m.ToString();
                str = Regex.Replace(str, "&nbsp;", " ");
                str = Regex.Replace(str, "&mdash;", "-");
                str = Regex.Replace(str, "&laquo;", "\"");
                str = Regex.Replace(str, "&raquo;", "\"");
                str = Regex.Replace(str, "<span>", "");
                str = Regex.Replace(str, "</span>", "");
                str = Regex.Replace(str, "<br/>", "");
                str = Regex.Replace(str, "<span class=\"_reachbanner_\">", "");

                try
                {
                    str = str.Remove(str.LastIndexOf("</p>"), str.Length - str.LastIndexOf("</p>"));
                    str = str.Remove(0, str.LastIndexOf("<p>") + 3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                rec.Description = str;
                textBoxWeb.Text += str;
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(1, 1, 145, 18);
            rect.Inflate(1, 1); // border thickness
            ControlPaint.DrawBorder(e.Graphics, rect, Color.Silver, ButtonBorderStyle.Solid);

            //base.OnPaint(e);
            //Pen penBorder = new Pen(Color.Gray, 1);
            //Rectangle rectBorder = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //e.Graphics.DrawRectangle(penBorder, rectBorder);

            //Rectangle textRec = new Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //TextRenderer.DrawText(e.Graphics, Text, this.Font, textRec, this.ForeColor, this.BackColor, TextFormatFlags.Default);

            //    toolStripTextBox1.BorderStyle = BorderStyle.None;
            //    Pen p = new Pen(SystemColors.ControlDark, 5);
            //    Graphics g = e.Graphics;
            //    g.DrawRectangle(p, new Rectangle(20, -15, 129, 90));
        }

        private void cRenameFolder_Click(object sender, EventArgs e)
        {
            panelFolder.BringToFront();
        }



        private void tsFindbyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string regReplace = tsFindbyName.Text.Replace("*", "");
                    Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);

                    dgvTableRec.ClearSelection();
                    dgvTableRec.MultiSelect = true;

                    foreach (DataGridViewRow row in dgvTableRec.Rows)
                    {
                        if (regex.IsMatch(row.Cells[0].Value.ToString()))
                        {
                            int f = row.Cells[0].RowIndex;

                            if (f < dgvTableRec.RowCount)
                            {
                                dgvTableRec.ClearSelection();
                                dgvTableRec.Rows[f].Selected = true;            // выделяем
                                dgvTableRec.FirstDisplayedScrollingRowIndex = f;// скролим
                                dgvTableRec.Update();
                            }
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cOpenFolder_Click(object sender, EventArgs e)
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                string filePath = Path.Combine(record.Path, record.FileName);
                if (!File.Exists(filePath))
                {
                    return;
                }

                // combine the arguments together
                // it doesn't matter if there is a space after ','
                string argument = "/select, \"" + filePath + "\"";

                Process.Start("explorer.exe", argument);
                //Process.Start("explorer.exe", record.Path);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\temp\TeST\new.1997.txt";

            // get file attributes
            FileAttributes fileAttributes = File.GetAttributes(filePath);
            MessageBox.Show(fileAttributes.ToString());

            var shell = new Shell();
            //var folder = shell.NameSpace(@"filepath");
            var folder = shell.NameSpace(@"X:\");
            foreach (FolderItem2 item in folder.Items())
            {
                //if (item.Name == "filename")
                if (item.Name == "123")
                {
                    MessageBox.Show("Test");
                    ulong aaa = item.ExtendedProperty("System.Media.Duration") / 10000000;
                    TimeSpan.FromSeconds((double)aaa);

                    MessageBox.Show(TimeSpan.FromSeconds((double)aaa).ToString());

                    //Console.WriteLine(TimeSpan.FromSeconds(item.ExtendedProperty("System.Media.Duration") / 10000000));
                }
            }

            Marshal.ReleaseComObject(folder);
            Marshal.ReleaseComObject(shell);
        }

        private void btnCleanDB_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < _videoCollection.VideoList.Count; i++)
            //{
            //    if (_videoCollection.VideoList[i].Visible == false) _videoCollection.Remove(_videoCollection.VideoList[i]);

            //}
            foreach (var item in _videoCollection.VideoList.FindAll(x => x.Visible == false))
            {
                _videoCollection.Remove(item);
            }


            _videoCollection.Save();
            dgvTableRec.ClearSelection();
            PepareRefresh();
        }






    }

}



//MessageBox.Show(month + "/" + day + "/" + year);

//maskDateOfBirth.
// \d{ 2}/\d{ 2}/\d{ 4}
//  00/00/0000

//string regReplace = tbFind.Text.Replace("*", "");//замена вхождения * 
//Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);


//    if (regex.IsMatch(row.Cells[cell].Value.ToString()))
//    {
//        i++;
//        dgvSelected.Add(row.Cells[cell].RowIndex);
//        row.Selected = true;
//        //break; //Требуется для выбора одно строки
//    }

//Regex regex = new Regex(@"\b([0-2][0-9][0-1][0-9]1[8-9][0-9][0-9])");
//Match match = regex.Match(maskDateOfBirth.Text);
//if (match.Success)
//{
//    // Console.WriteLine(match.Value);
//    MessageBox.Show(match.Value);
//}