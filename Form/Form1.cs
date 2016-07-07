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
        //List<Record> rec = new List<Record>();
        RecordCollection _videoCollection = new RecordCollection();
        Record record = null;

        /*
      //Вспомогательный класс, который и будем сериализовать, так как TreeNodeCollection не сериализуется.
      public class MyNode
      {
          public MyNode()
          {
              SubNodes = new List<MyNode>();
          }
          [XmlAttribute()]
          public string Text { get; set; }
          [XmlAttribute()]
          public string Name { get; set; }
          [XmlElement(IsNullable = true)]
          public List<MyNode> SubNodes { get; set; }
      }

      //Рекурсивная функция
      private void CreateMyNode(MyNode curNode, TreeNode node)
      {
          curNode.Text = node.Text;
          curNode.Name = node.Name;
          foreach (TreeNode nod in node.Nodes)
          {
              MyNode newNode = new MyNode();
              CreateMyNode(newNode, nod);
              curNode.SubNodes.Add(newNode);
          }
      }

     Использование
          MyNode myNode = new MyNode();
          foreach (TreeNode node in treeView1.Nodes)
              CreateMyNode(myNode, node);

      Сериализация:
          using (var writer = new XmlTextWriter("c:\\1.xml", Encoding.UTF8) { Indentation = 4, Formatting = Formatting.Indented })
              new XmlSerializer(typeof(MyNode)).Serialize(writer, myNode);
      */

        // Парсер treeView1 для сохранения в XML
        /*
        public static void SaveItems(XElement curNode, TreeNode item)
        {
            foreach (TreeNode itemloc in item.Nodes)
            {
                XElement newNode = new XElement("folder", new XAttribute("title", itemloc.Text));
                SaveItems(newNode, itemloc);
                curNode.Add(newNode);
            }
        }
        */






        // ГЛАВНАЯ ФОРМА +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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

            // Сохраняем файл XML содержимое treeView1
            //XElement root = new XElement("xbel", new XAttribute("version", "1.0"), new XElement("folder", new XAttribute("title", treeView1.Nodes[0].Text)));
            //foreach (TreeNode item in treeView1.Nodes)
            //    SaveItems(root, item);
            //root.Save("Dir.xml");


            // СОХРАНЕНИЕ XML
            //string rootPath = Console.ReadLine(); var dir = new DirectoryInfo(rootPath);
            var dir = new DirectoryInfo(@"C:\temp");
            var doc = new XDocument(GetDirectoryXml(dir));
            doc.Save("Dirs_v6.xml");


            // ЧТЕНИЕ XML и создание дерева
            //string samplePath = Application.StartupPath + @"\\sample.xml";
            string samplePath = Application.StartupPath + @"\\Dirs_v6.xml";
            DisplayTreeView(samplePath);



            ////ListView1.Items.Add(new ListViewItem(elem));
            //List<string> mylist = new List<string>() { "stealthy", "ninja", "panda" };
            ////ListView1.Items.Add(mylist);

            //listView1.BeginUpdate();

            ////foreach (var row in rec)
            ////{
            ////   listView1.Items.Add(row.Name);
            ////}
            //listView1.EndUpdate();

        }



        #region СОЗДАНИЕ ДЕРЕВА на основе ФАЙЛОВОЙ системы
        // СОЗДАНИЕ ДЕРЕВА на основе ФАЙЛОВОЙ системы =========================================================================================================
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            ////char[] charsToTrim = { '*', ' ', '\'' };
            //char[] charsToTrim = { '.' };
            //Чтение директории
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
                //curNode.Tag = "file";

                //rec.Add(new Record() {
                //    Name = file.Name,
                //    Year = "",
                //    Type = file.Extension
                //});

                //record = new Record();
                //record.Name = file.Name;
                //record.Year = file.Name.Remove(file.Name.LastIndexOf(file.Extension), file.Extension.Length);

                //record.Type = file.Extension.Trim(charsToTrim);
                ////str.Length

                //record.Path = file.DirectoryName;
                //_videoCollection.Add(record);
                //_videoCollection.Save();
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


            //XmlDocument doc = new XmlDocument();
            //doc.Load("Dirs_v6.xml");
            //XmlNode book;

            //XmlAttribute gidAttribute = (XmlAttribute)book.Attributes.GetNamedItem("gid");
            //String gidValue = null;
            //if (gidAttribute != null)
            //    string value = gidAttribute.Value;

            //var doc = XDocument.Parse(openSourceFileDialog.FileName); 
            string xmlPath = @"Dirs_v6.xml";
            //XmlDocument doc = new XmlDocument();
            //doc.Load(xmlPath);

            var doc = XDocument.Load(xmlPath);
            //var doc = XDocument.Parse("Dirs_v6.xml");
            //var anchors = from g in doc.Descendants("file") where g.Attribute("name").Value.Contains(e.Node.Name) select g;
            //textBox3.Text = anchors.Elements("comment").ToString();
            //textBox3.Text = anchors.;
            // no
            var nodesToRemove = (from n in doc.Descendants("file")
                                 where n.Attribute("name") != null && n.Attribute("name").Value == e.Node.Name
                                 select n).ToList();
            foreach (var node in nodesToRemove)
                //node.Remove();
                textBox3.Text = node.Name.ToString();



            //XmlDocument doc = new XmlDocument();
            //doc.Load("Dirs_v6.xml");
            //XmlNode book = doc.SelectSingleNode("..");
            //if (book != null)
            //{
            //    XmlAttribute gid = book.Attributes[e.Node.Name];
            //    if (gid != null)
            //    {
            //        string value = gid.Value;
            //        textBox3.Text = gid.Value;
            //    }
            //}


            textBox2.Text = e.Node.FullPath;
            //textBox3.Text = Convert.ToString(e.Node.Tag);
            //if (e.Node.Tag != null) textBox3.Text = e.Node.Tag.ToString();

            /*
                   if (Convert.ToString(e.Node.Tag) == "file")
                   {
                       //var doc = XDocument.Load("Dirs_v6.xml");
                       //var element = doc.Descendants("file")
                       //    .Where(arg => arg.Attribute("name").Value == e.Node.Name)
                       //    .Single();

                       XElement root = XElement.Load("Dirs_v6.xml");
                       IEnumerable<XElement> address =
                           from el in root.Elements("file")
                           where (string)el.Attribute("name") == e.Node.Name
                           select el;
                       foreach (XElement el in address)
                           label1.Text = "1";//Convert.ToString(el);


                       //label1.Text = element.Element("comment").Value;
                       //label1.Text=
                       //element.Attribute("Quantity").Value = "3";
                       //doc.Save("FileName.xml");

                   }
             * */


            //TreeNode selNode = e.Node;
            //textBox1.Text = selNode.Text;//Textbox where i want to show the value of the attribute.


            //XDocument doc = XDocument.Load("Dirs_v6.xml");

            //var xElement = (from q in doc.Elements("file")
            //                where q.Attribute("comment") != null
            //                select q);

            //foreach (var a in xElement)
            // textBox2.Text = a.Value;





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
                // SECTION 1. Create a DOM Document and load the XML data into it.
                XmlDocument dom = new XmlDocument();
                dom.Load(pathname);


                // SECTION 2. Initialize the TreeView control.
                treeView2.Nodes.Clear();
                treeView2.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = treeView2.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(dom.DocumentElement, tNode);

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

        // Создание новых узлов в treeView2.
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode ChildNode1 = new TreeNode();
            ChildNode1.Text = "Next Child 1";
            ChildNode1.ForeColor = Color.Black;
            ChildNode1.BackColor = Color.White;
            ChildNode1.ImageIndex = 1;
            ChildNode1.SelectedImageIndex = 1;
            treeView2.SelectedNode.Nodes.Add(ChildNode1);        //ParentNode is SelectedNode

            TreeNode ChildNode2 = new TreeNode();
            ChildNode2.Text = "Next Child 2";
            ChildNode2.ForeColor = Color.Black;
            ChildNode2.BackColor = Color.White;
            ChildNode2.ImageIndex = 1;
            ChildNode2.SelectedImageIndex = 1;
            treeView2.SelectedNode.Nodes.Add(ChildNode2);         //ParentNode is SelectedNode

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

            if (directory.Exists)
            {
                char[] charsToTrim = { '.' };
                foreach (FileInfo file in directory.GetFiles("*", SearchOption.AllDirectories))
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
            _videoCollection = RecordCollection.Load();
            RefreshTables();
        }


        private void RefreshTables()
        {
            List<Record> filtered = _videoCollection.VideoList;
            dataGridView1.DataSource = filtered;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _videoCollection = RecordCollection.Load();
            RefreshTables();
        }





        // СТРУКТУРА XML в TreeFolder


        //private void AdddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        //{
        //    XmlNode xNode;
        //    TreeNode tNode;
        //    XmlNodeList nodeList;
        //    int i = 0;
        //    if (inXmlNode.HasChildNodes)
        //    {
        //        nodeList = inXmlNode.ChildNodes;
        //        for (i = 0; i <= nodeList.Count - 1; i++)
        //        {
        //            xNode = inXmlNode.ChildNodes[i];
        //            inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
        //            tNode = inTreeNode.Nodes[i];
        //            AddNode(xNode, tNode);
        //        }
        //    }
        //    else
        //    {
        //        inTreeNode.Text = inXmlNode.InnerText.ToString();
        //    }
        //}

        //private void btnTree_Click(object sender, EventArgs e)
        //{
        //    //XmlDataDocument xmldoc = new XmlDataDocument();
        //    //XmlNode xmlnode;
        //    //FileStream fs = new FileStream("VideoList.xml", FileMode.Open, FileAccess.Read);
        //    //xmldoc.Load(fs);
        //    //xmlnode = xmldoc.ChildNodes[1];
        //    //treeFolder.Nodes.Clear();
        //    //treeFolder.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
        //    //TreeNode tNode;
        //    //tNode = treeFolder.Nodes[0];
        //    //AdddNode(xmlnode, tNode);


        //    BuildTreeS(treeFolder, XDocument.Load("VideoList.xml"));
        //}



        //private void BuildTreeS(TreeView treeView, XDocument doc)
        //{
        //    TreeNode treeNode = new TreeNode(doc.Root.Name.LocalName);
        //    treeView.Nodes.Add(treeNode);
        //    BuildNodes(treeNode, doc.Root);
        //}



        //private void BuildNodes(TreeNode treeNode, XElement element)
        //{
        //    foreach (XNode child in element.Nodes())
        //    {
        //        switch (child.NodeType)
        //        {
        //            case XmlNodeType.Element:
        //                XElement childElement = child as XElement;
        //                TreeNode childTreeNode = new TreeNode(childElement.Name.LocalName);
        //                treeNode.Nodes.Add(childTreeNode);
        //                BuildNodes(childTreeNode, childElement);
        //                break;
        //            case XmlNodeType.Text:
        //                XText childText = child as XText;
        //                treeNode.Nodes.Add(new TreeNode(childText.Value));
        //                break;
        //        }
        //    }
        //}



        private void btnTree_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("VideoList.xml");

            #region Чтение содержимого атрибута source и файла XML
            string SourceValue = "";
            foreach (XmlNode xmlNode in doc.ChildNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)                           // Проверка ноды, что это элемент
                {
                    foreach (XmlAttribute xmlattribute in xmlNode.Attributes)
                    {
                        if (xmlattribute.Name == "source") SourceValue = xmlattribute.Value; // Поиск атрибута "source"
                        break;
                    }
                }
            }
            #endregion

            XmlNodeList nodeList = doc.GetElementsByTagName("Path");             // Чтение элементов "Path"

            treeFolder.Nodes.Clear();
            var paths = new List<string>();                     // PopulateTreeView(treeFolder, paths, '\\');

            foreach (XmlNode node in nodeList)
            {
                paths.Add(node.ChildNodes[0].Value);            // PopulateTreeView(treeFolder, paths, '\\');
            }

            int dlinna = SourceValue.Length;

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
            }
        }


        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox4.Text = e.Node.FullPath;                // вывод полного пути ноды
        }


    }
}



