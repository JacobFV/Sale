using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class DirectObject
    {
        public List<string> englishDefaults;
        public List<string> spanishDefaults;

        List<List<string>> englishDirectObjects;
        List<List<string>> spanishDirectObjects;
        public bool possilbyHer = false;

        public DirectObject(
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
            englishDirectObjects = new List<List<string>>(6);
            spanishDirectObjects = new List<List<string>>(6);
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
                englishDirectObjects.Add(new List<string> { englishDefaults[person] });
                spanishDirectObjects.Add(new List<string> { spanishDefaults[person] });
            }
        }

        public void addDirectObject(string word, Person person, Language language)
        {
            if (language == Language.english)
            {
                englishDirectObjects[(int)person].Add(word);
            }
            else
            {
                spanishDirectObjects[(int)person].Add(word);
            }
        }
        public List<string> directObjects(Language language)
        {
            List<string> returnStrings = new List<string>();
            switch (language)
            {
                case Language.english:
                    foreach (List<string> englishPersonDirectObjects in englishDirectObjects)
                    {
                        returnStrings.AddRange(englishPersonDirectObjects);
                    }
                    break;
                case Language.spanish:
                    foreach (List<string> spanishPersonDirectObjects in spanishDirectObjects)
                    {
                        returnStrings.AddRange(spanishPersonDirectObjects);
                    }
                    break;
                default:
                    throw new Exception("No supported language");
                    break;
            }
            return returnStrings;
        }
        public string translate(string word, Language language)
        {
            string returnString = "";
            if (language == Language.spanish)
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    List<string> listOfDirectObjects = englishDirectObjects[personNum];
                    foreach (string directObjectWord in listOfDirectObjects)
                    {
                        if (directObjectWord == word.ToLower())
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
                    List<string> listOfDirectObjects = spanishDirectObjects[personNum];
                    foreach (string DirectObjectWord in listOfDirectObjects)
                    {
                        if (DirectObjectWord == word.ToLower())
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
            if (language == Language.spanish)
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    List<string> listOfIndirectObjects = englishDirectObjects[personNum];
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
                    List<string> listOfIndirectObjects = spanishDirectObjects[personNum];
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
