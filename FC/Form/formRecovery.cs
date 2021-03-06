﻿using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FilmCollection
{
    public partial class RecoveryForm : Form
    {
        internal string recoverBase = null;

        public RecoveryForm()
        {
            InitializeComponent();
        }

        private void RecoveryForm_Load(object sender, EventArgs e)
        {
            LoadBase();
        }

        public void LoadBase()
        {
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Дата", 80);
            listView1.Columns.Add("Время", 80);
            listView1.Columns.Add("Размер", 80);
            listView1.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            FileInfo[] files = directory.GetFiles("VideoList_*.xml", SearchOption.AllDirectories);


            for (int i = 0; i < files.Length; i++)
            {
                string[] subStrings = files[i].ToString().Split('_');

                if (!cbBadBase.Checked)
                    if (files[i].Length < 2 || subStrings.Length == 4)
                        continue;   // если видимость сбойных файлов отключена, то пропускаем

                if (subStrings.Length < 3)
                    continue;   // пропускаем файлы без даты

                ListViewItem li = new ListViewItem();

                // Дата файла
                if (files[i].Length < 2 || subStrings.Length == 4)
                {
                    li.ForeColor = Color.Gray;
                    li.Font = new Font(listView1.Font, FontStyle.Strikeout);
                }
                li.Text = subStrings[1];
                listView1.Items.Add(li);

                // Время создания файла
                string time = (subStrings.Length == 4) ? (subStrings[2]) : (subStrings[2].Remove(subStrings[2].Length - 4, 4));
                li.SubItems.Add(time);

                // Размер файла базы
                long Size = files[i].Length;
                string _size = "";

                if (Size <= 1024)
                {
                    _size = Size.ToString() + " Байт";
                }
                if (1024 < Size && Size <= 1024 * 1024)
                {
                    _size = (Math.Round((float)Size / 1024)).ToString() + " КБ";
                }
                if (Size > 1024 * 1024)
                {
                    _size = Math.Round(((double)Size / (1024 * 1024)), 1).ToString() + " МБ";
                }
                
                li.SubItems.Add(_size);
            }
        }

        private void btnEditOk_Click(object sender, EventArgs e)
        {
            ListViewItem selItem = listView1.SelectedItems[0];
            recoverBase = ("VideoList_" + selItem.SubItems[0].Text + "_" + selItem.SubItems[1].Text + ".xml");
        }

        private void cbBadBase_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Clear();
            LoadBase();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selItem = listView1.SelectedItems[0];
            if (selItem != null)
            {
                recoverBase = ("VideoList_" + selItem.SubItems[0].Text + "_" + selItem.SubItems[1].Text + ".xml");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private int sortColumn = -1;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }
            //listView1.Sort();

            //this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);
            //this.listView1.ListViewItemSorter = new ListViewItemComparer()
        }

    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
            ((ListViewItem)y).SubItems[col].Text);
            return returnVal;
        }
    }
}
