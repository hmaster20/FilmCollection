﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using FC.Provider;
using FC.Provider.Class.Main.Units;
using FC.Provider.Class.Main.Collection;

namespace FilmCollection
{
    public partial class ucMediaInfo : UserControl
    {
        private Record record { get; set; }
        private MainForm main { get; set; }
        private CollectionRecord _videoCollection { get; set; }

        public ucMediaInfo()
        {
            InitializeComponent();
        }

        public void InVisibleButton() => btnPlay.Visible = false;

        public void update(Record _record, MainForm main)
        {
            if (_record != null)
            {
                this.main = main;
                this.record = _record;
                this._videoCollection = CollectionRecord.CurrentInstance();

                tbfName.Text = _record.mName;
                tbfDesc.Text = _record.mDescription;
                tbfYear.Text = Convert.ToString(_record.mYear);
                tbfCountry.Text = _record.mCountry;
                GetPic(_record.combineLink.media);
                btnPlay.Enabled = true;
                lbActors.Items.Clear();
                if (_record.combineLink.media.ActorListID != null && _videoCollection != null)
                    foreach (int ListID in _record.combineLink.media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            lbActors.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));
            }
        }

        public void updatePreview(Media _media)
        {
            if (_media != null)
            {
                tbfName.Text = _media.Name;
                tbfDesc.Text = _media.Description;
                tbfYear.Text = Convert.ToString(_media.Year);
                tbfCountry.Text = _media.CountryString;
                GetPic(_media);
                btnPlay.Enabled = false;
                lbActors.Items.Clear();
                if (_media.ActorList != null)
                    _media.ActorList.ForEach(x => lbActors.Items.Add(x));
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (record != null) record.play();
        }

        private void GetPic(Media _media)
        {
            if (_media != null)
            {
                if (File.Exists(_media.GetFilename))
                {
                    Image image = Image.FromFile(_media.GetFilename);
                    pbImage.Image = (image.Height > 300)
                        ? image.GetThumbnailImage(300 * image.Width / image.Height, 300, null, IntPtr.Zero)
                        : image;

                    image.Dispose();
                }
                else pbImage.Image = null;
            }
            else
            {
                pbImage.Image = null;
            }
        }

        private void lbActors_DoubleClick(object sender, EventArgs e)
        {
            if (record != null && main != null) main.SelectActor(lbActors.SelectedItem.ToString());
        }

        public void Clear()
        {
            tbfName.Text = "";
            tbfDesc.Text = "";
            tbfYear.Text = "";
            tbfCountry.Text = "";
            GetPic(null);
            lbActors.Items.Clear();
            btnPlay.Enabled = false;
        }
    }
}