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

            // поиск видов дубликатов и их количества
            var queryss = nodes.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();

            Dictionary <string, int> ss = new Dictionary<string, int>();

            for (int i = 0; i < queryss.Count; i++)
            {
                ss.Add(queryss[i].Element, queryss[i].Counter);
            }

            listBox2.DataSource = new BindingSource(ss, null);
            listBox2.DisplayMember = "Value";
            listBox2.ValueMember = "Key";


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

            // TableRec.DataSource = filtered;

            dataGridView2.DataSource = newDic.ToArray();

            //dataGridView3.DataSource = newDic.ToArray().OrderBy(c => c.Value).ThenBy(c => c.Key);

            labelErrorCount.Text = "Количество ошибочныx элементов: " + newDic.Count + " !";


            //dataGridView2.Update();
















            XDocument xml2 = XDocument.Load(file);

            var ActorNodes = (from n in xml2.Descendants("Actor")
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
            XDocument xml = XDocument.Load(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName));

            List<string> nodes = (from n in xml.Descendants("media")
                         select n.Element("Id").Value
                         ).ToList();

            List<int> ID = new List<int>();
            ID = nodes.Select(int.Parse).ToList();


            int maxAge = ID.Max();


        }
    }
}
