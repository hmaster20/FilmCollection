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
        public ucChart()
        {
            InitializeComponent();

            ShowCharts();
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
