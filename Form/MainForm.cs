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

namespace FilmCollection
{
    public partial class MainForm : Form
    {
        RecordCollection _videoCollection = new RecordCollection(); // Доступ к коллекции
        TreeViewColletion _treeViewColletion = new TreeViewColletion(); // Доступ к коллекции

        Record record = null;       // Доступ к записи
        FileInfo fsInfo = null;     // Поле для нового файла, добавляемого в базу

        BackgroundWorker WorkerCB;
        public BackgroundWorker workeLoad;

        public MainForm()
        {

            //System.Windows.Window w = new System.Windows.Window();
            //w.TaskbarItemInfo = new System.Windows.Shell.TaskbarItemInfo() { ProgressState = System.Windows.Shell.TaskbarItemProgressState.Error };
            //w.TaskbarItemInfo.ProgressValue = 55;

            //w.Loaded += delegate {
            //    Action<Object> callUpdateProgress = (o) => {
            //        w.TaskbarItemInfo.ProgressValue = (double)o;
            //    };

            //    Thread t = new Thread(() => {
            //        for (int i = 1; i <= 10; i++)
            //        {
            //            w.Dispatcher.BeginInvoke(callUpdateProgress, 1.0 * i / 10);
            //            Thread.Sleep(1000);
            //        }
            //    });
            //    t.Start();
            //};



            InitializeComponent();                  // Создание и отрисовка элементов
            this.MinimumSize = new Size(800, 600);   // Установка минимального размера формы

            dgvTable.AutoGenerateColumns = false;   // Отключение автоматического заполнения таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона
            dgvTable.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста
            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию



            // Создание списка на основе перечисления
            foreach (var item in Enum.GetValues(typeof(CategoryVideoRus)))
            {
                cBoxTypeVideo.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(GenreVideoRus)))
            {
                cBoxGenre.Items.Add(item);
            }

            WorkerCB = new BackgroundWorker();
            WorkerCB.DoWork += Smth_DoWork;                         // Здесь работает поток
            WorkerCB.RunWorkerCompleted += Smth_RunWorkerCompleted; // Здесь завершающая задачка в потоке
            WorkerCB.ProgressChanged += Smth_ProgressChanged;       // Здесь работает прогрес бар
            WorkerCB.WorkerReportsProgress = true;                  // Говорим что поток может передавать информацию о ходе своей работы

        }



















        //void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    // When the task ends, change the ProgressState and Overlay
        //    // of the taskbar item to indicate a stopped task.
        //    if (e.Cancelled == true)
        //    {
        //        // The task was stopped by the user. Show the progress indicator
        //        // in the paused state.
        //        this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Paused;
        //    }
        //    else if (e.Error != null)
        //    {
        //        // The task ended with an error. Show the progress indicator
        //        // in the error state.
        //        this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Error;
        //    }
        //    else
        //    {
        //        // The task completed normally. Remove the progress indicator.
        //        this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.None;
        //    }
        //    // In all cases, show the 'Stopped' overlay.
        //    this.taskBarItemInfo1.Overlay = (DrawingImage)this.FindResource("StopImage");
        //}





        private void Smth_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgressBar.Value = e.ProgressPercentage;
        }


        private void Smth_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // здесь выполняются завершающие (быстрые задачи), потому как влияют на работу прогрес бара
            MessageBox.Show(_videoCollection.VideoList.Count.ToString());
        }


        private void Smth_DoWork(object sender, DoWorkEventArgs e)  // Тело потока
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


        //public Timer ttt = new Timer();
        //public void T_Tickss(object sender, EventArgs e)
        //{
        //   // ttt.Enabled = false;
        //    MessageBox.Show("Значение Count = " + Convert.ToString( XmlSerializeHelper.Count));
        //}

        private void CreateBase()       // Создание файла базы
        {
            // Создание диалогового окна FolderBrowserDialog
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.Description = "Укажите расположение файлов мультимедиа:";
            fbDialog.ShowNewFolderButton = false;

            // ============= Нужно сделать фильтрацию добавляемых файлов по расширению ============= 
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
                    RefreshTable("");          // сбрасываем старые значения таблицы
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

                //ttt.Interval = 2000;
                //ttt.Tick += T_Tickss;
                //ttt.Enabled = true;

                FormLoad();
                //ttt.Enabled = false;
            }
        }







        private void Main_FormLoad(object sender, EventArgs e)      // Загрузка формы
        {
            FormLoad();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)    // обработка закрытия формы или выхода
        {
            FormClose(e);
        }


        #region Главное меню

        private void CreateBase_Click(object sender, EventArgs e)
        {
            CreateBase();
        }

        private void UpdateBase_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void BackupBase_Click(object sender, EventArgs e)    // Создание копии базы
        {
            BackupBase();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Сформировать отчет в формате html и открыть его в браузере по умолчанию 
        }

        private void Exit_Click(object sender, EventArgs e)   //Выход
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
        private void Filter(object sender, EventArgs e)     // При выборе фильтра выполняется сброс фильтра по дереву и таблице
        {
            dgvTable.ClearSelection();
            RefreshTable("");
        }

        private void AddRec_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            NewRecord();
        }

        private void EditRec_Click(object sender, EventArgs e)                 // Изменение записи
        {
            panelEdit.BringToFront();
        }

        private void Test_Add_rec(object sender, EventArgs e)                 // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Add(form.rec);
                _videoCollection.Save();
                RefreshTable("");
            }
        }

        private void Test_Change_rec(object sender, EventArgs e)          // Изменить запись
        {
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                RefreshTable("");      //Должно быть обновление вместо фильтра
            }
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)    // Проверка селекта строки перед открытием меню
        {
            //contextMenu.Items[4].Enabled = false;
            contextMenu.Enabled = false;    // Блокировка меню

            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                //contextMenu.Items[4].Enabled = true;
                contextMenu.Enabled = true; // Разблокировка меню
            }
        }

        private void cFind_Click(object sender, EventArgs e)    // Поиск
        {
            panelFind.BringToFront();
        }
        #endregion


        private void FileNameEdit_Unlock(object sender, EventArgs e)  // Разблокировка поля имени файла
        {
            tbFileName.Enabled = true;
            btnFileNameEdit.Enabled = false;    // блокировка кнопки разблокировки :)
            UserModifiedChanged(sender, e);
        }

        private void Edit_NewRec(object sender, EventArgs e)    // Создание элемента
        {
            NewRecord();
        }
        private void Edit_SaveRec(object sender, EventArgs e)   // Сохранение нового или измененого элемента
        {
            EditSave();
        }
        private void Edit_Cancel(object sender, EventArgs e) // Отмена редактирования
        {
            EditCancel();
        }


        private void UserModifiedChanged(object sender, EventArgs e)    // Срабатывает при внесение изменения в панели редактирования
        {
            if (fsInfo == null) dgvTable.DefaultCellStyle.SelectionBackColor = Color.Red;   // подсветка редактируемой строки
            panelEditUnlock();          // разблокировка кнопок
            dgvTable.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева
        }















        #region Загрузка формы
        private void FormLoad()     // Загрузка формы
        {
            if (File.Exists(RecordOptions.BaseName))     // Если база создана, то выполняем
            {
                _videoCollection = RecordCollection.Load();
                if (_videoCollection.VideoList.Count > 0)
                {
                    tssLabel.Text = "Коллекция из " + _videoCollection.VideoList.Count.ToString() + " элементов";
                    RefreshTable("");
                    CreateTree();
                }
                timerLoad.Enabled = true;                   // Исключение раннего селекта treeFolder и фильтра dataGridView1

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

            }
        }

        private void T_Tick(object sender, EventArgs e)     // таймер для селекта MainForm_Load
        {
            timerLoad.Enabled = false;
            treeFolder.SelectedNode = null;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }
        #endregion




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


        private void RefreshTable(string nodeName)    // Обновление таблицы путем фильтрации элементов по полю Path
        {
            Record selected = GetSelectedRecord();  // получение выбранной строки

            List<Record> filtered = _videoCollection.VideoList;

            if (nodeName != "" && nodeName != "Фильмотека")
                filtered = filtered.FindAll(v => v.Path == _videoCollection.Options.Source + Path.DirectorySeparatorChar + nodeName);

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

            dgvTable.DataSource = null;
            dgvTable.DataSource = filtered;

            if (selected != null)
                SelectRecord(dgvTable, selected);
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
                if (dgv.SelectedRows[0].DataBoundItem is Record)
                    record = dgv.SelectedRows[0].DataBoundItem as Record;
                if (record != null)
                    return record;
            }
            return null;
        }


        // Сделать расчет для прогресс бара
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
                    if (node.ChildNodes[0].Value.Length > SourceLength)     // длинна патча, не должна превышать полного пути к дирректории
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
                    MessageBox.Show(e.Message + " " + node.Name + " - не заполен!");
                }
            }

            PopulateTreeView(treeFolder, paths, Path.DirectorySeparatorChar, paths.Count);
            //treeFolder.AfterSelect += treeFolder_AfterSelect;
            TreeFast(paths);
        }


        private void TreeFast(IEnumerable<string> paths)
        {
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
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null;
            }
            //treeView.ExpandAll();           // развернуть дерево
        }


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e) // Команда при клике по строке
        {
            RefreshTable(e.Node.FullPath);     // обновление на основе полученной ноды
        }


        private void ResetFilter_Click(object sender, EventArgs e)
        {
            RefreshTable("");
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


        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при правом клике выполняется выбор строки и открывается меню
        {
            //      if (e.RowIndex > -1 && e.RowIndex < dgvTable.Rows.Count - 1)
            //{
            if (e.Button == MouseButtons.Right)
            {

                dgvTable.CurrentCell = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvTable.Rows[e.RowIndex].Selected = true;
                dgvTable.Focus();
            }
            //}
        }


        private void Play_Click(object sender, EventArgs e)  // запуск файла
        {
            Record record = GetSelectedRecord();
            Process.Start(record.Path + Path.DirectorySeparatorChar + record.FileName);
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
                RefreshTable("");
            }
        }


        private void FindRec_Click(object sender, EventArgs e)  // Поиск
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
            Regex regex = new Regex(tbFind.Text, RegexOptions.IgnoreCase);

            dgvTable.ClearSelection();
            dgvTable.MultiSelect = true;    // Требуется для выбора всех строк
            try
            {
                foreach (DataGridViewRow row in dgvTable.Rows)
                {
                    if (regex.IsMatch(row.Cells[cell].Value.ToString()))
                    {
                        row.Selected = true;
                        //break; //Требуется для выбора одно строки
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
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

            // Сохранение состояния главной формы
            _videoCollection.Options.FormState = this.WindowState.ToString();

            _videoCollection.Save();

        }


        private void NewRecord()    // Создание новой записи - объекта Record
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

                panelEditUnlock();          // разблокировка кнопок
                btnFileNameEdit.Enabled = false; // блокировка кнопки разблокировки :)
                tbFileName.Enabled = false; // блокировка поля измнения названия файла
            }
        }





        private void EditSave()
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
            panelEditLock();    // блокировка панели
        }


        private void EditCancel()    // Отмена редактирования в panelEdit
        {
            fsInfo = null;
            panelEditLock();    // блокировка кнопок панели редактирования
        }


        private void panelEditLock()    //Блокировка кнопок
        {
            tbName.Modified = false;    // возвращаем назад статус изменения поля
            tbYear.Modified = false;    // возвращаем назад статус изменения поля
            tbCountry.Modified = false; // возвращаем назад статус изменения поля
            tbDescription.Modified = false;// возвращаем назад статус изменения поля

            treeFolder.Enabled = true;  // Разблокировка дерева
            dgvTable.Enabled = true;    // Разблокировка таблицы
            dgvTable.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

            RefreshTable("");  // перезагрузка таблицы

            btnFileNameEdit.Enabled = true; // Разблокировка кнопки разблокировки :)
            btnEditCancel.Visible = false;  // "Отмена" - скрыть
            btnEditCancel.Enabled = false;  // "Отмена" - блокировать
            btnEditSaveR.Visible = false;  // "Сохранить" - скрыть
            btnEditSaveR.Enabled = false;  // "Сохранить" - блокировать

            panelView.BringToFront();   // показать панель сведений
        }


        private void panelEditUnlock()    //Разблокировка кнопок
        {
            // Разблокировать клавишу "Отмена"
            btnEditCancel.Visible = true;
            btnEditCancel.Enabled = true;
            // Блокировать клавишу "Сохранить"
            btnEditSaveR.Visible = true;
            btnEditSaveR.Enabled = true;
        }


    }
}



// this.customersDataGridView.Columns[0].Visible = false;
/* Сделать настриваемый фильтр для доабвления файлов в процессе создания базы
 * Оптимизировать создание дерева до передачи инетрфейсу
 * Сделать опцию настройки и добавления столбцов
 * 
 * 
 * 
 */
