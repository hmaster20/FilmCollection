using System;
using System.Drawing;
using System.IO;
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
            //DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            //FileInfo[] files = directory.GetFiles("VideoList_*.xml", SearchOption.AllDirectories);

            //for (int i = 0; i < files.Length; i++)
            //{
            //    // listView1.Items.Add(files[i].Name).BackColor = (files[i].Length > 2) ? Color.Green : Color.Red;
            //    // listView1.Items.Add(files[i].Name).Font = new Font(listView1.Font, FontStyle.Strikeout);

            //    if (files[i].Length < 2)
            //    {
            //        listView1.Items.Add(files[i].Name).Font = new Font(listView1.Font, FontStyle.Strikeout);
            //        continue;
            //    }
            //    listView1.Items.Add(files[i].Name);
            //}

            //////======================================


            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Название", 70);
            listView1.Columns.Add("Дата", 80);
            listView1.Columns.Add("Время", 60);
            listView1.Columns.Add("Размер", 60);

            listView1.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directory.GetFiles("VideoList_*.xml", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                string[] subStrings = files[i].ToString().Split('_');
                if (files[i].Length < 2)
                    listView1.Items.Add(subStrings[0]).Font = new Font(listView1.Font, FontStyle.Strikeout);
                else
                    listView1.Items.Add(subStrings[0]);
                listView1.Items[i].SubItems.Add(subStrings[1]);
                listView1.Items[i].SubItems.Add(subStrings[2].Remove(subStrings[2].Length - 4, 4));
                listView1.Items[i].SubItems.Add(files[i].Length.ToString());
            }
        }

        private void btnEditOk_Click(object sender, EventArgs e)
        {
            recoverBase = listView1.SelectedItems.ToString();
            DialogResult = DialogResult.OK;
        }
    }
}
