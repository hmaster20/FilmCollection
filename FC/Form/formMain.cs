using FilmCollection.Properties;
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
using System.Windows.Threading;
using System.Threading.Tasks;

namespace FilmCollection
{
    public partial class MainForm : Form
    {
        #region Общедоступные свойства

        RecordCollection RCollection { get; set; }     // Доступ к коллекции
        // TreeViewColletion _treeViewColletion { get; set; }  // Доступ к коллекции
        FileInfo fsInfo { get; set; } = null;       // для нового файла, добавляемого в базу
        int FindCount { get; set; }                 // Счетчик найденных строк
        public List<int> dgvSelected { get; }  //Индексы найденных строк
        public string FormatOpen { get; }       //Формат открытия файлов
        public List<string> FormatAdd { get; }  //Список форматов файлов
        public string PicsFolder { get; }       //Каталог изображений
        Timer timerCursor { get; }      // Таймер для смены курсора
        public Cursor crEn { get; }     // Курсор английской раскладки
        public Cursor crRu { get; }     // Курсор русской раскладки

        HelpProvider helpProvider { get; set; } // Справка

        //private TreeViewFast.Controls.TreeViewFast treeViewFast1;

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
            //crEn = new Cursor(new MemoryStream(Properties.Resources.cursorEN)); // загрузка курсора
            //crRu = new Cursor(new MemoryStream(Properties.Resources.cursorRU)); // загрузка курсора

            using (var memoryStream = new MemoryStream(Properties.Resources.cursorEN))
                crEn = new Cursor(memoryStream);

            using (var memoryStream = new MemoryStream(Properties.Resources.cursorRU))
                crRu = new Cursor(memoryStream);


            ////Cursor myCursor;
            //using (var memoryStream = new MemoryStream(Properties.Resources.cursorEN))
            //{
            //    crEn = new Cursor(memoryStream);
            //}

            timerCursor = new Timer();      // Таймер для смены курсора
            timerCursor.Enabled = false;
            timerCursor.Interval = 200;
            timerCursor.Tick += new System.EventHandler(this.timerCursor_Tick);
            #endregion

            this.MinimumSize = new Size(1160, 600);  // Установка минимального размера формы

            RCollection = new RecordCollection();      // Доступ к коллекции
            //_treeViewColletion = new TreeViewColletion();   // Доступ к коллекции

            dgvTableActors.AutoGenerateColumns = false; // Отключение автоматического заполнения таблицы
            dgvTableActors.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            dgvTableActors.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки

            TableRec.AutoGenerateColumns = false;    // Отключение автоматического заполнения таблицы
            TableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            TableRec.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки
            TableRec.Columns[7].DefaultCellStyle.SelectionForeColor = Color.Blue;    // цвет текста выбранной строки нужного столбца

            panelView.BringToFront();  // Отображение панели описания

            tscbTypeFilter.SelectedIndex = 0;       // Выбор фильтра по умолчанию
            dgvSelected = new List<int>();          // хранение поисковых индексов

            FormatAdd = RecordOptions.getFormat();  // формат открытия файлов
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

            btnOptions.Visible = RecordOptions.isDebug;
            btnActors.Visible = RecordOptions.isDebug;

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
            //bool cur = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? true : false;

            //if (bbb != cur)
            //{
            //    mainMenuIcon.Cursor = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;
            //    this.Cursor = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;
            //    bbb = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? true : false;
            //}

            // mainMenuIcon.Cursor = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;

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

        #region Параметры
        private void Main_Load(object sender, EventArgs e)
        {
            // загрузка параметров из файла конфигурации
            RecordOptions.ToTray = Settings.Default.ToTray;
            LastNode = Settings.Default.TreeFolderSelect;
            FormLoad(true);
            UpdateStatusMenuButton();
            ReloadPoster();
            LoadFormVisualEffect();
            toolinfo.SetToolTip(btnFileNameEdit, "Разблокировать для переименования файла");// Всплывающая подсказка
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // сохранение параметров в файл конфигурации
            Settings.Default.TreeFolderSelect = GetNode();
            Settings.Default.ToTray = RecordOptions.ToTray;
            Settings.Default.Save();
        }
        #endregion

        private void Main_Close(object sender, FormClosingEventArgs e) => FormClose(e);// Закрытие формы или выход

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized && RecordOptions.ToTray)
            {
                //Hide();
                Tray.BalloonTipTitle = "Программа была спрятана";
                Tray.BalloonTipText = "Обратите внимание что программа была спрятана в трей и продолжит свою работу.";
                Tray.BalloonTipIcon = ToolTipIcon.Info;
                Tray.ShowBalloonTip(2);

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

        public bool FormLoad(bool LoadfromFile = false)
        {
            bool state = false;

            if (File.Exists(RecordOptions.BaseName))    // Если база создана, то загружаем
            {
                RCollection.Clear();

                try
                {
                    RCollection = RecordCollection.Load(LoadfromFile);
                    ZipArc.CreateBackup();
                }
                catch (ApplicationException ex)
                {
                    Logs.Log("При загрузки базы произошла ошибка:", ex);
                    //RecordCollectionMaintenance.BackupBase();
                    return state;
                }

                if (RCollection.CombineList.Count > 0)
                {
                    tssLabel.Text = "Коллекция из " + RCollection.CombineList.Count.ToString() + " элементов";
                    PrepareRefresh();
                    TreeViewCreator();
                    state = true;
                }
                timerLoad.Enabled = true;   // Исключение раннего селекта treeFolder и фильтра dataGridView1 
            }
            return state;
        }

        public void UpdateStatusMenuButton()
        {
            bool state = false;
            switch (tabControlNumber())
            {
                case 0: if (TableRec.Rows.Count > 0) { state = true; }; break;
                case 1: if (dgvTableActors.Rows.Count > 0) { state = true; }; break;
                case 2: if (flowLayoutPanelMain.Controls.Count > 0) { state = true; }; break;
                default: break;
            }

            tsAdd.Enabled = state;
            tsChange.Enabled = state;
            tsRemove.Enabled = state;
            tsFind.Enabled = state;
            tsFindbyName.Enabled = state;
        }

        private void FormClose(FormClosingEventArgs e)    // обработка события Close()
        {
            DialogResult dialog = MessageBox.Show("Вы уверены что хотите выйти из программы?",
                                                  "Завершение работы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialog == DialogResult.OK) Application.ExitThread();
            else if (dialog == DialogResult.Cancel) e.Cancel = true;

            SaveFormVisualEffect();

            //_videoCollection.Save();

            // Если сохранять нечего то выходим
            if (RCollection != null && RCollection.CombineList.Count != 0)
            {
                RCollection.SaveToFile();
            }
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
            RCollection.Options.FormState = this.WindowState.ToString();
            #region Сохранение состояния сплиттеров
            RCollection.Options.scMainSplitter = scMain.SplitterDistance;
            RCollection.Options.scTabFilmSplitter = scTabFilm.SplitterDistance;
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

        #endregion


        #region Главное меню

        private void CreateBase_Click(object sender, EventArgs e) => RCollection.Maintenance.NewBase(this);
        private void UpdateBase_Click(object sender, EventArgs e) => (new System.Threading.Thread(delegate () { RCollection.Maintenance.PreUpdate(this); })).Start();
        private void CleanBase_Click(object sender, EventArgs e) => RCollection.Maintenance.CleanBase(this);

        private void BackupBase_Click(object sender, EventArgs e) => RecordCollectionMaintenance.BackupBase();
        private void RecoveryBase_Click(object sender, EventArgs e) => RecordCollectionMaintenance.RecoveryBase(this);
        private void Exit_Click(object sender, EventArgs e) => Close();

        private void btnOpenCatalogDB_Click(object sender, EventArgs e) => OpenFolderDB();

        private void btnOptions_Click(object sender, EventArgs e)
        {
            using (Options form = new Options(RCollection, this))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //    _videoCollection.Save();
                }
            }
        }

        private void btnOpenReportForm_Click(object sender, EventArgs e)
        {
            using (Report report = new Report(RCollection))
                report.ShowDialog();
        }

        private void btnReindexerForm_Click(object sender, EventArgs e)
        {
            using (formReindexer reindex = new formReindexer())
            {
                if ((reindex.ShowDialog() == DialogResult.OK) && (reindex.status))
                {
                    FormLoad(true);
                }
            }
        }


        private void btnReportCSV_Click(object sender, EventArgs e) => CSVhelper.toCSV(RCollection);

        private void btnExportHTML_Click(object sender, EventArgs e) => Reports.Generator(RCollection);


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

        private static void History()
        {
            using (fromChangeLog formLog = new fromChangeLog())
                formLog.ShowDialog();
        }

        private static void AboutFC()
        {
            using (formAbout about = new formAbout())
                about.ShowDialog();
        }

        private void HelpShow()
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace, "about.htm");
        }

        #endregion


        #region Контекстное меню для DataGridView

        private void cFind_Click(object sender, EventArgs e) => panelFind.BringToFront();

        private void AddRec_Click(object sender, EventArgs e) => Add();

        private void EditRec_Click(object sender, EventArgs e) => Edit();

        private void DeleteRec_Click(object sender, EventArgs e) => Delete();

        private void cOpenFolder_Click(object sender, EventArgs e) => OpenFolder();

        private void UpdateInfo_Click(object sender, EventArgs e) => UpdateInfo();

        private void ShowChart_Click(object sender, EventArgs e) => ShowCharts();

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
                case 0: break;// Фильмы

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
            //TreeNode dragedNode = new TreeNode();

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
                        string dirPath = "";
                        //string dirPath = Path.Combine(RCollection.Options.Source, destinationNode.FullPath);

                        if (File.Exists(Path.Combine(record.Path, record.FileName)))
                            if (Directory.Exists(dirPath))
                                File.Move(Path.Combine(record.Path, record.FileName), Path.Combine(dirPath, record.FileName));

                        record.DirName = destinationNode.Text;
                        record.Path = dirPath;

                        RCollection.Save();
                        PrepareRefresh();
                    }
                }
                catch (ApplicationException ex) { Logs.Log("Произошла ошибка при перемещении Drag&Drop:", ex); }
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
        //private bool IsControlAtFrontUniversal(Control control)
        //{
        //    while (control.Parent != null)
        //    {
        //        if (control.Parent.Controls.GetChildIndex(control) == 0)
        //        {
        //            control = control.Parent;
        //            if (control.Parent == null)
        //                return true;
        //        }
        //        else
        //            return false;
        //    }
        //    return false;
        //}




        private void Table_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // Порядок 1
        {
            Debug.WriteLine(" - CellMouseDown");

            if (IsControlAtFront(panelFind))    // если отображается панель поиска, то пред просмотр только при двойном клике
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                    SelectRec();//SelectRecord_Info(sender, e);
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
            // организовано выделение правой кнопкой мыши
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                SelectRec(); // SelectRecord_Info(sender, e);
            }
        }

        private void TableLeftSelect(object sender, DataGridViewCellMouseEventArgs e)
        {
            // организовано выделение левой кнопкой мыши
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Left)
            {
                //var senderGrid = (DataGridView)sender;

                //var dataGridView = (sender as DataGridView);
                //DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                //if (!row.Selected)
                //{
                //    row.DataGridView.ClearSelection();
                //    row.Selected = true;
                //}

                //DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[0];
                //if (!cell.Selected)
                //{
                //    cell.DataGridView.ClearSelection();
                //    cell.DataGridView.CurrentCell = cell;
                //    cell.Selected = true;
                //}

                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
                SelectRec(); //SelectRecord_Info(sender, e);
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
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                Edit();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Insert)
            {
                Add();
                e.Handled = true;
            }
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

        private bool isTabFilm()
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
                return true;
            else
                return false;
        }

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)// проверка возможности переключения TabControl
        {
            UpdateStatusMenuButton();
            // e.Cancel = !CheckAccess();
            e.Cancel = tabControlisBlock;
        }

        bool tabControlisBlock { get; set; } = false;   // панель разблокирована

        //private bool CheckAccess()
        //{
        //    return true;

        //    //throw new NotImplementedException();
        //    // return true;//если доступ разрешен
        //    // return false; //если доступ запрещен
        //}

        //private void dgvTableRec_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    var formatter = e.CellStyle.FormatProvider as ICustomFormatter;
        //    if (formatter != null)
        //    {
        //        e.Value = formatter.Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
        //        e.FormattingApplied = true;
        //    }
        //}

        #endregion


        #region Обработка DataGridView


        /// <summary>Добавление новой записи</summary>
        private void Add()
        {
            if (isTabFilm())
                NewRecord();
            else
                NewActor();
        }

        /// <summary>Редактирование записи</summary>
        private void Edit()
        {
            if (isTabFilm()) panelEdit.BringToFront();
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
                                                  "Удаление записи", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                record.combineLink.recordList.Remove(record);
                RCollection.Save();
                FormLoad();
            }
        }


        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}
        //private void MainForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        this.Close();
        //    }
        //}



        private void DeleteActor()
        {
            Actor act = GetSelectedActor();
            if (act != null)
            {
                DialogResult dialog = MessageBox.Show("Вы хотите удалить запись \"" + act.FIO + "\" ?",
                                      "Удаление записи", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    RCollection.Remove(act);
                    RCollection.Save();
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
                                                      "Удаление записи", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        ReloadPoster();    // перезагрузка постеров  
                    }
                }
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

        //private bool checkNode()
        //{
        //    string nodeName = (GetNode());

        //    if (!string.IsNullOrEmpty(nodeName) && nodeName != "Фильмотека")
        //        return true;
        //    return false;
        //}

        public void PrepareRefresh(bool ShowAllFiles = false, int column = -1)
        {
            List<Record> filtered = new List<Record>();
            RCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

            filtered = filtered.FindAll(v => v.Visible == !cbIsVisible.Checked);    // фильтрация по видимости, т.е. фильм не удален
            filtered = (tscbTypeFilter.SelectedIndex != 0)                          // фильтрация по типу: Фильм, Мультфильм..
                ? filtered.FindAll(v => v.mCategory == ((CategoryVideo_Rus)(tscbTypeFilter.SelectedIndex - 1)).ToString())
                : filtered;


            if (getLevelSelected() != null)
            {
                var rootNode = FindRootNode(treeFolder.SelectedNode);
                int id = RCollection.SourceList.First(x => x.Source == rootNode.Text).Id;

                if (getLevelSelected() == 0)
                {
                    filtered = filtered.FindAll(v => v.SourceID == id);
                }

                if (getLevelSelected() != 0)
                {
                    if (!ShowAllFiles)
                    {
                        filtered = filtered.FindAll(v => (RCollection.SourceList.FindLast(x => x.Id == id).Source + v.Path) == GetNode());
                    }
                    else
                    {
                        filtered = filtered.FindAll(v => (RCollection.SourceList.FindLast(x => x.Id == id).Source + v.Path).StartsWith(GetNode()));
                    }
                }
            }








            if (isTabFilm())
            {
                if (column > -1)
                    SortRecord(filtered, column);
                else
                    SortRecord(filtered, tscbSort.SelectedIndex);

                PrepareActor(-1);
            }
            else
            {
                if (column > -1) PrepareActor(column);
                else PrepareActor(tsActSort.SelectedIndex);
            }
            // продумать обновление актеров

            RefreshTable(filtered);
        }

        private int? getLevelSelected()
        {
            int? level = null;
            if (treeFolder != null && treeFolder.Nodes.Count > 0)
            {
                if (treeFolder.SelectedNode != null && treeFolder.SelectedNode.IsSelected)
                {
                    level = treeFolder.SelectedNode.Level;
                    Debug.Print("Level: " + treeFolder.SelectedNode.Level.ToString());
                }
            }
            return level;
        }

        private TreeNode FindRootNode(TreeNode treeNode)
        {
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            return treeNode;
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
            List<Actor> filteredAct = new List<Actor>(RCollection.ActorList);

            if (tsActCountryFilter.SelectedIndex > -1)
                filteredAct = filteredAct.FindAll(a => a.Country == (Country_Rus)tsActCountryFilter.SelectedIndex);

            SortActor(filteredAct, switch_sort);

            dgvTableActors.DataSource = filteredAct;

            // список актеров
            chkActorList.Items.Clear();

            foreach (Actor item in RCollection.ActorList)
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
            catch (ApplicationException ex) { Logs.Log("Произошла ошибка при обновлении данных в таблице:", ex); }
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
        private void SelectRec()
        {
            Record record = GetSelectedRecord();

            panelView.BringToFront();
            ucView.update(record, this);

            if (record != null)
            {
                // Панель редактирования
                // Media
                cbNameMedia.Text = record.combineLink.media.Name;
                mtbYear.Text = Convert.ToString(record.combineLink.media.Year);
                rtDescription.Text = record.combineLink.media.Description;
                cBoxTypeVideo.SelectedIndex = ((int)record.combineLink.media.Category);
                cBoxGenre.SelectedIndex = ((int)record.combineLink.media.GenreVideo);
                cBoxCountry.SelectedIndex = ((int)record.combineLink.media.Country);
                chkActorSelect.Items.Clear();
                if (record.combineLink.media.ActorListID != null)
                    foreach (int ListID in record.combineLink.media.ActorListID)
                        if (RCollection.ActorList.Exists(act => act.id == ListID))
                            chkActorSelect.Items.Add(RCollection.ActorList.FindLast(act => act.id == ListID));

                // Record
                tbNameRecord.Text = record.Name;
                mtbTime.Text = record.TimeVideoSpan.ToString();
                tbFileName.Text = record.FileName;
                tbFilePath.Text = (record.Path + Path.DirectorySeparatorChar + record.FileName);
            }
        }

        private Record GetSelectedRecord()  // получение выбранной записи в dgvTable
        {
            DataGridView dgv = TableRec;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                Record record = null;
                if (dgv.SelectedRows[0].DataBoundItem is Record) record = dgv.SelectedRows[0].DataBoundItem as Record;
                //if (dgv.CurrentRow.DataBoundItem is Record) record = dgv.CurrentRow.DataBoundItem as Record;
                if (record != null) return record;
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
                        foreach (Combine com in RCollection.CombineList.FindAll(m => m.media.Id == recID))
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
                        foreach (Combine com in RCollection.CombineList.FindAll(m => m.media.Id == recID))
                            listViewFilm.Items.Add(new ListViewItem(
                                new string[] { com.media.Name, com.media.Year.ToString(), com.media.Id.ToString() }));
                }
                catch (ApplicationException ex) { Logs.Log("Произошла ошибка при отображении данных выбранной строки:", ex); }
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
            CardRecordPreview_Clear();
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
            catch (ApplicationException ex)
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
            catch (ApplicationException ex)
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

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                //fileDialog.InitialDirectory = RCollection.Options.Source;
                //fileDialog.InitialDirectory = Path.Combine(RCollection.Options.Source, GetNode());
                fileDialog.Filter = FormatOpen;
                fileDialog.Title = "Выберите файл:";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    NameBlock();

                    FileInfo newFile = new FileInfo(fileDialog.FileName); // получаем доступ к файлу
                    //if (!newFile.DirectoryName.StartsWith(RCollection.Options.Source))
                    //{
                    //    MessageBox.Show("Файл не принадлежит источнику коллекции " + RCollection.Options.Source);
                    //    return; // Выходим из метода
                    //}

                    CardRecordEdit_Clear();

                    // Заполняем поля
                    cbNameMedia.Text = newFile.Name.Remove(newFile.Name.LastIndexOf(newFile.Extension), newFile.Extension.Length);
                    tbNameRecord.Text = cbNameMedia.Text;
                    tbFileName.Text = newFile.Name;
                    mtbYear.Text = DateTime.Now.Year.ToString();

                    foreach (Actor item in RCollection.ActorList)
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
        }

        private void CardRecordEdit_Clear()
        {
            cbNameMedia.Text = "";
            tbNameRecord.Text = "";
            tbFileName.Text = "";
            rtDescription.Text = "";
            mtbYear.Text = "";
            cBoxGenre.SelectedIndex = -1;
            cBoxTypeVideo.SelectedIndex = -1;
            cBoxCountry.SelectedIndex = -1;
            chkActorList.Items.Clear();
        }

        /// <summary>Очистка панели просмотра</summary>
        private void CardRecordPreview_Clear()
        {
            ucView.Clear();
        }

        private void SaveRecord()
        {
            Combine cm = null;
            Record record = null;

            if (fsInfo != null) // Создание нового фильма
            {
                cm = GetMedia();

                //fsInfo.DirectoryName.Contains(x)
                //int id = RCollection.SourceList.First(x => fsInfo.DirectoryName.Contains(x.Source)).Id;
                if (RCollection.SourceList.Exists(x => fsInfo.DirectoryName.Contains(x.Source)))
                {
                    int id = RCollection.SourceList.First(x => fsInfo.DirectoryName.Contains(x.Source)).Id;
                }
                return;
                //record = RecordCollectionMaintenance.CreateRecord(fsInfo,);
            }
            else // редактирование имеющегося фильма
            {
                record = GetSelectedRecord();
                if (record != null) cm = record.combineLink;
            }

            SaveToMedia(cm);

            record.Name = tbNameRecord.Text;
            try { record.TimeVideoSpan = TimeSpan.Parse(mtbTime.Text); }
            catch (ApplicationException Ex)
            {
                MessageBox.Show(Ex.Message);
                record.TimeVideoSpan = TimeSpan.Parse("0");
            }

            if (record.FileName != tbFileName.Text)
            {
                if (File.Exists(record.Path + Path.DirectorySeparatorChar + record.FileName))
                {
                    File.Move(record.Path + Path.DirectorySeparatorChar + record.FileName,
                              record.Path + Path.DirectorySeparatorChar + tbFileName.Text);
                    record.FileName = tbFileName.Text;
                    record.Extension = Path.GetExtension(record.Path + Path.DirectorySeparatorChar + tbFileName.Text).Trim('.');
                }
                else
                {
                    MessageBox.Show("Файл " + record.FileName + " не найден!");
                }
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
                    RCollection.Add(cm);
                }
            }

            RCollection.Save();

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
                if (RCollection.CombineList.Exists(m => m.media.Name == cbNameMedia.SelectedItem.ToString()))
                    cm = RCollection.CombineList.FindLast(m => m.media.Name == cbNameMedia.SelectedItem.ToString());
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
            cm.media.Description = rtDescription.Text;
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
                if (cm.media.ActorListID.Count > 0)
                {
                    foreach (int actorID in cm.media.ActorListID)
                    {
                        foreach (Actor act in RCollection.ActorList)
                        {
                            if (act.id == actorID)
                            {
                                act.VideoID.Remove(cm.media.Id);
                            }
                        }

                    }
                    cm.media.ActorListID_Clear();
                    cm.media.ActorList.Clear();
                }
                else
                {
                    foreach (Actor act in RCollection.ActorList)
                    {
                        foreach (int filmID in act.VideoID)
                        {
                            if (filmID == cm.media.Id)
                            {
                                act.VideoID.Remove(cm.media.Id);
                                break;
                            }
                        }
                    }
                    cm.media.ActorList.Clear();
                }

                //List<int> originalActorListID = new List<int>(cm.media.ActorListID);


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

                foreach (var item in RCollection.CombineList) // создаем список фильмов для функции авто поиска
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
                if (RCollection.CombineList.Exists(m => m.media.Name == cbNameMedia.SelectedItem.ToString()))
                    cm = RCollection.CombineList.FindLast(m => m.media.Name == cbNameMedia.SelectedItem.ToString());
            }

            if (cm != null)
            {
                mtbYear.Text = Convert.ToString(cm.media.Year);
                rtDescription.Text = cm.media.Description;
                cBoxTypeVideo.SelectedIndex = ((int)cm.media.Category);
                cBoxGenre.SelectedIndex = ((int)cm.media.GenreVideo);
                cBoxCountry.SelectedIndex = ((int)cm.media.Country);
                chkActorSelect.Items.Clear();
                if (cm.media.ActorListID != null)
                    foreach (int ListID in cm.media.ActorListID)
                        if (RCollection.ActorList.Exists(act => act.id == ListID))
                            chkActorSelect.Items.Add(RCollection.ActorList.FindLast(act => act.id == ListID));
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
            rtDescription.Modified = false; // возвращаем назад статус изменения поля

            treeFolder.Enabled = true;      // Разблокировка дерева
            TableRec.Enabled = true;     // Разблокировка таблицы
            TableRec.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

            PrepareRefresh();  // перезагрузка таблицы

            FileNameEnabled();

            panelEdit_Button_Lock();

            panelView.BringToFront();// показать панель сведений
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

        //private void Play_Click(object sender, EventArgs e)  // запуск файла
        //{
        //    PlayRecord();
        //}

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

        public void SelectActor(string actor)
        {
            tabControl2.SelectTab(tabActors);

            if (actor != null)
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in dgvTableActors.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(actor))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                if (rowIndex != -1)
                {
                    dgvTableActors.Rows[rowIndex].Selected = true;
                    dgvTableActors.FirstDisplayedScrollingRowIndex = rowIndex;// прокручиваем
                }
            }
        }



        private void listViewFilmV_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(listViewFilmV.SelectedItems[0].SubItems[0].Text))
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

        private void TreeViewCreator()
        {
            treeFolder.BeginUpdate();
            treeFolder.Nodes.Clear();
            treeFolder.Nodes.AddRange(new TreeBuilder(RCollection).TreeViewCreator());
            treeFolder.ShowNodeToolTips = true;
            treeFolder.EndUpdate();
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
                RCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

                //filtered = filtered.FindAll(v => v.Path.StartsWith(RCollection.Options.Source + Path.DirectorySeparatorChar + treeFolder.SelectedNode.FullPath));

                foreach (Record rec in filtered)
                    cmNew.recordList.Add(rec);

                foreach (Record rec in filtered)
                    RCollection.CombineList.Remove(rec.combineLink);

                RCollection.CombineList.Add(cmNew);
                RCollection.Save();

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
            RCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

            //filtered = filtered.FindAll(v => v.Path.StartsWith(RCollection.Options.Source + Path.DirectorySeparatorChar + treeFolderPath));

            foreach (Record rec in filtered)
                cmNew.recordList.Add(rec);

            foreach (Record rec in filtered)
                RCollection.CombineList.Remove(rec.combineLink);

            foreach (Record rec in filtered)
            {
                rec.combineLink = cmNew;
            }

            RCollection.CombineList.Add(cmNew);
            //_videoCollection.Save();
            RCollection.Save();
            RCollection.SaveToFile();

            FormLoad(true);

            PrepareRefresh(FolderName, true);
        }

        private void UpdateCatalogInfo_Click(object sender, EventArgs e)
        {
            var cmList = (from cm in RCollection.CombineList
                          let recList = cm.recordList
                          from rec in recList
                              //where rec.Path.StartsWith(RCollection.Options.Source + Path.DirectorySeparatorChar + GetNode())
                          where rec.Path.StartsWith(RCollection.SourceList.First(x => x.Id == rec.SourceID).Source + Path.DirectorySeparatorChar + GetNode())
                          where rec.Visible == true
                          select rec.combineLink);    //.Distinct<Combine>();

            //foreach (Combine cm in cmList.Distinct().ToList())
            //    DownloadDetails.GetInfo(cm.media, _videoCollection);

            foreach (Combine cm in cmList.Distinct().ToList())
                foreach (Record rec in cm.recordList)
                    (new System.Threading.Thread(delegate () { DownloadDetails.GetInfo(rec, this); })).Start();
            //DownloadDetails.GetInfo(rec);
            //DownloadDetails.GetInfo(rec, _videoCollection);

            RCollection.Save();
            PrepareRefresh();
        }


        #endregion


        #region отображение схемы по одному фильму

        private void ShowCharts()
        {
            Record record = GetSelectedRecord();
            if (record != null)
            {
                tabControl2.SelectTab(tabDiagram);
                ucDiagr.update(record, this);

                // panelScheme.BringToFront();
                // ucScheme.update(record);
            }
        }

        #endregion


        #region обработка информации по одному фильму

        private void UpdateInfo() => (new System.Threading.Thread(delegate () { DownloadDetails.GetInfo(GetSelectedRecord(), this); })).Start();

        internal void AfterUpdateRefresh(Record record)
        {
            CardRecordPreview_Clear();
            RCollection.Save();
            RCollection.SaveToFile();
            PrepareRefresh();
            SelectRecord(TableRec, record);
            SelectRec();
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            string newTimeValue = FileDetails.GetTime(GetSelectedRecord());

            if (!string.IsNullOrEmpty(newTimeValue) && newTimeValue != mtbTime.Text)
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
            Actor actor = null;
            Actor act = GetSelectedActor();
            actor = (act == null) ? new Actor() : act;

            //if (!string.IsNullOrWhiteSpace(textbox.text))
            //return String.IsNullOrEmpty(value) || value.Trim().Length == 0;

            if (tbFIO.Text.Trim().Length == 0)
            {
                tbFIO.BackColor = Color.MistyRose;
                return;
            }

            actor.FIO = tbFIO.Text;

            if (act == null)
                foreach (Actor _act in RCollection.ActorList)
                {
                    if (_act.Equals(actor))
                    {
                        MessageBox.Show("\"" + actor.FIO + "\" уже есть в списке актеров!");
                        return;
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
                    RCollection.CombineList.FindLast(m => m.media.Id == VideoID).media.ActorListID_Add(actor.id);
                }
            }
            else
            {
                actor.VideoID_Clear();
            }


            if (act == null)
            {
                RCollection.Add(actor);
                RCollection.Save();
            }
            else
            {
                RCollection.Save();
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
            catch (ApplicationException ex) { MessageBox.Show(ex.Message); }
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

        private void ReloadPoster()    // сканирование указанного каталога
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
            try
            {
                // thread safe
                // ошибка из-за того что окно не успевает создаться, т.е. метод CreateHandle ещё не был вызван. Советую перед тем как выполнять Invoke из другого потока и при этом нет точной уверенности что форма уже создана проверять IsHandleCreated.
                if (IsHandleCreated)
                {
                    if (InvokeRequired)
                    {
                        if (m_AddImageDelegate != null)
                        {
                            if (this != null)
                            {
                                Invoke(m_AddImageDelegate, imageFilename);
                            }
                        }
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
            catch (ApplicationException ex)
            {
                Logs.Log("При обработке постеров возникла ошибка в методе AddImage(string imageFilename):", ex);
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
            Combine cm = RCollection.CombineList.FindLast(v => v.media.Pic == GetPicName(sender));

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



        //private string processingString(string str) // разбиение строки на равные куски
        //{
        //    if (str.Length > 0)
        //    {
        //        String[] sublines = str.Split(' ');
        //        str = null;
        //        int length = 50;//длина разбиения
        //        int j = 0;
        //        for (int i = 0; i < sublines.Count(); i++)
        //        {
        //            if (j + sublines[i].Length < length)
        //            {
        //                str = str + sublines[i] + " ";
        //                j = j + sublines[i].Length;
        //            }
        //            else
        //            {
        //                j = 0;
        //                str = str + "\r\n";
        //                i--;
        //            }
        //        }
        //    }
        //    return str;
        //}

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
            if (tsHidePanel.Checked && tabControlNumber() == 0)
            {
                scTabFilm.Panel2Collapsed = true;
                scTabFilm.Panel2.Hide();
            }
            else
            {
                scTabFilm.Panel2Collapsed = false;
                scTabFilm.Panel2.Show();
            }

            if (tsHidePanel.Checked && tabControlNumber() == 1)
            {
                scTabActors.Panel2Collapsed = true;
                scTabActors.Panel2.Hide();
            }
            else
            {
                scTabActors.Panel2Collapsed = false;
                scTabActors.Panel2.Show();
            }
        }

        private void cClearMetaData_Click(object sender, EventArgs e)
        {

        }

        private void dgvTableActors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
                e.Handled = true;
            }
        }

        private void TableRec_SelectionChanged(object sender, EventArgs e)
        {
            Debug.Print("TableRec_SelectionChanged");

            Record record = new Record();
            if (TableRec.SelectedRows.Count > 0 && TableRec.SelectedRows[0].DataBoundItem is Record)
            {
                record = TableRec.SelectedRows[0].DataBoundItem as Record;
                Debug.Print(record.mName);
            }
            else
            {
                Debug.Print("record = null");
            }

        }

        private void cOpenCurrentFolder_Click(object sender, EventArgs e)
        {
            string dirPath = treeFolder.SelectedNode.FullPath;
            if (Directory.Exists(dirPath))
            {
                Process.Start(@dirPath);
            }
        }

        //private void MainForm_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        //{
        //    //this.Cursor = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;
        //    //tsFindbyName.
        //    mainMenuIcon.Cursor = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;
        //    //HideCaret(mainMenuIcon.Handle);
        //    //Cursor.Current = (InputLanguages.GetKeyboardLayoutId() == "ENU") ? crEn : crRu;
        //}


        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //static extern bool HideCaret(IntPtr hWnd);


        //private void timerCursorEnabled()
        //{
        //    this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.MainForm_InputLanguageChanged);
        //}

        //private void timerCursorDisabled()
        //{
        //    this.InputLanguageChanged -= new System.Windows.Forms.InputLanguageChangedEventHandler(this.MainForm_InputLanguageChanged);
        //    this.Cursor = Cursors.Arrow;
        //}
    }
}