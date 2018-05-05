using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class PalindromeValidator
    {
        public TuringMachine Machine;

        public PalindromeValidator(String entry)
        {
            Machine = new TuringMachine("src/m5.txt", entry);
            Machine.EntryAlphabet.Add("1");
            Machine.EntryAlphabet.Add("0");
            Machine.TapeAlphabet.Add("a");
            Machine.TapeAlphabet.Add("b");
            Machine.TapeAlphabet.Add("c");


            Machine.AcceptingStates.Add(8);
            FillBlanks(entry);

            Machine.Q[0].Descripción = "Searches the next character to delete.";
            Machine.Q[1].Descripción = "Searches the next a to delete";
            Machine.Q[2].Descripción = "Replaces a to delete";
            Machine.Q[3].Descripción = "Searches the next character from left to right";
            Machine.Q[4].Descripción = "Searches the next b to delete";
            Machine.Q[5].Descripción = "Replaces b to delete";
            Machine.Q[6].Descripción = "Goes to accepting state";
            Machine.Q[7].Descripción = "Accepting state";
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            Machine.MachineTape.AddSymbol(Machine.blank);
        }
    }
}
