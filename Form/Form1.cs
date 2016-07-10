using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

using System.Xml;



namespace FilmCollection
{
    public partial class Form1 : Form
    {
        RecordCollection _videoCollection = new RecordCollection();
        Record record = null;
        string NodeName = "";       // хранение полного пути узла из TreeFolder
        string SourceValue = "";


        public Form1()
        {
            InitializeComponent();

            //  СОЗДАНИЕ дерева из ПАПКИ
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\temp");
            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect;
                BuildTree(directoryInfo, treeView1.Nodes);
            }

            // СОХРАНЕНИЕ XML
            //string rootPath = Console.ReadLine(); var dir = new DirectoryInfo(rootPath);
            var dir = new DirectoryInfo(@"C:\temp");
            var doc = new XDocument(GetDirectoryXml(dir));
            doc.Save("Dirs_v6.xml");


            // ЧТЕНИЕ XML и создание дерева
            string samplePath = Application.StartupPath + @"\\Dirs_v6.xml";
            DisplayTreeView(samplePath);
        }



        #region СОЗДАНИЕ ДЕРЕВА на основе ФАЙЛОВОЙ системы
        // СОЗДАНИЕ ДЕРЕВА на основе ФАЙЛОВОЙ системы =========================================================================================================
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            //Чтение директории
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }





        //Чтение файла при клике по ветке дерева
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.EndsWith("txt"))
            {
                this.richTextBox1.Clear();
                StreamReader reader = new StreamReader(e.Node.Name);
                this.richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }

            //var doc = XDocument.Parse(openSourceFileDialog.FileName); 
            string xmlPath = @"Dirs_v6.xml";

            var doc = XDocument.Load(xmlPath);

            var nodesToRemove = (from n in doc.Descendants("file")
                                 where n.Attribute("name") != null && n.Attribute("name").Value == e.Node.Name
                                 select n).ToList();
           // foreach (var node in nodesToRemove)
                //textBox2.Text = e.Node.FullPath;
        }

        // СОЗДАНИЕ ДЕРЕВА на основе ФАЙЛОВОЙ системы =========================================================================================================
        #endregion





        #region СОЗДАНИЕ XML
        // СОЗДАНИЕ XML =========================================================================================================

        public static XElement GetDirectoryXml(DirectoryInfo dir)
        {
            // Архитектура для папок
            var info = new XElement("dir",
                           //  new XAttribute("name", dir.Name));
                           new XAttribute("name", dir.Name),
                           new XAttribute("path", dir.FullName),
                                new XElement("info",
                                new XElement("comment", "информация о папке")));


            foreach (var file in dir.GetFiles())
                // Архитектура для файлов
                info.Add(new XElement("file",
                         new XAttribute("name", file.Name),
                           new XElement("info",
                           new XElement("lastModify", file.LastWriteTime),
                           new XElement("Attributes", file.Attributes.ToString()))));


            foreach (var subDir in dir.GetDirectories())
                info.Add(GetDirectoryXml(subDir));

            return info;
        }

        // СОЗДАНИЕ XML =========================================================================================================
        #endregion





        #region ЧТЕНИЕ XML и СОЗДАНИЕ ДЕРЕВА
        // ЧТЕНИЕ XML и СОЗДАНИЕ ДЕРЕВА =========================================================================================================

        private void DisplayTreeView(string pathname)
        {
            try
            {
                XmlDocument dom = new XmlDocument();    // SECTION 1. Create a DOM Document and load the XML data into it.
                dom.Load(pathname);

                treeView2.Nodes.Clear();                // SECTION 2. Initialize the TreeView control.
                treeView2.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = treeView2.Nodes[0];
                
                AddNode(dom.DocumentElement, tNode);    // SECTION 3. Populate the TreeView with the DOM nodes.

            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.

            if (inXmlNode.HasChildNodes)
            {
                //Check if the XmlNode has attributes
                foreach (XmlAttribute att in inXmlNode.Attributes)
                {
                    if (att.Name == "name")
                    {
                        //inTreeNode.Text = inTreeNode.Text + " " + att.Name + ": " + att.Value;
                        inTreeNode.Text = inTreeNode.Text + att.Value;
                    }
                }

                var nodeList = inXmlNode.ChildNodes;
                for (int i = 0; i < nodeList.Count; i++)
                {
                    var xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name == "dir")
                    {
                        var tNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(""))];
                        AddNode(xNode, tNode);
                    }
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
            treeView2.ExpandAll();
        }



        // ЧТЕНИЕ XML и СОЗДАНИЕ ДЕРЕВА =========================================================================================================
        #endregion






        private void btnScanDir_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp");
            _videoCollection.Source = directory.FullName;
            int dlinna = directory.FullName.Length;
            string strr;

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
                        if (-1 != file.DirectoryName.Substring(dlinna).IndexOf('\\')) strr = file.DirectoryName.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11

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
                if (-1 != node.ChildNodes[0].Value.Substring(dlinna).IndexOf('\\'))
                {
                    temp = node.ChildNodes[0].Value.Substring(dlinna + 1); //Обрезка строку путь C:\temp\1\11 -> 1\11
                    if (temp.Length != 0) paths.Add(node.ChildNodes[0].Value.Substring(dlinna + 1));
                }

            }



            PopulateTreeView(treeFolder, paths, '\\');          // PopulateTreeView(treeFolder, paths, '\\');
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


    }
}



