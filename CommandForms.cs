using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class CommandForms
    {
        public String affirmativeTu;
        public String affirmativeUd;
        public String affirmativeNos;
        public String affirmativeUds;
        public String negitiveTu;
        public String negitiveUd;
        public String negitiveNos;
        public String negitiveUds;

        public CommandForms(String affirmativeTu,
                            String affirmativeUd,
                            String affirmativeNos,
                            String affirmativeUds,
                            String negitiveTu,
                            String negitiveUd,
                            String negitiveNos,
                           String negitiveUds)
        {

            this.affirmativeTu = affirmativeTu;
            this.affirmativeUd = affirmativeUd;
            this.affirmativeNos = affirmativeNos;
            this.affirmativeUds = affirmativeUds;
            this.negitiveTu = negitiveTu;
            this.negitiveUd = negitiveUd;
            this.negitiveNos = negitiveNos;
            this.negitiveUds = negitiveUds;
        }
        public CommandForms(String affTu,
                            String negTu,
                            String Ud,
                            String Nos,
                            String Uds)
        {

            this.affirmativeTu = affTu;
            this.affirmativeUd = Ud;
            this.affirmativeNos = Nos;
            this.affirmativeUds = Uds;
            this.negitiveTu = negTu;
            this.negitiveUd = Ud;
            this.negitiveNos = Nos;
            this.negitiveUds = Uds;
        }
        public string[] allForms()
        {
            return new string[8] { affirmativeNos, affirmativeUds, affirmativeTu, affirmativeUd, 
                                   negitiveNos, negitiveUds, negitiveTu, negitiveUd};
        }
        public static int getIntForPerson(Person person, bool negative)
        {
            int negativeOffset = (negative) ? 4 : 0;
            switch (person)
            {
                case Person.firstSing:
                    throw new Exception("You can't have a first person command");
                    break;
                case Person.secondSing:
                    return 2 + negativeOffset;
                    break;
                case Person.thirdSing:
                    return 3 + negativeOffset;
                    break;
                case Person.firstPlural:
                    return 0 + negativeOffset;
                    break;
                case Person.secondPlural:
                    return 1 + negativeOffset;
                    break;
                case Person.thirdPlural:
                    throw new Exception("You can't have a first person command");
                    break;
            }
            return 256;
        }
    }
}
