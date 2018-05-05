using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Subtractor:TuringMachine
    {

        public Subtractor(string filePath, string entry) : base(filePath, entry)
        {
            BuildMachine("src/m4.txt");
            this.EntryAlphabet.Add("1");
            this.EntryAlphabet.Add("0");

            this.TapeAlphabet.Add("1");
            this.TapeAlphabet.Add("0");
            this.TapeAlphabet.Add("-");
            this.TapeAlphabet.Add("=");
            this.TapeAlphabet.Add("U");
            this.AcceptingStates.Add(7);
            this.CurrentStateNumber = 8;
            //this.Pointer = 1;
            FillBlanks(entry);

            this.Q[1].Descripción = "Adds 1 at the end.";
            this.Q[2].Descripción = "Searches the next 1 to copy it";
            this.Q[3].Descripción = "Starts to subtract";
            this.Q[4].Descripción = "Deletes last 1";
            this.Q[5].Descripción = "Deletes a 1";
            this.Q[6].Descripción = "Searches the next 1 to delete";
            this.Q[7].Descripción = "Accepting states";
            this.Q[8].Descripción = "Checks if there comes only one 1";
            this.Q[9].Descripción = "Duplicates in case its only one character";
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
                this.MachineTape.AddSymbol(this.blank);
            }

        }
    }
}
