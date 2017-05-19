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
        //public List<Media> MList { get; set; }
        public Media media = null;

        public formSelectMedia()
        {
            InitializeComponent();
        }

        public formSelectMedia(List<Media> MList)
        {
            InitializeComponent();

            MList.ForEach(x=> listBox1.Items.Add(x));

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Media media = (Media)listBox1.SelectedItem;
            DialogResult = DialogResult.OK;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Media media = (Media)listBox1.SelectedItem;

            SelectMediaInfo.update(media);

            //ucMediaInfo uc = new ucMediaInfo(media);             
            //uc.Show();
            //uc.Refresh();

           // lCountry.Text = media.CountryString;
          //  lYear.Text = media.Year.ToString();
                           
        }
    }
}

               