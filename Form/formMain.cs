using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Shell32;
using Thr = System.Threading;

namespace FilmCollection
{
    public partial class MainForm : Form
    {
        #region Общедоступные свойства

        RecordCollection _videoCollection { get; set; }     // Доступ к коллекции
        TreeViewColletion _treeViewColletion { get; set; }  // Доступ к коллекции
        FileInfo fsInfo { get; set; } = null;       // для нового файла, добавляемого в базу
        int FindCount { get; set; }                 // Счетчик найденных строк
        public List<int> dgvSelected { get; set; }  //Индексы найденных строк
        public string FormatOpen { get; }       //Формат открытия файлов
        public List<string> FormatAdd { get; }  //Список форматов файлов
        public string PicsFolder { get; }       //Каталог изображений
        Timer timerCursor { get; }      // Таймер для смены курсора
        public Cursor crEn { get; }     // Курсор английской раскладки
        public Cursor crRu { get; }     // Курсор русской раскладки

        HelpProvider helpProvider { get; set; } // Справка

        public bool isDebug { get; set; } =
#if DEBUG
            true;
#else
            false;
#endif

        #endregion


        #region Главная форма (Main)

        public MainForm()
        {
            InitializeComponent();                  // Создание и отрисовка элементов

            this.Icon = FilmCollection.Properties.Resources.FC; // Загрузка иконки
            Tray.Icon = FilmCollection.Properties.Resources.FC; // Загрузка иконки для отображения в трее

            Tray.Visible = false;   // скрываем иконку в трее
            Tray.ContextMenuStrip = TrayMenu;   // контекстное меню

            #region Управление курсором (Таймер и курсоры)
            crEn = new Cursor(new MemoryStream(Properties.Resources.cursorEN)); // загрузка курсора
            crRu = new Cursor(new MemoryStream(Properties.Resources.cursorRU)); // загрузка курсора

            timerCursor = new Timer();      // Таймер для смены курсора
            timerCursor.Enabled = false;
            timerCursor.Interval = 200;
            timerCursor.Tick += new System.EventHandler(this.timerCursor_Tick);
            #endregion

            this.MinimumSize = new Size(1160, 600);  // Установка минимального размера формы

            _videoCollection = new RecordCollection();      // Доступ к коллекции
            _treeViewColletion = new TreeViewColletion();   // Доступ к коллекции

            dgvTableActors.AutoGenerateColumns = false; // Отключение автоматического заполнения таблицы
            dgvTableActors.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            dgvTableActors.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки

            TableRec.AutoGenerateColumns = false;    // Отключение автоматического заполнения таблицы
            TableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            TableRec.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки
            TableRec.Columns[7].DefaultCellStyle.SelectionForeColor = Color.Blue;    // цвет текста выбранной строки нужного столбца

            panelView.BringToFront();               // Отображение панели описания
            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию
            dgvSelected = new List<int>();          // хранение поисковых индексов

            FormatAdd = RecordOptions.FormatAdd();  // формат открытия файлов
            FormatOpen = RecordOptions.FormatOpen();// список форматов файлов
            PicsFolder = RecordOptions.PicsFolder();//Каталог изображений

            // Создание списка на основе перечисления
            foreach (var item in Enum.GetValues(typeof(CategoryVideo_Rus)))
            { cBoxTypeVideo.Items.Add(item); }

            foreach (var item in Enum.GetValues(typeof(GenreVideo_Rus)))
            { cBoxGenre.Items.Add(item); }

            foreach (var item in Enum.GetValues(typeof(Country_Rus)))
            {
                cBoxCountry.Items.Add(item);
                cBoxCountryActor.Items.Add(item);
                tsActCountryFilter.Items.Add(item);
            }

            //MenuChange.Visible = isDebug;
            btnOptions.Visible = isDebug;
            btnActors.Visible = isDebug;

            #region Постеры
            this.buttonCancel.Enabled = false;

            m_AddImageDelegate = new DelegateAddImage(this.AddImage);

            m_Controller = new ThumbnailController();
            m_Controller.OnAdd += new ThumbnailControllerEventHandler(m_Controller_OnAdd);
            m_Controller.OnEnd += new ThumbnailControllerEventHandler(m_Controller_OnEnd);

            #endregion

            #region Справка
            helpProvider = new HelpProvider();
            helpProvider.HelpNamespace = "help.chm";
            helpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
            helpProvider.SetHelpKeyword(this, "Main.htm");
            helpProvider.SetShowHelp(this, true);

            helpProvider.SetHelpKeyword(panelEditAct, "editFilm.htm");
            helpProvider.SetHelpNavigator(panelEditAct, HelpNavigator.Topic);
            helpProvider.SetShowHelp(panelEditAct, true);

            helpProvider.SetHelpKeyword(panelEditAct, "editActor.htm");
            helpProvider.SetHelpNavigator(panelEditAct, HelpNavigator.Topic);
            helpProvider.SetShowHelp(panelEditAct, true);

            helpProvider.SetHelpKeyword(panelFind, "Find.htm");
            helpProvider.SetHelpNavigator(panelFind, HelpNavigator.Topic);
            helpProvider.SetShowHelp(panelFind, true);
            #endregion
        }


        #region Управление курсором (Методы управления)
        private void timerCursor_Tick(object sender, EventArgs e)
        {
            this.Cursor = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;
        }

        private void timerCursorEnabled()
        {
            timerCursor.Enabled = true;
        }

        private void timerCursorDisabled()
        {
            timerCursor.Enabled = false;
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        /// <summary>Отрисовка рамки вокруг tsFindbyName</summary>
        private void tsFindbyName_Paint(object sender, PaintEventArgs e)
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
            ChangeStatusMenuButton(FormLoad(true));
        }

        private void Main_Close(object sender, FormClosingEventArgs e) => FormClose(e);// Закрытие формы или выход

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                //Hide();
                Tray.BalloonTipTitle = "Программа была спрятана";
                Tray.BalloonTipText = "Обратите внимание что программа была спрятана в трей и продолжит свою работу.";
                Tray.ShowBalloonTip(500);
                Tray.BalloonTipIcon = ToolTipIcon.Info;

                // прячем наше окно из панели
                ShowInTaskbar = false;

                // делаем нашу иконку в трее активной
                Tray.Visible = true;
            }
        }

        private void RestoreWindow()
        {
            WindowState = FormWindowState.Maximized;

            // возвращаем отображение окна в панели
            ShowInTaskbar = true;
            // делаем нашу иконку скрытой
            Tray.Visible = false;
        }

        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e) => RestoreWindow();
        private void ShowWindow_Click(object sender, EventArgs e) => RestoreWindow();


        private bool FormLoad(bool LoadfromFile = false)
        {
            bool state = false;

            if (File.Exists(RecordOptions.BaseName))    // Если база создана, то загружаем
            {
                _videoCollection.Clear();

                try
                {
                    _videoCollection = RecordCollection.Load(LoadfromFile);
                }
                catch (Exception ex)
                {
                    Logs.Log("При загрузки базы произошла ошибка:", ex);
                    BackupBase();   // на всякий случай делаем бэкап
                    return state;
                }

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

            SaveFormVisualEffect();

            //_videoCollection.Save();
            _videoCollection.SaveToFile();

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

        /// <summary>Создание файла базы </summary>
        private void NewBase()
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
                TableRec.ClearSelection();      // выключаем селекты таблицы
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

        /// <summary>Добавить обновление базы</summary>
        private void UpdateBase()
        {
            if (_videoCollection.Options.Source == null || _videoCollection.Options.Source == "")  // Если есть информация о корневой папки коллекции
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

                        _videoCollection.SaveToFile();    // если все прошло гладко, то сохраняем в файл базы

                        FormLoad(true);                 // и перегружаем главную форму
                        MessageBox.Show("Сведения о файлах в каталоге \"" + directory + "\" обновлены!");
                    }
                    else
                        MessageBox.Show("Каталог " + directory + " не обнаружен!");
                }
                catch (Exception ex) { Logs.Log("При обновлении базы произошла ошибка:", ex); }
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

        /// <summary>Резервная копия базы</summary>
        private void BackupBase()
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
                catch (IOException ex) { Logs.Log("Произошла ошибка при создании резервной копии базы:", ex); }
            }
        }

        private void RecoveryBase()
        {
            RecoveryForm form = new RecoveryForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(RecordOptions.BaseName)) // если файл базы существует
                    {
                        // создаем копию испорченной базы
                        string BadFileBase = Path.GetFileNameWithoutExtension(RecordOptions.BaseName)
                            + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss_BAD")
                            + Path.GetExtension(RecordOptions.BaseName);
                        File.Copy(RecordOptions.BaseName, BadFileBase);
                    }
                    File.Copy(form.recoverBase, RecordOptions.BaseName, true);
                }
                catch (IOException ex) { Logs.Log("Произошла ошибка при восстановлении файла базы:", ex); }

                MessageBox.Show("База восстановлена из резервной копии:\n" + form.recoverBase + " ");
                FormLoad(true);
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
            TableRec.ClearSelection();
            // treeFolder.Nodes.Clear(); //добавить обработку очистки дерева
            PrepareRefresh();
            MessageBox.Show("Очистка выполнена!");
        }

        #endregion


        #region Главное меню

        private void CreateBase_Click(object sender, EventArgs e) => NewBase();
        private void UpdateBase_Click(object sender, EventArgs e) => UpdateBase();
        private void BackupBase_Click(object sender, EventArgs e) => BackupBase();
        private void RecoveryBase_Click(object sender, EventArgs e) => RecoveryBase();
        private void Exit_Click(object sender, EventArgs e) => Close();

        private void CleanBase_Click(object sender, EventArgs e) => CleanBase();
        private void btnOpenCatalogDB_Click(object sender, EventArgs e) => OpenFolderDB();

        private void btnOptions_Click(object sender, EventArgs e)
        {
            Options form = new Options(_videoCollection);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //    _videoCollection.Save();
            }
        }

        private void btnOpenReportForm_Click(object sender, EventArgs e)
        {
            Report _report = new Report(_videoCollection);
            _report.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // Сформировать отчет в формате HTML и открыть его в браузере по умолчанию 
        }


        private void About_Click(object sender, EventArgs e) => AboutFC();
        private void btnHistory_Click(object sender, EventArgs e) => History();
        private void btnHelp_Click(object sender, EventArgs e) => HelpShow();


        private void tsAdd_Click(object sender, EventArgs e) => Add();
        private void tsChange_Click(object sender, EventArgs e) => Edit();
        private void tsRemove_Click(object sender, EventArgs e) => Delete();

        private void tsFind_Click(object sender, EventArgs e) => panelFind.BringToFront();

        private void tsFindbyName_KeyDown(object sender, KeyEventArgs e) => QuicSearch(e);

        private void tsFindbyName_MouseEnter(object sender, EventArgs e) => timerCursorEnabled();

        private void tsFindbyName_MouseLeave(object sender, EventArgs e) => timerCursorDisabled();

        #endregion



        private static void History()
        {
            fromChangeLog formLog = new fromChangeLog();
            formLog.ShowDialog();

            //string ChangeLog = "ChangeLog.txt";
            //if (File.Exists(ChangeLog))
            //{
            //    Process.Start(ChangeLog);
            //}
        }

        private static void AboutFC()
        {
            formAbout about = new formAbout();
            about.ShowDialog();
        }

        private void HelpShow()
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace, "about.htm");
        }



        #region Контекстное меню для DataGridView

        private void cFind_Click(object sender, EventArgs e) => panelFind.BringToFront();

        private void AddRec_Click(object sender, EventArgs e) => Add();

        private void EditRec_Click(object sender, EventArgs e) => Edit();

        private void DeleteRec_Click(object sender, EventArgs e) => Delete();

        private void cOpenFolder_Click(object sender, EventArgs e) => OpenFolder();

        private void UpdateInfo_Click(object sender, EventArgs e) => UpdateInfo();

        #endregion


        #region Обработка запуска контекстное меню для DataGridView

        private void contextMenu_Opening(object sender, CancelEventArgs e)    // Проверка выбора строки перед открытием контекстного меню
        {
            // TabMenu.Enabled = false;    // Блокировка меню

            for (int i = 0; i < TabMenu.Items.Count; i++)
            {
                TabMenu.Items[i].Visible = true;
            }

            switch (tabControlNumber())
            {
                case 0: // Фильмы
                    {
                    }
                    break;

                case 1: // Актеры
                    {
                        // if (isRows()) TabMenu.Enabled = true; // Разблокировка меню

                        TabMenu.Items[0].Visible = false;   // Поиск
                        TabMenu.Items[1].Visible = false;   // Separator
                        TabMenu.Items[5].Visible = false;   // Separator
                        TabMenu.Items[6].Visible = false;   // Открыть папку
                        TabMenu.Items[7].Visible = false;   // Separator
                        TabMenu.Items[8].Visible = false;   // Обновить информацию
                    }
                    break;

                case 2: // Постеры
                    {
                        //TabMenu.Enabled = true; // Разблокировка меню

                        TabMenu.Items[0].Visible = false;
                        TabMenu.Items[1].Visible = false;
                        TabMenu.Items[3].Visible = false;
                        TabMenu.Items[7].Visible = false;
                        TabMenu.Items[8].Visible = false;
                    }
                    break;

                default: break;
            }
        }

        private void treeFolder_DragDrop(object sender, DragEventArgs e)// здесь функционал DragDrop DGV to TreeView
        {
            Point pt = treeFolder.PointToClient(new Point(e.X, e.Y));
            TreeNode destinationNode = treeFolder.GetNodeAt(pt);
            TreeNode dragedNode = new TreeNode();

            Record record = GetSelectedRecord();
            if (record != null)
            {
                try
                {
                    //if (destinationNode.Level == 0 && destinationNode.Index == 0)
                    //{ //если условие верно, то это главный узел - "Фильмотека"
                    //  //MessageBox.Show(destinationNode.FullPath);
                    //}
                    //else
                    //{
                    //    string dirPath = Path.Combine(_videoCollection.Options.Source, destinationNode.FullPath);

                    //    if (File.Exists(Path.Combine(record.Path, record.FileName)))
                    //        if (Directory.Exists(dirPath))
                    //            File.Move(Path.Combine(record.Path, record.FileName), Path.Combine(dirPath, record.FileName));

                    //    record.DirName = destinationNode.Text;
                    //    record.Path = dirPath;

                    //    _videoCollection.Save();
                    //    PrepareRefresh();
                    //}

                    if (destinationNode != treeFolder.TopNode)
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
                catch (Exception ex) { Logs.Log("Произошла ошибка при перемещении Drag&Drop:", ex); }
            }
        }

        private void treeFolder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        /// <summary>Проверка размещения панели на верхнем уровне</summary>
        private bool IsControlAtFront(Control control)
        {
            return control.Parent.Controls.GetChildIndex(control) == 0;
        }

        //This will work for any Control anywhere within the Form:
        private bool IsControlAtFrontUniversal(Control control)
        {
            while (control.Parent != null)
            {
                if (control.Parent.Controls.GetChildIndex(control) == 0)
                {
                    control = control.Parent;
                    if (control.Parent == null)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }




        private void Table_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // Порядок 1
        {
            Debug.WriteLine(" - CellMouseDown");

            if (IsControlAtFront(panelFind))    // если отображается панель поиска, то пред просмотр только при двойном клике
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                    SelectRecord_Info(sender, e);
            }
            else
            {
                TableDragDrop(e);
                TableRightSelect(sender, e);
                TableLeftSelect(sender, e);
            }
        }

        private void TableDragDrop(DataGridViewCellMouseEventArgs e)
        {
            // организован Drag&Drop и отображение
            if (e.Button == MouseButtons.Left && e.ColumnIndex != 7)
            {
                if (isRows())
                    if (TableRec.SelectedRows[0].Index == e.RowIndex) TableRec.DoDragDrop(e.RowIndex, DragDropEffects.Copy);
            }
        }

        private void TableRightSelect(object sender, DataGridViewCellMouseEventArgs e)
        {
            // организован селект правой кнопкой мыши
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                SelectRecord_Info(sender, e);
            }
        }

        private void TableLeftSelect(object sender, DataGridViewCellMouseEventArgs e)
        {
            // организован селект левой кнопкой мыши
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Left)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                SelectRecord_Info(sender, e);
            }
        }


        private void TableRec_MouseClick(object sender, MouseEventArgs e)   // Порядок 2
        {
            Debug.WriteLine(" - MouseClick");

            // организованы вывод меню при клике правой кнопкой и в соответствии с координатами выбранной строки
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (DataGridView)(sender);
                if (dgv.SelectedRows.Count > 0)
                {
                    int x = e.X;
                    int y = e.Y;

                    Rectangle RowCoordinates = dgv.GetRowDisplayRectangle(dgv.SelectedRows[0].Index, true);

                    if ((x > RowCoordinates.Left && x < RowCoordinates.Right && y > RowCoordinates.Top && y < RowCoordinates.Bottom))
                    {
                        TabMenu.Show(dgv, new Point(e.X, e.Y));
                    }
                }
            }
        }

        /// <summary>Сортировка при клике по колонке</summary>
        private void TableRec_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) => SortByColumn(e);

        private void SortByColumn(DataGridViewCellMouseEventArgs e)
        {
            // организована сортировка при выборе колонки
            if (e.Button == MouseButtons.Left) PrepareRefresh(false, e.ColumnIndex);
        }

        private void TableRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) panelView.BringToFront();
        }

        private void TableRec_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) PlayRecord();
        }



        #endregion


        #region TabControl

        private int tabControlNumber()
        {
            return tabControl2.SelectedIndex;
        }

        private bool isRecTabs()
        {
            return (tabControlNumber() == 0) ? true : false;
        }

        private DataGridView GetDgv()
        {
            return (tabControl2.SelectedIndex == 0) ? TableRec : dgvTableActors;
        }

        bool isRows()
        {
            DataGridView dgv = GetDgv();
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)// проверка возможности переключения TabControl
        {
            // e.Cancel = !CheckAccess();
            e.Cancel = tabControlisBlock;
        }

        bool tabControlisBlock { get; set; } = false;   // панель разблокирована

        private bool CheckAccess()
        {
            return true;

            //throw new NotImplementedException();
            // return true;//если доступ разрешен
            // return false; //если доступ запрещен
        }

        private void dgvTableRec_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //var formatter = e.CellStyle.FormatProvider as ICustomFormatter;
            //if (formatter != null)
            //{
            //    e.Value = formatter.Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
            //    e.FormattingApplied = true;
            //}
        }

        #endregion


        #region Обработка DataGridView


        /// <summary>Добавление новой записи</summary>
        private void Add()
        {
            if (isRecTabs())
                NewRecord();
            else
                NewActor();
        }

        /// <summary>Редактирование записи</summary>
        private void Edit()
        {
            if (isRecTabs()) panelEdit.BringToFront();
            else panelEditAct.BringToFront();
        }

        private void Delete()
        {
            switch (tabControlNumber())
            {
                case 0: DeleteRec(); break;
                case 1: DeleteActor(); break;
                case 2: DeletePic(); break;
                default: break;
            }
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
            if (act != null)
            {
                DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + act.FIO + "\" ?",
                                      "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    _videoCollection.Remove(act);
                    _videoCollection.Save();
                    TableRec.ClearSelection();
                    PrepareRefresh();
                }
            }
        }

        private void DeletePic()
        {
            if (m_ActiveImageViewer != null)
            {
                string filePath = m_ActiveImageViewer.ImageLocation;

                DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + filePath + "\" ?",
                                                      "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        AddFolder();    // перезагрузка постеров  
                    }
                }
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


        private void Filter(object sender, EventArgs e)     // При выборе фильтра > сброс фильтра по дереву и таблице
        {
            TableRec.ClearSelection();
            dgvTableActors.ClearSelection();
            PrepareRefresh();
        }

        public string LastNode { get; set; }

        private void PrepareRefresh(string nodeName, bool flag)
        {
            LastNode = nodeName;
            PrepareRefresh(flag);
        }

        private string GetNode()
        {
            return (LastNode == null) ? "" : LastNode;
        }

        private bool checkNode()
        {
            string nodeName = (GetNode());
            if (nodeName != "" && nodeName != "Фильмотека")
                return true;
            return false;
        }

        private void PrepareRefresh(bool ShowAllFiles = false, int column = -1)
        {
            Record selected = GetSelectedRecord();

            // List<Record> filtered = _videoCollection.VideoList;
            //dataGridView1.DataSource = new List<Combine>(_videoCollection.CombineList);

            List<Record> filtered = new List<Record>();
            _videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));
            TableRec.DataSource = filtered;

            filtered = filtered.FindAll(v => v.Visible == !cbIsVisible.Checked);

            filtered = (tscbTypeFilter.SelectedIndex != 0)  // фильтрация по типу: Фильм, Мультфильм..
                ? filtered.FindAll(v => v.mCategory == ((CategoryVideo_Rus)(tscbTypeFilter.SelectedIndex - 1)).ToString())
                : filtered;

            if (checkNode())
            {
                // Флаг не распространяется на клик по корню, т.е. на "Фильмотека" - отображается все содержимое каталогов
                filtered = (!ShowAllFiles)
                            // отобразить файлы в текущем каталоге
                            ? filtered.FindAll(v => v.Path == _videoCollection.Options.Source + Path.DirectorySeparatorChar + GetNode())
                            // отобразить все файлы в т.ч. и вложенные
                            : filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + GetNode()));
            }


            if (isRecTabs())
            {
                if (column > -1) SortRecord(filtered, column);
                else SortRecord(filtered, tscbSort.SelectedIndex);

                PrepareActor(-1);
            }
            else
            {
                if (column > -1) PrepareActor(column);
                else PrepareActor(tsActSort.SelectedIndex);
            }
            // продумать обновление актеров

            RefreshTable(filtered);

            if (selected != null) SelectRecord(TableRec, selected);
        }

        private static void SortRecord(List<Record> filtered, int switch_sort)  // Сортировка по столбцам
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

        private void PrepareActor(int switch_sort)
        {
            List<Actor> filteredAct = new List<Actor>(_videoCollection.ActorList);

            if (tsActCountryFilter.SelectedIndex > -1)
                filteredAct = filteredAct.FindAll(a => a.Country == (Country_Rus)tsActCountryFilter.SelectedIndex);

            SortActor(filteredAct, switch_sort);

            // dgvTableActors.DataSource = null;
            dgvTableActors.DataSource = filteredAct;

            // список актеров
            chkActorList.Items.Clear();

            foreach (Actor item in _videoCollection.ActorList)
                chkActorList.Items.Add(item);
        }

        private void SortActor(List<Actor> filteredAct, int switch_sort)  // Сортировка по столбцам
        {
            switch (switch_sort)
            {
                case 0: filteredAct.Sort(Actor.CompareByName); break;
                case 1: filteredAct.Sort(Actor.CompareByDateOfBirth); break;
                case 2: filteredAct.Sort(Actor.CompareByDateOfDeath); break;
                case 3: filteredAct.Sort(Actor.CompareByCountry); break;
                default: break;
            }
        }


        private void RefreshTable(List<Record> filtered)
        {
            Record selected = GetSelectedRecord();  // получение выбранной строки
            if (selected != null) SelectRecord(TableRec, selected);

            try
            {
                TableRec.DataSource = null;
                TableRec.DataSource = filtered;

                // отображаем другой шрифт и цвет для удаленных записей
                if (TableRec.RowCount > 0)
                {
                    foreach (DataGridViewRow row in TableRec.Rows)
                    {
                        if ((row.DataBoundItem as Record).Visible == false)
                        {
                            //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.Silver;
                            row.DefaultCellStyle.Font = new Font(TableRec.Font, FontStyle.Strikeout);

                        }
                        if ((row.DataBoundItem as Record).Visible == true)
                            row.Cells[7].Style.ForeColor = Color.Blue;
                    }
                }
            }
            catch (Exception ex) { Logs.Log("Произошла ошибка при обновлении данных в таблице:", ex); }
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

        /// <summary>Отражение информации в карточке при выборе строки</summary>
        private void SelectRecord_Info(object sender, EventArgs e)
        {
            SelectRec();
        }

        private void SelectRec()
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
                btnPlay.Enabled = true;
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

        //public string GetFilename(string name)
        //{
        //    return Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "" + name + ".jpg");
        //}

        private void GetPic(Media _media)
        {
            //string pic = "";
            //if (_media != null) pic = _media.Pic;

            //string filename;
            //filename = (pic == "")
            //    ? GetFilename("noPic")
            //    : GetFilename(pic);

            if (_media != null)
            {
                if (File.Exists(_media.GetFilename))
                {
                    Image image = Image.FromFile(_media.GetFilename);
                    pbImage.Image = (image.Height > 300)
                        ? image.GetThumbnailImage(300 * image.Width / image.Height, 300, null, IntPtr.Zero)
                        : image;
                }
                else pbImage.Image = null;
            }


        }

        private Record GetSelectedRecord()  // получение выбранной записи в dgvTable
        {
            DataGridView dgv = TableRec;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Record record = null;
                if (dgv.SelectedRows[0].DataBoundItem is Record) record = dgv.SelectedRows[0].DataBoundItem as Record;
                if (record != null) return record;

                //List<string> nnn = new List<string>();

                //foreach (DataGridViewTextBoxCell item in dgv.SelectedRows[0].Cells)
                //    if (item != null && item.Value != null)
                //        nnn.Add(item.Value.ToString());
            }
            return null;
        }


        /// <summary>Сортировка при клике по колонке</summary>
        private void dgvTableActors_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) => SortByColumn(e);


        private void TableRightSelect_Actor(object sender, DataGridViewCellMouseEventArgs e)
        {
            // организован селект правой кнопкой мыши
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                SelectActor_Info(sender, e);
            }
        }

        private void dgvTableActors_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            TableRightSelect_Actor(sender, e);
        }

        private void TableAct_MouseClick(object sender, MouseEventArgs e)
        {
            // организованы вывод меню при клике правой кнопкой и в соответствии с координатами выбранной строки
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (DataGridView)(sender);
                if (dgv.SelectedRows.Count > 0)
                {
                    int x = e.X;
                    int y = e.Y;

                    Rectangle RowCoordinates = dgv.GetRowDisplayRectangle(dgv.SelectedRows[0].Index, true);

                    if ((x > RowCoordinates.Left && x < RowCoordinates.Right && y > RowCoordinates.Top && y < RowCoordinates.Bottom))
                    {
                        TabMenu.Show(dgv, new Point(e.X, e.Y));
                    }
                }
            }
        }


        private void SelectActor_Info(object sender, EventArgs e)  // Отражение информации в карточке актеров
        {
            panelViewAct.BringToFront();               // Отображение панели описания
            Actor act = GetSelectedActor();            // Предоставляет данные выбранной записи
            if (act != null)
            {
                try
                {
                    // Панель описания
                    tbFIOv.Text = act.FIO;
                    linkBIOv.Text = act.BIO;
                    tbCountryAv.Text = act.CountryString;
                    maskDateOfBirthV.Text = act.DateOfBirth;
                    maskDateOfDeathV.Mask = "";
                    maskDateOfDeathV.Text = act.DateOfDeath;
                    listViewFilmV.Items.Clear();

                    foreach (int recID in act.VideoID)
                        foreach (Combine com in _videoCollection.CombineList.FindAll(m => m.media.Id == recID))
                            listViewFilmV.Items.Add(new ListViewItem(
                                new string[] { com.media.Name, com.media.CountryString, com.media.Year.ToString(), com.media.Id.ToString() }));
                    
                    // Панель редактирования
                    tbFIO.Text = act.FIO;
                    tbBIO.Text = act.BIO;
                    maskDateOfBirth.Text = act.DateOfBirth;
                    chLifeState.CheckState = (act.DateOfDeath == "По настоящее время") ? CheckState.Checked : CheckState.Unchecked;
                    maskDateOfDeath.Text = act.DateOfDeath;
                    cBoxCountryActor.SelectedIndex = ((int)act.Country);
                    listViewFilm.Items.Clear();

                    foreach (int recID in act.VideoID)
                        foreach (Combine com in _videoCollection.CombineList.FindAll(m => m.media.Id == recID))
                            listViewFilm.Items.Add(new ListViewItem(
                                new string[] { com.media.Name, com.media.Year.ToString(), com.media.Id.ToString() }));
                }
                catch (Exception ex) { Logs.Log("Произошла ошибка при отображении данных выбранной строки:", ex); }
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

        private void ResetFilter_Click(object sender, EventArgs e) => ResetFilter();

        private void ResetFilter()
        {
            PrepareRefresh();

            switch (tabControlNumber())
            {
                case 0:
                    {
                        TableRec.ClearSelection();
                        tscbSort.SelectedIndex = -1;
                        tscbTypeFilter.SelectedIndex = 0;
                        CardRecordPreview_Clear();
                        panelView.BringToFront();
                    }
                    break;

                case 1:
                    {
                        dgvTableActors.ClearSelection();
                        tsActSort.SelectedIndex = -1;
                        tsActCountryFilter.SelectedIndex = -1;
                        CardActorPreview_Clear();
                        panelViewAct.BringToFront();
                    }
                    break;

                default: break;
            }
        }

        private void OpenFolder()
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0: OpenRecFolder(); break;
                case 2: OpenPicFolder(); break;
                default: break;
            }
        }

        private void OpenRecFolder()
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

        private void OpenPicFolder()
        {
            if (m_ActiveImageViewer != null)
            {
                string filePath = m_ActiveImageViewer.ImageLocation;

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файл \"" + filePath + "\" не найден!");
                    return;
                }

                string argument = "/select, \"" + filePath + "\"";
                Process.Start("explorer.exe", argument);
            }
        }

        private void OpenFolderDB()
        {
            string filePath = RecordOptions.BaseName;
            if (!File.Exists(filePath))
                return;

            string argument = "/select, \"" + filePath + "\"";
            Process.Start("explorer.exe", argument);
        }

        #endregion


        #region панель поиска (panelFind)

        private void ResetFind()
        {
            tbFind.Text = "";
            FindStatusLabel.Text = "";
            cbTypeFind.SelectedIndex = -1;
            btnFind.Enabled = false;

            dgvSelected.Clear();
            FindNextButton_Lock();

            Reset();
        }

        private void Reset()
        {
            dgvTableActors.Enabled = true;  // Разблокировка таблицы при изменении панели
            dgvTableActors.ClearSelection();// Удаление фокуса
            CardActorPreview_Clear();       // Очистка информации на карточке

            TableRec.Enabled = true;        // Разблокировка таблицы при изменении панели
            TableRec.ClearSelection();      // Удаление фокуса
            CardRecordPreview_Clear();      // Очистка информации на карточке
        }

        /// <summary>Блокировка кнопки поиска следующего элемента</summary>
        private void FindNextButton_Lock()
        {
            FindCount = 0;
            btnFindNext.Enabled = false;
        }

        /// <summary>Выполняется при вводе значение поисковое поле и нажатии кнопки Enter</summary>
        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FindbyValue();
        }

        private void btnHidePanel_Click(object sender, EventArgs e) //Скрыть панель поиска
        {
            panelView.BringToFront();
        }

        private void Find_Click(object sender, EventArgs e)     //Кнопка найти всё
        {
            FindbyValue();
        }

        private void FindbyValue()
        {
            switch (cbTypeFind.SelectedIndex)
            {
                case 0: Find(0); break; // поиск по названию
                case 1: Find(2); break; // поиск по году
                default: MessageBox.Show("Укажите критерий поиска!"); break;
            }
        }

        private void btnFindNext_Click(object sender, EventArgs e) => FindNext();

        private void cbTypeFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = true;
        }

        private void tabControl_ChangeTab_Click(object sender, EventArgs e) => Reset();

        private void btnFindReset_Click(object sender, EventArgs e) => ResetFind();

        private void tbFind_MouseEnter(object sender, EventArgs e) => timerCursorEnabled();

        private void tbFind_MouseLeave(object sender, EventArgs e) => timerCursorDisabled();


        #endregion


        #region Поисковый механизм


        private void Find(int cell)
        {
            try
            {
                string regReplace = tbFind.Text.Replace("*", "");//замена вхождения * 
                Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);

                TableRec.ClearSelection();
                TableRec.MultiSelect = true;    // Требуется для выбора всех строк

                int i = 0;

                foreach (DataGridViewRow row in TableRec.Rows)
                {
                    if (regex.IsMatch(row.Cells[cell].Value.ToString()))
                    {
                        i++;
                        dgvSelected.Add(row.Cells[cell].RowIndex);
                        row.Selected = true;
                        TableRec.FirstDisplayedScrollingRowIndex = row.Index;// прокручиваем
                        //break; //Требуется для выбора одно строки
                    }
                }
                if (i == 0) MessageBox.Show("Элементов не найдено!");
                if (i > 0)
                {
                    FindStatusLabel.Text = "Найдено " + i + " элементов.";
                    btnFindNext.Focus();
                }

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
                TableRec.ClearSelection();
                if (dgvSelected.Count > 0) TableRec.FirstDisplayedScrollingRowIndex = dgvSelected[FindCount];

                foreach (DataGridViewRow row in TableRec.Rows)
                {
                    if (row.Index == dgvSelected[FindCount]) row.Selected = true;
                }
                FindCount++;
            }
            if (!(FindCount < dgvSelected.Count)) FindCount = 0;
        }


        private void QuicSearch(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string regReplace = tsFindbyName.Text.Replace("*", "");
                    Regex regex = new Regex(regReplace, RegexOptions.IgnoreCase);

                    DataGridView dgv = GetDgv();

                    dgv.ClearSelection();
                    dgv.MultiSelect = true;

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (regex.IsMatch(row.Cells[0].Value.ToString()))
                        {
                            int f = row.Cells[0].RowIndex;
                            if (f < dgv.RowCount)
                            {
                                dgv.ClearSelection();
                                dgv.Rows[f].Selected = true;            // выделяем
                                dgv.FirstDisplayedScrollingRowIndex = f;// прокручиваем
                                dgv.Update();
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

        #endregion


        #region Панель редактирования (panelEdit)
        private void FileNameEdit_Unlock(object sender, EventArgs e)  // Разблокировка поля имени файла
        {
            tbFileName.Enabled = true;
            btnFileNameEdit.Enabled = false;    // блокировка кнопки разблокировки :)
            UserModifiedChanged(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e) => NewRecord();    // Создание элемента
        private void btnSave_Click(object sender, EventArgs e) => SaveRecord();         // Сохранение нового или измененного элемента
        private void btnCancel_Click(object sender, EventArgs e) => CancelRecord();     // Отмена редактирования

        private void NewRecord()
        {
            TableRec.ClearSelection();   // сброс селекта таблицы

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Path.Combine(_videoCollection.Options.Source, GetNode());
            fileDialog.Filter = FormatOpen;
            fileDialog.Title = "Выберите файл:";
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

                CardRecordEdit_Clear();

                // Заполняем поля
                cbNameMedia.Text = newFile.Name.Remove(newFile.Name.LastIndexOf(newFile.Extension), newFile.Extension.Length);
                tbNameRecord.Text = cbNameMedia.Text;
                tbFileName.Text = newFile.Name;
                mtbYear.Text = DateTime.Now.Year.ToString();

                foreach (Actor item in _videoCollection.ActorList)
                {
                    chkActorList.Items.Add(item.FIO);
                }

                fsInfo = newFile;           // если все хорошо, то передаем объект    

                TableRec.Enabled = false;    // блокировка таблицы
                treeFolder.Enabled = false;     // блокировка дерева

                panelEdit_Button_Unlock();          // разблокировка кнопок
                FileNameDisabled();

                panelEdit.BringToFront();   // Отображаем панель редактирования

                // блокировка tabControl2
                tabControlisBlock = true;
            }
        }

        private void CardRecordEdit_Clear()
        {
            cbNameMedia.Text = "";
            tbNameRecord.Text = "";
            tbFileName.Text = "";
            tbDescription.Text = "";
            mtbYear.Text = "";
            cBoxGenre.SelectedIndex = -1;
            cBoxTypeVideo.SelectedIndex = -1;
            cBoxCountry.SelectedIndex = -1;
            chkActorList.Items.Clear();
        }

        private void CardRecordPreview_Clear()
        {
            tbfName.Text = "";
            tbfDesc.Text = "";
            tbfYear.Text = "";
            tbfCountry.Text = "";
            GetPic(null);
            lbActors.Items.Clear();
            btnPlay.Enabled = false;
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

            tabControlisBlock = false;
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

            if (chkActorSelect.Items.Count != 0)
            {
                foreach (Actor _actorID in chkActorSelect.Items)
                    if (_actorID != null)
                    {
                        cm.media.ActorListID_Add(_actorID.id);
                        _actorID.VideoID_Add(cm.media.Id);
                    }
            }
            else
            {
                cm.media.ActorListID_Clear(); // Продумать синхронизацию актёров и медиа при изменении или очистки списка актеров
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
                List<Media> tmp = new List<Media>();    // промежуточный список для ускорения построение списка

                foreach (var item in _videoCollection.CombineList) // создаем список фильмов для функции авто поиска
                    tmp.Add(item.media);

                cbNameMedia.Items.AddRange(tmp.ToArray());

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


        #region Годы
        private void mtbYear_KeyDown(object sender, KeyEventArgs e) => Modified();   // Срабатывает при изменении любого поля

        private void mtbYear_Validating(object sender, CancelEventArgs e)   // Проверка корректности вводимого года
        {
            if (!mtbYear.MaskCompleted)
                MessageBox.Show("Неверно указан год!");
        }

        private void mtbYearValidator()
        {
            string year = mtbYear.Text.Trim('_');

            if (year.Length == 4)
            {
                int count = (Convert.ToInt32(year));
                int Year = DateTime.Now.Year;
                if (count > Year || count < 1900)
                    mtbYear.Text = Year.ToString();
            }
        }

        private void mtbYear_KeyUp(object sender, KeyEventArgs e)
        {
            mtbYearValidator();
        }
        #endregion


        #region Время
        private void mtbTime_KeyDown(object sender, KeyEventArgs e) => Modified();  // Проверка времени

        private void mtbTime_Validating(object sender, CancelEventArgs e)
        {
            if (!mtbTime.MaskCompleted)
            {
                MessageBox.Show("Неверно указано время!");
                mtbTime.Focus();
            }
        }
        #endregion

        private void Modified()
        {
            if (fsInfo == null) TableRec.DefaultCellStyle.SelectionBackColor = Color.Salmon; // подсветка редактируемой строки в таблице
            panelEdit_Button_Unlock();  // разблокировка кнопок
            TableRec.Enabled = false;   // блокировка таблицы
            treeFolder.Enabled = false; // блокировка дерева
        }


        #region Управление блокировками

        private void CancelRecord()    // Отмена редактирования в panelEdit
        {
            fsInfo = null;
            panelEdit_Lock();    // блокировка кнопок панели редактирования
            tabControlisBlock = false;
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
            TableRec.Enabled = true;     // Разблокировка таблицы
            TableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

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


        #region Панель просмотра

        private void Play_Click(object sender, EventArgs e)  // запуск файла
        {
            PlayRecord();
        }

        private void PlayRecord()
        {
            Record record = GetSelectedRecord();
            if (record != null) // убрать возможность нажатия при отсутствии селекта
            {
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
        }

        private void linkBIOv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkBIOv.Text);
            //ProcessStartInfo sInfo = new ProcessStartInfo("http://www.google.com");
            //Process.Start(sInfo);
        }

        private void lbActors_DoubleClick(object sender, EventArgs e)
        {
            // tabControl2.SelectTab(tabActors);
            //tabControl2.SelectedTab = tabActors;

            if (lbActors.SelectedItem != null)
            {
                string searchValue = lbActors.SelectedItem.ToString();
                int rowIndex = -1;
                foreach (DataGridViewRow row in dgvTableActors.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                if (rowIndex != -1)
                {
                    dgvTableActors.Rows[rowIndex].Selected = true;
                    //dgvTableActors.Rows[rowIndex].Visible = true;
                    dgvTableActors.FirstDisplayedScrollingRowIndex = rowIndex;// прокручиваем

                }
            }
        }

        private void listViewFilmV_DoubleClick(object sender, EventArgs e)
        {
            if (listViewFilmV.SelectedItems[0].SubItems[0].Text != "")
            {
                string searchValue = listViewFilmV.SelectedItems[0].SubItems[0].Text;
                FindAndSelect_Record(searchValue);
            }
        }

        /// <summary>Поиск фильма и переход к нему</summary>
        /// <param name="VideoName">Название фильма</param>
        private void FindAndSelect_Record(string VideoName)
        {
            PrepareRefresh("Фильмотека", true); // решает проблему с поиском, если в дереве выбрана другая вкладка (фактически делает сброс)

            int rowIndex = -1;

            IEnumerable<int> index = (from r in TableRec.Rows.Cast<DataGridViewRow>()
                                      where r.Cells["cmnName"].Value.ToString() == VideoName
                                      select r.Index);

            if (index != null && index.Count() > 0) // для устранения исключения при отсутствии нужного элемента
            {
                rowIndex = index.First();
            }

            //DataGridViewRow row = dgvTableRec.Rows
            //    .Cast<DataGridViewRow>()
            //    .Where(r => r.Cells["cmnName"].Value.ToString().Equals(searchValue))
            //    .First();
            //rowIndex = row.Index;           

            if (rowIndex != -1)
            {
                if (TableRec.Rows[rowIndex].Cells["cmnName"].Value.ToString() != VideoName)
                {   // если точно не найден фильм по названию картинки, то выходим из метода
                    return;
                }

                TableRec.Rows[rowIndex].Selected = true;
                TableRec.FirstDisplayedScrollingRowIndex = rowIndex;// прокручиваем

                tabControl2.SelectTab(tabFilm);
            }
        }

        #endregion


        #region Дерево (treeFolder)

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
            //treeViewFast1.LoadItems(_treeViewColletion.Employees, getId, getParentId, getDisplayName);
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







            TreeNode trv = new TreeNode();

            TreeNode lastNode = null;
            string subPathAgg;

            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;

                    TreeNode[] nodes = trv.Nodes.Find(subPathAgg, true);

                    if (nodes.Length == 0)  // lastNode = (lastNode == null) ? trv.Nodes.Add(subPathAgg, subPath) : lastNode.Nodes.Add(subPathAgg, subPath);
                        if (lastNode == null)
                        {
                            lastNode = trv.Nodes.Add(subPathAgg, subPath);
                        }
                        else
                        {
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                        }
                    else lastNode = nodes[0];
                }
                lastNode = null;
            }

            List<TreeNode> _ListTree = new List<TreeNode>();

            foreach (TreeNode node in trv.Nodes)    // проход по корневым нодам
                _ListTree.Add(node);                // добавление корневой ноды, содержащей все под-ноды


            //treeView.BeginUpdate();
            treeView.Nodes.AddRange(_ListTree.ToArray());
        }

        #endregion


        #region Контекстное меню для дерева (treeFolder)


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e) // Команда при клике по строке
        {
            tabControl2.SelectTab(tabFilm);

            // при клике из другой вкладке выполняет переключение на актуальную вкладку
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

            string FolderName = "";
            FolderName = (Regex.Replace(treeFolder.SelectedNode.Text, @"[0-9]", string.Empty)).Trim('.');
            FolderName = (Regex.Replace(FolderName, @"[^\w\s]", "", RegexOptions.Compiled)).Trim();


            Combine cmNew = new Combine();
            cmNew.media.Name = FolderName;
            cmNew.media.Id = RecordCollection.GetMediaID();
            cmNew.media.Category = CategoryVideo.Series;


            List<Record> filtered = new List<Record>();
            _videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

            filtered = filtered.FindAll(v => v.Path.StartsWith(_videoCollection.Options.Source + Path.DirectorySeparatorChar + treeFolderPath));

            foreach (Record rec in filtered)
                cmNew.recordList.Add(rec);

            foreach (Record rec in filtered)
                _videoCollection.CombineList.Remove(rec.combineLink);

            _videoCollection.CombineList.Add(cmNew);
            //_videoCollection.Save();
            _videoCollection.SaveToFile();

            FormLoad(true);

            PrepareRefresh(FolderName, true);
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
                MediaInfoDownload.GetInfo(cm.media, _videoCollection);

            _videoCollection.Save();
            PrepareRefresh();
        }


        #endregion


        #region обработка информации по одному фильму

        private void UpdateInfo()
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                CardRecordPreview_Clear();
                if (MediaInfoDownload.GetInfo(record.combineLink.media, _videoCollection))
                {
                    _videoCollection.Save();
                    PrepareRefresh();
                    SelectRec();
                }

                //Thr.Thread t = new Thr.Thread(getInfofromWeb);
                //t.Start();
                //while (!t.IsAlive)
                //{ };

            }
        }


        private void btnGetTime_Click(object sender, EventArgs e)
        {
            Record record = GetSelectedRecord();

            string newTimeValue = MediaInfoDownload.GetTime(record);
            if (newTimeValue != "" && newTimeValue != mtbTime.Text)
            {
                mtbTime.Text = newTimeValue;
                Modified();
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
                foreach (Actor _actor in chkActorList.CheckedItems)
                {
                    if (!chkActorSelect.Items.Contains(_actor))
                    {
                        chkActorSelect.Items.Add(_actor);
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

        private void btnRemoveAllGroup_Click(object sender, EventArgs e)
        {

            chkActorSelect.Items.Clear();
            UserModifiedChanged(sender, e);
        }

        private void btnNewActor_Click(object sender, EventArgs e) => NewActor();

        private void NewActor()
        {
            CardActorEdit_Clear();

            dgvTableActors.Enabled = false;     // Блокировка таблицы при изменении панели
            dgvTableActors.ClearSelection();    // Удаление фокуса

            panelEditAct.BringToFront();
        }

        private void CardActorEdit_Clear()
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
        }

        private void CardActorPreview_Clear()
        {
            tbFIOv.Text = "";
            linkBIOv.Text = "";
            tbCountryAv.Text = "";
            maskDateOfBirthV.Text = "";
            maskDateOfDeathV.Mask = "";
            maskDateOfDeathV.Text = "";
            listViewFilmV.Items.Clear();
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

            if (listViewFilm.Items.Count > 0)
            {
                actor.VideoID_Clear();
                foreach (ListViewItem eachItem in listViewFilm.Items)
                {
                    int VideoID = Convert.ToInt32(eachItem.SubItems[2].Text);
                    actor.VideoID_Add(VideoID);
                    _videoCollection.CombineList.FindLast(m => m.media.Id == VideoID).media.ActorListID_Add(actor.id);
                }
            }
            else
            {
                actor.VideoID_Clear();
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

                foreach (DataGridViewRow row in TableRec.Rows)
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


        #region Постеры

        public event ThumbnailImageEventHandler OnImageSizeChanged;
        private ThumbnailController m_Controller { get; set; }
        private ImageViewer m_ActiveImageViewer { get; set; }

        private int ImageSize { get { return (64 * (trackBarSize.Value + 1)); } }

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
            if (InvokeRequired)
            {
                Invoke(new ThumbnailControllerEventHandler(m_Controller_OnEnd), sender, e);
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

            // ошибка из-за того что окно не успевает создаться, т.е. метод CreateHandle ещё не был вызван. Советую перед тем как выполнять Invoke из другого потока и при этом нет точной уверенности что форма уже создана проверять IsHandleCreated.
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    Invoke(m_AddImageDelegate, imageFilename);
                }
                else
                {
                    int size = ImageSize;

                    ImageViewer imageViewer = new ImageViewer();
                    // imageViewer.Dock = DockStyle.Bottom;  // привязка изображения
                    imageViewer.Dock = DockStyle.None;
                    imageViewer.LoadImage(imageFilename, 256, 256);
                    imageViewer.Width = size;
                    imageViewer.Height = size;
                    imageViewer.IsThumbnail = true;

                    imageViewer.MouseClick += new MouseEventHandler(imageViewer_MouseClick);        // При клике по картинке
                    imageViewer.MouseEnter += new EventHandler(imageViewer_Description);            // При наведении появляется описание
                    imageViewer.MouseDoubleClick += new MouseEventHandler(imageViewer_SelectRecord);// При двойном клике по картинке

                    OnImageSizeChanged += new ThumbnailImageEventHandler(imageViewer.ImageSizeChanged);

                    flowLayoutPanelMain.Controls.Add(imageViewer);
                }
            }
        }

        private static string GetPicName(object sender)
        {
            ImageViewer AImage = (ImageViewer)sender;
            string path = AImage.ImageLocation;

            path = path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1);
            path = path.Substring(0, path.IndexOf('.'));
            return path;
        }

        /// <summary>imageViewer.MouseDoubleClick</summary>
        /// <param name="sender">Передается объект imageViewer</param>
        /// <param name="e">Передаются координаты и нажатая кнопка мыши</param>
        private void imageViewer_SelectRecord(object sender, EventArgs e)
        {
            FindAndSelect_Record(GetPicName(sender));
        }

        private void imageViewer_Description(object sender, EventArgs e)    // Вывод описания
        {
            Combine cm = _videoCollection.CombineList.FindLast(v => v.media.Pic == GetPicName(sender));

            if (cm != null)
            {
                //string _desc = "";

                //if (cm.recordList.Count == 1)
                //{
                //    _desc = cm.media.Name + "\n " + cm.recordList[0].mDescription;

                //    ToolTip tT = new ToolTip();
                //    tT.ToolTipTitle = cm.media.Name;
                //    //tT.Show(cm.recordList[0].mDescription, AImage);
                //    tT.Show(processingString(cm.recordList[0].mDescription), AImage);
                //}
                //else
                //{
                //    _desc = cm.media.Name;
                //}

                toolinfo.SetToolTip((ImageViewer)sender, cm.media.Name);
                //toolinfo.SetToolTip(AImage, cm.media.Name);
                //toolinfo.SetToolTip(AImage, _desc);
            }
        }



        private string processingString(string str) // разбиение строки на равные куски
        {
            if (str.Length > 0)
            {
                String[] sublines = str.Split(' ');
                str = null;
                int length = 50;//длина разбиения
                int j = 0;
                for (int i = 0; i < sublines.Count(); i++)
                {
                    if (j + sublines[i].Length < length)
                    {
                        str = str + sublines[i] + " ";
                        j = j + sublines[i].Length;
                    }
                    else
                    {
                        j = 0;
                        str = str + "\r\n";
                        i--;
                    }
                }
            }
            return str;
        }

        /// <summary>Обработка клика по постеру</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (m_ActiveImageViewer != null)
                m_ActiveImageViewer.IsActive = false;

            m_ActiveImageViewer = (ImageViewer)sender;
            m_ActiveImageViewer.IsActive = true;

            if (e.Button == MouseButtons.Right)
                TabMenu.Show(Cursor.Position);
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

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            UpdateService.download();
            UpdateService.unzipFile();
            //Thr.Thread.Sleep(20000);
            UpdateService.compareVersion();
        }

        private void tsHidePanel_CheckedChanged(object sender, EventArgs e)
        {
            if (tsHidePanel.Checked)
            {
                scTabFilm.Panel2Collapsed = true;
                scTabFilm.Panel2.Hide();
            }
            else
            {
                scTabFilm.Panel2Collapsed = false;
                scTabFilm.Panel2.Show();
            }
        }



    }
}
