using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class PalindromeValidator:TuringMachine
    {

        public PalindromeValidator(string filePath, string entry) : base(filePath, entry)
        {
            this.BuildMachine("src/m5.txt");
            this.EntryAlphabet.Add("1");
            this.EntryAlphabet.Add("0");
            this.TapeAlphabet.Add("a");
            this.TapeAlphabet.Add("b");
            this.TapeAlphabet.Add("c");


            this.AcceptingStates.Add(8);
            FillBlanks(entry);

            this.Q[0].Descripción = "Searches the next character to delete.";
            this.Q[1].Descripción = "Searches the next a to delete";
            this.Q[2].Descripción = "Replaces a to delete";
            this.Q[3].Descripción = "Searches the next character from left to right";
            this.Q[4].Descripción = "Searches the next b to delete";
            this.Q[5].Descripción = "Replaces b to delete";
            this.Q[6].Descripción = "Goes to accepting state";
            this.Q[7].Descripción = "Accepting state";
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            this.MachineTape.AddSymbol(this.blank);
        }
    }
}
