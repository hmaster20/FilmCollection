using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Xml;



namespace FilmCollection
{
    public partial class MainForm : Form
    {
        RecordCollection _videoCollection = new RecordCollection();
        Record record = null;
        string NodeName = "";       // хранение полного пути узла из TreeFolder
        string SourceValue = "";


        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;  // Отключение автоматического заполнения таблицы

            //string rootPath = Console.ReadLine(); var dir = new DirectoryInfo(rootPath);
            //string samplePath = Application.StartupPath + @"\\Dirs_v6.xml";
            //DisplayTreeView(samplePath);
        }


        private void btnScanDir_Click(object sender, EventArgs e)       // Автоматическое построение базы
        {
            CreateBase();
        }

        private void CreateBase()       // Автоматическое построение базы
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp");
            _videoCollection.Source = directory.FullName;
            _videoCollection.Save();
            //int dlinna = directory.FullName.Length;

            #region Формирование списка файлов в базе XML для использования при дальнейшей проверке. Нужно ли их добавлять.
            List<string> FileNameList = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load("VideoList.xml");

            XmlNodeList nodeList = doc.GetElementsByTagName("FileName");    // передается название файла

            foreach (XmlNode node in nodeList)
            {
                FileNameList.Add(node.ChildNodes[0].Value);
            }
            #endregion


            if (directory.Exists)
            {
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
                        _videoCollection.Save();
                    }
                }
            }
            _videoCollection = RecordCollection.Load();
            RefreshTables();
        }


        private void RefreshTables()    // Обновление таблицы путем фильтрации элементов по полю Path
        {
            List<Record> filtered = _videoCollection.VideoList;
            if (NodeName != "")
            {
                filtered = filtered.FindAll(v => v.Path == SourceValue + Path.DirectorySeparatorChar + NodeName);
                dataGridView1.DataSource = filtered;
            }
            else
            {
                dataGridView1.DataSource = filtered;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)  // Загрузка базы
        {
            _videoCollection = RecordCollection.Load();
            RefreshTables();
        }



        private void btnTree_Click(object sender, EventArgs e)  // Построение дерева
        {
            CreateTree();
        }


        private void CreateTree()  // Построение дерева
        {
             XmlDocument doc = new XmlDocument();
            doc.Load(RecordCollection.BaseName);                            // Получения файла базы

            #region Поиск атрибута source из файла XML, содержащего путь к папке с видео
            foreach (XmlNode xmlNode in doc.ChildNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)                // Проверка ноды, что это элемент
                {
                    foreach (XmlAttribute xmlattribute in xmlNode.Attributes)
                    {
                        if (xmlattribute.Name == "source") SourceValue = xmlattribute.Value; // Поиск атрибута "source"
                        if ((SourceValue != null) && (SourceValue.Length != 0)) break;
                    }
                }
            }
            #endregion

            int SourceLength = SourceValue.Length; // Получение длинны пути

            XmlNodeList nodeList = doc.GetElementsByTagName("Path");        // Чтение элементов "Path"

            treeFolder.Nodes.Clear();                                       // Очистка дерева
            var paths = new List<string>();                                 // Создание списка
            //paths.Add("Фильмотека");

            foreach (XmlNode node in nodeList)                              // Заполнение списка для формирования дерева
            {
                string temp = "";
                if (-1 != node.ChildNodes[0].Value.Substring(SourceLength).IndexOf(Path.DirectorySeparatorChar))
                {
                    temp = node.ChildNodes[0].Value.Substring(SourceLength + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                    if (temp.Length != 0) paths.Add(node.ChildNodes[0].Value.Substring(SourceLength + 1));
                }
            }
            PopulateTreeView(treeFolder, paths, Path.DirectorySeparatorChar);
            //treeFolder.AfterSelect += treeFolder_AfterSelect;
        }



        private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)  // Построение дерева
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
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
            treeView.ExpandAll();           // развернуть дерево
        }

        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e)                                 // Команда при клике по строке
        {
            NodeName = e.Node.FullPath;         // получение полного пути ноды
            RefreshTables();
        }







        private void cMenuChange_Click(object sender, EventArgs e)
        {

            //EditForm form = new EditForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    //_videoCollection.Add(form.Record);
            //    //_videoCollection.Save();
            //    RefreshTables();
            //}
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                RefreshTables();
            }


        }



        private Record GetSelectedRecord()
        {
            DataGridView dgv = dataGridView1;
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



        private void cAdd_Click(object sender, EventArgs e)     // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Add(form.rec);
                _videoCollection.Save();
                RefreshTables();
            }
        }

        Timer t = new Timer();
        private void MainForm_Load(object sender, EventArgs e)
        {
            _videoCollection = RecordCollection.Load();
            CreateTree();
            RefreshTables();

            // костыль для исключения селекта treeFolder и фильтра dataGridView1
            t.Interval = 100;
            t.Tick += T_Tick;
            t.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Enabled = false;
            treeFolder.SelectedNode = null;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }



        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)    // проверка выбора строки перед открытием меню
        {
            contextMenu.Items[4].Enabled = false;
            DataGridView dgv = dataGridView1;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                contextMenu.Items[4].Enabled = true;
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при правом клике выполняется выбор строки и открывается меню
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.Focus();
            }
        }

        private void cResetTreeFilter_Click(object sender, EventArgs e)     // Сброс фильтра по дереву
        {
            NodeName = ""; 
            RefreshTables();
        }






















        public void ChooseFolder()
        {
            //if (browserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    //textBox1.Text = foldBrowsDialog.SelectedPath;
            //}



            //// Show the FolderBrowserDialog.
            //DialogResult result = browserDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    folderName = browserDialog.SelectedPath;
            //    if (!fileOpened)
            //    {
            //        // No file is opened, bring up openFileDialog in selected path.
            //        openFileDialog1.InitialDirectory = folderName;
            //        openFileDialog1.FileName = null;
            //        openMenuItem.PerformClick();
            //    }
            //}


            //if (browserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    //textBox1.Text = browserDialog.SelectedPath;
          
            //}

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browserDialog.Description = "Выбор папки!!!!!!!!!";
            DialogResult dialogresult = browserDialog.ShowDialog();
            //Надпись выше окна контрола

            string folderName = "";
            if (dialogresult == DialogResult.OK)
            {
                //Извлечение имени папки
                folderName = browserDialog.SelectedPath;
                MessageBox.Show(folderName);
            }
        }
    }
}



