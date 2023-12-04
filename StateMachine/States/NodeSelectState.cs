using IND_KDM.Graphs.Base;
using IND_KDM.GUI;
using System;
using System.Windows.Forms;

namespace IND_KDM.StateMachine.States
{
    public class NodeSelectState : State
    {
        private Node _node;

        protected override void OnEnter()
        {
            StateMachine.Input.OnNodeHoverEnter += OnNodeHoverEnter;
            StateMachine.Input.OnNodeHoverLeave += OnNodeHoverLeave;
            StateMachine.Input.OnNodeMouseDown += OnNodeMouseDown;
            StateMachine.Input.OnNodeMouseUp += OnNodeMouseUp;
        }

        protected override void OnLeave()
        {
            StateMachine.Input.OnNodeHoverEnter -= OnNodeHoverEnter;
            StateMachine.Input.OnNodeHoverLeave -= OnNodeHoverLeave;
            StateMachine.Input.OnNodeMouseDown -= OnNodeMouseDown;
            StateMachine.Input.OnNodeMouseUp -= OnNodeMouseUp;
        }

        protected override void OnSignal(string e, object args = null)
        {
            if (e == Signals.MouseDoubleClick)
            {
                var graph = StateMachine.Graph;
                var mouseArgs = (MouseEventArgs)args;
                if (mouseArgs.Button != MouseButtons.Left) return;

                StateMachine.Graph.AddNode(mouseArgs.X - Node.DefaultRadius, mouseArgs.Y - Node.DefaultRadius, graph.LastValue + 1);
                Listing.AddLine($"Добавлена вершина с номером {graph.LastValue}");
                Status.Show($"Добавлена вершина с номером {graph.LastValue}");

                return;
            }

            if (e == Signals.MouseMove)
            {
                if (_node == null) return;

                var mouseArgs = (MouseEventArgs)args;
                var deltaX = mouseArgs.Location.X - _node.Center.X;
                var deltaY = mouseArgs.Location.Y - _node.Center.Y;
                if (Math.Abs(deltaX) < _node.Radius / 4 && Math.Abs(deltaY) < _node.Radius / 4) return;

                StateMachine.ChangeState(new NodeMoveState(_node));
            }
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
            _node = node;
        }

        private void OnNodeMouseUp(Node node)
        {
            if (node == _node)
            {
                node.Hovered = false;
                StateMachine.ChangeState(new NodeSelectedState(node));
            }
        }
    }
}
