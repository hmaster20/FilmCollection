using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
//using Microsoft.Msagl.Core.Layout;
//using Microsoft.Msagl;

namespace FilmCollection
{
    public partial class ucChart : UserControl
    {
        private MainForm main { get; set; }
        private Dictionary<string, string> rcDic { get; set; }

        public ucChart()
        {
            InitializeComponent();
            SuspendLayout();
            Controls.Add(viewer);
            viewer.Dock = DockStyle.Fill;
            viewer.LayoutAlgorithmSettingsButtonVisible = false;
            ResumeLayout();
        }
        GViewer viewer = new GViewer();

       public void button1_Click(object sender, EventArgs e)
        {
            var tree = new PhyloTree();
            var edge = (PhyloEdge)tree.AddEdge("a", "b");
            //edge.Length = 0.8;
            edge = (PhyloEdge)tree.AddEdge("a", "c");
            //edge.Length = 0.2;
            tree.AddEdge("c", "d");
            tree.AddEdge("c", "e");
            tree.AddEdge("c", "f");
            tree.AddEdge("e", "0");
            tree.AddEdge("e", "1");
            tree.AddEdge("e", "2");

            viewer.Graph = tree;
        }


        public void button2_Click(object sender, EventArgs e)
        {
            var tree = new PhyloTree();
            var edge = (PhyloEdge)tree.AddEdge("a", "b");
            //edge.Length = 0.8;
            edge = (PhyloEdge)tree.AddEdge("a", "c");
            //edge.Length = 0.2;
            tree.AddEdge("z", "d");
            tree.AddEdge("z", "e");
            tree.AddEdge("z", "f");
            tree.AddEdge("z", "0");
            tree.AddEdge("e", "1");
            tree.AddEdge("e", "2");

            viewer.Graph = tree;
        }






        internal void update(Record _record, MainForm mainForm)
        {
            main = mainForm;

            rcDic = new Dictionary<string, string>();
            RecordCollection _videoCollection = RecordCollection.GetInstance();
            List<Actor> acts = new List<Actor>();

            if (_record.combineLink.media.ActorListID != null)
                foreach (int ListID in _record.combineLink.media.ActorListID)
                    if (_videoCollection.ActorList.Exists(act => act.id == ListID))
                        acts.Add(_videoCollection.ActorList.FindLast(act => act.id == ListID));

            if (acts.Count > 0)
            {
                foreach (Actor act in acts)
                {
                    if (!rcDic.ContainsKey(act.FIO))
                    {
                        rcDic.Add(act.FIO, _record.combineLink.media.Name);
                    }
                }
                Show(rcDic);
            }
        }



        private void Show(Dictionary<string, string> rcDic)
        {
            GViewer viewer = new GViewer();
            Graph graph = new Graph("graph");
            string RootNode = rcDic.Values.First();

            foreach (var item in rcDic)
            {
                graph.AddEdge(item.Value, item.Key);
            }

            graph.FindNode(RootNode).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Gray;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode(RootNode);
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            viewer.Graph = graph;
            viewer.CurrentLayoutMethod = LayoutMethod.MDS;
            viewer.MouseDoubleClick += Viewer_MouseDoubleClick;
            viewer.MouseClick += Viewer_MouseClick;
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
        }

        private GViewer _viewer { get; set; }

        private void Viewer_MouseClick(object sender, MouseEventArgs e)
        {
            GViewer viewer = sender as GViewer;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (viewer.SelectedObject is Node)
                {
                    _viewer = viewer;
                    Node node = viewer.SelectedObject as Node;
                    Debug.Print(node.Id);
                    ChartMenu.Show(viewer, new Point(e.X, e.Y));
                }
            }
        }

        private void Viewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GViewer viewer = sender as GViewer;
            if (viewer.SelectedObject is Node)
            {
                Node node = viewer.SelectedObject as Node;
                viewer.Graph.FindNode(node.Id).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Gray;
                //Debug.Print(node.Id);
                //Debug.Print(node.Label.Text);
                if (main != null)
                {
                    main.SelectActor(node.Id);
                }
            }
        }


        void Test_Tree(object sender, EventArgs e)
        {
            GViewer viewer = new GViewer();
            var tree = new PhyloTree();
            var edge = (PhyloEdge)tree.AddEdge("a", "b");
            //edge.Length = 0.8;
            edge = (PhyloEdge)tree.AddEdge("a", "c");
            //edge.Length = 0.2;
            tree.AddEdge("c", "d");
            tree.AddEdge("c", "e");
            tree.AddEdge("c", "f");
            tree.AddEdge("e", "0");
            tree.AddEdge("e", "1");
            tree.AddEdge("e", "2");

            viewer.Graph = tree;
            viewer.LayoutAlgorithmSettingsButtonVisible = false;
            this.Controls.Add(viewer);
        }


        private void SaveToImage(object sender, EventArgs e)
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "B");
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
            Microsoft.Msagl.GraphViewerGdi.GraphRenderer renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(graph);
            renderer.CalculateLayout();
            int width = 50;
            Bitmap bitmap = new Bitmap(width, (int)(graph.Height * (width / graph.Width)), PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            bitmap.Save("test.png");
        }



        private void ShowCharts()
        {
            //create a form 
            //System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;

            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            //form.Size = new Size(800, 800);
            this.SuspendLayout();
            //form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            //form.Controls.Add(viewer);
            this.ResumeLayout();
            //form.ResumeLayout();
            //show the form 
            //form.ShowDialog();
        }


        private static void Viewer_MouseUp(object sender, MouseEventArgs e)
        {
            var gviewer = (Microsoft.Msagl.GraphViewerGdi.GViewer)sender;
            var dnode = gviewer.ObjectUnderMouseCursor as Microsoft.Msagl.GraphViewerGdi.DNode;
            if (dnode == null) return;
            if (dnode.Node.LabelText == "C")
                MessageBox.Show("C is clicked");
        }

        private void tsDetails_Click(object sender, EventArgs e)
        {
            if (_viewer.SelectedObject is Node)
            {
                Node node = _viewer.SelectedObject as Node;
                RecordCollection _videoCollection = RecordCollection.GetInstance();
                List<Actor> acts = new List<Actor>();

                if (_videoCollection.ActorList.Exists(x => x.FIO == node.Id))
                {
                    if (_videoCollection.ActorList.First(x => x.FIO == node.Id).VideoID.Count > 0)
                    {
                        foreach (int ListID in _videoCollection.ActorList.First(x => x.FIO == node.Id).VideoID)
                        {
                            string film = _videoCollection.CombineList.First(x => x.media.Id == ListID).media.Name;
                            if (!rcDic.ContainsKey(film))
                            {
                                rcDic.Add(film, node.Id);
                            }                            
                        }
                        Show(rcDic);
                    }
                } 
            }
        }
    }
}
