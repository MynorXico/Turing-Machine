using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Subtractor
    {
        public TuringMachine Machine;

        public Subtractor(String entry)
        {
            Machine = new TuringMachine("src/m4.txt", " "+entry);
            Machine.EntryAlphabet.Add("1");
            Machine.EntryAlphabet.Add("0");
            Machine.TapeAlphabet.Add("1");
            Machine.TapeAlphabet.Add("0");

            Machine.AcceptingStates.Add(8);
            Machine.CurrentStateNumber = 0;
            Machine.Pointer = 1;
            FillBlanks(entry);

            Machine.Q[1].Descripción = "Adds 1 at the end.";
            Machine.Q[2].Descripción = "Searches the next 1 to copy it";
            Machine.Q[3].Descripción = "Starts to subtract";
            Machine.Q[4].Descripción = "Deletes last 1";
            Machine.Q[5].Descripción = "Deletes a 1";
            Machine.Q[6].Descripción = "Searches the next 1 to delete";
            Machine.Q[7].Descripción = "Accepting states";
            Machine.Q[8].Descripción = "Checks if there comes only one 1";
            Machine.Q[9].Descripción = "Duplicates in case its only one character";
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            String factor1 = Entry.Split('=')[0].Split('-')[0];
            int BlanksNumber = factor1.Length+1;
            for (int i = 0; i < BlanksNumber; i++)
            {
                Machine.MachineTape.AddSymbol(Machine.blank);
            }

        }
    }
}
