using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace FilmCollection
{
    public partial class ucMediaInfo : UserControl
    {
        public Record record { get; set; }

        public ucMediaInfo()
        {
            InitializeComponent();
        }

        public ucMediaInfo(Record _record)
        {          
            this.record = _record;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (record != null) // убрать возможность нажатия при отсутствии селекта
            {
                string _file = (record.Path + Path.DirectorySeparatorChar + record.FileName);
                if (File.Exists(_file))
                {
                    Process.Start(_file);
                }
                else
                {
                    MessageBox.Show("Отсутствует файл: " + _file);
                }
            }
        }

   
    }
}
