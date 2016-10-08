using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace FilmCollection
{
    public partial class EditForm : Form
    {
        public Record rec = null;


        public EditForm()               // Конструктор по умолчанию
        {
            InitializeComponent();

            cBoxTypeVideo.Items.AddRange(new object[] {     // Создание списка для типа записи (Фильм. Сериал, Мультфильм)
            "Фильм",
            "Сериал",
            "Мультфильм"});

            cBoxGenre.Items.AddRange(new object[] {         // Создание списка жанров
            "Боевик",
            "Вестерн",
            "Комедия"});
        }

        public EditForm(Record record)  // Переопределенный конструктор по умолчанию
        {
            InitializeComponent();

            cBoxTypeVideo.Items.AddRange(new object[] {     // Создание списка для типа записи (Фильм. Сериал, Мультфильм)
            "Фильм",
            "Сериал",
            "Мультфильм"});

            cBoxGenre.Items.AddRange(new object[] {         // Создание списка жанров
            "Боевик",
            "Вестерн",
            "Комедия"});

            rec = record;

            tbName.Text = record.Name;
            tbYear.Text = record.Year;
            tbCountry.Text = record.Country;
            numericTime.Value = record.Time;
            tbDescription.Text = record.Description;
            tbFileName.Text = record.FileName;

            switch (record.Category)
            {
                case CategoryVideo.Film: cBoxTypeVideo.SelectedIndex = 0; break;
                case CategoryVideo.Series: cBoxTypeVideo.SelectedIndex = 1; break;
                case CategoryVideo.Cartoon: cBoxTypeVideo.SelectedIndex = 2; break;
            }

            switch (record.GenreVideo)
            {
                case GenreVideo.Action: cBoxGenre.SelectedIndex = 0; break;
                case GenreVideo.Vestern: cBoxGenre.SelectedIndex = 1; break;
                case GenreVideo.Comedy: cBoxGenre.SelectedIndex = 2; break;
            }

        }


        private void btnEditOk_Click(object sender, EventArgs e)    // Сохранение измененных параметров
        {
            CategoryVideo category;
            GenreVideo genre;

            switch (cBoxGenre.SelectedIndex)
            {
                case 0: genre = GenreVideo.Action; break;
                case 1: genre = GenreVideo.Vestern; break;
                case 2: genre = GenreVideo.Comedy; break;
                default: MessageBox.Show("Не выбран тип"); return;
            }

            switch (cBoxTypeVideo.SelectedIndex)
            {
                case 0: category = CategoryVideo.Film; break;
                case 1: category = CategoryVideo.Series; break;
                case 2: category = CategoryVideo.Cartoon; break;
                default: MessageBox.Show("Не выбран тип"); return;
            }


            if (rec == null)
                rec = new Record();

            rec.Name = tbName.Text;
            rec.Year = tbYear.Text;
            rec.Country = tbCountry.Text;
            rec.Time = (int)numericTime.Value;
            rec.Category = category;
            rec.GenreVideo = genre;
            rec.Description = tbDescription.Text;

            DialogResult = DialogResult.OK;
        }




        private void button1_Click(object sender, EventArgs e)      // отображение данных в RichTextBox и сохранение
        {

            //dynamicRichTextBox.BackColor = Color.White;
            //dynamicRichTextBox.Clear();
            //dynamicRichTextBox.BulletIndent = 10;
            //dynamicRichTextBox.SelectionFont = new Font("Georgia", 16, FontStyle.Bold);
            //dynamicRichTextBox.SelectedText = "Mindcracker Network \n";
            //dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);
            //dynamicRichTextBox.SelectionBullet = true;
            //dynamicRichTextBox.SelectionColor = Color.DarkBlue;
            //dynamicRichTextBox.SelectedText = "C# Corner" + "\n";
            //dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);
            //dynamicRichTextBox.SelectionColor = Color.Orange;
            //dynamicRichTextBox.SelectedText = "VB.NET Heaven" + "\n";
            //dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);
            //dynamicRichTextBox.SelectionColor = Color.Green;
            //dynamicRichTextBox.SelectedText = ".Longhorn Corner" + "\n";
            //dynamicRichTextBox.SelectionColor = Color.Red;
            //dynamicRichTextBox.SelectedText = ".NET Heaven" + "\n";
            //dynamicRichTextBox.SelectionBullet = false;
            //dynamicRichTextBox.SelectionFont = new Font("Tahoma", 10);
            //dynamicRichTextBox.SelectionColor = Color.Gray;
            //dynamicRichTextBox.SelectedText = "This is a list of Mindcracker Network websites.\n";
            //dynamicRichTextBox.SelectionFont = new Font("Microsoft San Serif", 12);
            //dynamicRichTextBox.SelectedText = "Microsoft.\n";


            //RecordCollection _videoCollection = new RecordCollection();
            //_videoCollection.Txt = dynamicRichTextBox.Rtf.ToString();
            //_videoCollection.Save();

        }

        private void button2_Click(object sender, EventArgs e)      // загрузка данных в RichTextBox
        {
            //DirectoryInfo directory = new DirectoryInfo(@"C:\temp");

            //XmlDocument doc = new XmlDocument();
            //doc.Load("VideoList.xml");

            //XmlNodeList nodeList = doc.GetElementsByTagName("Txt");

            //foreach (XmlNode node in nodeList)
            //{
            //    //dynamicRichTextBox.AppendText(node.ChildNodes[0].Value);
            //    dynamicRichTextBox.Rtf = node.ChildNodes[0].Value;
            //}

        }


        private void btnBold_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = dynamicRichTextBox.SelectionFont;
            if (SelectedText_Font != null)
                dynamicRichTextBox.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = dynamicRichTextBox.SelectionFont;
            if (SelectedText_Font != null)
                dynamicRichTextBox.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = dynamicRichTextBox.SelectionFont;
            if (SelectedText_Font != null)
                dynamicRichTextBox.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Underline);
        }

        private void btnSizePlus_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = dynamicRichTextBox.SelectionFont;
            int count;
            count = Convert.ToInt32(SelectedText_Font.Size);
            if (SelectedText_Font != null)
                dynamicRichTextBox.SelectionFont = new Font(SelectedText_Font.ToString(), ++count);
        }

        private void btnSizeMinus_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = dynamicRichTextBox.SelectionFont;
            int count;
            count = Convert.ToInt32(SelectedText_Font.Size);
            if (SelectedText_Font != null)
                dynamicRichTextBox.SelectionFont = new Font(SelectedText_Font.ToString(), --count);
        }



        private void ToggleBold()
        {
            if (dynamicRichTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = dynamicRichTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (dynamicRichTextBox.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                dynamicRichTextBox.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ToggleBold();
        }

        private void EditForm_Load(object sender, EventArgs e)          // Всплывающая подсказка
        {
            toolTipEditForm.SetToolTip(labelTypeVideo,
            @"Необходимо выбрать один из следующих типов:
            Фильм - Полнометражный фильм (состоит из одного файла)
            Сериал - многосерийный фильм
            Мультфильм - мультипликационный фильм
            Прочее - короткометражные фильмы, зарисовки и т.д");

            toolTipEditForm.SetToolTip(lblTime,
            "Указать в минутах");


            toolTipEditForm.SetToolTip(btnFileNameEdit,
            "Переименовать файл");       
        }

        private void btnFileNameEdit_Click(object sender, EventArgs e)
        {
            tbFileName.Enabled = true;
            btnFileNameEdit.Enabled = false;
        }
    }
}
