using System;
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
using System.Runtime.InteropServices;
using Shell32;

namespace FilmCollection
{
    public partial class MainForm : Form
    {
        RecordCollection _videoCollection { get; set; }     // Доступ к коллекции
        TreeViewColletion _treeViewColletion { get; set; }  // Доступ к коллекции

        FileInfo fsInfo { get; set; } = null;       // для нового файла, добавляемого в базу
        int FindCount { get; set; }                 // счетчик найденных строк
        public List<int> dgvSelected { get; set; }  // индексы найденных строк

        string FormatOpen { get; } = "Видео (*.avi, *.mkv, *.mp4, ..)|*.avi;*.mkv;*.mp4;*.wmv;*.webm;*.rm;*.mpg;*.flv;*.divx|Все файлы (*.*) | *.*";
        List<string> FormatAdd { get; } = new List<string> { ".avi", ".mkv", ".mp4", ".wmv", ".webm", ".rm", ".mpg", ".mpeg", ".flv", ".divx" };

        public string PicsFolder { get; } = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics");

        #region Главная форма (Main)

        public MainForm()                           //Конструктор формы
        {
            InitializeComponent();                  // Создание и отрисовка элементов
            this.MinimumSize = new Size(1160, 600);  // Установка минимального размера формы

            _videoCollection = new RecordCollection();      // Доступ к коллекции
            _treeViewColletion = new TreeViewColletion();   // Доступ к коллекции

            dgvTableRec.AutoGenerateColumns = false;    // Отключение автоматического заполнения таблицы
            dgvTableActors.AutoGenerateColumns = false; // Отключение автоматического заполнения таблицы

            dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            dgvTableRec.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки
            dgvTableRec.Columns[7].DefaultCellStyle.SelectionForeColor = Color.Blue;    // цвет текста выбранной строки нужного столбца

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

            MenuChange.Visible =
#if DEBUG
            true;
#else
            false;
#endif

            #region Постеры
            this.buttonCancel.Enabled = false;

            m_AddImageDelegate = new DelegateAddImage(this.AddImage);

            m_Controller = new ThumbnailController();
            m_Controller.OnAdd += new ThumbnailControllerEventHandler(m_Controller_OnAdd);
            m_Controller.OnEnd += new ThumbnailControllerEventHandler(m_Controller_OnEnd);

            #endregion

        }

        private void tsFindbyName_Paint(object sender, PaintEventArgs e)   // отрисовка рамки вокруг tsFindbyName
        {
            Rectangle rect = new Rectangle(1, 1, 145, 18);
            rect.Inflate(1, 1); // border thickness
            ControlPaint.DrawBorder(e.Graphics, rect, Color.Silver, ButtonBorderStyle.Solid);
        }

        private void T_Tick(object sender, EventArgs e)     // таймер для селекта MainForm_Load
        {
            timerLoad.Enabled = false;
            treeFolder.SelectedNode = null;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }

        private void Main_Load(object sender, EventArgs e)  // Загрузка формы
        {
            ChangeStatusMenuButton(FormLoad());
        }

        private void Main_Close(object sender, FormClosingEventArgs e) => FormClose(e);// Закрытие формы или выход


        private bool FormLoad()
        {
            bool state = false;

            if (File.Exists(RecordOptions.BaseName))    // Если база создана, то загружаем
            {
                _videoCollection.Clear();

                try { _videoCollection = RecordCollection.Load(); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return state;
                }

                //BackupBase();   // на всякий случай делаем бэкап

                if (_videoCollection.CombineList.Count > 0)
                {
                    tssLabel.Text = "Коллекция из " + _videoCollection.CombineList.Count.ToString() + " элементов";
                    PrepareRefresh();
                    CreateTree();

                    state = true;
                }

                timerLoad.Enabled = true;               // Исключение раннего селекта treeFolder и фильтра dataGridView1

                LoadFormVisualEffect();
                Form_Tooltip();
                AddFolder();    // загрузка постеров               
            }
            return state;
        }

        private void ChangeStatusMenuButton(bool state)
        {
            tsAdd.Enabled = state;
            tsChange.Enabled = state;
            tsRemove.Enabled = state;
            tsFind.Enabled = state;
            tsFindbyName.Enabled = state;
        }

        private void Form_Tooltip()     // Всплывающая подсказка
        {
            toolinfo.SetToolTip(btnFileNameEdit, "Разблокировать для переименования файла");
        }

        private void FormClose(FormClosingEventArgs e)    // обработка события Close()
        {
            DialogResult dialog = MessageBox.Show("Вы уверены что хотите выйти из программы?",
                                                  "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes) Application.ExitThread();
            else if (dialog == DialogResult.No) e.Cancel = true;

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

        private void NewBase()       // Создание файла базы
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.Description = "Укажите расположение файлов мультимедиа:";
            fbDialog.ShowNewFolderButton = false;

            isExistBase();  // инициализация файла базы

            DialogResult dialogStatus = fbDialog.ShowDialog();  // Запрашиваем новый каталог с коллекцией видео

            if (dialogStatus == DialogResult.OK)
                CreateBase(fbDialog);   // создание базы
            ChangeStatusMenuButton(false);
        }

        private void isExistBase()
        {
            if (File.Exists(RecordOptions.BaseName)) // Если база есть, то запрашиваем удаление
            {
                DialogResult result = MessageBox.Show("Выполнить удаление текущей базы ?",
                                                      "Удаление базы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) BackupBase();
                File.WriteAllText(RecordOptions.BaseName, string.Empty); // Затираем содержимое файла базы
                _videoCollection.Clear();       // очищаем коллекцию
                treeFolder.Nodes.Clear();       // очищаем иерархию
                dgvTableRec.ClearSelection();   // выключаем селекты таблицы
                PrepareRefresh();               // сбрасываем старые значения таблицы
            }
            else
            {   // Если базы нет, то создаем пустой файл базы
                File.Create(RecordOptions.BaseName).Close(); // создание файла и закрытие дескриптора (Объект FileStream)
            }
        }

        private void CreateBase(FolderBrowserDialog fbDialog)
        {
            string folderName = fbDialog.SelectedPath;         //Извлечение имени папки

            DialogResult CheckfolderName = MessageBox.Show("Источником фильмотеки выбран каталог: " + folderName,
                                                            "Создание фильмотеки (" + folderName + ")",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if (CheckfolderName == DialogResult.Cancel) NewBase();

            DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки
            if (directory.Exists)
            {
                _videoCollection.Options.Source = directory.FullName;   // Сохранение каталога фильмов

                var myFiles = directory.GetFiles("*.*", SearchOption.AllDirectories)
                                          .Where(s => FormatAdd.Contains(Path.GetExtension(s.ToString())));

                foreach (FileInfo file in myFiles)
                    CreateCombine(file);
            }

            _videoCollection.Save();
            //MessageBox.Show(_videoCollection.VideoList.Count.ToString());
            FormLoad();
        }

        private void UpdateBase()       // Добавить обновление базы
        {
            if (_videoCollection.Options.Source == "" && _videoCollection.Options.Source == null)  // Если есть информация о корневой папки коллекции
                MessageBox.Show("Необходимо создать базу данных.");
            else
            {
                try
                {
                    if (_videoCollection.Options.Source == null)
                    {
                        MessageBox.Show("Файл базы испорчен!");
                        return;
                    }
                    DirectoryInfo directory = new DirectoryInfo(_videoCollection.Options.Source);

                    if (directory.Exists)   // проверяем доступность каталога
                    {
                        foreach (Combine _combine in _videoCollection.CombineList)
                            _combine.invisibleRecord(); // скрываем файлы

                        var myFiles = directory.GetFiles("*.*", SearchOption.AllDirectories)
                                                  .Where(s => FormatAdd.Contains(Path.GetExtension(s.ToString())));

                        //foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                        foreach (FileInfo file in myFiles)
                        {
                            Record record = new Record();
                            record.FileName = file.Name;                            // полное название файла (film.avi)
                            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)

                            if (!RecordExist(record))
                                CreateCombine(file); // если файла нет в коллекции, создаем     
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


        private bool RecordExist(Record record)
        {
            List<Record> list = new List<Record>();
            _videoCollection.CombineList.ForEach(combine => list.AddRange(combine.recordList));

            foreach (Record rec in list)    // проверка наличия файла
            {
                if (rec.Equals(record))
                {
                    _videoCollection.CombineList.FindLast(x => x.media == rec.combineLink.media).recordList.FindLast(y => y == rec).Visible = true;
                    return true;    // если файл есть
                }
            }
            return false;           // иначе файла нет файл есть
        }


        void CreateCombine(FileInfo file)
        {
            Combine cm = new Combine();

            Record record = CreateRecord(file);

            record.combineLink = cm;
            cm.recordList.Add(record);
            cm.media.Name = record.Name;
            cm.media.Id = RecordCollection.GetMediaID();

            _videoCollection.Add(cm);
        }

        private static Record CreateRecord(FileInfo file)
        {
            Record record = new Record();
            record.Name = getRecordName(file);
            record.FileName = file.Name;        // полное название файла (film.avi)
            record.Path = file.DirectoryName;   // полный путь (C:\Folder)
            record.Visible = true;              // видимость
            record.Extension = file.Extension.Trim('.');            // расширение файла (avi)
            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
            record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                    // if (-1 != file.DirectoryName.Substring(dlina).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
            return record;
        }

        private static string getRecordName(FileInfo file)
        {
            string name_1 = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length); // название без расширения (film)
            string name_2 = Regex.Replace(name_1, @"[0-9]{4}", string.Empty);       // название без года
            string name_f = Regex.Replace(name_2, @"[a-zA-Z_.'()]", string.Empty);  // название без символов                       
            name_f = name_f.Trim();                         // название без пробелов вначале и конце
            return (name_f != "") ? name_f : name_1;
        }


        private void BackupBase()       // Резервная копия базы
        {
            if (File.Exists(RecordOptions.BaseName)) // если есть, что резервировать...
            {
                try
                {   // создаем резервную копию
                    string FileBase = Path.GetFileNameWithoutExtension(RecordOptions.BaseName)
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss")
                        + Path.GetExtension(RecordOptions.BaseName);

                    File.Copy(RecordOptions.BaseName, FileBase);

                    MessageBox.Show("Создана резервная копия базы:\n" + FileBase + " ");
                }
                catch (IOException copyError) { MessageBox.Show(copyError.Message); }
            }
        }

        private void RecoveryBase()
        {
            RecoveryForm form = new RecoveryForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // создаем копию испорченной базы
                string BadFileBase = Path.GetFileNameWithoutExtension(RecordOptions.BaseName)
                    + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss_BAD")
                    + Path.GetExtension(RecordOptions.BaseName);

                File.Copy(RecordOptions.BaseName, BadFileBase);
                File.Copy(form.recoverBase, RecordOptions.BaseName, true);
                MessageBox.Show("База восстановлена из резервной копии:\n" + form.recoverBase + " ");
                FormLoad();
            }
        }

        private void CleanBase()   // очистка базы путем удаления старых файлов видео
        {
            for (int i = 0; i < _videoCollection.CombineList.Count; i++)
            {
                _videoCollection.CombineList[i].DeleteOldRecord();
                if (_videoCollection.CombineList[i].recordList.Count == 0)
                {
                    _videoCollection.CombineList.Remove(_videoCollection.CombineList[i]);
                }
            }

            _videoCollection.Save();
            dgvTableRec.ClearSelection();
            // treeFolder.Nodes.Clear(); //добавить обработку очистки дерева
            PrepareRefresh();
            MessageBox.Show("Очистка выполнена!");
        }

        #endregion


        #region Главное меню

        private void CreateBase_Click(object sender, EventArgs e)
        {
            NewBase();
        }

        private void UpdateBase_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void BackupBase_Click(object sender, EventArgs e)
        {
            BackupBase();
        }

        private void RecoveryBase_Click(object sender, EventArgs e)
        {
            RecoveryBase();
        }

        private void CleanBase_Click(object sender, EventArgs e)
        {
            CleanBase();
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


        #region Контекстное меню для DataGridView

        private void AddRec_Click(object sender, EventArgs e)           // добавление новой записи
        {
            if (isRecTab()) NewRecord_Dialog();
            else NewActor();
        }

        private bool isRecTab()
        {
            return (tabControl2.SelectedIndex == 0) ? true : false;
        }

        private void EditRec_Click(object sender, EventArgs e)          // Изменение записи
        {
            if (isRecTab()) panelEdit.BringToFront();
            else panelEditAct.BringToFront();
        }

        private void cFind_Click(object sender, EventArgs e) => panelFind.BringToFront();       // Поиск

        private void tsFindbyName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string regReplace = tsFindbyName.Text.Replace("*", "");
                    Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);

                    GetDgv().ClearSelection();
                    GetDgv().MultiSelect = true;

                    foreach (DataGridViewRow row in GetDgv().Rows)
                    {
                        if (regex.IsMatch(row.Cells[0].Value.ToString()))
                        {
                            int f = row.Cells[0].RowIndex;
                            if (f < GetDgv().RowCount)
                            {
                                GetDgv().ClearSelection();
                                GetDgv().Rows[f].Selected = true;            // выделяем
                                GetDgv().FirstDisplayedScrollingRowIndex = f;// прокручиваем
                                GetDgv().Update();
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteRec_Click(object sender, EventArgs e)
        {
            if (isRecTab()) DeleteRec();
            else DeleteActor();
        }

        private void DeleteRec()
        {
            Record record = GetSelectedRecord();
            DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + record.Name + "\" ?",
                                                  "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                record.combineLink.recordList.Remove(record);
                _videoCollection.Save();
                FormLoad();
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
                PrepareRefresh();
            }
        }

        private void OLD_Add_rec(object sender, EventArgs e)        // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //_videoCollection.Add(form.rec);
                _videoCollection.Save();
                PrepareRefresh();
            }
        }

        private void OLD_Change_rec(object sender, EventArgs e)     // Изменить запись
        {
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                PrepareRefresh();      //Должно быть обновление вместо фильтра
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


        #endregion


        #region Обработка DataGridView

        private void Filter(object sender, EventArgs e)     // При выборе фильтра > сброс фильтра по дереву и таблице
        {
            dgvTableRec.ClearSelection();
            dgvTableActors.ClearSelection();
            PrepareRefresh();
        }

        private void dgvTableRec_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)    // Сортировка по колонке
        {
            if (e.Button == MouseButtons.Left) PrepareRefresh(false, e.ColumnIndex);
        }

        public string LastNode { get; set; }

        private void PrepareRefresh(string nodeName, bool flag)
        {
            LastNode = nodeName;
            PrepareRefresh(flag);
        }

        string GetNode()
        {
            return (LastNode == null) ? "" : LastNode;
        }

        bool checkNode()
        {
            string nodeName = (GetNode());
            if (nodeName != "" && nodeName != "Фильмотека")
                return true;
            return false;
        }

        private void PrepareRefresh(bool flag = false, int column = -1)
        {
            Record selected = GetSelectedRecord();

            // List<Record> filtered = _videoCollection.VideoList;
            //dataGridView1.DataSource = new List<Combine>(_videoCollection.CombineList);

            List<Record> filtered = new List<Record>();
            _videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));
            dgvTableRec.DataSource = filtered;

            filtered = filtered.FindAll(v => v.Visible == !cbIsVisible.Checked);

            filtered = (tscbTypeFilter.SelectedIndex != 0)  // фильтрация по типу: Фильм, Мультфильм..
                ? filtered.FindAll(v => v.mCategory == ((CategoryVideo_Rus)(tscbTypeFilter.SelectedIndex - 1)).ToString())
                : filtered;

            if (checkNode())
            {
                filtered = (!flag)
                            ? filtered.FindAll(v => v.Path == _videoCollection.Options.Source + Path.DirectorySeparatorChar + GetNode())
                            : filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + GetNode()));
            }

            Sort(filtered, tscbSort.SelectedIndex);
            if (column > -1) Sort(filtered, column);

            RefreshTable(filtered);
            Sort_Actor();

            if (selected != null) SelectRecord(dgvTableRec, selected);
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
                filteredAct = filteredAct.FindAll(a => a.Country == (Country_Rus)tscCountryFilter.SelectedIndex);

            dgvTableActors.DataSource = null;
            dgvTableActors.DataSource = filteredAct;

            // список актеров
            chkActorList.Items.Clear();

            foreach (Actor item in _videoCollection.ActorList)
                chkActorList.Items.Add(item);
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
                    {
                        if ((row.DataBoundItem as Record).Visible == false)
                        {
                            //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.Silver;
                            row.DefaultCellStyle.Font = new Font(dgvTableRec.Font, FontStyle.Strikeout);

                        }
                        if ((row.DataBoundItem as Record).Visible == true)
                            row.Cells[7].Style.ForeColor = Color.Blue;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            Record record = GetSelectedRecord();    // Предоставляет данные выбранной записи
            if (record != null)
            {
                // Панель описания
                tbfName.Text = record.mName;
                tbfDesc.Text = record.mDescription;
                tbfYear.Text = Convert.ToString(record.mYear);
                tbfCountry.Text = record.mCountry;
                GetPic(record.combineLink.media);
                lbActors.Items.Clear();
                if (record.combineLink.media.ActorListID != null)
                    foreach (int ListID in record.combineLink.media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            lbActors.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));

                // Панель редактирования
                // Media
                cbNameMedia.Text = record.combineLink.media.Name;
                mtbYear.Text = Convert.ToString(record.combineLink.media.Year);
                tbDescription.Text = record.combineLink.media.Description;
                cBoxTypeVideo.SelectedIndex = ((int)record.combineLink.media.Category);
                cBoxGenre.SelectedIndex = ((int)record.combineLink.media.GenreVideo);
                cBoxCountry.SelectedIndex = ((int)record.combineLink.media.Country);
                chkActorSelect.Items.Clear();
                if (record.combineLink.media.ActorListID != null)
                    foreach (int ListID in record.combineLink.media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            chkActorSelect.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));

                // Record
                tbNameRecord.Text = record.Name;
                mtbTime.Text = record.TimeVideoSpan.ToString();
                tbFileName.Text = record.FileName;
                tbFilePath.Text = (record.Path + Path.DirectorySeparatorChar + record.FileName);
            }
        }

        private string GetFilename(string name)
        {
            return Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "" + name + ".jpg");
        }

        private void GetPic(Media _media)
        {
            string filename;
            filename = (_media.Pic == "")
                ? GetFilename("noPic")
                : GetFilename(_media.Pic);

            if (File.Exists(filename))
            {
                Image image = Image.FromFile(filename);
                pbImage.Image = (image.Height > 300)
                    ? image.GetThumbnailImage(300 * image.Width / image.Height, 300, null, IntPtr.Zero)
                    : image;
            }
            else pbImage.Image = null;
        }

        private Record GetSelectedRecord()  // получение выбранной записи в dgvTable
        {
            DataGridView dgv = dgvTableRec;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Record record = null;
                if (dgv.SelectedRows[0].DataBoundItem is Record) record = dgv.SelectedRows[0].DataBoundItem as Record;
                if (record != null) return record;

                List<string> nnn = new List<string>();

                foreach (DataGridViewTextBoxCell item in dgv.SelectedRows[0].Cells)
                    if (item != null && item.Value != null)
                        nnn.Add(item.Value.ToString());
            }
            return null;
        }

        private void SelectActor_Info(object sender, EventArgs e)  // Отражение информации в карточке актеров
        {
            panelViewAct.BringToFront();               // Отображение панели описания
            Actor act = GetSelectedActor();            // Предоставляет данные выбранной записи
            if (act != null)
            {
                // Панель описания
                tbFIOv.Text = act.FIO;
                linkBIOv.Text = act.BIO;
                tbCountryAv.Text = act.CountryString;
                maskDateOfBirthV.Text = act.DateOfBirth;
                maskDateOfDeathV.Mask = "";
                maskDateOfDeathV.Text = act.DateOfDeath;
                listViewFilmV.Items.Clear();
                try
                {
                    foreach (int recID in act.VideoID)
                        foreach (Combine com in _videoCollection.CombineList.FindAll(m => m.media.Id == recID))
                            listViewFilmV.Items.Add(new ListViewItem(new string[] { com.media.Name, com.media.Year.ToString(), com.media.Id.ToString() }));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }


                // Панель редактирования
                tbFIO.Text = act.FIO;
                tbBIO.Text = act.BIO;
                maskDateOfBirth.Text = act.DateOfBirth;
                chLifeState.CheckState = (act.DateOfDeath == "По настоящее время") ? CheckState.Checked : CheckState.Unchecked;
                maskDateOfDeath.Text = act.DateOfDeath;
                cBoxCountryActor.SelectedIndex = ((int)act.Country);
                listViewFilm.Items.Clear();
                try
                {
                    foreach (int recID in act.VideoID)
                        foreach (Combine com in _videoCollection.CombineList.FindAll(m => m.media.Id == recID))
                            listViewFilm.Items.Add(new ListViewItem(new string[] { com.media.Name, com.media.Year.ToString(), com.media.Id.ToString() }));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            PrepareRefresh();
            dgvTableRec.ClearSelection(); // сброс селекта
            dgvTableActors.ClearSelection();

            tscbTypeFilter.SelectedIndex = 0;
            tscbSort.SelectedIndex = -1;

            tscCountryFilter.SelectedIndex = -1;


            cbNameMedia.Text = "";
            //numericTime.Value = 0;
            tbDescription.Text = "";
            tbFileName.Text = "";

            panelView.BringToFront();   // Отображение панели описания
            //cBoxGenre.SelectedIndex = 0;
            //cBoxTypeVideo.SelectedIndex = 0;
            //cBoxCountry.SelectedIndex = 0;
        }

        private void cOpenFolder_Click(object sender, EventArgs e)
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                string filePath = Path.Combine(record.Path, record.FileName);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файл \"" + filePath + "\" не найден!");
                    return;
                }

                string argument = "/select, \"" + filePath + "\"";
                Process.Start("explorer.exe", argument);
            }
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

        private void btnSave_Click(object sender, EventArgs e) => SaveRecord();  // Сохранение нового или измененного элемента

        private void btnCancel_Click(object sender, EventArgs e) => CancelRecord();// Отмена редактирования

        private void NewRecord_Dialog()
        {
            dgvTableRec.ClearSelection();   // сброс селекта таблицы

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Path.Combine(_videoCollection.Options.Source, GetNode());
            fileDialog.Filter = FormatOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                NameBlock();

                FileInfo newFile = new FileInfo(fileDialog.FileName); // получаем доступ к файлу
                if (!newFile.DirectoryName.StartsWith(_videoCollection.Options.Source))
                {
                    MessageBox.Show("Файл не принадлежит источнику коллекции " + _videoCollection.Options.Source);
                    return; // Выходим из метода
                }

                // Заполняем поля
                cbNameMedia.Text = newFile.Name.Remove(newFile.Name.LastIndexOf(newFile.Extension), newFile.Extension.Length);
                tbNameRecord.Text = newFile.Name.Remove(newFile.Name.LastIndexOf(newFile.Extension), newFile.Extension.Length);
                tbFileName.Text = newFile.Name;
                tbDescription.Text = "";
                mtbYear.Text = DateTime.Now.Year.ToString();
                cBoxGenre.SelectedIndex = -1;
                cBoxTypeVideo.SelectedIndex = -1;
                cBoxCountry.SelectedIndex = -1;

                chkActorList.Items.Clear();
                foreach (Actor item in _videoCollection.ActorList)
                {
                    chkActorList.Items.Add(item.FIO);
                }

                fsInfo = newFile;           // если все хорошо, то передаем объект    

                dgvTableRec.Enabled = false;    // блокировка таблицы
                treeFolder.Enabled = false;     // блокировка дерева

                panelEdit_Button_Unlock();          // разблокировка кнопок
                FileNameDisabled();

                panelEdit.BringToFront();   // Отображаем панель редактирования

                // добавить блокировку tabControl2
            }
        }

        private void SaveRecord()
        {
            Combine cm = null;
            Record record = null;

            if (fsInfo != null) // Создание нового фильма
            {
                cm = GetMedia();
                record = CreateRecord(fsInfo);
            }
            else // редактирование имеющегося фильма
            {
                record = GetSelectedRecord();
                if (record != null) cm = record.combineLink;
            }

            SaveToMedia(cm);

            record.Name = tbNameRecord.Text;
            try { record.TimeVideoSpan = TimeSpan.Parse(mtbTime.Text); }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                record.TimeVideoSpan = TimeSpan.Parse("0");
            }
            if (record.FileName != tbFileName.Text)
            {
                File.Move(record.Path + Path.DirectorySeparatorChar + record.FileName,
                          record.Path + Path.DirectorySeparatorChar + tbFileName.Text);
                record.FileName = tbFileName.Text;
                record.Extension = Path.GetExtension(record.Path + Path.DirectorySeparatorChar + tbFileName.Text).Trim('.');
            }
            else record.FileName = tbFileName.Text;

            if (fsInfo != null)
            {
                if (cm.media.Id != 0 && checkNewRecord.Checked != true)
                {
                    if (cm.recordList.Exists(v => v.Name == record.Name) || cm.recordList.Exists(v => v.FileName == record.FileName))
                        MessageBox.Show("Файл уже есть в списке, добавление не требуется!");
                    else
                        cm.recordList.Add(record);
                }
                else
                {
                    cm.recordList.Add(record);
                    _videoCollection.Add(cm);
                }
            }

            _videoCollection.Save();

            FormLoad();

            fsInfo = null;

            panelEdit_Lock();    // блокировка панели
        }

        private Combine GetMedia()
        {
            Combine cm = null;
            if (cbNameMedia.SelectedItem != null)
            {
                if (_videoCollection.CombineList.Exists(m => m.media.Name == cbNameMedia.SelectedItem.ToString()))
                    cm = _videoCollection.CombineList.FindLast(m => m.media.Name == cbNameMedia.SelectedItem.ToString());
            }
            else
            {
                cm = new Combine();
                cm.media.Id = RecordCollection.GetMediaID();
            }
            return cm;
        }

        private void SaveToMedia(Combine cm)
        {
            cm.media.Name = cbNameMedia.Text;
            cm.media.Year = Convert.ToInt32(mtbYear.Text);
            cm.media.Description = tbDescription.Text;
            cm.media.Category = (CategoryVideo)cBoxTypeVideo.SelectedIndex;
            cm.media.GenreVideo = (GenreVideo)cBoxGenre.SelectedIndex;
            cm.media.Country = (Country_Rus)cBoxCountry.SelectedIndex;

            foreach (Actor _actorID in chkActorSelect.Items)
                if (_actorID != null)
                {
                    cm.media.ActorListID.Add(_actorID.id);
                    _actorID.VideoID.Add(cm.media.Id);
                }
        }

        private void checkNewRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNewRecord.Checked)
            {
                cbNameMedia.Enabled = false;
            }
            else
            {
                foreach (var item in _videoCollection.CombineList) // создаем список фильмов для функции авто поиска
                    cbNameMedia.Items.Add(item.media);
                cbNameMedia.Enabled = true;
            }
            UserModifiedChanged(sender, e);
        }

        private void cBoxNameMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combine cm = null;
            if (cbNameMedia.SelectedItem != null)
            {
                if (_videoCollection.CombineList.Exists(m => m.media.Name == cbNameMedia.SelectedItem.ToString()))
                    cm = _videoCollection.CombineList.FindLast(m => m.media.Name == cbNameMedia.SelectedItem.ToString());
            }

            if (cm != null)
            {
                mtbYear.Text = Convert.ToString(cm.media.Year);
                tbDescription.Text = cm.media.Description;
                cBoxTypeVideo.SelectedIndex = ((int)cm.media.Category);
                cBoxGenre.SelectedIndex = ((int)cm.media.GenreVideo);
                cBoxCountry.SelectedIndex = ((int)cm.media.Country);
                chkActorSelect.Items.Clear();
                if (cm.media.ActorListID != null)
                    foreach (int ListID in cm.media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            chkActorSelect.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));
            }
        }

        private void UserModifiedChanged(object sender, EventArgs e) => Modified();   // Срабатывает при изменении любого поля

        private void mtbTime_KeyDown(object sender, KeyEventArgs e) => Modified();

        private void Modified()
        {
            if (fsInfo == null) dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Salmon; // подсветка редактируемой строки в таблице
            panelEdit_Button_Unlock();  // разблокировка кнопок
            dgvTableRec.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева
        }

        private void cbTypeFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = true;
        }

        private void btnFindNext_Click(object sender, EventArgs e) => FindNext();

        private void tabControl_ChangeTab_Click(object sender, EventArgs e) => ResetFind();

        private void btnFindReset_Click(object sender, EventArgs e) => ResetFind();

        private void mtbYear_Validating(object sender, CancelEventArgs e)   // Проверка корректности вводимого года
        {
            if (!mtbYear.MaskCompleted)
                MessageBox.Show("Неверно указан год!");
            if (!mtbTime.MaskCompleted)
            {
                MessageBox.Show("Неверно указано время!");
                mtbTime.Focus();
            }
        }


        #region Управление блокировками

        private void CancelRecord()    // Отмена редактирования в panelEdit
        {
            fsInfo = null;
            panelEdit_Lock();    // блокировка кнопок панели редактирования
        }

        private void NameBlock()
        {
            checkNewRecord.CheckState = CheckState.Checked;  // выполняем привязку
            cbNameMedia.Enabled = false;  // блокируем название
        }

        private void panelEdit_Lock()    //Блокировка кнопок
        {
            NameBlock();

            mtbYear.Modified = false;       // возвращаем назад статус изменения поля  
            tbDescription.Modified = false; // возвращаем назад статус изменения поля

            treeFolder.Enabled = true;      // Разблокировка дерева
            dgvTableRec.Enabled = true;     // Разблокировка таблицы
            dgvTableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

            PrepareRefresh();  // перезагрузка таблицы

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

            dgvTableActors.Enabled = true;  // Разблокировка таблицы при изменении панели
            dgvTableActors.ClearSelection();// Удаление фокуса
            dgvTableRec.Enabled = true;     // Разблокировка таблицы при изменении панели
            dgvTableRec.ClearSelection();   // Удаление фокуса
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
            PlayRecord();
        }

        private void PlayRecord()
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

        private void linkBIOv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkBIOv.Text);
            //ProcessStartInfo sInfo = new ProcessStartInfo("http://www.google.com");
            //Process.Start(sInfo);
        }

        private void lbActors_DoubleClick(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabActors;
            if (lbActors.SelectedItem != null)
            {
                String searchValue = lbActors.SelectedItem.ToString();
                int rowIndex = -1;
                foreach (DataGridViewRow row in dgvTableActors.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex != -1) dgvTableActors.Rows[rowIndex].Selected = true;
            }
        }

        private void listViewFilmV_DoubleClick(object sender, EventArgs e)
        {
            if (listViewFilmV.SelectedItems[0].SubItems[0].Text != "")
            {
                string searchValue = listViewFilmV.SelectedItems[0].SubItems[0].Text;
                tabControl2.SelectedTab = tabFilm;
                int rowIndex = -1;
                DataGridViewRow row = dgvTableRec.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["cmnName"].Value.ToString().Equals(searchValue))
                    .First();
                rowIndex = row.Index;
                if (rowIndex != -1) dgvTableRec.Rows[rowIndex].Selected = true;
            }
        }

        #endregion


        #region Обработка меню дерева (treeFolder)


        private void CreateTree()       // Построение дерева
        {
            treeFolder.Nodes.Clear();                                  // Очистка дерева
            int SourceLength = _videoCollection.Options.Source.Length; // Получение длинны пути

            var test = (from cm in _videoCollection.CombineList
                        let recList = cm.recordList
                        from rec in recList
                        where rec.Visible == true   //orderby rec
                        select rec.Path).Distinct<string>().OrderBy(name => name);

            List<string> pathList = new List<string>() { "Фильмотека" };
            pathList.AddRange(test.Where(n => n.Length > SourceLength).Select(n => n.Substring(SourceLength + 1)).ToList()); //Обрезка пути C:\temp\1\11 -> 1\11  

            PopulateTreeView(treeFolder, pathList, Path.DirectorySeparatorChar, pathList.Count);
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
            PrepareRefresh(e.Node.FullPath, false);     // обновление на основе полученной ноды
            textBox4.Text = e.Node.Text;                //  panelFolder
        }

        private void treeFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeFolder.SelectedNode = treeFolder.GetNodeAt(e.X, e.Y);
                if (treeFolder.SelectedNode != null) // && treeFolder.SelectedNode.Parent == null)
                {
                    TreeMenu.Items[7].Enabled = (treeFolder.SelectedNode.Text == "Фильмотека") ? false : true;
                    TreeMenu.Items[11].Enabled = (treeFolder.SelectedNode.Text == "Фильмотека") ? false : true;
                    TreeMenu.Items[12].Enabled = (treeFolder.SelectedNode.Text == "Фильмотека") ? false : true;
                    TreeMenu.Show(treeFolder, e.Location);
                }
            }
        }

        private void сCollapseAll_Click(object sender, EventArgs e) => treeFolder.CollapseAll();

        private void сExpandAll_Click(object sender, EventArgs e) => treeFolder.ExpandAll();

        private void cExpandSelectNode_Click(object sender, EventArgs e) => treeFolder.SelectedNode.ExpandAll();

        private void cShowSelcetNodeAllFiles_Click(object sender, EventArgs e)
        {
            PrepareRefresh(treeFolder.SelectedNode.FullPath, true);     // обновление на основе полученной ноды        
        }

        private void cRenameFolder_Click(object sender, EventArgs e) => panelFolder.BringToFront();

        private void ChangeCatalogTypeVideo_Click(object sender, EventArgs e)   // сделать каталог сериалом на основе записи
        {
            Record record = GetSelectedRecord();
            if (record == null)
            {
                MessageBox.Show("Выберите запись для создания сериала!");
            }
            else
            {
                Combine cmNew = new Combine();
                cmNew.media = record.combineLink.media;
                cmNew.media.Category = CategoryVideo.Series;

                List<Record> filtered = new List<Record>();
                _videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

                filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + treeFolder.SelectedNode.FullPath));

                foreach (Record rec in filtered)
                    cmNew.recordList.Add(rec);

                foreach (Record rec in filtered)
                    _videoCollection.CombineList.Remove(rec.combineLink);

                _videoCollection.CombineList.Add(cmNew);
                _videoCollection.Save();

                string treeFolderPath = treeFolder.SelectedNode.FullPath;

                FormLoad();

                PrepareRefresh(treeFolderPath, true);
            }
        }


        private void ChangeCatalogTypeVideo2_Click(object sender, EventArgs e)   // сделать каталог сериалом на основе имени каталога
        {
            string treeFolderPath = treeFolder.SelectedNode.FullPath;

            Combine cmNew = new Combine();

            cmNew.media.Name = (Regex.Replace(treeFolderPath, @"[0-9]{4}", string.Empty)).Trim('.');       // название без года
            cmNew.media.Id = RecordCollection.GetMediaID();
            cmNew.media.Category = CategoryVideo.Series;

            List<Record> filtered = new List<Record>();
            _videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

            filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + treeFolder.SelectedNode.FullPath));

            foreach (Record rec in filtered)
                cmNew.recordList.Add(rec);

            foreach (Record rec in filtered)
                _videoCollection.CombineList.Remove(rec.combineLink);

            _videoCollection.CombineList.Add(cmNew);
            _videoCollection.Save();


            FormLoad();

            PrepareRefresh(treeFolderPath, true);
        }

        private void UpdateCatalogInfo_Click(object sender, EventArgs e)
        {
            var cmList = (from cm in _videoCollection.CombineList
                          let recList = cm.recordList
                          from rec in recList
                          where rec.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + GetNode())
                          where rec.Visible == true
                          select rec.combineLink);    //.Distinct<Combine>();

            foreach (Combine cm in cmList.Distinct().ToList())
                GetInfo(cm.media);

            _videoCollection.Save();
            PrepareRefresh();
        }


        #endregion


        #region DragDrop DGV to TreeView


        private void treeFolder_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = treeFolder.PointToClient(new Point(e.X, e.Y));
            TreeNode destinationNode = treeFolder.GetNodeAt(pt);
            TreeNode dragedNode = new TreeNode();

            Record record = GetSelectedRecord();
            if (record != null)
            {
                try
                {
                    if (destinationNode.Level == 0 && destinationNode.Index == 0)
                    { //если условие верно, то это главный узел - "Фильмотека"
                      //MessageBox.Show(destinationNode.FullPath);
                    }
                    else
                    {
                        string dirPath = Path.Combine(_videoCollection.Options.Source, destinationNode.FullPath);

                        if (File.Exists(Path.Combine(record.Path, record.FileName)))
                            if (Directory.Exists(dirPath))
                                File.Move(Path.Combine(record.Path, record.FileName), Path.Combine(dirPath, record.FileName));

                        record.DirName = destinationNode.Text;
                        record.Path = dirPath;

                        _videoCollection.Save();
                        PrepareRefresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void treeFolder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при клике выполняется выбор строки и открывается меню
        {
            try
            {
                FindNextButton_Lock();
                if (e.Button == MouseButtons.Right) GetMenuDgv(e);
                if (e.Button == MouseButtons.Left)
                {
                    if (e.ColumnIndex != 7)
                    {
                        DataGridView dgv = dgvTableRec;
                        if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
                            if (dgv.SelectedRows[0].Index == e.RowIndex)
                            {
                                dgvTableRec.DoDragDrop(e.RowIndex, DragDropEffects.Copy);
                            }
                            else
                            {
                                // MessageBox.Show("Сдвиг не соответствует селекту");
                            }
                    }
                }

            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }

        private void dgvTableRec_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                //MessageBox.Show(dgvTableRec.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                PlayRecord();
            }
        }

        #endregion


        #region обработка информации по одному фильму

        private void UpdateFIlmInfo_Click(object sender, EventArgs e)
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                if (GetInfo(record.combineLink.media))
                {
                    _videoCollection.Save();
                    PrepareRefresh();
                }
            }
        }

        public static string GetHtml(string url)       //получение веб-страницы
        {
            try
            {
                WebClient client = new WebClient();
                using (Stream data = client.OpenRead(url))
                using (StreamReader reader = new StreamReader(data))
                    return reader.ReadToEnd();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return "";
        }

        private bool GetInfo(Media media)
        {
            string webQuery;

            if (media.Category == CategoryVideo.Series)
            {
                webQuery = "https://afisha.mail.ru/search/?ent=20&q=";
            }
            else
            {
                webQuery = "https://afisha.mail.ru/search/?ent=1&q=";
            }

            //string htmlPage = GetHtml("https://afisha.mail.ru/search/?q=" + media.Name);

            string htmlPage = GetHtml(webQuery + media.Name);


            //MatchCollection mc = Regex.Matches(htmlPage, "(<a href=.*?searchitem__item__pic__img.*?>)", RegexOptions.IgnoreCase);

            //MatchCollection mc = Regex.Matches(htmlPage, "(<a class=.*?p-poster__img.*?>)", RegexOptions.IgnoreCase);
            //MatchCollection mc = Regex.Matches(htmlPage, "(<a class=.*?p-poster__img.*?</a>)", RegexOptions.IgnoreCase);

            MatchCollection mc = Regex.Matches(htmlPage, "(p-poster__img.*?</a>)", RegexOptions.IgnoreCase);


            //{<a class="searchmenu__item__link" href="/search/?region_id=70&amp;q=%D0%9B%D1%83%D1%87%D1%88%D0%B0%D1%8F%20%D0%B4%D0%BE%D1%80%D0%BE%D0%B3%D0%B0
            //%20%D0%BD%D0%B0%D1%88%D0%B5%D0%B9%20%D0%B6%D0%B8%D0%B7%D0%BD%D0%B8&amp;ent=20"><u class="searchmenu__item__link__name">Сериалы</u>
            //<i class="searchmenu__item__link__count">1</i></a></span></div></div></div><!--5509--><!--/5509--><div class="block"><div class="wrapper">
            //    <div class="hdr"><div class="hdr__wrapper"><span class="hdr__text"><span class="hdr__inner">Сериалы</span></span></div><span class="countyellow">1</span></div>
            //    <section class="searchitem"><div class="searchitem__items clearin  searchitem__items_all">
            //<article class="searchitem__item"><div class="p-poster margin_bottom_20"><i class="p-poster__stack"></i>
            //    <a class="p-poster__img" href="/series_838303_luchshaya_doroga_nashei_zhizni/" style="background-image: url(https://pic.afisha.mail.ru/3176763/)"></a>}


            // {<a href="/cinema/movies/432352_stalker/">Сталкер</a> (1979)</div></article>
            // <article class="searchitem__item"><div class="p-poster margin_bottom_20">
            // <a class="p-poster__img" href="/cinema/movies/857278_stalker/" style="background-image: url(https://pic.afisha.mail.ru/4309917/)">}

            for (int i = 0; i < mc.Count; i++)
            {
                //string[] subStrings = mc[i].ToString().Split('"', '(', ')');
                List<string> arrayPath = new List<string>(mc[i].ToString().Split('"', '(', ')'));

                string PicWeb = arrayPath.FindLast(p => p.StartsWith("https://"));
                string Link_txt = arrayPath.FindLast(p => p.StartsWith("/cinema/") && p.EndsWith("/"));
                if (Link_txt == null)
                {
                    Link_txt = arrayPath.FindLast(p => p.StartsWith("/series") && p.EndsWith("/"));
                }



                if (PicWeb != "" && PicWeb != null && Link_txt != "") // для более полного соответствия искомому фильму
                {
                    DownloadAddon("https://afisha.mail.ru" + Link_txt, media);
                    return true;
                }
            }
            return false;



            //for (int y = 0; y < subStrings.Length; y++)
            //{
            //    //if (subStrings[y] == "background-image:url")
            //        if (subStrings[y] == "background-image: url")
            //        {
            //        ++y;
            //        if (subStrings[y].Contains("http"))
            //        {
            //            PicWeb = subStrings[y];         //"https://pic.afisha.mail.ru/2536415/"
            //            //Link_txt = subStrings[y - 5];   //"/cinema/movies/432352_stalker/"
            //            Link_txt = subStrings[y - 3];   //"/cinema/movies/432352_stalker/"
            //            string tt = arrayPath.FindLast(p => p.StartsWith ("/cinema/") && p.EndsWith("/"));
            //            string ts = arrayPath.FindLast(p => p.StartsWith("https://"));

            //            break;
            //        }
            //    }
            //}

        }

        private void DownloadAddon(string link, Media media)
        {
            string sourcestring = GetHtml(link);

            DownloadCountry(media, sourcestring);

            DownloadYear(media, sourcestring);

            DownloadGenre(media, sourcestring);

            DownloadDescription(media, sourcestring);

            DownloadPic(media, sourcestring);
        }

        public static bool StringIsValid(string str)
        {
            //return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"[^a-zA-z\d_]");
            return !string.IsNullOrEmpty(str) && Regex.IsMatch(str, "^[А-Яа-я]+$");
        }

        private static void DownloadCountry(Media media, string sourcestring)
        {
            // Обработка страны
            MatchCollection mcCountries = Regex.Matches(sourcestring, "(itemevent__head__info.*?<a href=.*?>[0-9]{4}</a>)", RegexOptions.IgnoreCase);

            bool flag = false;
            foreach (Match m in mcCountries)
            {
                MatchCollection mcCountry = Regex.Matches(m.ToString(), "(>.*?<)", RegexOptions.IgnoreCase);
                foreach (Match mm in mcCountry)
                {
                    string strt = mm.ToString();
                    strt = strt.Remove(0, strt.IndexOf('>') + 1);
                    strt = strt.Remove(strt.IndexOf('<'), 1);
                    if (StringIsValid(strt))
                    {
                        try
                        { // может несколько стран
                            media.Country = (Country_Rus)Enum.Parse(typeof(Country_Rus), strt);
                            flag = true;
                            break;// оставляем одну страну и выходим
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                if (flag) break;
            }
        }

        private static void DownloadYear(Media media, string sourcestring)
        {
            // Обработка года
            MatchCollection mcYear = Regex.Matches(sourcestring, "(itemevent__head__sep.*?<a href=.*?>[0-9]{4})", RegexOptions.IgnoreCase);

            string year = "";
            foreach (Match m in mcYear)
            {
                year = m.ToString();
                year = year.Remove(0, m.Length - 4);
                break;
            }
            if (year != "")
            {
                media.Year = Convert.ToInt32(year);
            }
        }

        private static void DownloadGenre(Media media, string sourcestring)
        {
            // Обработка жанра
            //MatchCollection mcGenre = Regex.Matches(sourcestring, "(itemevent__head__genre.*?<a href=.*?>[0-9]{4}</a>)", RegexOptions.IgnoreCase);
            MatchCollection mcGenre = Regex.Matches(sourcestring, "(itemevent__head__genre.*?</a>)", RegexOptions.IgnoreCase);

            // Value = "itemevent__head__genre\" itemprop=\"genre\"><a href=\"/cinema/all/drama/\">драма</a> <a href=\"/cinema/all/detektiv/\">детектив</a> <a href=\"/cinema/all/kriminal/\">криминал</a> <a href=\"/cinema/all/fentezi/\">фэнтези</a></div><div class=\"movieabout__sl...

            foreach (Match m in mcGenre)
            {
                //MatchCollection mcCountry = Regex.Matches(m.ToString().Trim(), "(>.*?<)", RegexOptions.IgnoreCase);
                //MatchCollection mcCountry = Regex.Matches(m.ToString().Replace(" ", string.Empty), "(>.*?<)", RegexOptions.IgnoreCase);
                MatchCollection mcCountry = Regex.Matches(m.ToString(), "(>.*?<)", RegexOptions.IgnoreCase);

                int arrayCount = (mcCountry.Count > 10) ? 10 : mcCountry.Count;

                for (int i = 0; i < arrayCount; i++)
                {
                    if (mcCountry[i].ToString().Replace(" ", string.Empty) == "><") continue;

                    string strt = mcCountry[i].ToString().Replace(" ", string.Empty);
                    strt = strt.Remove(0, strt.IndexOf('>') + 1);
                    strt = strt.Remove(strt.IndexOf('<'), 1);
                    if (StringIsValid(strt))
                    {
                        try
                        { // может несколько жанров
                            if (strt == "мультфильмы")
                            {
                                media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), "Детский", true);
                                media.Category = (CategoryVideo)Enum.Parse(typeof(CategoryVideo_Rus), "Мультфильм", true);
                            }
                            else
                            {
                                media.GenreVideo = (GenreVideo)Enum.Parse(typeof(GenreVideo_Rus), strt, true);
                            }
                            break;// оставляем одну страну и выходим
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                break;
            }
        }

        private static void DownloadDescription(Media media, string sourcestring)
        {
            // Обработка описания
            // MatchCollection mcDesc = Regex.Matches(sourcestring, @"(<div class=\""movieabout__info__descr__tx.*?>.*?</p>)", RegexOptions.IgnoreCase);
            MatchCollection mcDesc = Regex.Matches(sourcestring, @"(movieabout__info__descr__txt.*?</div>)", RegexOptions.IgnoreCase);

            /*
             * {<div class="movieabout__info__descr__txt" itemprop="description">
             */

            foreach (Match m in mcDesc)
            {
                string str = m.ToString();

                try
                {
                    if (-1 != str.IndexOf("<p"))
                    {
                        str = str.Remove(0, str.IndexOf("<p"));
                        if (-1 != str.IndexOf(">"))
                            str = str.Remove(0, str.IndexOf(">") + 1);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                str = Regex.Replace(str, "&nbsp;", " ");
                str = Regex.Replace(str, "&mdash;", "-");
                str = Regex.Replace(str, "&laquo;", "\"");
                str = Regex.Replace(str, "&raquo;", "\"");
                str = Regex.Replace(str, "&bdquo;", "\"");
                str = Regex.Replace(str, "&ldquo;", "\"");
                str = Regex.Replace(str, "<span>", "");
                str = Regex.Replace(str, "</span>", "");
                str = Regex.Replace(str, "<br/>", "");
                str = Regex.Replace(str, "<span class=\"_reachbanner_\">", "");
                str = Regex.Replace(str, "&hellip;", "...");

                str = Regex.Replace(str, "<p>", "");
                str = Regex.Replace(str, "</p>", "");
                str = Regex.Replace(str, "</div>", "");

                media.Description = str.Trim();
            }
        }

        private void DownloadPic(Media media, string sourcestring)
        {
            // Обработка картинки
            MatchCollection Pics = Regex.Matches(sourcestring, "(<img src=.*?class=\"movieabout__pic__img\")", RegexOptions.IgnoreCase);

            foreach (Match Pic in Pics)
            {
                string PicPath = Pic.ToString();
                PicPath = PicPath.Remove(0, PicPath.IndexOf('"') + 1);
                PicPath = PicPath.Remove(PicPath.IndexOf('"'), PicPath.Length - PicPath.IndexOf('"'));
                if (PicPath != "")
                {
                    if (File.Exists(GetFilename(media.Pic))) File.Delete(GetFilename(media.Pic));
                    DownloadPicBig(PicPath, media.Name);
                    media.Pic = media.Name;
                    break;
                }
            }
        }

        private void DownloadPicBig(string PicWeb, string Pic)
        {
            try
            {
                if (PicWeb.StartsWith("http"))                //if (PicWeb.Contains("http"))
                {
                    using (WebClient webClient = new WebClient())
                        webClient.DownloadFile(PicWeb, GetFilename(Pic));
                }
            }
            catch (Exception Ex) { MessageBox.Show("Загрузить изображение не удалось: " + Ex.Message); }
        }

        private void btnGetTime_Click(object sender, EventArgs e) => GetTime();

        private void GetTime()
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                Shell shell = new Shell();
                Folder folder = shell.NameSpace(record.Path);
                foreach (FolderItem2 _file in folder.Items())
                {
                    if (_file.Name == record.FileName.Remove(record.FileName.LastIndexOf(record.Extension) - 1, record.Extension.Length + 1))
                    {
                        double nanoseconds;
                        double.TryParse(Convert.ToString(_file.ExtendedProperty("System.Media.Duration")), out nanoseconds);
                        if (nanoseconds > 0)
                        {
                            string oldvalue = mtbTime.Text;
                            mtbTime.Text = TimeSpan.FromSeconds(nanoseconds / 10000000).ToString();
                            if (mtbTime.Text != oldvalue)
                                Modified();
                        }
                    }
                }
                Marshal.ReleaseComObject(folder);
                Marshal.ReleaseComObject(shell);
            }
        }

        #endregion


        #region Обработка актеров

        private void btnCancelActor_Click(object sender, EventArgs e)
        {
            dgvTableActors.Enabled = true;
            panelViewAct.BringToFront();
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
            NewActor();
        }

        private void NewActor()
        {
            tbFIO.Text = "";
            tbBIO.Text = "";
            maskDateOfBirth.Text = "";
            maskDateofDeath_RecoveryState();
            chLifeState.Checked = false;
            cBoxCountryActor.SelectedIndex = -1;
            tbFilmFind.Text = "";
            listViewFilm.Clear();
            lvSelectRecord.Items.Clear();

            dgvTableActors.Enabled = false;     // Блокировка таблицы при изменении панели
            dgvTableActors.ClearSelection();    // Удаление фокуса

            panelEditAct.BringToFront();
        }

        private void btnSaveActor_Click(object sender, EventArgs e) => SaveActor();

        private void SaveActor()
        {
            Actor actor;
            Actor act = GetSelectedActor();
            actor = (act == null) ? new Actor() : act;

            actor.FIO = tbFIO.Text;

            if (act == null)
                foreach (Actor item in _videoCollection.ActorList)
                {
                    if (item.Equals(actor))
                    {
                        MessageBox.Show("\"" + actor.FIO + "\" уже есть в списке актеров!");
                        return; // Выходим
                    }
                }

            actor.BIO = tbBIO.Text;
            actor.DateOfBirth = maskDateOfBirth.Text;
            actor.DateOfDeath = maskDateOfDeath.Text;
            actor.Country = (Country_Rus)cBoxCountryActor.SelectedIndex;
            actor.id = RecordCollection.GetActorID();

            foreach (ListViewItem eachItem in listViewFilm.Items)
            {
                actor.VideoID.Add(Convert.ToInt32(eachItem.SubItems[2].Text));
                _videoCollection.CombineList.FindLast(m => m.media.Id == Convert.ToInt32(eachItem.SubItems[2].Text)).media.ActorListID.Add(actor.id);
            }

            if (act == null)
            {
                _videoCollection.Add(actor);
                _videoCollection.Save();
            }
            else
            {
                _videoCollection.Save();
            }

            dgvTableActors.Enabled = true;
            PrepareRefresh();
        }



        private void checkLive_CheckedChanged(object sender, EventArgs e)
        {
            if (chLifeState.Checked)
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
                        if (record != null) lvSelectRecord_add(record.combineLink.media.Name, record.combineLink.media.Year, record.combineLink.media.Id);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                    listViewFilm.Items.Add((ListViewItem)item.Clone());
            }
        }

        private void listViewFilm_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listViewFilm.SelectedItems)
                listViewFilm.Items.Remove(eachItem);
        }


        #endregion



        //===================================

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)// проверка возможности переключения TabControl
        {
            e.Cancel = !CheckAccess();
        }

        private bool CheckAccess()
        {
            return true;

            //throw new NotImplementedException();
            // return true;//если доступ разрешен
            // return false; //если доступ запрещен
        }


        //private void dgvTableRec_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    //var formatter = e.CellStyle.FormatProvider as ICustomFormatter;
        //    //if (formatter != null)
        //    //{
        //    //    e.Value = formatter.Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
        //    //    e.FormattingApplied = true;
        //    //}
        //}


        #region Постеры

        public event ThumbnailImageEventHandler OnImageSizeChanged;
        private ThumbnailController m_Controller { get; set; }
        private ImageViewer m_ActiveImageViewer { get; set; }

        private int ImageSize { get { return (64 * (this.trackBarSize.Value + 1)); } }

        private void buttonCancel_Click(object sender, EventArgs e) // отмена сканирования
        {
            m_Controller.CancelScanning = true;
        }

        private void AddFolder()    // сканирование указанного каталога
        {
            this.flowLayoutPanelMain.Controls.Clear();
            m_Controller.AddFolder(PicsFolder);
            buttonCancel.Enabled = true;
            //buttonBrowseFolder.Enabled = false;

        }

        private void m_Controller_OnAdd(object sender, ThumbnailControllerEventArgs e)
        {
            AddImage(e.ImageFilename);
            Invalidate();
        }

        private void m_Controller_OnEnd(object sender, ThumbnailControllerEventArgs e)
        {
            // thread safe
            if (this.InvokeRequired)
            {
                this.Invoke(new ThumbnailControllerEventHandler(m_Controller_OnEnd), sender, e);
            }
            else
            {
                buttonCancel.Enabled = false;
                //buttonBrowseFolder.Enabled = true;
            }
        }

        delegate void DelegateAddImage(string imageFilename);
        private DelegateAddImage m_AddImageDelegate;

        private void AddImage(string imageFilename)
        {
            // thread safe
            if (InvokeRequired)
            {
                Invoke(m_AddImageDelegate, imageFilename); // exception dispose
            }
            else
            {
                int size = ImageSize;

                ImageViewer imageViewer = new ImageViewer();
                imageViewer.Dock = DockStyle.Bottom;
                imageViewer.LoadImage(imageFilename, 256, 256);
                imageViewer.Width = size;
                imageViewer.Height = size;
                imageViewer.IsThumbnail = true;
                imageViewer.MouseClick += new MouseEventHandler(imageViewer_MouseClick);

                this.OnImageSizeChanged += new ThumbnailImageEventHandler(imageViewer.ImageSizeChanged);

                this.flowLayoutPanelMain.Controls.Add(imageViewer);
            }
        }

        private void imageViewer_MouseClick(object sender, MouseEventArgs e)
        {

            if (m_ActiveImageViewer != null)
            {
                m_ActiveImageViewer.IsActive = false;
            }

            m_ActiveImageViewer = (ImageViewer)sender;
            m_ActiveImageViewer.IsActive = true;
            MessageBox.Show(m_ActiveImageViewer.ImageLocation);
        }

        private void trackBarSize_ValueChanged(object sender, EventArgs e)
        {
            //if (OnImageSizeChanged != null)
            //{
            //    OnImageSizeChanged(this, new ThumbnailImageEventArgs(ImageSize));
            //}
            OnImageSizeChanged?.Invoke(this, new ThumbnailImageEventArgs(ImageSize));
        }


        #endregion

    }
}


