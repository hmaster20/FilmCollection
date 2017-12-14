﻿using System;
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
                btnDelSource.Enabled = false;
            }
            else
            {
                btnAddSource.Enabled = true;
                btnDelSource.Enabled = true;
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

            














            ///////////////////////////////////////////////////////////////////


            //Graphics g = e.Graphics;
            //Brush _textBrush;

            //TabPage _tabPage = tabControl2.TabPages[e.Index];
            //Rectangle _tabBounds = tabControl2.GetTabRect(e.Index);

            //if (e.State == DrawItemState.Selected)
            //{
            //    _textBrush = new SolidBrush(Color.LightBlue);
            //    g.FillRectangle(Brushes.LightGray, e.Bounds);
            //}
            //else
            //{
            //    _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
            //    e.DrawBackground();
            //}
            //Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);


            //StringFormat _stringFlags = new StringFormat();
            //_stringFlags.Alignment = StringAlignment.Center;
            //_stringFlags.LineAlignment = StringAlignment.Center;
            //g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));




            ///////////////////////////////////////////////////////////////////




            //Graphics g = e.Graphics;
            //Brush _textBrush;

            //// Get the item from the collection.
            //// Получить элемент из коллекции.
            //TabPage _tabPage = tabControl2.TabPages[e.Index];

            //// Get the real bounds for the tab rectangle.
            //// Получите реальные границы прямоугольника вкладки.
            //Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            //if (e.State == DrawItemState.Selected)
            //{

            //    // Draw a different background color, and don't paint a focus rectangle.
            //    // Нарисуйте другой цвет фона и не нарисуйте прямоугольник фокуса.
            //    _textBrush = new SolidBrush(Color.Red);
            //    //g.FillRectangle(Brushes.Gray, e.Bounds);
            //}
            //else
            //{
            //    _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
            //    e.DrawBackground();
            //}

            //// Use our own font.
            //// Используйте наш собственный шрифт.
            ////Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);
            //Font _tabFont = new Font("Microsoft Sans Serif", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);


            //// Draw string. Center the text.
            //// Строка рисования. Центрируйте текст.
            //StringFormat _stringFlags = new StringFormat();
            //_stringFlags.Alignment = StringAlignment.Center;
            //_stringFlags.LineAlignment = StringAlignment.Center;
            //g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}