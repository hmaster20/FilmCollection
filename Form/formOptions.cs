using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class Options : Form
    {
        private MainForm mainForm;
        private RecordCollection VC;

        public Options(RecordCollection _videoCollection)
        {
            InitializeComponent();

            checkBox1.Checked = RecordOptions.ToTray;

            if (_videoCollection == null)
                throw new ArgumentNullException("_videoCollection", "_videoCollection не может содержать null");

            //if (_videoCollection.Options.Source != null)
            //{
            //    lBasePath.Text = _videoCollection.Options.Source;
            //}
            lCatalogPath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);

            //foreach (DataColumn dc in dataSet.Tables[0].Columns)
            //{
            //    checkedListBox1.Items.Add(dc.ColumnName);
            //}

            RecordOptions.getFormat().ForEach(x => clBoxFormats.Items.Add(x));


            //clBoxColumn.Items.AddRange

            List<Record> list = new List<Record>();

            //var obj = list[0].GetType();
            var obj = list.GetType();

            //now grab all properties
            var properties = obj.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                clBoxColumn.Items.Add(properties[i].Name);
            }

        }

        public Options(RecordCollection _videoCollection, MainForm mainForm) : this(_videoCollection)
        {
            this.VC = _videoCollection;
            this.mainForm = mainForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ManagedMMF.Program.MAIN_();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                RecordOptions.ToTray = true;
            }
            else
            {
                RecordOptions.ToTray = false;
            }
        }

        private void ColAdd_Click(object sender, EventArgs e)
        {
            if (clBoxColumn.CheckedItems.Count > 0)
            {
                foreach (var item in clBoxColumn.CheckedItems.OfType<string>().ToList())
                {
                    clBoxColumnCurrent.Items.Add(item);
                    clBoxColumn.Items.Remove(item);
                }
            }

            if (clBoxColumn.SelectedItems.Count > 0)
            {
                clBoxColumnCurrent.Items.Add(clBoxColumn.SelectedItem);
                clBoxColumn.Items.Remove(clBoxColumn.SelectedItem);
            }
        }

        private void ColRemove_Click(object sender, EventArgs e)
        {
            if (clBoxColumnCurrent.CheckedItems.Count > 0)
            {
                foreach (var item in clBoxColumnCurrent.CheckedItems.OfType<string>().ToList())
                {
                    clBoxColumn.Items.Add(item);
                    clBoxColumnCurrent.Items.Remove(item);
                }
            }

            if (clBoxColumnCurrent.SelectedItems.Count > 0)
            {
                clBoxColumn.Items.Add(clBoxColumnCurrent.SelectedItem);
                clBoxColumnCurrent.Items.Remove(clBoxColumnCurrent.SelectedItem);
            }
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            // e.Cancel = true;
            //if (this.DialogResult == DialogResult.OK)
            //{
            //    MessageBox.Show("Test");
            //}
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
                            (new System.Threading.Thread(delegate () { VC.Maintenance.Update(mainForm); })).Start();
                        }
                }
            }
        }








    }
}
