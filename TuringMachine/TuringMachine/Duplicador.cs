using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Duplicador
    {
        public TuringMachine Machine;

        public Duplicador(String entry)
        {
            Machine = new TuringMachine("src/m2.txt", " "+entry);
            Machine.EntryAlphabet.Add("1");
            Machine.EntryAlphabet.Add("0");
            Machine.TapeAlphabet.Add("1");
            Machine.TapeAlphabet.Add("0");

            Machine.AcceptingStates.Add(10);
            Machine.CurrentStateNumber = 13;
            FillBlanks(entry);
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            
            int BlanksNumber = Entry.Length*2;
            for (int i = 0; i < BlanksNumber; i++)
            {
                Machine.MachineTape.AddSymbol(Machine.blank);
            }
        }
    }
}
