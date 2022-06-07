using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class Verb
    {
        //english variants
        public TenseArray englishForms;
        public String englishInfinitive;
        public String englishParticiple;
        //spanish variants
        public TenseArray spanishForms;
        public String spanishInfinitive;
        public String spanishParticiple;
        public CommandForms spanishCommandForms;
        //other
        public Transitivity transitivity;

        public DateTime randomtag;

        public Verb(TenseArray englishForms, String englishInfinitive, String englishParticiple,
                    TenseArray spanishForms, String spanishInfinitive, String spanishParticiple,
                    CommandForms spanishCommandForms, Transitivity transitivity)
        {
            this.randomtag = DateTime.UtcNow;
            this.englishForms = englishForms;
            this.englishInfinitive = englishInfinitive;
            this.englishParticiple = englishParticiple;
            this.spanishForms = spanishForms;
            this.spanishInfinitive = spanishInfinitive;
            this.spanishParticiple = spanishParticiple;
            this.spanishCommandForms = spanishCommandForms;
            this.transitivity = transitivity;
        }
        public Verb(int number)
        {
            this.randomtag = DateTime.UtcNow;
            this.englishForms = new TenseArray("", "", "", "", "", "");
            this.englishInfinitive = "Verb" + number.ToString();
            this.englishParticiple = "";
            this.spanishForms = new TenseArray("", "", "", "", "", "");
            this.spanishInfinitive = "Verbo" + number.ToString();
            this.spanishParticiple = "";
            this.spanishCommandForms = new CommandForms("", "", "", "", "");
            this.transitivity = Transitivity.ditransitive;
        }
        public Verb(Verb verb)
        {
            this.randomtag = verb.randomtag;
            this.englishForms = verb.englishForms;
            this.englishInfinitive = verb.englishInfinitive;
            this.englishParticiple = verb.englishParticiple;
            this.spanishForms = verb.spanishForms;
            this.spanishInfinitive = verb.spanishInfinitive;
            this.spanishParticiple = verb.spanishParticiple;
            this.spanishCommandForms = verb.spanishCommandForms;
            this.transitivity = verb.transitivity;
        }

        public List<string> allVerbForms(Language language)
        {
            List<string> returnStrings;
            if (language == Language.english)
            {
                returnStrings = new List<string>();
                returnStrings.AddRange(englishForms.allForms());
                returnStrings.Add(englishInfinitive);
                returnStrings.Add(englishParticiple);
            }
            else
            {
                returnStrings = new List<string>();
                returnStrings.AddRange(spanishForms.allForms());
                returnStrings.AddRange(spanishCommandForms.allForms());
                returnStrings.Add(spanishInfinitive);
                returnStrings.Add(spanishParticiple);
            }
            return returnStrings;
        }
    }
    public enum Language{ english, spanish }

    public enum Transitivity
    {
        intransitive,
        transitiveDirect,
        transitiveIndirect,
        ditransitive
    }
}
