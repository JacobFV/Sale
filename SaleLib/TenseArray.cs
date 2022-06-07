using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class TenseArray
    {
        String firstSingular;
        String secondSingular;
        String thirdSingular;
        String firstPlural;
        String secondPlural;
        String thirdPlural;

        public TenseArray() { }

        public TenseArray(String firstSingular,
                          String secondSingular,
                          String thirdSingular,
                          String firstPlural,
                          String secondPlural,
                          String thirdPlural)
        {
            this.firstSingular = firstSingular;
            this.secondSingular = secondSingular;
            this.thirdSingular = thirdSingular;
            this.firstPlural = firstPlural;
            this.secondPlural = secondPlural;
            this.thirdPlural = thirdPlural;
        }
        public TenseArray(String englishInfinitive,
                          String thirdPersonSingularForm)
        {
            this.firstSingular = englishInfinitive;
            this.secondSingular = englishInfinitive;
            this.thirdSingular = thirdPersonSingularForm;
            this.firstPlural = englishInfinitive;
            this.secondPlural = englishInfinitive;
            this.thirdPlural = englishInfinitive;
        }
        public TenseArray(String spanishInfinitive)
        {
            String stem = spanishInfinitive.Substring(0, spanishInfinitive.Length - 2);
            String ending = spanishInfinitive.Substring(spanishInfinitive.Length - 2, 2);

            TenseArray endings = new TenseArray();

            switch (ending)
            {
                case "ar":
                    endings = new TenseArray("o", "as", "a", "amos", "an", "an");
                    break;
                case "er":
                    endings = new TenseArray("o", "es", "e", "emos","en", "en");
                    break;
                case "ir":
                    endings = new TenseArray("o", "es", "e", "imos","en", "en");
                    break;
            }

            this.firstSingular = stem + endings.firstSingular;
            this.secondSingular = stem + endings.secondSingular;
            this.thirdSingular = stem + endings.thirdSingular;
            this.firstPlural = stem + endings.firstPlural;
            this.secondPlural = stem + endings.secondPlural;
            this.thirdPlural = stem + endings.thirdPlural;
        }

        public String[] allForms()
        {
            return new String[6] {firstSingular, secondSingular, thirdSingular,
                                  firstPlural, secondPlural, thirdPlural};
        }
    }

    enum StemChangingPattern //not yet implemented anywhere
    {
        o_ue,
        e_ie,
        e_i
    }
}
