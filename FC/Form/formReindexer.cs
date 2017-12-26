using FC.Provider;
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

            this.Icon = FilmCollection.Properties.Resources.FC; // Загрузка иконки
            dataGridView2.AutoGenerateColumns = false;    // Отключение автоматического заполнения таблицы
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Цвет фона выбранной строки
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;     // Цвета текста выбранной строки
            labelErrorCount.Text = "";
        }

        public List<string> CountID = new List<string>();
        public bool status = false;

        private void btnParse_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);

            var nodes = (from n in XDocument.Load(file).Descendants("media")
                         select n.Element("Id").Value
                         ).ToList();

            // поиск видов дубликатов по наименованию 
            List<string> querys = nodes.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            querys.ForEach(x => CountID.Add(x));


            Dictionary<string, int> newDic = new Dictionary<string, int>();

            XDocument xmlErr = XDocument.Load(file);
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

            if (newDic.Count >0)
            {
                btnFix.Enabled = true;
            }

            //// Проверка индексов актеров
            //List<string> ActorNodes = (from n in XDocument.Load(file).Descendants("Actor")
            //                           select n.Element("id").Value
            //                           ).ToList();

            //var duplicateKeys2 = ActorNodes.GroupBy(x => x)
            //    .Where(group => group.Count() > 1)
            //    .Select(group => group.Key);
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
            XDocument xmlFile = XDocument.Load(PathFile);

            foreach (string IDs in CountID)
            {
                var selectionsS = xmlFile.Descendants("media")
                    .Where(n => n.Descendants("Id").First().Value == IDs);

                foreach (var xEl in selectionsS)
                {
                    maxAge = ++maxAge;
                    xEl.Element("Id").Value = maxAge.ToString();
                }
            }

            xmlFile.Save(PathFile);
            status = true;
        }
    }
}
