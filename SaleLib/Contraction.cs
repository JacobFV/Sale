using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class Contraction
    {
        public string contraction;
        public string firstWord;
        public string secondWord;

        public Contraction(string contraction, string firstWord, string secondWord)
        {
            this.contraction = contraction;
            this.firstWord = firstWord;
            this.secondWord = secondWord;
        }
    }
}
