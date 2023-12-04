using IND_KDM.Graphs;
using System;
using System.Windows.Forms;

namespace IND_KDM.StateMachine
{
    public class EditorStateMachine
    {
        private Graph _graph;
        private State _state;

        public State CurrentState => _state;
        public Graph Graph => _graph;
        public readonly GraphInput Input;

        public EditorStateMachine(Graph graph)
        {
            _graph = graph;
            Input = new GraphInput(_graph);
        }

        public void ChangeState(State state)
        {
            _state?.Leave(this);
            _state = state;
            _state.Enter(this);
        }

        public void Signal(string e, object args = null)
        {
            Action<MouseEventArgs> action = null;
            switch (e)
            {
                case Signals.MouseMove:
                    action = Input.HandleMove;
                    break;
                case Signals.MouseDown:
                    action = Input.HandleMouseDown;
                    break;
                case Signals.MouseUp:
                    action = Input.HandleMouseUp;
                    break;
            }

            if (action != null)
            {
                action.Invoke((MouseEventArgs)args);
                Refresh();
            }

            _state?.Signal(e, args);
        }

        public void Refresh()
        {
            _graph.Refresh();
        }
    }
}
