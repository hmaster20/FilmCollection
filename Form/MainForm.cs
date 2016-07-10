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

            //string rootPath = Console.ReadLine(); var dir = new DirectoryInfo(rootPath);
            //string samplePath = Application.StartupPath + @"\\Dirs_v6.xml";
            //DisplayTreeView(samplePath);
        }



        private void btnScanDir_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp");
            _videoCollection.Source = directory.FullName;
            _videoCollection.Save();
            //int dlinna = directory.FullName.Length;
            //string strr;

            #region Формирование списка файлов в базе XML для использования при дальнейшей проверке. Нужно ли их добавлять.
            List<string> FileName = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load("VideoList.xml");

            XmlNodeList nodeList = doc.GetElementsByTagName("Name");

            foreach (XmlNode node in nodeList)
            {
                FileName.Add(node.ChildNodes[0].Value);
            }
            #endregion


            if (directory.Exists)
            {
                char[] charsToTrim = { '.' };
                foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
                {
                    if (file.Name != FileName.Find(x => x.Contains(file.Name)))
                    {
                        record = new Record();
                        record.Name = file.Name;
                        record.Year = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length);
                        record.Type = file.Extension.Trim(charsToTrim);
                        record.Path = file.DirectoryName;//полный путь к файлу               // record.Path = file.Directory.Name; - папка расположения файла
                                                         // if (-1 != file.DirectoryName.Substring(dlinna).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11

                        _videoCollection.Add(record);
                        _videoCollection.Save();
                    }
                }
            }
            _videoCollection = RecordCollection.Load();
            RefreshTables();
        }


        private void RefreshTables()
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _videoCollection = RecordCollection.Load();
            RefreshTables();

        }






        private void btnTree_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("VideoList.xml");

            #region Чтение содержимого атрибута source и файла XML
            //string SourceValue = "";
            foreach (XmlNode xmlNode in doc.ChildNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)                           // Проверка ноды, что это элемент
                {
                    foreach (XmlAttribute xmlattribute in xmlNode.Attributes)
                    {
                        if (xmlattribute.Name == "source") SourceValue = xmlattribute.Value; // Поиск атрибута "source"
                        if ((SourceValue != null) && (SourceValue.Length != 0)) break;
                    }
                }
            }
            #endregion

            int dlinna = SourceValue.Length; // расчет длинны пути

            XmlNodeList nodeList = doc.GetElementsByTagName("Path");             // Чтение элементов "Path"

            treeFolder.Nodes.Clear();
            var paths = new List<string>();                     // PopulateTreeView(treeFolder, paths, '\\');
            //paths.Add("Фильмотека");

            foreach (XmlNode node in nodeList)
            {
                string temp = "";
                //if (-1 != node.ChildNodes[0].Value.Substring(dlinna).IndexOf('\\')) //Path.DirectorySeparatorChar
                if (-1 != node.ChildNodes[0].Value.Substring(dlinna).IndexOf(Path.DirectorySeparatorChar))
                {
                    temp = node.ChildNodes[0].Value.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                    if (temp.Length != 0) paths.Add(node.ChildNodes[0].Value.Substring(dlinna + 1));
                }

            }



            //PopulateTreeView(treeFolder, paths, '\\');          // PopulateTreeView(treeFolder, paths, '\\');
            PopulateTreeView(treeFolder, paths, Path.DirectorySeparatorChar);          // PopulateTreeView(treeFolder, paths, '\\');
            treeFolder.AfterSelect += treeFolder_AfterSelect;
        }



        private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
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
                lastNode = null; // This is the place code was changed
            }
        }


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodeName = e.Node.FullPath;         // получение полного пути ноды
            RefreshTables();

            //TreeNode ChildNode1 = new TreeNode();
            //ChildNode1.Text = "Next Child 1";
            //ChildNode1.ImageIndex = 1;
            //ChildNode1.SelectedImageIndex = 1;
            //treeView2.SelectedNode.Nodes.Add(ChildNode1);       
        }


        public void ChooseFolder()
        {
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                //textBox1.Text = foldBrowsDialog.SelectedPath;
            }

        }

    }
}



