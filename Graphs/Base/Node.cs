using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace IND_KDM.Graphs.Base
{
    public class Node
    {
        public const int DefaultRadius = 20;
        public readonly int Radius = DefaultRadius;

        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; }
        public Point Anchor => new Point(X, Y);
        public Point Center => new Point(X + Radius, Y + Radius);
        public Size Size => new Size(Radius * 2, Radius * 2);
        public Rectangle Bounds => new Rectangle(Anchor, Size);
        public bool Selected { get; set; }
        public bool Hovered { get; set; }
        public Color Color { get; set; } = Color.White;
        public Color TextColor => Color.GetBrightness() > 0.5 ? Color.Black : Color.White;
        public Color BorderColor => Selected ? Color.DarkCyan : Hovered ? Color.Blue : Color.Black;
        public IEnumerable<Edge> Edges => _edges;
        public IEnumerable<Node> Connections => _connections;

        private readonly List<Edge> _edges = new List<Edge>();
        private readonly List<Node> _connections = new List<Node>();

        public Node(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public Node(int x, int y) : this(x, y, 0) { }

        ~Node()
        {
            var connections = _connections.ToArray();
            foreach (var node in connections)
            {
                RemoveConnection(node);
            }
        }

        public void AddConnection(Node node)
        {
            if (_connections.Contains(node)) return;

            AddConnectionLogic(node);
            node.AddConnectionLogic(this);
        }

        public void AddConnection(Node node, int weight)
        {
            Edge edge;
            if ((edge = _edges.FirstOrDefault(e => e.Node2 == node)) != null)
            {
                edge.Weight = weight;
                return;
            }

            AddConnectionLogic(node, weight);
            node.AddConnectionLogic(this, weight);
        }

        public void RemoveConnection(Node node)
        {
            if (!_connections.Contains(node)) return;

            RemoveConnectionLogic(node);
            node.RemoveConnectionLogic(this);
        }

        public void RemoveConnections()
        {
            _connections.ForEach(node => node.RemoveConnectionLogic(this));
            _edges.Clear();
            _connections.Clear();
        }

        private Edge AddConnectionLogic(Node node)
        {
            var edge = new Edge(this, node);
            _edges.Add(edge);
            _connections.Add(node);

            return edge;
        }

        private Edge AddConnectionLogic(Node node, int weight)
        {
            var edge = AddConnectionLogic(node);
            edge.Weight = weight;
            return edge;
        }

        private void RemoveConnectionLogic(Node node)
        {
            var edge = _edges.Find(e => e.Node2 == node);
            _edges.Remove(edge);
            _connections.Remove(node);
        }
    }
}
