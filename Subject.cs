using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class Subject
    {
        public List<string> englishDefaults;
        public List<string> spanishDefaults;
        
        List<List<Tuple<string,Gender>>> englishSubjects;
        List<List<Tuple<string, Gender>>> spanishSubjects;
        
        public Subject(
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
            englishSubjects = new List<List<Tuple<string, Gender>>>(6);
            spanishSubjects = new List<List<Tuple<string, Gender>>>(6);
            englishDefaults = new string[6]{
            firstSingularEnglish,
            secondSingularEnglish,
            thirdSingularEnglish,
            firstPluralEnglish,
            secondPluralEnglish,
            thirdPluralEnglish}.ToList();
            spanishDefaults = new string[6]{
                firstSingularSpanish,
                secondSingularSpanish,
                thirdSingularSpanish,
                firstPluralSpanish,
                secondPluralSpanish,
                thirdPluralSpanish}.ToList();
            for (int person = 0; person < 6; person++)
            {
                englishSubjects.Add(new List<Tuple<string, Gender>> { new Tuple<string, Gender>(englishDefaults[person], Gender.masculine) }.ToList());
                spanishSubjects.Add(new List<Tuple<string, Gender>> { new Tuple<string, Gender>(spanishDefaults[person], Gender.masculine) }.ToList());
            }
        }

        public void addSubject(string word, Person person, Language language, Gender gender)
        {
            if (language == Language.english)
            {
                englishSubjects[(int)person].Add(new Tuple<string, Gender>(word, gender));
            }
            else
            {
                spanishSubjects[(int)person].Add(new Tuple<string, Gender>(word, gender));
            }
        }
        public List<string> subjectsOfGender(Gender gender)
        {
            List<string> returnSubjects = new List<string>();
            foreach (List<Tuple<string, Gender>> subjectList in spanishSubjects) { //not all subjects
                foreach (Tuple<string, Gender> subject in subjectList)
                {
                    if (subject.Item2 == gender)
                    {
                        returnSubjects.Add(subject.Item1);
                    }
                }
            }
            return returnSubjects;
        }
        public List<string> subjects(Language language)
        {
            List<string> returnStrings = new List<string>();
            switch (language)
            {
                case Language.english:
                    foreach (List<Tuple<string, Gender>> englishPersonSubjects in englishSubjects)
                    {
                        foreach (Tuple<string, Gender> singleString in englishPersonSubjects)
                        {
                        returnStrings.Add(singleString.Item1);
                        }
                    }
                    break;
                case Language.spanish:
                    foreach (List<Tuple<string, Gender>> spanishPersonSubjects in spanishSubjects)
                    {
                        foreach (Tuple<string, Gender> singleString in spanishPersonSubjects)
                        {
                            returnStrings.Add(singleString.Item1);
                        }
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
            string translatedWord = "";
            if (destinationLanguage == Language.english)
            {
                if (word.ToLower() == "ella")
                {
                    translatedWord = "she";
                    return translatedWord;
                }
                /*else if (word.ToLower() == "él") //el with accent mark
                {
                    translatedWord = "he";
                    return translatedWord;
                }*/
                else
                {
                    if (word.ToLower() == "she")
                    {
                        translatedWord = "ella";
                        return translatedWord;
                    }
                    if (word.ToLower() == "he")
                    {
                        translatedWord = "él";
                        return translatedWord;
                    }
                    else
                    {
                        for (int personNum = 0; personNum < 6; personNum++)
                        {
                            foreach (Tuple<string, Gender> possiblePersonSubject in spanishSubjects[personNum])
                            {
                                if (word == possiblePersonSubject.Item1)
                                {
                                    translatedWord = englishDefaults[personNum];
                                    return translatedWord;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (word.ToLower() == "she")
                {
                    translatedWord = "ella";
                    return translatedWord;
                }
                else
                {
                    for (int personNum = 0; personNum < 6; personNum++)
                    {
                        foreach (Tuple<string, Gender> possiblePersonSubject in englishSubjects[personNum])
                        {
                            if (word == possiblePersonSubject.Item1)
                            {
                                translatedWord = spanishDefaults[personNum];
                                return translatedWord;
                            }
                        }
                    }
                }
            }
            return translatedWord;
        }
        public Person findPersonForSubject(string word, Language language)
        {
            if (language == Language.english)
            {
                for (int personNum = 0; personNum < 6; personNum++)
                {
                    foreach (Tuple<string, Gender> possiblePersonSubject in englishSubjects[personNum])
                    {
                        if (word == possiblePersonSubject.Item1)
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
                    foreach (Tuple<string, Gender> possiblePersonSubject in spanishSubjects[personNum])
                    {
                        if (word == possiblePersonSubject.Item1)
                        {
                            return (Person)personNum;
                        }
                    }
                }
            }
            return Person.thirdSing;
        }
    }

    public enum Gender { masculine, feminine }
    public enum Person{
        firstSing = 0,
        secondSing = 1,
        thirdSing = 2,
        firstPlural = 3,
        secondPlural = 4,
        thirdPlural = 5
    }
}
