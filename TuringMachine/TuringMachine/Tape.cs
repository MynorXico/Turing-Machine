using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class Tape
    {
        public List<String> boxes = new List<string>();

        public void AddSymbol(String newSymbol)
        {
            boxes.Add(newSymbol);
        }

        public override string ToString()
        {
            String output = "[";
            for(int i = 0; i < boxes.Count; i++)
            {
                output += boxes[i]+((i<boxes.Count-1)?"|":"");
            }
            output += "]";
            return output;
        }
    }
}
