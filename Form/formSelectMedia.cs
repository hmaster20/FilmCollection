using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class formSelectMedia : Form
    {
        public List<Media> MList { get; set; }

        public formSelectMedia()
        {
            InitializeComponent();
        }

        public formSelectMedia(List<Media> MList)
        {

        }
    }
}
