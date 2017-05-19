﻿using System;
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
        public Media media = null;

        public formSelectMedia()
        {
            InitializeComponent();
        }

        public formSelectMedia(List<Media> MList)
        {
            InitializeComponent();
            MList.ForEach(x => listMedia.Items.Add(x));

            //listMedia.Items.Clear();
            //foreach (Media _media in MList)
            //    listMedia.Items.Add(new ListViewItem(new string[] {_media.Name, _media.CountryString, _media.Year.ToString() }));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            media = (Media)listMedia.SelectedItem;           
            DialogResult = DialogResult.OK;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Media media = (Media)listMedia.SelectedItem;
            SelectMediaInfo.update(media);
        }
    }
}

