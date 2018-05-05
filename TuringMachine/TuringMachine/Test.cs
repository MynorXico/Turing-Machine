using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Test : TuringMachine
    {
        public Test(string filePath, string entry) : base(filePath, entry)
        {
            this.BuildMachine("src/m1.txt");
            
        }
    }
}
