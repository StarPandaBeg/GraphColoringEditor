using IND_KDM.Graphs.Base;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IND_KDM.Graphs
{
    public class GraphRenderer
    {
        private Graph _graph;
        private SolidBrush _nodeBrush = new SolidBrush(Color.White);
        private SolidBrush _textBrush = new SolidBrush(Color.Black);
        private Pen _borderPen = new Pen(Color.Black, 1.8f);
        private Pen _edgePen = new Pen(Color.DarkSlateGray, 2f);

        private static readonly Font LabelFont = new Font("Microsoft Sans Serif", 14);
        private static readonly Font WeightLabelFont = new Font("Microsoft Sans Serif", 8);
        private static readonly StringFormat LabelFormat = new StringFormat();

        static GraphRenderer() {
            LabelFormat.Alignment = StringAlignment.Center;
            LabelFormat.LineAlignment = StringAlignment.Center;
        }

        public GraphRenderer(Graph graph)
        {
            _graph = graph;
        }

        public void Draw(Graphics graphics)
        {
            foreach (var edge in _graph.Edges)
            {
                if (_graph.IsWeighted)
                {
                    DrawWeightedEdge(graphics, edge);
                    continue;
                }
                DrawEdge(graphics, edge);
            }

            foreach (var node in _graph.Nodes)
            {
                DrawNode(graphics, node);
            }
        }

        private void DrawEdge(Graphics graphics, Edge edge)
        {
            graphics.DrawLine(_edgePen, edge.Node1.Center, edge.Node2.Center);
        }

        private void DrawWeightedEdge(Graphics graphics, Edge edge)
        {
            _textBrush.Color = Color.Black;

            var pointA = edge.Node1.Center;
            var pointB = edge.Node2.Center;
            var center = new Point((pointA.X + pointB.X) / 2, (pointA.Y + pointB.Y) / 2);

            Size labelSize = TextRenderer.MeasureText(edge.Weight.ToString(), WeightLabelFont);
            graphics.DrawString(edge.Weight.ToString(), WeightLabelFont, _textBrush, center.X, center.Y, LabelFormat);

            graphics.DrawLine(_edgePen, pointA, ShrinkVector(pointA, center, labelSize.Width / 2));
            graphics.DrawLine(_edgePen, pointB, ShrinkVector(pointB, center, labelSize.Width / 2));
        }

        private void DrawNode(Graphics graphics, Node node)
        {
            _nodeBrush.Color = node.Color;
            _borderPen.Color = node.BorderColor;
            _textBrush.Color = node.TextColor;

            graphics.FillEllipse(_nodeBrush, node.Bounds);
            graphics.DrawEllipse(_borderPen, node.Bounds);

            graphics.DrawString(node.Value.ToString(), LabelFont, _textBrush, node.X + node.Radius, node.Y + node.Radius, LabelFormat);
        }

        private Point ShrinkVector(Point a, Point b, double distance) {

            var AB_x = b.X - a.X;
            var AB_y = b.Y - a.Y;

            var lengthAB = Math.Sqrt(Math.Pow(AB_x, 2) + Math.Pow(AB_y, 2));
            var unitVector_x = AB_x / lengthAB;
            var unitVector_y = AB_y / lengthAB;

            return new Point((int)(b.X - distance * unitVector_x), (int)(b.Y - distance * unitVector_y));
        }
}
}
