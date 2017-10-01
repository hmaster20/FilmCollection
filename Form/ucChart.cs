using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Msagl;

namespace FilmCollection
{
    public partial class ucChart : UserControl
    {
        //public ucChart()
        //{
        //    InitializeComponent();
        //    ShowCharts();
        //}

        public ucChart() => InitializeComponent();


        public void update(Record _record)
        {
            //this.record = _record;
            //ShowCharts();

            Dictionary<string, string> rcDic = new Dictionary<string, string>();

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
                    //rcDic.Add(_record.combineLink.media.Name, act.FIO);
                    rcDic.Add(act.FIO, _record.combineLink.media.Name);
                }
                Show(rcDic);
            }
        }

        private void Show(Dictionary<string, string> rcDic)
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            foreach (var item in rcDic)
            {
                graph.AddEdge(item.Value, item.Key);
            }
            //string f = rcDic.Keys.First();
            string f = rcDic.Values.First();

            graph.FindNode(f).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Gray;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode(f);
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            viewer.Graph = graph;
            this.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(viewer);
            this.ResumeLayout();
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

    }
}
