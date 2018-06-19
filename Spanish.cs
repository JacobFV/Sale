using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class Spanish
    {
        public Idea understand(String scentence, Dictionary dictionary)
        {
            string newScentence = "";
            foreach (char letter in scentence)
            {
                if (char.IsLetter(letter) || letter == ' ' || letter == '\'')
                {
                    newScentence += char.ToLower(letter);
                }
            }
            scentence = newScentence;
            Idea idea = new Idea("tú", null, null, null, null, IdeaType.declarative, false);
            List<string> words = scentence.Split(new char[2] { ' ', ',' }).ToList();
            bool pronounsAttatched = false;
            string commandVerbRoot = "";
            for (int wordNum = 0; wordNum < words.Count(); /*incrementor at bottom*/)
            {
                string word = words[wordNum].ToLower();
                //go through the word and remove accent marks except for saber: 'sé'
                /*
                bool okayToRemoveAccents = true;
                foreach (string exception in new string[1] { "sé" })
                {
                    if (word == exception)
                    {
                        okayToRemoveAccents = false;
                    }
                }
                if (okayToRemoveAccents == true) 
                {
                    //remove accents func
                    word = removeAccents(word);
                }
                 */
                if (word == "no") /// this is wrong; check for negation directly after the subject or at the beggining
                {
                    idea.negitive = true; //but it'll do
                }
                bool foundVerb = false;
                foreach (Verb verb in dictionary.verbs)
                {
                    //see if it's the main verb
                    List<string> allPossibleConjugatedForms = verb.spanishForms.allForms().ToList();
                    foreach (Person person in new Person[6]{Person.firstSing,
                                                           Person.secondSing,
                                                           Person.thirdSing,
                                                           Person.firstPlural,
                                                           Person.secondPlural,
                                                           Person.thirdPlural})
                    {
                        if (word == verb.spanishForms.allForms()[(int)person].ToLower() && idea.verb == null)
                        {
                            foundVerb = true;
                            idea.verb = verb;
                            idea.ideaType = IdeaType.declarative;
                            idea.verbTypes = VerbTypes.conjugated;
                            idea.subject = dictionary.subjects.spanishDefaults[(int)person];
                            if (word == verb.spanishCommandForms.allForms()[1/*2*/])//If this causes problems, remove it
                            {
                                idea.possiblyTuCommandOrThirdPeron = true;
                                //idea.ideaType = IdeaType.command;
                            }
                        }
                    }
                    //see if it's a spanish infinitive
                    string rootWord = "xxxxxxxxxxxxxxxxxxxxxxxx";
                    if (foundVerb == false)
                    {
                        string[] affirmatives = verb.spanishCommandForms.allForms();
                        string affirmativeTu = affirmatives[2];
                        if (word.Length >= verb.spanishInfinitive.Length) //this looks ugly but I've yet to find a bug in it
                        {
                            rootWord = word.Substring(0, verb.spanishInfinitive.Length);
                        }
                        else if (word.Length >= affirmativeTu.Length)
                        {
                            rootWord = word.Substring(0, affirmativeTu.Length);
                        }
                        //this doesn't work with all the shorites like 'pon', 'haz', etc.
                        if (removeAccents(rootWord) == verb.spanishInfinitive && idea.auxilleryVerb == null)
                        {
                            //it is an infinitive
                            if (idea.verb == null)
                            {
                                idea.verb = verb;
                                idea.auxilleryVerb = null;
                                idea.verbTypes = VerbTypes.infinitive;
                                return idea; //this is new and hasn't been tested. if it's a problem, remove it
                            }
                            else
                            {
                                idea.auxilleryVerb = verb;
                                idea.verbTypes = VerbTypes.conjugated_infinitive;
                            }
                            if (removeAccents(rootWord) != removeAccents(word))
                            {
                                pronounsAttatched = true;
                            }
                            idea = extractor(idea, removeAccents(word.Substring(rootWord.Length)), dictionary);
                        }
                    }
                    //see if it's a spanish participle
                    if (word.Length >= verb.spanishParticiple.Length)
                    {
                        rootWord = removeAccents(word.Substring(0, verb.spanishParticiple.Length));
                    }
                    if (removeAccents(rootWord) == verb.spanishParticiple && idea.auxilleryVerb == null)
                    {
                        //it is a spanish participle
                        idea.auxilleryVerb = verb;
                        if (idea.verb == null)
                        {
                            //having trouble recognizing the verb
                            throw new Exception("No conjugated verb before participle");
                        }
                        else
                        {
                            idea.verbTypes = VerbTypes.conjugated_participle;
                        }
                        if (removeAccents(rootWord) != removeAccents(word))
                        {
                            pronounsAttatched = true;
                        }
                        idea = extractor(idea, removeAccents(word.Substring(rootWord.Length)), dictionary);
                    }
                    //see if it's an command
                    Person commandPerson = Person.secondSing;
                    for (int commandTenseNum = 0; commandTenseNum < 4; commandTenseNum++) //-we, -y'all, -you, -you(formal)
                    {
                        switch (commandTenseNum)
                        {
                            case 0:
                                commandPerson = Person.firstPlural;
                                break;
                            case 1:
                                commandPerson = Person.secondPlural;
                                break;
                            case 2:
                                commandPerson = Person.secondSing;
                                break;
                            case 3:
                                commandPerson = Person.thirdSing;
                                break;
                        }
                        //check for affirmative form
                        string[] allForms = verb.spanishCommandForms.allForms();
                        string affirmativeVerb = verb.spanishCommandForms.allForms()[commandTenseNum];
                        if (idea.ideaType != IdeaType.command)
                        {
                            if (word.Length >= affirmativeVerb.Length)
                            {
                                rootWord = removeAccents(word.Substring(0, affirmativeVerb.Length));
                            }
                            List<string> possibleIndirects = dictionary.indirectObjects.indirectObjects(Language.spanish);
                            List<string> possibleDirects = dictionary.directObjects.directObjects(Language.spanish);
                            possibleIndirects.Add("");
                            possibleDirects.Add("");
                            foreach (string possibleIndirect in possibleIndirects)
                            {
                                foreach (string possibleDirect in possibleDirects)
                                {
                                    bool wordsAreEqual = removeAccents(word) == (removeAccents(rootWord) + removeAccents(possibleIndirect)
                                        + removeAccents(possibleDirect));
                                    bool equalsAffVerb = removeAccents(affirmativeVerb) == removeAccents(rootWord);
                                    if (wordsAreEqual && equalsAffVerb)
                                    {
                                        idea.verb = verb;
                                        idea.indirectObject = (possibleIndirect == "") ? null : removeAccents(possibleIndirect);
                                        idea.directObject = (possibleDirect == "") ? null : removeAccents(possibleDirect);
                                        idea.subject = dictionary.subjects.spanishDefaults[(int)commandPerson];
                                        idea.ideaType = IdeaType.command;
                                        if (removeAccents(rootWord) != removeAccents(word))
                                        {
                                            pronounsAttatched = true;
                                            idea.possiblyTuCommandOrThirdPeron = false;
                                        }
                                        else
                                        {
                                            pronounsAttatched = false;
                                        }
                                        /*if (removeAccents(word) == verb.spanishForms.allForms()[2])
                                        {
                                            idea.eitherIOPorDOP = true;
                                        }*/
                                        if (possibleIndirect == "" ^ possibleDirect == "")
                                        {
                                            string combo = possibleDirect + possibleIndirect;
                                            if (combo != "les" || combo != "las" || combo != "los" ||
                                               combo != "le" || combo != "la" || combo != "lo")
                                            {
                                                idea.eitherIOPorDOP = true;
                                            }
                                        }
                                        if (word == verb.spanishCommandForms.allForms()[2] && word == verb.spanishForms.allForms()[2])
                                        {
                                            idea.subject = dictionary.subjects.spanishDefaults[2];
                                            idea.ideaType = IdeaType.declarative;
                                            idea.possiblyTuCommandOrThirdPeron = true;
                                            goto endOfWordThinker;
                                        }
                                    }
                                }
                                //now check for negitive command form
                                if (verb.spanishCommandForms.allForms()[commandTenseNum + 4] == word.ToLower())
                                {
                                    idea.verb = verb;
                                    commandVerbRoot = rootWord;
                                    pronounsAttatched = false;
                                    idea.ideaType = IdeaType.command;
                                    idea.subject = dictionary.subjects.spanishDefaults[(int)commandPerson];
                                }
                            }
                        }
                    }
                }
            endOfWordThinker:
                wordNum++;
            }
            /*
            if (idea.negitive == false && idea.subject == dictionary.subjects.spanishDefaults[2] &&
                idea.indirectObject == null && idea.directObject == null)// add some clause  to not make 'de' possibly
            {
                idea.possiblyTuCommandOrThirdPeron = true;
            }*/
            if (pronounsAttatched == false)
            {
                foreach (string word in words)
                {
                    foreach (string indirectObject in
                        dictionary.indirectObjects.indirectObjects(Language.spanish))
                    {
                        if (word.ToLower() == indirectObject)
                        {
                            idea.indirectObject = indirectObject;
                            idea.eitherIOPorDOP = true;
                            //look to see if there's a DOP
                            foreach (string directObject in dictionary.directObjects.directObjects(Language.spanish))
                            {
                                if (words.Count > words.IndexOf(idea.indirectObject) - 1)
                                {
                                    if (words[words.IndexOf(idea.indirectObject) + 1].ToLower() == directObject)
                                    {
                                        idea.directObject = directObject;
                                        idea.eitherIOPorDOP = false;
                                    }
                                }
                            }
                        }
                    }
                    if (idea.indirectObject == null)
                    {
                        foreach (string directObject in
                            dictionary.directObjects.directObjects(Language.spanish))
                        {
                            if (word.ToLower() == directObject)
                            {
                                idea.directObject = directObject;
                            }
                        }
                    }
                }
            }
            foreach (string word in words)
            {
                foreach (string possibleFemininePronoun in dictionary.subjects.subjectsOfGender(Gender.feminine))
                {
                    if (word.ToLower() == possibleFemininePronoun)
                    {
                        idea.subject = possibleFemininePronoun;
                        idea.masculineSubject = false;
                        idea.foundSubject = true;
                    }
                }
                foreach (string possibleMasculinePronoun in dictionary.subjects.subjectsOfGender(Gender.masculine))
                {
                    if (word.ToLower() == possibleMasculinePronoun)
                    {
                        idea.subject = possibleMasculinePronoun;
                        idea.masculineSubject = true;
                        idea.foundSubject = true;
                    }
                }
            }
            if (idea.ideaType == IdeaType.command && idea.verbTypes == VerbTypes.infinitive)
            {
                idea.verbTypes = VerbTypes.conjugated;
            }
            if (idea.ideaType == IdeaType.command)
            {
                if (dictionary.subjects.findPersonForSubject(idea.subject, Language.spanish) == Person.thirdSing)
                {
                    idea.subject = dictionary.subjects.spanishDefaults[1];
                }
            }
            if (pronounsAttatched == false)
            {
                if (idea.negitive == false && (idea.indirectObject != null || idea.directObject != null) &&
                    dictionary.subjects.findPersonForSubject(idea.subject, Language.spanish) == Person.thirdSing)
                {
                    idea.possiblyTuCommandOrThirdPeron = false;
                }
                if (idea.negitive == false && idea.ideaType == IdeaType.command &&
                    idea.possiblyTuCommandOrThirdPeron == false &&
                    (idea.directObject == null ^ idea.indirectObject == null))
                {
                    string betterOption = idea.subject + " " + commandVerbRoot +
                        ((idea.indirectObject != null) ? idea.indirectObject : "") +
                        ((idea.directObject != null) ? idea.directObject : "");
                    throw new Exception("You need to stack pronouns on the end of an affirmative verb. Try: \"" + betterOption
                         + "\" instead.");
                }
            }
            return idea;
        }
        Idea extractor(Idea idea, string ending, Dictionary dictionary)
        {
            //add code to look for IOP's and DOP's in the ending
            foreach (string indirectObject in dictionary.indirectObjects.indirectObjects(Language.spanish))
            {
                if (ending.Length >= indirectObject.Length)
                {
                    string cutoffIndirect = ending.Substring(0, indirectObject.Length);
                    if (cutoffIndirect == indirectObject)
                    {
                        idea.eitherIOPorDOP = true;
                        idea.indirectObject = indirectObject;
                        string newEnding = ending.Substring(indirectObject.Length);
                        foreach (string directObject in dictionary.directObjects.directObjects(Language.spanish))
                        {
                            if (newEnding.Length >= directObject.Length)
                            {
                                string cutoffdirect = newEnding.Substring(0, directObject.Length);
                                if (cutoffdirect == directObject)
                                {
                                    idea.eitherIOPorDOP = false;
                                    idea.directObject = directObject;

                                    if (idea.directObject == "las" ||
                                       idea.directObject == "la")
                                    {
                                        //feminine DOP
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (idea.indirectObject == null)
            {
                foreach (string directObject in dictionary.directObjects.directObjects(Language.spanish))
                {
                    if (ending.Length >= directObject.Length)
                    {
                        string cutoffIndirect = ending.Substring(0, directObject.Length);
                        if (cutoffIndirect == directObject)
                        {
                            idea.eitherIOPorDOP = false;
                            idea.directObject = directObject;

                            if (idea.directObject == "las" ||
                               idea.directObject == "la")
                            {
                                //feminine DOP
                            }
                        }
                    }
                }
            }
            return idea;
        }
        string removeAccents(string word)
        {
            string newWord = "";
            foreach (char letter in word)
            {
                char newLetter = letter;
                if (newLetter == 'á')
                {
                    newLetter = 'a';
                }
                if (newLetter == 'é')
                {
                    newLetter = 'e';
                }
                if (newLetter == 'í')
                {
                    newLetter = 'i';
                }
                if (newLetter == 'ó')
                {
                    newLetter = 'o';
                }
                if (newLetter == 'ú')
                {
                    newLetter = 'u';
                }
                newWord += newLetter;
            }
            return newWord;
        }
        public List<string> render(Idea idea, Dictionary dictionary)
        {
            List<string> scentences = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            if (idea.verb.transitivity == Transitivity.ditransitive && idea.eitherIOPorDOP == true && (idea.directObject == null ^ idea.indirectObject == null))
            {
                if (tempIdea.directObject == null)
                {
                    scentences.AddRange(IOPswitch(tempIdea, dictionary));
                    tempIdea = new Idea(idea);
                    //tempIdea.directObject = tempIdea.indirectObject; //THIS DOESN'T WORK FOR LOS LO LAS LAS LE AND LES
                    tempIdea.directObject = dictionary.directObjects.spanishDefaults
                        [(int)dictionary.indirectObjects.findPerson(idea.indirectObject, Language.spanish)];
                    tempIdea.indirectObject = null;
                    scentences.AddRange(IOPswitch(tempIdea, dictionary));
                }
                else
                {

                    scentences.AddRange(IOPswitch(tempIdea, dictionary));
                    tempIdea = new Idea(idea);
                    tempIdea.indirectObject = dictionary.indirectObjects.spanishDefaults
                        [(int)dictionary.directObjects.findPerson(idea.directObject, Language.spanish)];
                    tempIdea.directObject = null;
                    scentences.AddRange(IOPswitch(tempIdea, dictionary));
                }
            }
            else
            {
                if (idea.verb.transitivity == Transitivity.transitiveDirect && idea.indirectObject != null && idea.directObject == null)
                {
                    idea.directObject = idea.indirectObject;
                    idea.indirectObject = null;
                }
                if (idea.verb.transitivity == Transitivity.transitiveIndirect && idea.directObject != null && idea.indirectObject == null)
                {
                    idea.directObject = idea.indirectObject;
                    idea.indirectObject = null;
                }
                scentences.AddRange(IOPswitch(idea, dictionary));
            }
            /*List<string> finalScentences = new List<string>(1);
            foreach (string scentence in scentences)
            {
                bool foundMatch = false;
                List<string> remainingScentences = scentences;
                remainingScentences.Remove(scentence);
                foreach (string otherScentence in remainingScentences)
                {
                    if(otherScentence == )
                }
            }*/
            return scentences;
        }
        public List<string> IOPswitch(Idea idea, Dictionary dictionary)
        {
            List<string> scentences = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            if (tempIdea.indirectObject != null && tempIdea.directObject != null)
            {
                if (tempIdea.directObject.StartsWith("l") && tempIdea.indirectObject.StartsWith("l"))
                {
                    tempIdea.indirectObject = "se";
                }
            }
            scentences.AddRange(DOPswitch(idea, dictionary));
            return scentences;
        }
        public List<string> DOPswitch(Idea idea, Dictionary dictionary)
        {
            List<string> scentences = new List<string>(1);
            if (idea.DOPisIt == true)
            {
                Idea tempIdea = new Idea(idea);
                tempIdea.directObject = "lo";
                scentences.AddRange(ideaSwitch(idea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.directObject = "la";
                scentences.AddRange(ideaSwitch(tempIdea, dictionary));
            }
            else{
                scentences.AddRange(ideaSwitch(idea,dictionary));
            }

            return scentences;
        }
        public List<string> ideaSwitch(Idea idea, Dictionary dictionary)
        {
            List<string> scentences = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            if (tempIdea.possiblyInfinitive == true)
            {
                scentences.Add(idea.verb.spanishInfinitive);
            }
            switch (tempIdea.ideaType)
            {
                case IdeaType.command:
                    scentences.Add(command(tempIdea, dictionary));
                    break;
                case IdeaType.declarative:
                    scentences.Add(declarative(tempIdea, dictionary));
                    break;
                case IdeaType.infinitive:
                    scentences.Add(tempIdea.verb.spanishInfinitive);
                    break;
                case IdeaType.interogitive:
                    throw new Exception("Questions not implemented");
                    break;
            }
            return scentences;
        }
        string declarative(Idea idea, Dictionary dictionary)
        {
            List<string> words = new List<string>(1);
            //words.Add(idea.subject);
            Person subjectPerson = dictionary.subjects.findPersonForSubject(idea.subject, Language.spanish);
            if (idea.indirectObject != null && idea.directObject != null)
            {
                if (idea.indirectObject[0] == 'l' && idea.directObject[0] == 'l')
                {
                    string oldIO = idea.indirectObject;
                    idea.indirectObject = "se";
                }
            }
            if (idea.negitive == true)
            {
                words.Add("no");
            }
            if (idea.verbTypes == VerbTypes.conjugated || idea.verbTypes == VerbTypes.infinitive)
            {
                if (idea.indirectObject != null)
                {
                    words.Add(idea.indirectObject);
                }
                if (idea.directObject != null)
                {
                    words.Add(idea.directObject);
                }
            }
            words.Add(idea.verb.spanishForms.allForms()[(int)subjectPerson]);
            if (idea.verbTypes == VerbTypes.conjugated_infinitive)
            {
                words.Add("a");
                words.Add(idea.auxilleryVerb.spanishInfinitive +
                    ((idea.indirectObject != null) ? idea.indirectObject : "") +
                    ((idea.directObject != null) ? idea.directObject : ""));
            }
            if (idea.verbTypes == VerbTypes.conjugated_participle)
            {
                words.Add(idea.auxilleryVerb.spanishParticiple +
                    ((idea.indirectObject != null) ? idea.indirectObject : "") +
                    ((idea.directObject != null) ? idea.directObject : ""));
            }
            return grammer(words);
        }
        string command(Idea idea, Dictionary dictionary)
        {
            List<string> words = new List<string>(1);
            string verb = idea.verb.spanishCommandForms.allForms()
                [CommandForms.getIntForPerson(dictionary.subjects.findPersonForSubject
                (idea.subject, Language.spanish), idea.negitive)];
            if (idea.indirectObject != null && idea.directObject != null)
            {
                if (idea.indirectObject[0] == 'l' && idea.directObject[0] == 'l')
                {
                    string oldIO = idea.indirectObject;
                    idea.indirectObject = "se";
                }
            }
            if (idea.negitive == true)
            {
                words.Add("no");
                if (idea.indirectObject != null)
                {
                    words.Add(idea.indirectObject);
                }
                if (idea.directObject != null)
                {
                    words.Add(idea.directObject);
                }
                words.Add(verb);
            }
            else
            {
                words.Add(verb + ((idea.indirectObject != null) ? idea.indirectObject : "") +
                    ((idea.directObject != null) ? idea.directObject : ""));
            }
            switch (idea.verbTypes)
            {
                case VerbTypes.conjugated_infinitive:
                    words.Add("a");
                    words.Add(idea.auxilleryVerb.spanishInfinitive);
                    break;
                case VerbTypes.conjugated_participle:
                    words.Add(idea.auxilleryVerb.spanishParticiple);
                    break;
            }
            return grammer(words);
        }
        string grammer(List<string> words)
        {
            string scentence = "";
            foreach (string word in words)
            {
                scentence += word + " ";
            }
            bool capitalizedALetter = false;
            string finalScentence = "";
            foreach (char character in scentence)
            {
                char newChar = character;
                if (capitalizedALetter == false && char.IsLetter(character))
                {
                    capitalizedALetter = true;
                    newChar = char.ToUpper(character);
                }
                finalScentence += newChar;
            }
            finalScentence = finalScentence.Substring(0, finalScentence.Length - 1);
            finalScentence += ".";
            return finalScentence;
        }
    }
}
