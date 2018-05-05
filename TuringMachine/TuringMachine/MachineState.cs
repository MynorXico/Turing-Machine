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
        public String Descripción;
        public MachineState()
        {

        }
        public void AddTransition(Transition t)
        {
            Transitions.Add(t);
        }

        public String getTransition(String input)
        {
            for(int i = 0; i < Transitions.Count; i++)
            {
                if(Transitions[i].symbol == input)
                {
                    return String.Format("({0},{1},{2})", Transitions[i].replacingSymbol, Transitions[i].nextState, (Transitions[i].right? "R": "L"));
                }
            }
            return "----";
        }
    }
}
