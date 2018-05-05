using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TuringMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //TuringMachine test = new Test("", "1*11=");
            
            
            Console.WriteLine(System.Single.MaxValue);
            Form1 f = new Form1();
            f.ShowDialog();
            
            
            /*String entry = "111*111=";
            UnaryMultiplier um = new UnaryMultiplier(entry);
                
            List<String> output = new List<string>();

            for (int i = 0; i < um.Machine.Q.Count; i++)
            {
                output.Add(String.Format("q{0}:", i));
                Console.WriteLine("q{0}:",i);
                for(int j = 0; j < um.Machine.Q[i].Transitions.Count; j++)
                {
                    Transition CurrentTransition = um.Machine.Q[i].Transitions[j];
                    String symbol = CurrentTransition.symbol;
                    String replacing = CurrentTransition.replacingSymbol;
                    String move = CurrentTransition.right ? "R" : "L";
                    String nextState = "q"+CurrentTransition.nextState;
                    output.Add("\t"+symbol+": {write: "+replacing+", "+move+": "+ nextState+"}");
                }
            }
            File.WriteAllLines("out.txt",output.ToArray<String>());       
            */
        }
    }
}
