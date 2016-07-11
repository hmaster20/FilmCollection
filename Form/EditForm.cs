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
        public EditForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dynamicRichTextBox.BackColor = Color.White;

            dynamicRichTextBox.Clear();


            dynamicRichTextBox.BulletIndent = 10;

            dynamicRichTextBox.SelectionFont = new Font("Georgia", 16, FontStyle.Bold);

            dynamicRichTextBox.SelectedText = "Mindcracker Network \n";

            dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);

            dynamicRichTextBox.SelectionBullet = true;

            dynamicRichTextBox.SelectionColor = Color.DarkBlue;

            dynamicRichTextBox.SelectedText = "C# Corner" + "\n";

            dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);

            dynamicRichTextBox.SelectionColor = Color.Orange;

            dynamicRichTextBox.SelectedText = "VB.NET Heaven" + "\n";

            dynamicRichTextBox.SelectionFont = new Font("Verdana", 12);

            dynamicRichTextBox.SelectionColor = Color.Green;

            dynamicRichTextBox.SelectedText = ".Longhorn Corner" + "\n";

            dynamicRichTextBox.SelectionColor = Color.Red;

            dynamicRichTextBox.SelectedText = ".NET Heaven" + "\n";

            dynamicRichTextBox.SelectionBullet = false;

            dynamicRichTextBox.SelectionFont = new Font("Tahoma", 10);

            dynamicRichTextBox.SelectionColor = Color.Black;

            dynamicRichTextBox.SelectedText = "This is a list of Mindcracker Network websites.\n";

            RecordCollection _videoCollection = new RecordCollection();
            _videoCollection.Txt = dynamicRichTextBox.Rtf.ToString();
            _videoCollection.Save();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp");

            XmlDocument doc = new XmlDocument();
            doc.Load("VideoList.xml");

            XmlNodeList nodeList = doc.GetElementsByTagName("Txt");

            foreach (XmlNode node in nodeList)
            {
                //dynamicRichTextBox.AppendText(node.ChildNodes[0].Value);
                dynamicRichTextBox.Rtf = node.ChildNodes[0].Value;
            }

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




    }
}
