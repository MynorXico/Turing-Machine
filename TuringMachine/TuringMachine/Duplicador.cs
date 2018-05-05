using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Duplicador:TuringMachine
    {

        public Duplicador(string filePath, string entry) : base(filePath, entry)
        {
            this.BuildMachine("src/m2.txt");
            this.EntryAlphabet.Add("1");
            this.EntryAlphabet.Add("0");
            this.TapeAlphabet.Add("1");
            this.TapeAlphabet.Add("0");
            this.TapeAlphabet.Add("a");
            this.TapeAlphabet.Add("b");
            this.TapeAlphabet.Add("c");
            this.TapeAlphabet.Add("A");
            this.TapeAlphabet.Add("B");
            this.TapeAlphabet.Add("C");

            this.AcceptingStates.Add(10);
            this.CurrentStateNumber = 13;
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
                this.MachineTape.AddSymbol(this.blank);
            }
        }
    }
}
