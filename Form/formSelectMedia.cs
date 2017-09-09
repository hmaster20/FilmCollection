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
        private List<Media> mediaList = null;
        //private Media mediaSelected = null;

        public formSelectMedia(List<Media> mediaList, Record record)
        {
            InitializeComponent();
            this.Icon = FilmCollection.Properties.Resources.FC; // Загрузка иконки

            if (mediaList == null)
                throw new ArgumentNullException("mediaList", "mediaList не может содержать null");
            
            this.mediaList = mediaList;
            
            foreach (Media m in mediaList)
            {
                string[] row = { m.Name, m.Year.ToString(), m.CountryString, m.GenreString };
                var listViewItem = new ListViewItem(row);
                listMedia.Items.Add(listViewItem);
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

            // сброс выбора
            // listMedia.SelectedIndex = 0;
            this.listMedia.LostFocus += (s, e) => this.listMedia.SelectedIndices.Clear();


            SelectMediaInfo.InVisibleButton();

            //listMedia.Items.Clear();
            //foreach (Media _media in MList)
            //    listMedia.Items.Add(new ListViewItem(new string[] {_media.Name, _media.CountryString, _media.Year.ToString() }));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
          //media = (Media)listMedia.SelectedItem;
            DialogResult = DialogResult.OK;
        }

        //private void listRecord_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SelectMediaInfo.update((Media)listMedia.SelectedItem);
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectMediaInfo.Clear();
            media = null;
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMedia.SelectedItems.Count > 0)
            {
                var ss = listMedia.Items.IndexOf(listMedia.SelectedItems[0]);
                Console.WriteLine("индекс строки = " + ss);
                if (mediaList != null && mediaList.Count > 0)
                {
                    SelectMediaInfo.update(mediaList[ss]);
                    // mediaSelected = mediaList[ss];
                    media = mediaList[ss];
                }
            }
        }
    }
}

