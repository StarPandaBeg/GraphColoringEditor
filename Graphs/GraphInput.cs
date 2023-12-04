using IND_KDM.Graphs.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IND_KDM.Graphs
{
    public class GraphInput
    {
        public event Action<Node> OnNodeHoverEnter;
        public event Action<Node> OnNodeHoverLeave;
        public event Action<Node> OnNodeHover;

        public event Action<Node> OnNodeMouseDown;
        public event Action<Node> OnNodeMouseUp;

        public event Action<Point> OnVoidMouseDown;
        public event Action<Point> OnVoidMouseUp;

        private Graph _graph;
        private Node _hoveredNode = null;
        private Node _selectedNode = null;
        private bool _voidPressed = false;

        public GraphInput(Graph graph)
        {
            _graph = graph;
        }

        public void HandleMove(MouseEventArgs e)
        {
            foreach (Node node in _graph.Nodes)
            {
                var hovered = IsInNode(e.X, e.Y, node);
               
                if (hovered && node != _hoveredNode)
                {
                    OnNodeHoverEnter?.Invoke(node);
                    _hoveredNode = node;
                }
                if (!hovered && node == _hoveredNode)
                {
                    OnNodeHoverLeave?.Invoke(node);
                    _hoveredNode = null;
                }
                if (hovered) OnNodeHover?.Invoke(node);
            }
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            var dirty = false;
            foreach (Node node in _graph.Nodes)
            {
                var hovered = IsInNode(e.X, e.Y, node);
                if (!hovered) continue;

                if (node != _selectedNode)
                {
                    OnNodeMouseDown?.Invoke(node);
                    _selectedNode = node;
                    dirty = true;
                }
            }

            if (_voidPressed == dirty)
            {
                _voidPressed = !dirty;
                OnVoidMouseDown?.Invoke(e.Location);
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            var dirty = false;

            foreach (Node node in _graph.Nodes)
            {
                var hovered = IsInNode(e.X, e.Y, node);
                if (!hovered) continue;

                if (node == _selectedNode)
                {
                    OnNodeMouseUp?.Invoke(node);
                    _selectedNode = null;
                    dirty = true;
                }
            }

            if (_voidPressed && !dirty)
            {
                OnVoidMouseUp?.Invoke(e.Location);
            }
            _voidPressed = false;
        }

        private bool IsInNode(int x, int y, Node node)
        {
            return node.Bounds.Contains(x, y);
        }
    }
}
