﻿using System;
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
        private Record record { get; set; }

        public ucMediaInfo()
        {
            InitializeComponent();
        }

        public ucMediaInfo(Record _record)
        {
            InitializeComponent();
        }        

        public void update(Record _record)
        {
            RecordCollection _videoCollection = RecordCollection.GetInstance();

            this.record = _record;

            if (_record != null)
            {
                // Панель описания
                tbfName.Text = _record.mName;
                tbfDesc.Text = _record.mDescription;
                tbfYear.Text = Convert.ToString(_record.mYear);
                tbfCountry.Text = _record.mCountry;
                GetPic(_record.combineLink.media);
                btnPlay.Enabled = true;
                lbActors.Items.Clear();
                if (_record.combineLink.media.ActorListID != null)
                    foreach (int ListID in _record.combineLink.media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            lbActors.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));
            }
        }


        public void update(Media _media)
        {
            RecordCollection _videoCollection = RecordCollection.GetInstance();

            if (_media != null)
            {
                // Панель описания
                tbfName.Text = _media.Name;
                tbfDesc.Text = _media.Description;
                tbfYear.Text = Convert.ToString(_media.Year);
                tbfCountry.Text = _media.CountryString;
                GetPic(_media);
                btnPlay.Enabled = false;
                lbActors.Items.Clear();
                if (_media.ActorListID != null)
                    foreach (int ListID in _media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            lbActors.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));
            }
        }




        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (record != null)
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
        }

    }
}
