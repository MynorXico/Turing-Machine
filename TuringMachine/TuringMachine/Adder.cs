using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Adder:TuringMachine
    {

        public Adder(string filePath, string entry) : base(filePath, entry)
        {
            BuildMachine("src/m3.txt");
            this.EntryAlphabet.Add("1");
            this.EntryAlphabet.Add("0");
            this.TapeAlphabet.Add("1");
            this.TapeAlphabet.Add("0");
            this.TapeAlphabet.Add("+");
            this.TapeAlphabet.Add("=");
            this.TapeAlphabet.Add("U");
            this.AcceptingStates.Add(3);

            FillBlanks(entry);

            this.Q[0].Descripción = "Substitutes U by 1";
            this.Q[1].Descripción = "Writes 1 at the end of the tape";
            this.Q[2].Descripción = "Back substitutes 1 by U";
            this.Q[3].Descripción = "Accepting state";
        }

        /*public void Run()
        {
            Machine.Run();
        }*/
        public void FillBlanks(String Entry)
        {
            String factor1="";
            String factor2="";
            try
            {
                factor1 = Entry.Split('=')[0].Split('+')[0];
                factor2 = Entry.Split('=')[0].Split('+')[1];
            }
            catch
            {
                //throw new Exception();;
            }
           
            int BlanksNumber = factor1.Length + factor2.Length;
            for (int i = 0; i < BlanksNumber; i++)
            {
                this.MachineTape.AddSymbol(this.blank);
            }

        }
    }
}

