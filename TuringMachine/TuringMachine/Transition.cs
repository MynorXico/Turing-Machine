using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class Transition
    {
        public String symbol;
        public int nextState;
        public Boolean right; // True -> moves right, False -> moves left
        public String replacingSymbol;
        public Transition(string Symbol, int nextState, string ReplacingSymbol, bool moveRight)
        {
            this.symbol = Symbol;
            this.nextState = nextState;
            this.right = moveRight;
            this.replacingSymbol = ReplacingSymbol;
        }

        
    }
}
