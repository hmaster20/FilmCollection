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
            InitializeComponent();

            this.record = _record;
           // this._videoCollection = RecordCollection.GetInstance();
            RecordCollection _videoCollection = RecordCollection.GetInstance();


            if (record != null)
            {
                // Панель описания
                tbfName.Text = record.mName;
                tbfDesc.Text = record.mDescription;
                tbfYear.Text = Convert.ToString(record.mYear);
                tbfCountry.Text = record.mCountry;
                GetPic(record.combineLink.media);
                btnPlay.Enabled = true;
                lbActors.Items.Clear();
                if (record.combineLink.media.ActorListID != null)
                    foreach (int ListID in record.combineLink.media.ActorListID)
                        if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                            lbActors.Items.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));
            }
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
                }
                else pbImage.Image = null;
            }
        }

    }
}
