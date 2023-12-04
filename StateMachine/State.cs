using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IND_KDM.StateMachine
{
    public abstract class State
    {
        protected EditorStateMachine StateMachine;

        public void Enter(EditorStateMachine machine) {
            StateMachine = machine;
            OnEnter();
        }

        public void Leave(EditorStateMachine machine) {
            StateMachine = machine;
            OnLeave();
        }

        public void Signal(string e, object args = null)
        {
            OnSignal(e, args);
        }

        protected virtual void OnEnter() { }
        protected virtual void OnLeave() { }
        protected virtual void OnSignal(string e, object args = null) { }
    }
}
