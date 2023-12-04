using IND_KDM.Graphs.Base;
using IND_KDM.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IND_KDM.StateMachine.States
{
    public class NodeSelectedState : State
    {
        private Node _node;
        private Node _nodeClicked;

        public NodeSelectedState(Node node)
        {
            _node = node;
        }

        protected override void OnEnter()
        {
            StateMachine.Input.OnVoidMouseUp += OnVoidMouseUp;
            StateMachine.Input.OnNodeMouseDown += OnNodeMouseDown;
            StateMachine.Input.OnNodeMouseUp += OnNodeMouseUp;
            StateMachine.Input.OnNodeHoverEnter += OnNodeHoverEnter;
            StateMachine.Input.OnNodeHoverLeave += OnNodeHoverLeave;

            _node.Selected = true;
            Status.Show($"Выбрана вершина: {_node.Value}");
        }

        protected override void OnLeave()
        {
            StateMachine.Input.OnVoidMouseUp -= OnVoidMouseUp;
            StateMachine.Input.OnNodeMouseDown -= OnNodeMouseDown;
            StateMachine.Input.OnNodeMouseUp -= OnNodeMouseUp;

            _node.Selected = false;
            Status.Clear();
        }

        protected override void OnSignal(string e, object args = null)
        {
            if (e == Signals.KeyboardUp)
            {
                var keyboardArgs = (KeyEventArgs)args;
                
                switch (keyboardArgs.KeyCode)
                {
                    case Keys.Delete:
                        StateMachine.Graph.RemoveNode(_node);
                        StateMachine.ChangeState(new NodeSelectState());
                        break;
                    case Keys.Up:
                        _node.Y -= 1;
                        StateMachine.Refresh();
                        break;
                    case Keys.Down:
                        _node.Y += 1;
                        StateMachine.Refresh();
                        break;
                    case Keys.Left:
                        _node.X -= 1;
                        StateMachine.Refresh();
                        break;
                    case Keys.Right:
                        _node.X += 1;
                        StateMachine.Refresh();
                        break;
                }
            }

            if (e == Signals.MouseMove)
            {
                if (_nodeClicked != _node) return;

                var mouseArgs = (MouseEventArgs)args;
                var deltaX = mouseArgs.Location.X - _node.Center.X;
                var deltaY = mouseArgs.Location.Y - _node.Center.Y;
                if (Math.Abs(deltaX) < _node.Radius / 4 && Math.Abs(deltaY) < _node.Radius / 4) return;

                StateMachine.ChangeState(new NodeMoveState(_node));
            }
        }

        private void OnVoidMouseUp(Point mousePoint)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                var graph = StateMachine.Graph;
                var node = graph.AddNode(mousePoint.X - Node.DefaultRadius, mousePoint.Y - Node.DefaultRadius, graph.LastValue + 1);
                Listing.AddLine($"Добавлена вершина с номером {graph.LastValue}");

                StateMachine.Graph.AddEdge(_node, node);
                Listing.AddLine($"Добавлено ребро {_node.Value}-{node.Value}");
                Status.Show($"Добавлено ребро {_node.Value}-{node.Value}");
            }

            StateMachine.ChangeState(new NodeSelectState());
        }

        private void OnNodeMouseDown(Node node)
        {
            _nodeClicked = node;
        }

        private void OnNodeMouseUp(Node node)
        {
            if (_nodeClicked == node)
            {
                StateMachine.ChangeState(new NodeSelectState());
            }

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                Edge edge;
                if ((edge = StateMachine.Graph.GetEdge(_node, node)) != null)
                {
                    StateMachine.Graph.RemoveEdge(edge);
                    Listing.AddLine($"Удалено ребро {_node.Value}-{node.Value}");
                    Status.Show($"Удалено ребро {_node.Value}-{node.Value}");
                }
                else
                {
                    StateMachine.Graph.AddEdge(_node, node);
                    Listing.AddLine($"Добавлено ребро {_node.Value}-{node.Value}");
                    Status.Show($"Добавлено ребро {_node.Value}-{node.Value}");
                }
            } else
            {
                StateMachine.ChangeState(new NodeSelectedState(_nodeClicked));
            }

            _nodeClicked = null;
        }

        private void OnNodeHoverEnter(Node node)
        {
            node.Hovered = true;
        }

        private void OnNodeHoverLeave(Node node)
        {
            node.Hovered = false;
        }
    }
}
