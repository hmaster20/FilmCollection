using FC.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FilmCollection
{
    public partial class Report : Form
    {
        RecordCollection videoCollection { get; set; }     // Доступ к коллекции

        public Report()
        {
            InitializeComponent();
        }

        public Report(RecordCollection сollection)
        {
            InitializeComponent();

            this.Icon = FilmCollection.Properties.Resources.FC; // Загрузка иконки

            videoCollection = сollection;

            cbSelectReport.Items.Add("Отчет по формату");
            cbSelectReport.Items.Add("Отчет по категориям");
            cbSelectReport.Items.Add("Отчет по жанрам");
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (cbSelectReport.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите вариант отчета!");
            }
            switch (cbSelectReport.SelectedIndex)
            {
                case 0: ChartGenerateByFormat(); break;
                case 1: ChartGenerateByCategory(); break;
                case 2: ChartGenerateByGenre(); break;
                default: break;
            }
        }


        void ChartGenerateByGenre()
        {
            List<string> GenreVideo = new List<string>();
            foreach (var item in Enum.GetValues(typeof(GenreVideo_Rus)))
            {
                GenreVideo.Add(item.ToString());
            }
            Dictionary<string, int> charter = new Dictionary<string, int>();
            foreach (string ext in GenreVideo)
            {
                charter.Add(ext, 0);
            }

            foreach (Combine item in videoCollection.CombineList)
            {
                if (charter.ContainsKey(item.media.GenreString))
                {
                    charter[item.media.GenreString] = ++charter[item.media.GenreString];
                }
            }

            charter = charter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;   // Надписи под каждым столбцом
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;   // Вертикальные линии - отключены
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;   // Горизонтальные линии - отключены

            chart1.ChartAreas[0].AxisX.Interval = 1;

            using (Series ser2 = new Series("По жанрам"))
            {
                ser2.IsValueShownAsLabel = true;    // включение меток над столбцами
                chart1.Series.Add(ser2);
                chart1.Series[ser2.Name].SmartLabelStyle.Enabled = true;
                chart1.Series[ser2.Name].Points.DataBindXY(charter.Keys, charter.Values);
            }
        }


        void ChartGenerateByCategory()
        {
            List<string> CategoryVideo = new List<string>();
            foreach (var item in Enum.GetValues(typeof(CategoryVideo_Rus)))
            {
                CategoryVideo.Add(item.ToString());
            }
            Dictionary<string, int> charter = new Dictionary<string, int>();
            foreach (string ext in CategoryVideo)
            {
                charter.Add(ext, 0);
            }

            foreach (Combine item in videoCollection.CombineList)
            {
                if (charter.ContainsKey(item.media.CategoryString))
                {
                    charter[item.media.CategoryString] = ++charter[item.media.CategoryString];
                }
            }

            charter = charter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;   // Надписи под каждым столбцом
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;   // Вертикальные линии - отключены
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;   // Горизонтальные линии - отключены


            using (Series ser2 = new Series("По категориям"))
            {
                ser2.IsValueShownAsLabel = true;    // включение меток над столбцами
                chart1.Series.Add(ser2);
                chart1.Series[ser2.Name].Points.DataBindXY(charter.Keys, charter.Values);
            }
        }


        void ChartGenerateByFormat()
        {
            List<string> FormatAdd = new List<string>();
            foreach (var item in Enum.GetValues(typeof(MediaFormat)))
            {
                FormatAdd.Add(item.ToString());
            }

            Dictionary<string, int> charter = new Dictionary<string, int>();
            foreach (string ext in FormatAdd)
            {
                charter.Add(ext, 0);
            }

            List<Record> filtered = new List<Record>();
            videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

            foreach (Record item in filtered)
            {
                if (charter.ContainsKey(item.FileExt))
                {
                    charter[item.FileExt] = ++charter[item.FileExt];
                }
            }

            charter = charter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);   // Сортировка по количеству фильмов (Value) конкретного типа (Key)

            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;   // Надписи под каждым столбцом
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;   // Вертикальные линии - отключены
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;   // Горизонтальные линии - отключены

            using (Series ser1 = new Series("По типам", 10))
            {
                ser1.IsValueShownAsLabel = true;    // включение меток над столбцами
                chart1.Series.Add(ser1);
                //chart1.Series[ser1.Name].SmartLabelStyle.Enabled = true;
                chart1.Series[ser1.Name].Points.DataBindXY(charter.Keys, charter.Values);
            }
        }
    }
}
