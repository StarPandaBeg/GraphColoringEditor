using IND_KDM.Graphs.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IND_KDM.StateMachine.States
{
    public class NodeMoveState : State
    {
        private Node _node;

        public NodeMoveState(Node node)
        {
            _node = node;
        }

        protected override void OnEnter()
        {
            _node.Selected = true;
        }

        protected override void OnLeave()
        {
            _node.Selected = false;
        }

        protected override void OnSignal(string e, object args = null)
        {
            MouseEventArgs mouseArgs;

            if (e == Signals.MouseMove)
            {
                mouseArgs = (MouseEventArgs)args;
                _node.X = mouseArgs.X - _node.Radius;
                _node.Y = mouseArgs.Y - _node.Radius;
                return;
            }

            if (e == Signals.MouseUp)
            {
                _node.Selected = false;
                StateMachine.ChangeState(new NodeSelectState());
            }
        }
    }
}
