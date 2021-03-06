﻿using FC.Provider;
using FC.Provider.Class.Main.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class formSelectMedia : Form
    {
        internal Media media = null;
        private List<Media> mediaList = null;

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
                //ListViewItem listViewItem = new ListViewItem(new string[] { m.Name, m.Year.ToString(), m.CountryString, m.GenreString });
                listMedia.Items.Add(listViewItem);
            }

            labelRecordName.Text = (record != null) ? record.FileName : "";
            if (record != null)
            {
                string resultString = Regex.Match(record.FileName, @"[0-9]{4}").Value;
                //MessageBox.Show(resultString);

                //var iii = listMedia.Items.IndexOfKey(resultString);
                //MessageBox.Show(iii.ToString());
                //var lll = listMedia.Items.Find(resultString, true);
                var lll = listMedia.FindItemWithText(resultString);
                listMedia.EnsureVisible(lll.Index);
                lll.Selected = true;
                lll.Focused = true;
                listMedia.Select();

                //this.listMedia.Items[lll.Index].Focused = true;
                //this.listMedia.Items[lll.Index].Selected = true;


                //MessageBox.Show(lll.ToString());

            }

            // listMedia.SelectedIndex = 0;
            this.listMedia.LostFocus += (s, e) => this.listMedia.SelectedIndices.Clear();

            SelectMediaInfo.InVisibleButton();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //media = (Media)listMedia.SelectedItem;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectMediaInfo.Clear();
            media = null;
        }

        private void listMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SelectMediaInfo.update((Media)listMedia.SelectedItem);
            if (listMedia.SelectedItems.Count > 0)
            {
                var indexSelected = listMedia.Items.IndexOf(listMedia.SelectedItems[0]);
                Console.WriteLine("индекс строки = " + indexSelected);
                if (mediaList != null && mediaList.Count > 0)
                {
                    SelectMediaInfo.updatePreview(mediaList[indexSelected]);
                    media = mediaList[indexSelected];
                }
            }
        }
    }
}
