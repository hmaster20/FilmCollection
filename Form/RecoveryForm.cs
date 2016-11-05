using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace FilmCollection
{
    public partial class RecoveryForm : Form
    {
        public string recoverBase = null;

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
            //listView1.Columns.Add("Название", 70);
            listView1.Columns.Add("Дата", 80);
            listView1.Columns.Add("Время", 80);
            listView1.Columns.Add("Размер", 80);

            listView1.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            FileInfo[] files = directory.GetFiles("VideoList_*.xml", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                string[] subStrings = files[i].ToString().Split('_');

                if (subStrings.Length == 4)
                {
                    //MessageBox.Show("Test");
                }
                //if (subStrings[4].Contains("BAD"))
                //{
                //   // continue;
                //}

                // Дата файла
                if (files[i].Length < 2 || subStrings.Length == 4)
                    listView1.Items.Add(subStrings[1]).Font = new Font(listView1.Font, FontStyle.Strikeout);
                else
                    listView1.Items.Add(subStrings[1]);
                //listView1.Items[i].SubItems.Add(subStrings[1]);

                // Время создания файла
                if (subStrings.Length == 4)
                {
                    listView1.Items[i].SubItems.Add(subStrings[2]);
                }
                else
                {
                    listView1.Items[i].SubItems.Add(subStrings[2].Remove(subStrings[2].Length - 4, 4));
                }
               // listView1.Items[i].SubItems.Add(subStrings[2].Remove(subStrings[2].Length - 4, 4));

                // Размер файла базы
                long Size = files[i].Length;
                string _size = "";
                if (Size <= 1024) _size = Size.ToString() + " Байт";
                else if (Size > 1024 && Size <= 1024 * 1024) _size = (Math.Round((float)Size / 1024)).ToString() + " КБ";
                else if (Size > 1024 * 1024) _size = Math.Round(((double)Size / (1024 * 1024)), 1).ToString() + " МБ";
                listView1.Items[i].SubItems.Add(_size);
            }



            //IEnumerable<FileInfo> Bases = directory.GetFiles("VideoList_*.xml").Where(f => !f.Name.Contains("BAD"));
            //int BaseCount = Bases.Count();

            //for (int i = 0; i < BaseCount; i++)
            //{
            //    string[] subStrings = files[i].ToString().Split('_');

            //    // Дата файла
            //    if (files[i].Length < 2)
            //        listView1.Items.Add(subStrings[1]).Font = new Font(listView1.Font, FontStyle.Strikeout);
            //    else
            //        listView1.Items.Add(subStrings[1]);
            //    //listView1.Items[i].SubItems.Add(subStrings[1]);

            //    // Время создания файла
            //    listView1.Items[i].SubItems.Add(subStrings[2].Remove(subStrings[2].Length - 4, 4));

            //    // Размер файла базы
            //    long Size = files[i].Length;
            //    string _size = "";
            //    if (Size <= 1024) _size = Size.ToString() + " Байт";
            //    else if (Size > 1024 && Size <= 1024 * 1024) _size = (Math.Round((float)Size / 1024)).ToString() + " КБ";
            //    else if (Size > 1024 * 1024) _size = Math.Round(((double)Size / (1024 * 1024)), 1).ToString() + " МБ";
            //    listView1.Items[i].SubItems.Add(_size);
            //}
            
        }

        private void btnEditOk_Click(object sender, EventArgs e)
        {
            ListViewItem selItem = listView1.SelectedItems[0];

            recoverBase = ("VideoList_" + selItem.SubItems[0].Text + "_" + selItem.SubItems[1].Text + ".xml");
        }
    }
}
