using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        public Options(RecordCollection _videoCollection)
        {
            InitializeComponent();

            if (_videoCollection.Options.Source != null)
            {
                lBasePath.Text = _videoCollection.Options.Source;
            }
            lCatalogPath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);

            //foreach (DataColumn dc in dataSet.Tables[0].Columns)
            //{
            //    checkedListBox1.Items.Add(dc.ColumnName);
            //}
        }
    }
}
