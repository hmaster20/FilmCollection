using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FilmCollection
{
    public partial class Report : Form
    {
        RecordCollection _videoCollection { get; set; }     // Доступ к коллекции

        public Report()
        {
            InitializeComponent();
        }

        public Report(RecordCollection _сollection)
        {
            InitializeComponent();

            _videoCollection = _сollection;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ChartGenerate();
        }

        void ChartGenerate()
        {
            List<string> FormatAdd = new List<string> { "avi", "mkv", "mp4", "wmv", "webm", "rm", "mpg", "mpeg", "flv", "divx" };

            Dictionary<string, int> charter = new Dictionary<string, int>();
            foreach (string item in FormatAdd)
            {
                charter.Add(item, 0);
            }

            List<Record> filtered = new List<Record>();
            _videoCollection.CombineList.ForEach(r => filtered.AddRange(r.recordList));

            foreach (Record item in filtered)
            {
                if (charter.ContainsKey (item.Extension))
                {
                    charter[item.Extension] = ++charter[item.Extension];
                }
            }
            charter = charter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);   // Сортировка по количеству фильмов (Value) конкретного типа (Key)

            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;   // Надписи под каждым столбцом
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;   // Вертикальные линии - отключены
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;   // Горизонтальные линии - отключены

            Series ser1 = new Series("My Series", 10);
            ser1.IsValueShownAsLabel = true;    // включение меток над столбцами
            chart1.Series.Add(ser1);

            chart1.Series[ser1.Name].SmartLabelStyle.Enabled = true;
            chart1.Series[ser1.Name].Points.DataBindXY(charter.Keys, charter.Values);
            // chart1.Series["My Series"].Points.DataBindXY(charter.Keys, charter.Values);




      


        }
    }
}
