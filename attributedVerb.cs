using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class attributedVerb
    {
        public Verb verb;
        public string text;
        public int position;

        public attributedVerb()
        {
            this.verb = null;
            this.text = null;
            this.position = 0;
        }
        public attributedVerb(Verb verb, string text, int position)
        {
            this.verb = verb;
            this.text = text;
            this.position = position;
        }
    }
}
