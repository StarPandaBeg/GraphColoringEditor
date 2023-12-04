using IND_KDM.Graphs.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IND_KDM.Graphs
{
    public class GraphStorage
    {
        private const int FileVersion = 1;

        private Graph _graph;

        public GraphStorage(Graph graph)
        {
            _graph = graph;
        }

        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"{FileVersion}");
                writer.WriteLine($"{_graph.Count} {_graph.EdgesCount}");

                foreach (var node in _graph.Nodes)
                {
                    writer.WriteLine($"{node.X} {node.Y} {node.Value}");
                }
                foreach (var edge in _graph.Edges)
                {
                    writer.WriteLine($"{edge.Node1.Value} {edge.Node2.Value} {(edge.HasWeight ? 1 : 0)} {edge.Weight}");
                }

            }
        }

        public void Load(string path)
        {
            ReadData(path, out var nodes, out var edges);

            _graph.Clear();
            foreach (var node in nodes)
            {
                _graph.AddNode(node);
            }
            foreach (var edge in edges)
            {
                if (edge.HasWeight)
                {
                    _graph.AddEdge(edge.Node1, edge.Node2, edge.Weight);
                    continue;
                }
                _graph.AddEdge(edge.Node1, edge.Node2);
            }
        }

        private void ReadData(string path, out List<Node> nodes, out List<Edge> edges)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();

                string countLine = reader.ReadLine();
                string[] countParts = countLine.Split(' ');

                if (countParts.Length != 2)
                {
                    throw new InvalidDataException("Cannot load node & edge count");
                }
                int nodeCount = Convert.ToInt32(countParts[0]);
                int edgeCount = Convert.ToInt32(countParts[1]);

                if (nodeCount < 0 || edgeCount < 0 || (nodeCount == 0 && edgeCount != 0))
                {
                    throw new InvalidDataException("Invalid node or edge count");
                }

                ReadNodes(reader, nodeCount, out nodes);
                ReadEdges(reader, edgeCount, nodes, out edges);
            }
        }

        private void ReadNodes(StreamReader reader, int count, out List<Node> nodes)
        {
            nodes = new List<Node>();

            for (int i = 0; i < count; i++)
            {
                string nodeData = reader.ReadLine();
                if (nodeData == null)
                {
                    throw new InvalidDataException($"Cannot load node data (node index {i}). End of file reached.");
                }

                string[] nodeParts = nodeData.Split(' ');
                if (nodeParts.Length != 3)
                {
                    throw new InvalidDataException($"Cannot load node data (node index {i})");
                }

                int x = Convert.ToInt32(nodeParts[0]);
                int y = Convert.ToInt32(nodeParts[1]);
                int value = Convert.ToInt32(nodeParts[2]);

                if (nodes.FirstOrDefault(n => n.Value == value) != null)
                {
                    throw new InvalidDataException($"Node with index {i} is already added to the graph");
                }
                nodes.Add(new Node(x, y, value));
            }
        }

        private void ReadEdges(StreamReader reader, int count, List<Node> nodes, out List<Edge> edges)
        {
            edges = new List<Edge>();

            for (int i = 0; i < count; i++)
            {
                string edgeData = reader.ReadLine();
                if (edgeData == null)
                {
                    throw new InvalidDataException($"Cannot load edge data (edge index {i}). End of file reached.");
                }

                string[] edgeParts = edgeData.Split(' ');
                if (edgeParts.Length != 4)
                {
                    throw new InvalidDataException($"Cannot load edge data (edge index {i})");
                }

                int valueA = Convert.ToInt32(edgeParts[0]);
                int valueB = Convert.ToInt32(edgeParts[1]);
                bool isWeighted = edgeParts[2] == "1";
                int weight = Convert.ToInt32(edgeParts[3]);

                var nodeA = nodes.FirstOrDefault(n => n.Value == valueA);
                var nodeB = nodes.FirstOrDefault(n => n.Value == valueB);

                if (nodeA == null)
                {
                    throw new InvalidDataException($"Node with value {valueA} wasn't registered but accessed by edge with index {i}");
                }
                if (nodeB == null)
                {
                    throw new InvalidDataException($"Node with value {valueB} wasn't registered but accessed by edge with index {i}");
                }

                if (isWeighted)
                {
                    edges.Add(new Edge(nodeA, nodeB, weight));
                    continue;
                }
                edges.Add(new Edge(nodeA, nodeB));
            }
        }
    }
}
