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

namespace FilmCollection
{
    public partial class MainForm : Form
    {
        RecordCollection _videoCollection = new RecordCollection(); // Доступ к коллекции
        TreeViewColletion _treeViewColletion = new TreeViewColletion(); // Доступ к коллекции

        Record record = null;       // Доступ к записи
        FileInfo fsInfo = null;     // Поле для нового файла, добавляемого в базу

        int FindCount { get; set; }                 // счетчик найденых строк
        public List<int> dgvSelected { get; set; }  // индексы найденых строк

        BackgroundWorker WorkerCB;
        public BackgroundWorker workeLoad;


        #region Главная форма (Main)

        public MainForm()                           //Конструктор формы
        {
            InitializeComponent();                  // Создание и отрисовка элементов
            this.MinimumSize = new Size(800, 600);  // Установка минимального размера формы

            dgvTable.AutoGenerateColumns = false;   // Отключение автоматического заполнения таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона
            dgvTable.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста

            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию
            dgvSelected = new List<int>();          // хранение поисковых индексов

            // Создание списка на основе перечисления
            foreach (var item in Enum.GetValues(typeof(CategoryVideoRus)))
            { cBoxTypeVideo.Items.Add(item); }

            foreach (var item in Enum.GetValues(typeof(GenreVideoRus)))
            { cBoxGenre.Items.Add(item); }

            WorkerCB = new BackgroundWorker();
            WorkerCB.DoWork += Worker_DoWork;                     // Здесь работает поток
            WorkerCB.RunWorkerCompleted += WorkerCompleted;     // Здесь завершающая задачка в потоке
            WorkerCB.ProgressChanged += WorkerProgressChanged;  // Здесь работает прогресс бар
            WorkerCB.WorkerReportsProgress = true;              // Говорим что поток может передавать информацию о ходе своей работы
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
                _videoCollection = RecordCollection.Load();
                if (_videoCollection.VideoList.Count > 0)
                {
                    tssLabel.Text = "Коллекция из " + _videoCollection.VideoList.Count.ToString() + " элементов";
                    PepareRefresh();
                    CreateTree();
                }
                timerLoad.Enabled = true;               // Исключение раннего селекта treeFolder и фильтра dataGridView1
            }
            LoadFormVisualEffect();
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
            #region Восстановление состояния главной формы
            string switch_on = _videoCollection.Options.FormState;
            switch (switch_on)
            {
                case "Normal": WindowState = FormWindowState.Normal; break;
                case "Minimized": WindowState = FormWindowState.Minimized; break;
                case "Maximized": WindowState = FormWindowState.Maximized; break;
                default: WindowState = FormWindowState.Maximized; break;
            }
            #endregion

            #region Восстановление состояния сплиттеров
            scMain.SplitterDistance = _videoCollection.Options.scMainSplitter;
            scTabFilm.SplitterDistance = _videoCollection.Options.scTabFilmSplitter;
            #endregion

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
                if (result == DialogResult.Yes) // Если соглашаемся
                {
                    File.WriteAllText(RecordOptions.BaseName, string.Empty); // Затираем содержимое файла базы
                    _videoCollection.Clear();   // очищаем колелкцию
                    treeFolder.Nodes.Clear();   // очищаем иерархию
                    dgvTable.ClearSelection();  // выключаем селекты таблицы
                    PepareRefresh();            // сбрасываем старые значения таблицы
                }
            }
            else // Если базы нет, то создаем пустой файл базы
            {
                File.Create(RecordOptions.BaseName).Close(); // создание файла и закрытие дескриптора (Объект FileStream)
            }

            DialogResult dialogStatus = fbDialog.ShowDialog();  // Запрашиваем новый каталог с коллекцией видео
            string folderName = "";

            if (dialogStatus == DialogResult.OK)
            {
                tsProgressBar.Visible = true;
                tsProgressBar.ForeColor = Color.FromArgb(255, 0, 0);
                tsProgressBar.BackColor = Color.FromArgb(150, 0, 0);

                folderName = fbDialog.SelectedPath;                     //Извлечение имени папки

                DialogResult correct = MessageBox.Show("Источником фильмотеки выбран каталог: " + folderName, "Создание фильмотеки (" + folderName + ")",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (correct == DialogResult.Cancel)
                {
                   CreateBase();
                }

                DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки
                try
                {
                    tsProgressBar.Maximum = directory.GetFiles("*", SearchOption.AllDirectories).Length;    // Получаем количесво файлов
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }

                WorkerCB.RunWorkerAsync(directory);

                _videoCollection.Save();

                FormLoad();
            }
        }

        private void UpdateBase()       // Добавить обновление базы
        {
            if (_videoCollection.Options.Source != "")  // Если есть информация о корневой папки коллекции
            {
                DirectoryInfo directory = new DirectoryInfo(_videoCollection.Options.Source);
                if (directory.Exists)   // проверяем существование заявленной папки коллекции
                {
                    #region Формирование списка файлов в базе XML для использования при дальнейшей проверке. Нужно ли их добавлять.
                    List<string> FileNameList = new List<string>();                 // создаем пустой список типа string
                    XmlDocument doc = new XmlDocument();                            // создаем объект для доступа в xml документ
                    doc.Load(RecordOptions.BaseName);                            // загружаем файл базы
                    XmlNodeList nodeList = doc.GetElementsByTagName("FileName");    // передается название файла

                    foreach (XmlNode node in nodeList)
                    {
                        FileNameList.Add(node.ChildNodes[0].Value);
                    }
                    #endregion

                    char[] charsToTrim = { '.' };
                    foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.Name != FileNameList.Find(x => x.Contains(file.Name)))
                        {
                            record = new Record();

                            record.Name = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length);  // название без расширения (film)
                            record.FileName = file.Name;                            // полное название файла (film.avi)
                            record.Extension = file.Extension.Trim(charsToTrim);    // расширение файла (avi)
                            record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
                            record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                                    // if (-1 != file.DirectoryName.Substring(dlinna).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                            _videoCollection.Add(record);
                        }
                    }
                    _videoCollection.Save();    // если все прошло гладко, то сохраняем в файл базы
                    FormLoad();                 // и перегружаем главную форму
                }
            }
        }

        private void BackupBase()       // Резервная копия базы
        {
            if (File.Exists(RecordOptions.BaseName)) // если есть что бэкапить...
            {
                try
                {   // создаем бэкап
                    File.Copy(RecordOptions.BaseName, Path.GetFileNameWithoutExtension(RecordOptions.BaseName)
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss")
                        + Path.GetExtension(RecordOptions.BaseName));
                    MessageBox.Show("Создана резервная копия!");
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Сформировать отчет в формате html и открыть его в браузере по умолчанию 
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
                

        #region Фоновый поток обработки коллекции файлов

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgressBar.Value = e.ProgressPercentage;
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // здесь выполняются завершающие (быстрые задачи), потому как влияют на работу прогрес бара
            MessageBox.Show(_videoCollection.VideoList.Count.ToString());
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)  // Тело потока
        {
            DirectoryInfo directory = (DirectoryInfo)e.Argument;

            if (directory.Exists)
            {
                int count = 0;
                _videoCollection.Options.Source = directory.FullName;   // Сохранение каталога фильмов
                char[] charsToTrim = { '.' };
                foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                {
                    count++;
                    WorkerCB.ReportProgress(count);

                    record = new Record();

                    record.Name = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length);  // название без расширения (film)
                    record.FileName = file.Name;                            // полное название файла (film.avi)
                    record.Extension = file.Extension.Trim(charsToTrim);    // расширение файла (avi)
                    record.Path = file.DirectoryName;                       // полный путь (C:\Folder)
                    record.DirName = file.Directory.Name;                   // папка с фильмом (Folder)
                                                                            // if (-1 != file.DirectoryName.Substring(dlinna).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                    _videoCollection.Add(record);
                }
            }
        }

        #endregion


        #region Обработка DataGridView

        #region Контекстное меню для DataGridView
        
        private void AddRec_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            NewRecord();
        }

        private void EditRec_Click(object sender, EventArgs e)                 // Изменение записи
        {
            panelEdit.BringToFront();
        }

        private void DeleteRec_Click(object sender, EventArgs e)
        {
            Record record = GetSelectedRecord();
            DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + record.Name + "\" ?",
                                                  "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                _videoCollection.Remove(record);
                dgvTable.ClearSelection();
                _videoCollection.Save();
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

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)    // Проверка селекта строки перед открытием меню
        {
            //contextMenu.Items[4].Enabled = false;
            contextTabMenu.Enabled = false;    // Блокировка меню

            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                //contextMenu.Items[4].Enabled = true;
                contextTabMenu.Enabled = true; // Разблокировка меню
            }
        }

        private void cFind_Click(object sender, EventArgs e)    // Поиск
        {
            panelFind.BringToFront();
        }
        #endregion

        private void Filter(object sender, EventArgs e)     // При выборе фильтра > сброс фильтра по дереву и таблице
        {
            dgvTable.ClearSelection();
            PepareRefresh();
        }

        private void PepareRefresh()
        {
            PepareRefresh("", false);
        }
        
        private void PepareRefresh(string nodeName, bool flag)
        {
            List<Record> filtered = _videoCollection.VideoList;

            if (nodeName != "" && nodeName != "Фильмотека")
                if (!flag)
                {
                    filtered = filtered.FindAll(v => v.Path == _videoCollection.Options.Source + Path.DirectorySeparatorChar + nodeName);
                }
                else
                {
                    filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + nodeName));
                }


            int switch_filter = tscbTypeFilter.SelectedIndex;
            switch (switch_filter)  // фильтр по категориям
            {
                case 1: filtered = filtered.FindAll(v => v.Category == CategoryVideo.Film); break;
                case 2: filtered = filtered.FindAll(v => v.Category == CategoryVideo.Cartoon); break;
                case 3: filtered = filtered.FindAll(v => v.Category == CategoryVideo.Series); break;
                default: break;
            }

            int switch_sort = tscbSort.SelectedIndex;
            switch (switch_sort)  // Сортировка по столбцам
            {
                case 0: filtered.Sort(Record.CompareByName); break;
                case 1: filtered.Sort(Record.CompareByTime); break;
                case 2: filtered.Sort(Record.CompareByYear); break;
                case 3: filtered.Sort(Record.CompareByCategory); break;
                default: break;
            }
            RefreshTable(filtered);
        }

        private void RefreshTable(List<Record> filtered)
        {
            Record selected = GetSelectedRecord();  // получение выбранной строки
            if (selected != null) SelectRecord(dgvTable, selected);

            try
            {
                dgvTable.DataSource = null;
                dgvTable.DataSource = filtered;
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
            // Предоставляет данные выбранной записи
            Record record = GetSelectedRecord();
            if (record != null)
            {
                // Панель описания
                tbfName.Text = record.Name;
                tbfDesc.Text = record.Description;
                tbfYear.Text = record.Year;
                tbfCountry.Text = record.Country;

                // Панель редактирования
                tbName.Text = record.Name;
                tbYear.Text = record.Year;
                tbCountry.Text = record.Country;
                numericTime.Value = record.Time;
                tbDescription.Text = record.Description;
                tbFileName.Text = record.FileName;

                switch (record.Category)
                {
                    case CategoryVideo.Film: cBoxTypeVideo.SelectedIndex = 0; break;
                    case CategoryVideo.Series: cBoxTypeVideo.SelectedIndex = 1; break;
                    case CategoryVideo.Cartoon: cBoxTypeVideo.SelectedIndex = 2; break;
                    case CategoryVideo.Unknown: cBoxTypeVideo.SelectedIndex = 3; break;
                }

                switch (record.GenreVideo)
                {
                    case GenreVideo.Action: cBoxGenre.SelectedIndex = 0; break;
                    case GenreVideo.Vestern: cBoxGenre.SelectedIndex = 1; break;
                    case GenreVideo.Comedy: cBoxGenre.SelectedIndex = 2; break;
                    case GenreVideo.Unknown: cBoxGenre.SelectedIndex = 3; break;
                }
            }
        }

        private Record GetSelectedRecord()  // получение выбранной записи в dgvTable
        {
            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Record record = null;
                if (dgv.SelectedRows[0].DataBoundItem is Record) record = dgv.SelectedRows[0].DataBoundItem as Record;
                if (record != null) return record;
            }
            return null;
        }

        private void ResetFilter_Click(object sender, EventArgs e)
        {
            PepareRefresh();
            dgvTable.ClearSelection(); // сброс селекта

            tscbTypeFilter.SelectedIndex = 0;
            tscbSort.SelectedIndex = -1;

            tbName.Text = "";
            tbYear.Text = "";
            tbCountry.Text = "";
            numericTime.Value = 0;
            tbDescription.Text = "";
            tbFileName.Text = "";
            cBoxGenre.SelectedIndex = 0;
            cBoxTypeVideo.SelectedIndex = 0;
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при клике выполняется выбор строки и открывается меню
        {
            FindNextButton_Lock();    //блокировка кнопки поиска следующего элемента

            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.ColumnIndex > -1 && e.RowIndex > -1)
                    {
                        dgvTable.CurrentCell = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgvTable.Rows[e.RowIndex].Selected = true;
                        dgvTable.Focus();
                        dgvTable.ContextMenuStrip = contextTabMenu;
                        //if (e.ColumnIndex > -1 && e.RowIndex > -1) dgvTable.CurrentCell = dgvTable[e.ColumnIndex, e.RowIndex];
                    }
                    else
                    {
                        dgvTable.ContextMenuStrip = null;
                        dgvTable.ClearSelection();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
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

        private void btnNew_Click(object sender, EventArgs e)    // Создание элемента
        {
            NewRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)   // Сохранение нового или измененного элемента
        {
            SaveRecord();
        }

        private void btnCancel_Click(object sender, EventArgs e) // Отмена редактирования
        {
            CancelRecord();
        }

        private void NewRecord()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = _videoCollection.Options.Source;
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.Filter = "Все файлы (*.*)|*.*";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(fileDialog.FileName);
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

                // Заполняем поля
                tbName.Text = fInfo.Name.Remove(fInfo.Name.LastIndexOf(fInfo.Extension), fInfo.Extension.Length);
                tbYear.Text = "";
                tbCountry.Text = "";
                numericTime.Value = 0;
                tbDescription.Text = "";
                tbFileName.Text = fInfo.Name;
                cBoxGenre.SelectedIndex = 0;
                cBoxTypeVideo.SelectedIndex = 0;

                fsInfo = fInfo;             // если все хорошо, то передаем объект

                panelEdit.BringToFront();   // показываем панель редактирования

                dgvTable.Enabled = false;   // блокировка таблицы
                treeFolder.Enabled = false; // блокировка дерева

                panelEdit_Button_Unlock();          // разблокировка кнопок

                FileNameDisabled();
            }
        }

        private void SaveRecord()
        {
            GenreVideo genre;
            CategoryVideo category;
            char[] charsToTrim = { '.' };

            switch (cBoxGenre.SelectedIndex)
            {
                case 0: genre = GenreVideo.Action; break;
                case 1: genre = GenreVideo.Vestern; break;
                case 2: genre = GenreVideo.Comedy; break;
                case 3: genre = GenreVideo.Unknown; break;
                default: genre = GenreVideo.Unknown; return;
            }
            switch (cBoxTypeVideo.SelectedIndex)
            {
                case 0: category = CategoryVideo.Film; break;
                case 1: category = CategoryVideo.Series; break;
                case 2: category = CategoryVideo.Cartoon; break;
                case 3: category = CategoryVideo.Unknown; break;
                default: category = CategoryVideo.Unknown; return;
            }

            if (fsInfo != null) // если новый объект
            {
                Record record = new Record();

                record.FileName = fsInfo.Name;
                record.Path = fsInfo.DirectoryName;
                record.DirName = fsInfo.Directory.Name;
                record.Extension = fsInfo.Extension.Trim(charsToTrim);
                record.Name = tbName.Text;
                record.Year = tbYear.Text;
                record.Country = tbCountry.Text;
                record.Time = (int)numericTime.Value;
                record.Category = category;
                record.GenreVideo = genre;
                record.Description = tbDescription.Text;

                _videoCollection.Add(record);
                _videoCollection.Save();

                fsInfo = null;
            }
            else    // если выбраный объект 
            {
                Record record = GetSelectedRecord();
                if (record != null)
                {
                    record.Name = tbName.Text;
                    record.Year = tbYear.Text;
                    record.Country = tbCountry.Text;
                    record.Time = (int)numericTime.Value;
                    record.Category = category;
                    record.GenreVideo = genre;
                    record.Description = tbDescription.Text;
                    if (record.FileName != tbFileName.Text)
                    {
                        // System.IO.File.Move("oldfilename", "newfilename");
                        File.Move(record.Path + Path.DirectorySeparatorChar + record.FileName,
                                  record.Path + Path.DirectorySeparatorChar + tbFileName.Text);
                        record.FileName = tbFileName.Text;
                        record.Extension = Path.GetExtension(record.Path + Path.DirectorySeparatorChar + tbFileName.Text).Trim(charsToTrim);
                    }
                    else
                    {
                        record.FileName = tbFileName.Text;
                    }

                    _videoCollection.Save();
                }
            }
            panelEdit_Lock();    // блокировка панели
        }

        private void UserModifiedChanged(object sender, EventArgs e)    // Срабатывает при изменении любого поля
        {
            if (fsInfo == null) dgvTable.DefaultCellStyle.SelectionBackColor = Color.Red;   // подсветка редактируемой строки в таблице
            panelEdit_Button_Unlock();          // разблокировка кнопок
            dgvTable.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева
        }

        private void cbTypeFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = true;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        private void tabControl_ResetFindStatus_Click(object sender, EventArgs e)
        {
            ResetFind();
        }

        private void btnFindReset_Click(object sender, EventArgs e)
        {
            ResetFind();
        }


        #region Управление блокировками

        private void CancelRecord()    // Отмена редактирования в panelEdit
        {
            fsInfo = null;
            panelEdit_Lock();    // блокировка кнопок панели редактирования
        }

        private void panelEdit_Lock()    //Блокировка кнопок
        {
            tbName.Modified = false;    // возвращаем назад статус изменения поля
            tbYear.Modified = false;    // возвращаем назад статус изменения поля
            tbCountry.Modified = false; // возвращаем назад статус изменения поля
            tbDescription.Modified = false;// возвращаем назад статус изменения поля

            treeFolder.Enabled = true;  // Разблокировка дерева
            dgvTable.Enabled = true;    // Разблокировка таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

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
            dgvTable.ClearSelection();
            FindNextButton_Lock();
        }

        private void FindNextButton_Lock()
        {
            FindCount = 0;
            btnFindNext.Enabled = false;
        }

        private void Find_Click(object sender, EventArgs e)  // Поиск
        {
            int switch_Find = cbTypeFind.SelectedIndex;
            switch (switch_Find)
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

                dgvTable.ClearSelection();
                dgvTable.MultiSelect = true;    // Требуется для выбора всех строк

                int i = 0;

                foreach (DataGridViewRow row in dgvTable.Rows)
                {
                    if (regex.IsMatch(row.Cells[cell].Value.ToString()))
                    {
                        i++;
                        dgvSelected.Add(row.Cells[cell].RowIndex);
                        row.Selected = true;
                        //break; //Требуется для выбора одно строки
                    }
                }
                if (i == 0)
                    MessageBox.Show("Элементов не найдено!");
                else
                {
                    FindStatusLabel.Text = "Найдено " + i + " элементов.";
                    btnFindNext.Enabled = true;
                }
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
                dgvTable.ClearSelection();
                if (dgvSelected.Count > 0) dgvTable.FirstDisplayedScrollingRowIndex = dgvSelected[FindCount];

                foreach (DataGridViewRow row in dgvTable.Rows)
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
            Process.Start(record.Path + Path.DirectorySeparatorChar + record.FileName);
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
            //treeView.ExpandAll();           // развернуть дерево
        }


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e) // Команда при клике по строке
        {
            PepareRefresh(e.Node.FullPath, false);     // обновление на основе полученной ноды
        }
        
        private void treeFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeFolder.SelectedNode = treeFolder.GetNodeAt(e.X, e.Y);
                if (treeFolder.SelectedNode != null) // && treeFolder.SelectedNode.Parent == null)
                {
                    contextTreeMenu.Show(treeFolder, e.Location);
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

        private void btnActors_Click(object sender, EventArgs e)
        {
            Actors form = new Actors();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // _videoCollection.Add(form.Record);
                // _videoCollection.Save();
                // RefreshTables();
            }
        }
        
        #endregion


        #region Обработка постеров
        private void DownloadPic_Click(object sender, EventArgs e)
        {
            string remoteFileUrl = @"https://pic.afisha.mail.ru/share/event/730486/?20160916210443.1";
            string localFileName = "someImage.jpg";

            //using (WebClient webClient = new WebClient())
            WebClient webClient = new WebClient();
            webClient.DownloadFile(remoteFileUrl, localFileName);

            //byte[] data;
            //using (WebClient client = new WebClient())
            //{
            //    data = client.DownloadData("http://testsite.com/web/abc.jpg");
            //}
            //File.WriteAllBytes(@"c:\images\xyz.jpg", data);
        }

        static void Mains()
        {
            GetMetaInfo();
            Console.WriteLine("!!!");
            //string ii = GetHtmlPageText("https://afisha.mail.ru/cinema/movies/730486_polevye_ogni/");
            // Console.WriteLine(ii);
            Console.ReadKey();
        }

        //<meta property="og:image" content="

        //получение meta тэга
        static void GetMetaInfo()
        {
            string sourcestring = GetHtmlPageText("https://afisha.mail.ru/cinema/movies/730486_polevye_ogni/");
            //var tags = Regex.Matches(myHtmlText, @"(?<tag>\<meta[^\>]*>)", RegexOptions.IgnoreCase);
            //MatchCollection mc = Regex.Matches(sourcestring, @"(?<tag>\<meta[^\>]*>)", RegexOptions.IgnoreCase);
            //Regex metaTag = new Regex(@"<meta name=\"(.+?)\" content=\"(.+?)\">");
            //MatchCollection mc = Regex.Matches(sourcestring, @"(?<tag>\<meta property\""(.+?)\"">)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = Regex.Matches(sourcestring, @"(?<tag>\<meta.property=\""og:image\"".[^\>]*>)", RegexOptions.IgnoreCase);
            //MatchCollection mc = re.Matches(sourcestring);
            //int mIdx = 0;
            foreach (Match m in mc)
            {
                Console.WriteLine(m.ToString());
                //for (int gIdx = 0; gIdx < m.Groups.Count; gIdx++)
                //{
                //    Console.WriteLine("[{0}][{1}] = {2}", mIdx, re.GetGroupNames()[gIdx], m.Groups[gIdx].Value);
                //}
                //mIdx++;
                Console.WriteLine("====================");
                string myString = m.ToString();
                string[] subStrings = myString.Split('"');
                Console.WriteLine("content = " + subStrings[3]);
                //foreach (string str in subStrings)
                //{
                //    Console.WriteLine(str);
                //}
            }
        }

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

        // https://afisha.mail.ru/search/?q=полевые+огни&region_id=70
        // <a href = "/cinema/movies/730486_polevye_ogni/" class="searchitem__item__pic__img" style="background-image:url(https://pic.afisha.mail.ru/7087162/)"></a>
        // https://afisha.mail.ru/cinema/movies/730486_polevye_ogni/
        // https://afisha.mail.ru
        // https://pic.afisha.mail.ru/7087157/
        #endregion

    }
}
