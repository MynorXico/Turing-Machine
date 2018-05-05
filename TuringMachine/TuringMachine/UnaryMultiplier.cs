using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TuringMachine
{
    class UnaryMultiplier: TuringMachine
    {
       

        public UnaryMultiplier(string filePath, string entry) : base(filePath, entry)
        {
            this.BuildMachine("src/m1.txt");
            this.EntryAlphabet.Add("1");
            this.EntryAlphabet.Add("0");

            this.TapeAlphabet.Add("1");
            this.TapeAlphabet.Add("0");
            this.TapeAlphabet.Add("*");
            this.TapeAlphabet.Add("=");
            this.TapeAlphabet.Add("U");
            this.TapeAlphabet.Add("D");

            this.AcceptingStates.Add(13);

            FillBlanks(entry);
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
                factor1 = Entry.Split('=')[0].Split('*')[0];
                factor2 = Entry.Split('=')[0].Split('*')[1];
            }
            catch
            {
                
            }
            
            int BlanksNumber = factor1.Length * factor2.Length;
            for (int i = 0; i < BlanksNumber; i++)
            {
                this.MachineTape.AddSymbol(this.blank);
            }

        }
    }
}
