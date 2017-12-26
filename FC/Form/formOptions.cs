using FC.Provider;
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

            ListUpdate(_videoCollection);

            if (_videoCollection.SourceList.Count < 1)
            {
                btnAddSource.Enabled = false;
                btnChangeSource.Enabled = false;
            }
            else
            {
                btnAddSource.Enabled = true;
                btnChangeSource.Enabled = true;
            }

            lCatalogPath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);

            //foreach (DataColumn dc in dataSet.Tables[0].Columns)
            //{
            //    checkedListBox1.Items.Add(dc.ColumnName);
            //}

            RecordOptions.getFormat().ForEach(x => clBoxFormats.Items.Add(x));

            List<Record> list = new List<Record>();
            var obj = list.GetType();

            var properties = obj.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                clBoxColumn.Items.Add(properties[i].Name);
            }

            foreach (var item in RecordOptions.getFormat())
            {
                lbtpCountry.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(GenreVideo_Rus)))
            {
                lbtpGenre.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(CategoryVideo_Rus)))
            {
                lbtpCategory.Items.Add(item);
            }

            btnChangeSource.Enabled = false;

        }

        private void ListUpdate(RecordCollection _videoCollection)
        {
            listBase.Items.Clear();
            if (_videoCollection.SourceList.Count > 0)
            {
                _videoCollection.SourceList.ForEach(x => listBase.Items.Add(x.Source));
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
            RecordOptions.ToTray = (checkBox1.Checked) ? true : false;
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
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuAdd.Show(ptLowerLeft);

        }

        private void tsPathFolder_Click(object sender, EventArgs e)
        {
            using (fromChangeText form = new fromChangeText())
            {
                if (form.ShowDialog() == DialogResult.OK && VC != null)
                {
                    string newSource = form.tbChangeText.Text;
                    CreateNewSource(newSource);
                }
            }
        }

        private void btnAddSource_(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbDialog = new FolderBrowserDialog())
            {
                fbDialog.Description = "Укажите расположение файлов мультимедиа:";
                fbDialog.ShowNewFolderButton = false;

                DialogResult dialogStatus = fbDialog.ShowDialog();  // Запрашиваем новый каталог с коллекцией видео
                if (dialogStatus == DialogResult.OK)
                {
                    string folderName = fbDialog.SelectedPath;  //Извлечение имени папки
                    CreateNewSource(folderName);
                }
            }
        }

        private void CreateNewSource(string folderName)
        {
            DirectoryInfo directory = new DirectoryInfo(folderName);    //создание объекта для доступа к содержимому папки
            if (directory.Exists)
                if (VC != null)
                {
                    int id = VC.AddSource(directory.FullName);
                    ListUpdate(VC);

                    mainForm.UPD();
                    //(new System.Threading.Thread(delegate () { VC.Maintenance.PreUpdate(mainForm); })).Start();

                    // (new System.Threading.Thread(delegate () { VC.Maintenance.Update(mainForm, VC, VC.SourceList.FindLast(x => x.Id == id)); })).Start();
                }
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage _tabPage = tabControl2.TabPages[e.Index];
            Rectangle _tabBounds = tabControl2.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
                g.FillRectangle(Brushes.White, e.Bounds);
            }
            else
            {
                g.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
            }
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, SystemFonts.DefaultFont, Brushes.Black, _tabBounds, new StringFormat(_stringFlags));
        }


        private void btnChangeSource_Click(object sender, EventArgs e)
        {
            using (fromChangeText form = new fromChangeText())
            {
                var item = listBase.SelectedItems[0];

                if (!string.IsNullOrWhiteSpace(item.ToString()))
                {
                    form.tbChangeText.Text = item.ToString();

                    if (form.ShowDialog() == DialogResult.OK && VC != null)
                    {
                        string newSource = form.tbChangeText.Text;
                        Sources oldSource = VC.SourceList.FindLast(x => x.Source == item.ToString());
                        oldSource.Source = newSource;

                        VC.Save();
                        VC.SaveToFile();
                        mainForm.FormLoad(true);

                        listBase.Items[listBase.SelectedIndex] = newSource;
                    }
                }
            }
        }


        private void listBase_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBase.SelectedItems.Count > 0)
            {
                var item = listBase.SelectedItems[0];

                if (!string.IsNullOrWhiteSpace(item.ToString()))
                {
                    btnChangeSource.Enabled = true;
                }
            }
        }


    }
}