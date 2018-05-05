using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Adder
    {
        public TuringMachine Machine;

        public Adder(String entry)
        {
            Machine = new TuringMachine("src/m3.txt", entry);
            Machine.EntryAlphabet.Add("1");
            Machine.EntryAlphabet.Add("0");
            Machine.TapeAlphabet.Add("1");
            Machine.TapeAlphabet.Add("0");

            Machine.AcceptingStates.Add(3);

            FillBlanks(entry);

            Machine.Q[0].Descripción = "Substitutes U by 1";
            Machine.Q[1].Descripción = "Writes 1 at the end of the tape";
            Machine.Q[2].Descripción = "Back substitutes 1 by U";
            Machine.Q[3].Descripción = "Accepting state";
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            String factor1 = Entry.Split('=')[0].Split('+')[0];
            String factor2 = Entry.Split('=')[0].Split('+')[1];
            int BlanksNumber = factor1.Length + factor2.Length;
            for (int i = 0; i < BlanksNumber; i++)
            {
                Machine.MachineTape.AddSymbol(Machine.blank);
            }

        }
    }
}

