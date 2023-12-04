using IND_KDM.Graphs.Base;
using IND_KDM.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IND_KDM.Graphs
{
    class GraphPaint
    {
        private static readonly Random random = new Random();


        public static void Do(Graph graph)
        {
            var colors = new int[graph.Count];

            Listing.AddLine("Начата раскраска графа");

            for (int i = 0; i < graph.Count; i++)
            {
                colors[i] = GetColorIndex(i, graph.Nodes[i], graph, colors);
                Listing.AddLine($"Вершина {graph.Nodes[i].Value} - цвет {colors[i]}");
            }

            var chromatic = colors.Max() + 1;
            var colorValues = new List<Color>();
            for (int i = 0; i < chromatic; i++)
            {
                colorValues.Add(GetRandomDullColor());
            }

            for (int i = 0; i < graph.Count; i++)
            {
                var node = graph.Nodes[i];
                node.Color = colorValues[colors[i]];
            }
            graph.Refresh();

            Listing.AddLine("Граф раскрашен");
            Status.Show("Граф раскрашен");
        }

        private static int GetColorIndex(int index, Node node, Graph graph, int[] colors)
        {
            var usedColors = new List<int>();
            for (int i = 0; i < index; i++)
            {
                var nodeOther = graph.Nodes[i];
                if (!node.Connections.Contains(nodeOther)) continue;
                usedColors.Add(colors[i]);
            }

            for (int i = 0; ; i++)
            {
                if (usedColors.Contains(i)) continue;
                return i;
            }
        }

        private static Color GetRandomDullColor()
        {
            int r = random.Next(50, 200);
            int g = random.Next(50, 200);
            int b = random.Next(50, 200);
            return Color.FromArgb(r, g, b);
        }
    }
}
