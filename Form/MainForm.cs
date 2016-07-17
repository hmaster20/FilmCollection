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
        //string NodeName = "";       // хранение полного пути узла из TreeFolder


        public MainForm()
        {
            InitializeComponent();
            dgvTable.AutoGenerateColumns = false;  // Отключение автоматического заполнения таблицы
        }

        private void MainForm_Load(object sender, EventArgs e)      // Загрузка главное формы
        {
            LoadForm();
        }

        private void LoadForm()
        {
            if (File.Exists(RecordCollection.BaseName)) // Если база создана, то выполняем
            {
                _videoCollection = RecordCollection.Load();
                if (_videoCollection.VideoList.Count > 0)
                {
                    RefreshTables("");
                    CreateTree();
                }
                timerLoad.Enabled = true;   // костыль для исключения селекта treeFolder и фильтра dataGridView1
            }
        }

        private void T_Tick(object sender, EventArgs e)             // таймер для селекта MainForm_Load
        {
            timerLoad.Enabled = false;
            treeFolder.SelectedNode = null;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }



        #region Главное меню

        private void btnCreateBase_Click(object sender, EventArgs e)
        {
            CreateBase();
        }

        private void btnUpdateBase_Click(object sender, EventArgs e)
        {
            UpdateBase();
        }

        private void btnLoad_Click(object sender, EventArgs e)  // Загрузка базы
        {
            _videoCollection = RecordCollection.Load();
            RefreshTables("");
        }

        private void btnBackupBase_Click(object sender, EventArgs e)    // Создание копии базы
        {
            BackupBase();
        }

        #endregion


        private void CreateBase()       // Создание файла базы
        {
            if (File.Exists(RecordCollection.BaseName))
            {
                DialogResult result = MessageBox.Show("Текущая база будет удалена", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.WriteAllText(RecordCollection.BaseName, string.Empty);
                    _videoCollection.Clear();
                    treeFolder.Nodes.Clear();
                    //NodeName = "";
                    RefreshTables("");
                    //MessageBox.Show("Очистка выполнена!");

                    DialogResult dialogresult = browserDialog.ShowDialog();

                    string folderName = "";

                    if (dialogresult == DialogResult.OK)
                    {
                        folderName = browserDialog.SelectedPath;                //Извлечение имени папки

                        DirectoryInfo directory = new DirectoryInfo(folderName);

                        if (directory.Exists)
                        {
                            _videoCollection.Source = directory.FullName;   // Сохранение каталога фильмов
                            char[] charsToTrim = { '.' };
                            foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
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
                        _videoCollection.Save();
                        LoadForm();
                    }


                }

            }

        }


        private void UpdateBase()       // Добавить обновление базы
        {
            DirectoryInfo directory = new DirectoryInfo(_videoCollection.Source);

            #region Формирование списка файлов в базе XML для использования при дальнейшей проверке. Нужно ли их добавлять.
            List<string> FileNameList = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(RecordCollection.BaseName);

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
                    }
                }
            }
            _videoCollection.Save();
            LoadForm();
        }

        private void BackupBase()       // Резервная копия базы
        {
            if (File.Exists(RecordCollection.BaseName))
            {
                try
                {
                    File.Copy(RecordCollection.BaseName, Path.GetFileNameWithoutExtension(RecordCollection.BaseName)
                        + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss")
                        + Path.GetExtension(RecordCollection.BaseName));
                    MessageBox.Show("Создана резервная копия!");
                }
                catch (IOException copyError)
                {
                    //Console.WriteLine(copyError.Message);
                    MessageBox.Show(copyError.Message);
                }
            }
        }



        private void RefreshTables(string nodeName)    // Обновление таблицы путем фильтрации элементов по полю Path
        {

            List<Record> filtered = _videoCollection.VideoList;
            //if (NodeName != "")
            if (nodeName != "")
            {
                //filtered = filtered.FindAll(v => v.Path == _videoCollection.Source + Path.DirectorySeparatorChar + NodeName);
                filtered = filtered.FindAll(v => v.Path == _videoCollection.Source + Path.DirectorySeparatorChar + nodeName);

                dgvTable.DataSource = filtered;
            }
            else
            {
                dgvTable.DataSource = filtered;
            }
        }



        private void CreateTree()  // Построение дерева
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(RecordCollection.BaseName);                            // Получения файла базы

            //#region Поиск атрибута source из файла XML, содержащего путь к папке с видео
            //foreach (XmlNode xmlNode in doc.ChildNodes)
            //{
            //    if (xmlNode.NodeType == XmlNodeType.Element)                // Проверка ноды, что это элемент
            //    {
            //        foreach (XmlAttribute xmlattribute in xmlNode.Attributes)
            //        {
            //            //if (xmlattribute.Name == "source") SourceValue = xmlattribute.Value; // Поиск атрибута "source"
            //            //if ((SourceValue != null) && (SourceValue.Length != 0)) break;
            //            if (xmlattribute.Name == "source") SourceValue = xmlattribute.Value; // Поиск атрибута "source"
            //            if ((SourceValue != null) && (SourceValue.Length != 0)) break;

            //        }
            //    }
            //}
            //#endregion

            //int SourceLength = SourceValue.Length; // Получение длинны пути
            int SourceLength = _videoCollection.Source.Length; // Получение длинны пути
            //_videoCollection.Source

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
            //treeView.ExpandAll();           // развернуть дерево
        }

        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e)                                 // Команда при клике по строке
        {
            RefreshTables(e.Node.FullPath);     // обновление на основе полученной ноды
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



        #region Контекстное меню для DataGridView

        private void cResetTreeFilter_Click(object sender, EventArgs e)     // Сброс фильтра по дереву
        {
            //NodeName = "";
            RefreshTables("");
        }

        private void cAdd_Click(object sender, EventArgs e)                 // добавление новой записи
        {
            EditForm form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Add(form.rec);
                _videoCollection.Save();
                RefreshTables("");
            }
        }

        private void cMenuChange_Click(object sender, EventArgs e)          // Изменить запись
        {
            Record record = GetSelectedRecord();
            if (new EditForm(record).ShowDialog() == DialogResult.OK)
            {
                _videoCollection.Save();
                RefreshTables("");      //Должно быть обновление вместо фильтра
            }
        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)    // Загрузка меню и проверка селекта строки перед открытием меню
        {
            contextMenu.Items[4].Enabled = false;
            DataGridView dgv = dgvTable;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                contextMenu.Items[4].Enabled = true;
            }
        }

        #endregion


        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // при правом клике выполняется выбор строки и открывается меню
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvTable.CurrentCell = dgvTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvTable.Rows[e.RowIndex].Selected = true;
                dgvTable.Focus();
            }
        }


    }
}



