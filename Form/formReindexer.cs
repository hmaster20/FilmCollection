using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FilmCollection
{
    public partial class formReindexer : Form
    {
        public formReindexer()
        {
            InitializeComponent();

            dataGridView2.AutoGenerateColumns = false;    // Отключение автоматического заполнения таблицы
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки
        }

        public formReindexer(RecordCollection _videoCollection)
        {
            InitializeComponent();
        }

        public List<string> CountID = new List<string>();

        private void btnParse_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);

            XDocument xml = XDocument.Load(file);

            var nodes = (from n in xml.Descendants("media")
                         select n.Element("Id").Value
                         ).ToList();

            //// поиск самих дубликатов
            //var duplicatesSs = nodes.GroupBy(s => s)
            //    .SelectMany(grp => grp.Skip(1)).ToList();

            // поиск видов дубликатов по наименованию 
            var querys = nodes.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            for (int i = 0; i < querys.Count; i++)
            {
                CountID.Add(querys[i]);
            }         

            // поиск видов дубликатов и их количества
            var queryss = nodes.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();

            Dictionary<string, int> ss = new Dictionary<string, int>();

            for (int i = 0; i < queryss.Count; i++)
            {
                ss.Add(queryss[i].Element, queryss[i].Counter);
            }

            listBox2.DataSource = new BindingSource(ss, null);
            listBox2.DisplayMember = "Value";
            listBox2.ValueMember = "Key";

            listBox4.DataSource = new BindingSource(ss, null);
            listBox4.DisplayMember = "Key";
            listBox4.ValueMember = "Value";


            foreach (KeyValuePair<string, int> kvp in ss)
            {
                ListViewItem lvi = listView2.Items.Add(kvp.Key);
                string temp = string.Join(", ", kvp.Value);
                lvi.SubItems.Add(temp);
            }


            dataGridView1.DataSource = ss.ToArray();
            dataGridView1.Update();







            XDocument xmlErr = XDocument.Load(file);

            foreach (var item in querys)
            {
                var nodesErr = (from n in xmlErr.Descendants("media")
                                where n.Element("Id").Value == item //"0"
                                select n.Element("Name").Value
                                ).ToList();

                foreach (var node in nodesErr)
                {
                    listView1.Items.Add(node.Trim());
                    listBox1.Items.Add(node.Trim());
                }
            }



            Dictionary<string, int> newDic = new Dictionary<string, int>();

            foreach (var item in querys)
            {
                var nodesErr = (from n in xmlErr.Descendants("media")
                                where n.Element("Id").Value == item //"0"
                                select new { Name = n.Element("Name").Value, ID = n.Element("Id").Value }
                                );

                foreach (var items in nodesErr)
                {
                    newDic.Add(items.Name, Convert.ToInt32(items.ID));
                }

            }

            // сортировка словаря
            var sortedDic = (from c in newDic
                             orderby c.Key ascending
                             orderby c.Value ascending
                             select c);

            dataGridView2.DataSource = sortedDic.ToArray();
            //dataGridView2.Update();
            labelErrorCount.Text = "Количество ошибочныx элементов: " + newDic.Count;




            var ActorNodes = (from n in XDocument.Load(file).Descendants("Actor")
                              select n.Element("id").Value
                         ).ToList();

            List<string> nn2 = new List<string>();
            nn2 = ActorNodes;

            var duplicateKeys2 = nn2.GroupBy(x => x)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);





            //foreach (var item in nodes)
            //{
            //    Console.WriteLine(item.Trim());
            //}


            //XmlTextReader reader = new XmlTextReader(file);
            //while (reader.Read())
            //{
            //    if (reader.ReadToDescendant("title"))
            //    {
            //        reader.Read();//this moves reader to next node which is text 
            //                      //result = reader.Value; //this might give value than 
            //                      //break;
            //        Console.WriteLine(reader.Value.Trim());
            //    }
            //}
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            string PathFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);

            XDocument xml = XDocument.Load(PathFile);

            List<string> nodes = (from n in xml.Descendants("media")
                                  select n.Element("Id").Value
                         ).ToList();

            List<int> ID = new List<int>();
            ID = nodes.Select(int.Parse).ToList();

            int maxAge = ID.Max();

            // исправление индексов


            //XmlDocument doc = new XmlDocument();
            ////doc.Load("D:\\build.xml");
            //doc.Load(PathFile);
            //XmlNode root = doc.DocumentElement;
            //XmlNode myNode = root.SelectSingleNode("descendant::books");
            //myNode.Value = "blabla";
            //doc.Save(PathFile);


            //XDocument xmlFile = XDocument.Load("books.xml");
            XDocument xmlFile = XDocument.Load(PathFile);
            //var query = from c in xmlFile.Elements("catalog").Elements("book")
            //            select c;

            //var query = from c in xmlFile.Elements("RecordCollection").Elements("CombineList").Elements("CombineList").Elements("Combine") select c;


            //// Рабочая версия 1
            //XElement selection = xmlFile.Descendants("media")
            //    .Where(n => n.Descendants("Id").First().Value == "0")
            //    .FirstOrDefault();

            //if (selection != null)
            //{
            //    //XElement nom = selection.Descendants("Nom").First();
            //    //nom.Value = "Name one";
            //    selection.Element("Id").Value = "999999";
            //}



            //// Рабочая версия 2
            //var selections = xmlFile.Descendants("media")
            // .Where(n => n.Descendants("Id").First().Value == "0");

            //foreach (var item in selections)
            //{
            //    maxAge = ++maxAge;
            //    item.Element("Id").Value = maxAge.ToString();
            //}



            // Рабочая версия 3
            foreach (string IDs in CountID)
            {
                var selectionsS = xmlFile.Descendants("media").Where(n => n.Descendants("Id").First().Value == IDs);

                foreach (var xEl in selectionsS)
                {
                    maxAge = ++maxAge;
                    xEl.Element("Id").Value = maxAge.ToString();
                    Console.WriteLine(maxAge.ToString());
                    //int lineNumber = ((IXmlLineInfo)xEl).HasLineInfo() ? ((IXmlLineInfo)xEl).LineNumber : -1;
                    //Console.WriteLine("line number : " + lineNumber);
                }
            }

            xmlFile.Save(PathFile);




            /////////////////////////////////////
            //for (int i = 0; i < CountID.Count; i++)
            //{
            //    var queryS = from n in xml.Descendants("media")
            //                 where n.Element("Id").Value == CountID[i]
            //                 select n;

            //    foreach (XElement book in queryS)
            //    {
            //        maxAge++;
            //        book.Element("Id").Value = maxAge.ToString();
            //        ///book.Attribute("attr1").Value = "MyNewValue";
            //    }

            //}
            ///////////////////////////////////////////////////





            // string PathFile2 = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "test.xml");

            //xmlFile.Save(PathFile2);

            //if (listBox4.Items.Count > 0)
            //{
            //    for (int i = 0; i < listBox4.Items.Count; i++)
            //    {
            //        Console.WriteLine(listBox4.Items[i]);
            //    }
            //    foreach (var item in listBox4.Items)
            //    {
            //        Console.WriteLine(item);
            //    }               
            //}
        }
    }
}

