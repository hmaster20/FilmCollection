using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FilmCollection
{
    public partial class ucSelectCatalog : UserControl
    {
        private MainForm mainForm;
        private RecordCollection VC;

        public ucSelectCatalog()
        {
            InitializeComponent();
        }

        public ucSelectCatalog(RecordCollection _videoCollection, MainForm mainForm)
        {
            this.VC = _videoCollection;
            this.mainForm = mainForm;

            if (_videoCollection == null)
                throw new ArgumentNullException("_videoCollection", "_videoCollection не может содержать null");

            ListUpdate(_videoCollection);
        }

        private void ListUpdate(RecordCollection _videoCollection)
        {
            listBase.Items.Clear();
            if (_videoCollection.SourceList.Count > 0)
            {
                _videoCollection.SourceList.ForEach(x => listBase.Items.Add(x.Source));
            }
        }

        private void btnAddSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbDialog = new FolderBrowserDialog())
            {
                fbDialog.Description = "Укажите расположение файлов мультимедиа:";
                fbDialog.ShowNewFolderButton = false;

                DialogResult dialogStatus = fbDialog.ShowDialog();  // Запрашиваем новый каталог с коллекцией видео
                if (dialogStatus == DialogResult.OK)
                {
                    string folderName = fbDialog.SelectedPath;  //Извлечение имени папки
                    DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки
                    if (directory.Exists)
                        if (VC != null)
                        {
                            int id = VC.AddSource(directory.FullName);
                            ListUpdate(VC);

                            (new System.Threading.Thread(delegate () { VC.Maintenance.PreUpdate(mainForm); })).Start();

                            // (new System.Threading.Thread(delegate () { VC.Maintenance.Update(mainForm, VC, VC.SourceList.FindLast(x => x.Id == id)); })).Start();
                        }
                }
            }
        }

        private void btnDelSource_Click(object sender, EventArgs e)
        {

        }
    }
}
