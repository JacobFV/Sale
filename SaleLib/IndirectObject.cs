using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class IndirectObject
    {
        public List<string> englishDefaults;
        public List<string> spanishDefaults;

        List<List<string>> spanishIndirectObjects;
        List<List<string>> englishIndirectObjects;

        public IndirectObject(
            string firstSingularEnglish,
            string secondSingularEnglish,
            string thirdSingularEnglish,
            string firstPluralEnglish,
            string secondPluralEnglish,
            string thirdPluralEnglish,
            string firstSingularSpanish,
            string secondSingularSpanish,
            string thirdSingularSpanish,
            string firstPluralSpanish,
            string secondPluralSpanish,
            string thirdPluralSpanish)
        {
            englishIndirectObjects = new List<List<string>>(6);
            spanishIndirectObjects = new List<List<string>>(6);
            englishDefaults = new List<string>{
            firstSingularEnglish,
            secondSingularEnglish,
            thirdSingularEnglish,
            firstPluralEnglish,
            secondPluralEnglish,
            thirdPluralEnglish};
            spanishDefaults = new List<string>{
                firstSingularSpanish,
                secondSingularSpanish,
                thirdSingularSpanish,
                firstPluralSpanish,
                secondPluralSpanish,
                thirdPluralSpanish};
            for (int person = 0; person < 6; person++)
            {
                englishIndirectObjects.Add(new string[1] { englishDefaults[person] }.ToList());
                spanishIndirectObjects.Add(new string[1] { spanishDefaults[person] }.ToList());
            }
        }

        public void addIndirectObject(string word, Person person, Language language)
        {
            if (language == Language.english)
            {
                englishIndirectObjects[(int)person].Add(word);
            }
            else
            {
                spanishIndirectObjects[(int)person].Add(word);
            }
        }
        public List<string> indirectObjects(Language language) //give all indirect objects
        {
            List<string> returnStrings = new List<string>();
            switch (language)
            {
                case Language.english:
                    foreach (List<string> englishPersonIndirectObjects in englishIndirectObjects)
                    {
                        returnStrings.AddRange(englishPersonIndirectObjects);
                    }
                    break;
                case Language.spanish:
                    foreach (List<string> spanishPersonIndirectObjects in spanishIndirectObjects)
                    {
                        returnStrings.AddRange(spanishPersonIndirectObjects);
                    }
                    break;
                default:
                    throw new Exception("No supported language");
                    break;
            }
            return returnStrings;
        }
        public string translate(string word, Language destinationLanguage)
        {
            string returnString = "";
            if (destinationLanguage == Language.spanish)
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    List<string> listOfIndirectObjects = englishIndirectObjects[personNum];
                    foreach (string indirectObjectWord in listOfIndirectObjects)
                    {
                        if (indirectObjectWord == word.ToLower())
                        {
                            returnString = spanishDefaults[personNum];
                            return returnString;
                        }
                    }
                }
            }
            else
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    List<string> listOfIndirectObjects = spanishIndirectObjects[personNum];
                    foreach (string indirectObjectWord in listOfIndirectObjects)
                    {
                        if (indirectObjectWord == word.ToLower())
                        {
                            returnString = englishDefaults[personNum];
                            return returnString;
                        }
                    }
                }
            }
            return returnString;
        }
        public Person findPerson(string word, Language language)
        {
            if (language == Language.english)
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    List<string> listOfIndirectObjects = englishIndirectObjects[personNum];
                    foreach (string indirectObjectWord in listOfIndirectObjects)
                    {
                        if (indirectObjectWord == word.ToLower())
                        {
                            return (Person)personNum;
                        }
                    }
                }
            }
            else
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    List<string> listOfIndirectObjects = spanishIndirectObjects[personNum];
                    foreach (string indirectObjectWord in listOfIndirectObjects)
                    {
                        if (indirectObjectWord == word.ToLower())
                        {
                            return (Person)personNum;
                        }
                    }
                }
            }
            return Person.firstSing;
        }
    }
}