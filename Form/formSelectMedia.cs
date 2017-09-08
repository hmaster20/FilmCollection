using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class formSelectMedia : Form
    {
        internal Media media = null;

        public formSelectMedia(List<Media> mediaList, Record record)
        {
            InitializeComponent();
            this.Icon = FilmCollection.Properties.Resources.FC; // Загрузка иконки

            if (mediaList == null)
                throw new ArgumentNullException("mediaList", "mediaList не может содержать null");

            mediaList.ForEach(x => listMedia.Items.Add(x));





            foreach (Media m in mediaList)
            {
                string[] row = { m.Name, m.Year.ToString(), m.CountryString, m.GenreString };
                var listViewItem = new ListViewItem(row);
                listView3.Items.Add(listViewItem);
            }

            //foreach (Media m in mediaList)
            //{
            //    ListViewItem lvi = new ListViewItem(new string[] { m.Name, m.Year.ToString(), m.CountryString, m.GenreString });
            //    listView4.Items.Add(lvi);
            //}




            if (record != null)
            {
                labelRecordName.Text = record.FileName;
            }
            else
            {
                labelRecordName.Text = "";
            }
            listMedia.SelectedIndex = 0;

            SelectMediaInfo.InVisibleButton();

            //listMedia.Items.Clear();
            //foreach (Media _media in MList)
            //    listMedia.Items.Add(new ListViewItem(new string[] {_media.Name, _media.CountryString, _media.Year.ToString() }));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            media = (Media)listMedia.SelectedItem;
            DialogResult = DialogResult.OK;

        }

        private void listRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMediaInfo.update((Media)listMedia.SelectedItem);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectMediaInfo.Clear();
            media = null;
        }
    }
}

