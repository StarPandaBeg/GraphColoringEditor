using IND_KDM.Graphs.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IND_KDM.Graphs
{
    public class Graph
    {
        public event Action OnChange;
        public int Count => _nodes.Count;
        public int EdgesCount => _edges.Count;
        public int LastValue => _nodes.Count == 0 ? 0 : _nodes.Last().Value;
        public bool IsWeighted => _edges.Any(e => e.HasWeight);
        public IReadOnlyList<Node> Nodes => _nodes;
        public IReadOnlyList<Edge> Edges => _edges;

        private readonly List<Node> _nodes = new List<Node>();
        private readonly List<Edge> _edges = new List<Edge>();

        public void AddNode(Node n)
        {
            _nodes.Add(n);
            Refresh();
        }

        public Node AddNode(int x, int y, int value)
        {
            var node = new Node(x, y, value);
            AddNode(node);
            return node;
        }

        public void AddEdge(Edge edge)
        {
            var hasA = _nodes.Find(n => n == edge.Node1) != null;
            var hasB = _nodes.Find(n => n == edge.Node2) != null;
            
            if (!hasA && !hasB)
            {
                throw new InvalidOperationException("This edge does not belong to the graph");
            }

            if (!hasA) AddNode(edge.Node1);
            if (!hasB) AddNode(edge.Node2);

            if (edge.HasWeight)
            {
                edge.Node1.AddConnection(edge.Node2, edge.Weight);
            } else
            {
                edge.Node1.AddConnection(edge.Node2);
            }

            
            _edges.Add(edge);
        }

        public void AddEdge(Node node1, Node node2)
        {
            AddEdge(new Edge(node1, node2));
        }

        public void AddEdge(Node node1, Node node2, int weight)
        {
            AddEdge(new Edge(node1, node2, weight));
        }

        public Node GetNode(int value)
        {
            return _nodes.FirstOrDefault(n => n.Value == value);
        }

        public Edge GetEdge(Node node1, Node node2)
        {
            return _edges.FirstOrDefault(e =>
            {
                if (e.Node1 == node1 && e.Node2 == node2) return true;
                if (e.Node2 == node1 && e.Node1 == node2) return true;
                return false;
            });
        }

        public bool HasEdge(Node node1, Node node2)
        {
            return GetEdge(node1, node2) != null;
        }

        public bool HasEdge(Edge edge)
        {
            return HasEdge(edge.Node1, edge.Node2);
        }

        public void RemoveNode(Node node)
        {
            if (!_nodes.Contains(node)) return;

            foreach (var nodeOther in node.Connections) {
                _edges.Remove(GetEdge(node, nodeOther));
            }
            _nodes.Remove(node);
            Refresh();
        }

        public void RemoveEdge(Edge edge)
        {
            if (!_edges.Remove(edge)) return;
            edge.Node1.RemoveConnection(edge.Node2);
            Refresh();
        }

        public void Clear()
        {
            _edges.Clear();
            _nodes.Clear();
            Refresh();
        }

        public void ClearEdges()
        {
            _edges.Clear();
            _nodes.ForEach(n => n.RemoveConnections());

            Refresh();
        }

        public void Refresh()
        {
            OnChange?.Invoke();
        }
    }
}
