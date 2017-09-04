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
using System.Xml.Linq;

namespace FilmCollection
{
    public partial class formReindexer : Form
    {
        public formReindexer()
        {
            InitializeComponent();
        }

        public formReindexer(RecordCollection _videoCollection)
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName);


            XDocument xml = XDocument.Load(file);

            var nodes = (from n in xml.Descendants("media")
                         select n.Element("Id").Value
                 ).ToList();

            List<string> nn = new List<string>();
            nn = nodes;



            var duplicatesSs = nodes.GroupBy(s => s)
                .SelectMany(grp => grp.Skip(1)).ToList();

            var querys = nodes.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            var queryss = nodes.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Element = y.Key, Counter = y.Count() })
              .ToList();

            var duplicateKeys = nn.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key)
                        .ToList();



            XDocument xmlErr = XDocument.Load(file);

            foreach (var item in querys)
            {
                var nodesErr = (from n in xmlErr.Descendants("media")
                                where n.Element("Id").Value == item //"0"
                                select n.Element("Name").Value
                                ).ToList();

                foreach (var node in nodesErr)
                {
                    Console.WriteLine(node.Trim());
                }

            }







            XDocument xml2 = XDocument.Load(file);

            var ActorNodes = (from n in xml2.Descendants("Actor")
                         select n.Element("id").Value
                         ).ToList();

            List<string> nn2 = new List<string>();
            nn2 = ActorNodes;

            var duplicateKeys2 = nn2.GroupBy(x => x)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);




            //foreach (var item in nodes)
            //{
            //    Console.WriteLine(item.Trim());
            //}



            //XmlTextReader reader = new XmlTextReader(file);
            //while (reader.Read())
            //{
            //    if (reader.ReadToDescendant("title"))
            //    {
            //        reader.Read();//this moves reader to next node which is text 
            //                      //result = reader.Value; //this might give value than 
            //                      //break;
            //        Console.WriteLine(reader.Value.Trim());
            //    }
            //}
        }
    }
}
