using IND_KDM.Graphs.Base;
using IND_KDM.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IND_KDM.StateMachine.States
{
    public class EdgeAddState : State
    {
        private Node _node;

        protected override void OnEnter()
        {
            StateMachine.Input.OnNodeHoverEnter += OnNodeHoverEnter;
            StateMachine.Input.OnNodeHoverLeave += OnNodeHoverLeave;
            StateMachine.Input.OnNodeMouseDown += OnNodeMouseDown;
            StateMachine.Input.OnVoidMouseDown += OnVoidMouseDown;

            Status.Show("Выберите 1 вершину");
        }

        protected override void OnLeave()
        {
            StateMachine.Input.OnNodeHoverEnter -= OnNodeHoverEnter;
            StateMachine.Input.OnNodeHoverLeave -= OnNodeHoverLeave;
            StateMachine.Input.OnNodeMouseDown -= OnNodeMouseDown;
            StateMachine.Input.OnVoidMouseDown -= OnVoidMouseDown;
        }

        private void OnVoidMouseDown(Point mousePoint)
        {
            if (_node != null)
            {
                var graph = StateMachine.Graph;
                var node = graph.AddNode(mousePoint.X - Node.DefaultRadius, mousePoint.Y - Node.DefaultRadius, graph.LastValue + 1);

                Listing.AddLine($"Добавлена вершина с номером {graph.LastValue}");
                OnNodeMouseDown(node);
                return;
            }

            Status.Clear();
            StateMachine.ChangeState(new NodeSelectState());
        }

        private void OnNodeHoverEnter(Node node)
        {
            node.Hovered = true;
        }

        private void OnNodeHoverLeave(Node node)
        {
            node.Hovered = false;
        }

        private void OnNodeMouseDown(Node node)
        {
            if (_node == null)
            {
                _node = node;
                node.Selected = true;

                Status.Show("Выберите 2 вершину");
                return;
            }
            if (_node == node)
            {
                _node.Selected = false;
                _node = null;
                Status.Show("Выберите 1 вершину");
                return;
            }

            Edge edge;
            if ((edge = StateMachine.Graph.GetEdge(_node, node)) != null)
            {
                StateMachine.Graph.RemoveEdge(edge);
                Listing.AddLine($"Удалено ребро {_node.Value}-{node.Value}");
                Status.Show($"Удалено ребро {_node.Value}-{node.Value}");
            } else
            {
                StateMachine.Graph.AddEdge(_node, node);
                Listing.AddLine($"Добавлено ребро {_node.Value}-{node.Value}");
                Status.Show($"Добавлено ребро {_node.Value}-{node.Value}");
            }

            node.Selected = false;
            _node.Selected = false;

            StateMachine.ChangeState(new NodeSelectState());
        }
    }
}
