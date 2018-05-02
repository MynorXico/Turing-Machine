using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TuringMachine
{
    class UnaryMultiplier
    {
       
        public TuringMachine Machine;

        public UnaryMultiplier(String entry)
        {
            Machine = new TuringMachine("src/m1.txt", entry);
            Machine.EntryAlphabet.Add("1");
            Machine.EntryAlphabet.Add("0");
            Machine.TapeAlphabet.Add("1");
            Machine.TapeAlphabet.Add("0");

            Machine.AcceptingStates.Add(13);

            FillBlanks(entry);
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            String factor1 = Entry.Split('=')[0].Split('*')[0];
            String factor2 = Entry.Split('=')[0].Split('*')[1];
            int BlanksNumber = factor1.Length * factor2.Length;
            for (int i = 0; i < BlanksNumber; i++)
            {
                Machine.MachineTape.AddSymbol(Machine.blank);
            }

        }
    }
}
