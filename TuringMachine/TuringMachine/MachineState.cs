using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class MachineState
    {
        bool isFinal;
        public List<Transition> Transitions = new List<Transition>();
        public MachineState()
        {

        }
        public void AddTransition(Transition t)
        {
            Transitions.Add(t);
        }
    }
}
