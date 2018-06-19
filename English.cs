using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class English
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
            string[] crazyVerbs = new string[6] { "do", "does", "can", "am", "are", "is" };
            Idea idea = new Idea(null, null, null, null, null, IdeaType.declarative, false);
            List<String> words = (scentence.Split(new char[4] { ' ', ',', '.', '?' })).ToList();
            //WORK ON THIS IF GATE HERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (words.Count == 1)
            {
                //it's either a command or infinitive
                foreach (Verb verb in dictionary.verbs)
                {
                    if (words[0] == verb.englishInfinitive.ToLower())
                    {
                        idea.subject = dictionary.subjects.englishDefaults[1];
                        idea.ideaType = IdeaType.command;
                        idea.possiblyInfinitive = true; //infinitives are a subset of commands
                        idea.verb = verb;
                        return idea;
                    }
                }
            }
            else if (words.Count == 0)
            {
                throw new Exception("please enter some text");
            }
            else if (words.Count == 2 && words[0] == "to")
            {
                foreach (Verb verb in dictionary.verbs)
                {
                    if (words[1] == verb.englishInfinitive)
                    {
                        idea.ideaType = IdeaType.infinitive;
                        idea.verb = verb;
                        return idea;
                    }
                }
            }
            else
            {
                //seporate contractions
                attributedVerb firstVerb = null;
                attributedVerb secondVerb = null;
                string[] replaceStrings = new string[2];
                for (int wordNum = 0; wordNum < words.Count; wordNum++)
                {
                    replaceStrings = new string[2] { "", "" };
                    foreach (Contraction contraction in dictionary.englishContractions)
                    {
                        if (words[wordNum].ToLower() == contraction.contraction)
                        {
                            replaceStrings[0] = contraction.firstWord;
                            replaceStrings[1] = contraction.secondWord;
                        }
                    }
                    if (replaceStrings[0] != "" || replaceStrings[1] != "")
                    {
                        words.RemoveAt(wordNum);
                        words.InsertRange(wordNum, replaceStrings);
                    }
                }
                //find all verbs in list in any form
                //List<Tuple<Verb, int>> verbs = new List<Tuple<Verb, int>>();

                for (int wordNum = 0; wordNum < words.Count; )
                {
                    string word = words[wordNum].ToLower();
                    foreach (Verb verb in dictionary.verbs)
                    {
                        List<string> allVerbForms = verb.allVerbForms(Language.english);
                        foreach (String possibleConjugation in allVerbForms)
                        {
                            if (possibleConjugation == word)
                            {
                                //verbs.Add(new Tuple<Verb, int>(verb, wordNum));
                                if (firstVerb == null)
                                {
                                    firstVerb = new attributedVerb(verb, word, wordNum);
                                    if (firstVerb.verb.englishInfinitive == "let" && firstVerb.position == 0)
                                    {
                                        //if (words.Count > 1) //there is always more than one word in this branch
                                        //{
                                        idea.ideaType = IdeaType.command;
                                        idea.subject = dictionary.subjects.englishDefaults[1];
                                        if (words[1] == "us")
                                        {
                                            words.Remove("us");
                                            idea.subject = dictionary.subjects.englishDefaults[3];
                                            firstVerb = null;
                                            goto endOfWordNumLoop;
                                        }
                                        //}
                                    }
                                    //continue;
                                }
                                else
                                {
                                    if (firstVerb != null && secondVerb != null)
                                    {
                                        if (firstVerb.verb.englishInfinitive == "do")
                                        {
                                            firstVerb = secondVerb;
                                        }
                                    }
                                    if (firstVerb.position != wordNum)
                                    {
                                        secondVerb = new attributedVerb(verb, word, wordNum);
                                        if (possibleConjugation == verb.englishInfinitive)
                                        {
                                            idea.verbTypes = VerbTypes.conjugated_infinitive;
                                        }
                                        else if (possibleConjugation == verb.englishParticiple)
                                        {
                                            idea.verbTypes = VerbTypes.conjugated_participle;
                                        }
                                    }
                                }
                            }
                        }
                    }
                endOfWordNumLoop:
                    wordNum++;
                }
                if (firstVerb != null)
                {
                    idea.verb = firstVerb.verb;
                }
                else
                {
                    throw new Exception("no verb");
                }
                if (secondVerb != null)
                {
                    idea.auxilleryVerb = secondVerb.verb;
                }
                //if do in any conj. form appears directly before "not" remove it as a verb
                if(firstVerb.verb.englishInfinitive == "be" ||
                   firstVerb.verb.englishInfinitive == "can"||
                   firstVerb.verb.englishInfinitive == "do" ||
                   firstVerb.verb.englishInfinitive == "let")
                {
                    if (words.Count > firstVerb.position + 1)
                    {
                        if (words[firstVerb.position + 1] == "not")
                        {
                            idea.negitive = true;
                        }
                    }
                    /*string text = Console.ReadLine();
                    string[] seporate_words = text.Split(new char[1] { ' ' });
                    int i = 5;
                    Console.WriteLine("my number is" + i.ToString());
                    Console.WriteLine("please say 'hi'");
                    if (Console.ReadLine() == "hi")
                    {
                        "grsfdbf"==namespace
                    }*/
                }
                else
                {
                    if (firstVerb.position > 0)
                    {
                        if (words[firstVerb.position - 1] == "not")
                        {
                            idea.negitive = true;
                        }
                    }
                }
                /*foreach (Tuple<Verb, int> verb in verbs)
                {
                    if (verb.Item1.englishInfinitive.ToLower() == "do"
                        && words[verb.Item2 + 1].ToLower() == "not")
                    {
                        verbs.Remove(verb);
                    }
                }*/
                //look for let us
                /*if (words[0].ToLower() == "let")
                {
                    idea.subject = "we";
                    idea.ideaType = IdeaType.command;
                    foreach (string possibleIndirectObject in
                        dictionary.indirectObjects.indirectObjects(Language.english))
                    {
                        if (possibleIndirectObject == words[1].ToLower())
                        {
                            idea.possiblyInfinitive = false;
                            idea.indirectObject = possibleIndirectObject;
                        }
                    }
                    if (idea.indirectObject == "us")
                    {
                        idea.indirectObject = null;
                        idea.subject = "we";
                    }
                    verbs.RemoveAt(0);
                }*/
                //look for question verbs
                /*foreach (string qVerb in crazyVerbs)
                {
                    if (words[verbs[0].Item2] == qVerb && words[verbs[0].Item2] == words[0])
                    {
                        if (verbs.Count == 1 && //"do him it" "do it"
                           verbs[0].Item1.englishInfinitive == "do")
                        {
                            idea.ideaType = IdeaType.command;
                            idea.verbTypes = VerbTypes.conjugated;
                        }
                        else
                        {
                            if (words[verbs[0].Item2] == qVerb)
                            {
                                idea.ideaType = IdeaType.interogitive;
                                idea.subject = words[verbs[0].Item2 + 1];
                            }
                        }
                    }
                }*/
                //checking verb type
                /*
                switch (verbs.Count)
                {
                    case 2:
                        idea.auxilleryVerb = verbs[1].Item1;
                        string lastVerb = words[verbs[1].Item2];
                        if (lastVerb.Length < 3)
                        {
                            throw new Exception("Verb shorter than three words");
                        }
                        string ending = lastVerb.Substring(lastVerb.Length - 3);
                        if (ending.ToLower() == "ing")
                        {
                            idea.verbTypes = VerbTypes.conjugated_participle;
                        }
                        else if (lastVerb.ToLower() == verbs[1].Item1.englishInfinitive)
                        {
                            idea.verbTypes = VerbTypes.conjugated_infinitive;
                        }
                        else
                        {
                            throw new Exception("Last word in scenetence is not -ing or infinitive");
                        }
                        break;
                    case 1:
                        if (verbs[0].Item1.englishParticiple == words[verbs[0].Item2].ToLower())
                        {
                            throw new Exception("No be, go, or do verb to help to participle");
                        }
                        idea.verbTypes = VerbTypes.conjugated;
                        break;
                    case 0:
                    default:
                        throw new Exception("Invalid number of verbs");
                        break;

                }*/
                //look for do not directly before (or after with any 'be' conj) first verb to make negation
                /*if (verbs[0].Item2 > 0 && words[verbs[0].Item2 - 1].ToLower() == "not")
                {
                    idea.negitive = true;
                }
                else if (verbs[0].Item1.englishInfinitive == "be")
                {
                    if (verbs.Count > 1 &&
                        words[verbs[1].Item2 - 1].ToLower() == "not")
                    {
                        idea.negitive = true;
                    }
                    if (words[verbs[0].Item2 + 1].ToLower() == "not")
                    {
                        idea.negitive = true;
                    }
                }
                else
                {
                    idea.negitive = false;
                }*/
                //look for iop floating if not two ops
                for (int wordNum = 0; wordNum <= words.Count - 2; wordNum++)
                {
                    foreach (string indirectObject in dictionary.indirectObjects.indirectObjects(Language.english))
                    {
                        if (words[wordNum] == "to" &&
                            words[wordNum + 1] == indirectObject)
                        {
                            idea.indirectObject = indirectObject;
                        }
                        if (words[wordNum] == "for" &&
                            words[wordNum + 1] == indirectObject)
                        {
                            idea.indirectObject = indirectObject;
                        }
                    }
                }
                //look for op(s) after verb
                /*
                bool foundCrazyVerb = false;
                foreach (string verb in crazyVerbs)
                {
                    if (verb == words[verbs[0].Item2])
                    {
                        foundCrazyVerb = true;
                    }
                }
                if (foundCrazyVerb == true && verbs.Count == 1 && idea.negitive == true)
                {
                    //check to see if the scentence is long enough to have a DOP
                    if (words.Count > verbs[0].Item2)
                    {
                        //look ahead and see if a DOP exists
                        foreach (string possibleDirectObjects in dictionary.directObjects.directObjects(Language.english))
                        {
                            if (words[verbs[0].Item2 + 2] == possibleDirectObjects)
                            {
                                idea.directObject = words[verbs[0].Item2 + 2];
                                if (verbs[0].Item1.englishInfinitive == "be")
                                {
                                    idea.useSer = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (idea.indirectObject == null)
                    {
                        if (words.Count - 1 > verbs[verbs.Count - 1].Item2)
                        {
                            foreach (string possibleIndirectObjects in dictionary.indirectObjects.indirectObjects(Language.english))
                            {
                                if (words[verbs[verbs.Count - 1].Item2 + 1] == possibleIndirectObjects)
                                {
                                    idea.indirectObject = words[verbs[verbs.Count - 1].Item2 + 1];
                                    idea.eitherIOPorDOP = true;
                                    //look ahead and see if another op exists; if it does, it's the DOP
                                    if (words.Count > verbs[verbs.Count - 1].Item2 + 2)
                                    {
                                        foreach (string possibleDirectObjects in dictionary.directObjects.directObjects(Language.english))
                                        {
                                            if (words[verbs[verbs.Count - 1].Item2 + 2] == possibleDirectObjects)
                                            {
                                                idea.directObject = words[verbs[verbs.Count - 1].Item2 + 2];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (idea.indirectObject == "" || idea.indirectObject == null)
                        {
                            if (words.Count - 1 > verbs[verbs.Count - 1].Item2)
                            {
                                foreach (string possibleDirectObjects in dictionary.directObjects.directObjects(Language.english))
                                {
                                    if (words[verbs[verbs.Count - 1].Item2 + 1] == possibleDirectObjects)
                                    {
                                        idea.directObject = words[verbs[verbs.Count - 1].Item2 + 1];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (words.Count - 1 > verbs[verbs.Count - 1].Item2)
                        {
                            foreach (string possibleDirectObjects in dictionary.directObjects.directObjects(Language.english))
                            {
                                if (words[verbs[verbs.Count - 1].Item2 + 1] == possibleDirectObjects)
                                {
                                    idea.directObject = words[verbs[verbs.Count - 1].Item2 + 1];
                                }
                            }
                        }
                    }
                }*/
                int lastVerbPosition = 0;
                if (secondVerb == null)
                {
                    lastVerbPosition = firstVerb.position;
                }
                else
                {
                    lastVerbPosition = secondVerb.position;
                }
                if (idea.indirectObject == null)
                {
                    if (words.Count > lastVerbPosition + 1)
                    {
                        //look for an IO directly following the verb
                        foreach (string possibleIndirectObject in dictionary.indirectObjects.indirectObjects(Language.english))
                        {
                            if (possibleIndirectObject == words[lastVerbPosition + 1])
                            {
                                //if found set idea.eitherIOPorDop to be true
                                idea.indirectObject = possibleIndirectObject;
                                idea.eitherIOPorDOP = true;
                                //look for a DO following the IO (or 2+ the last verb)
                                if (words.Count > lastVerbPosition + 2)
                                {
                                    foreach (string possibleDirectObject in dictionary.directObjects.directObjects(Language.english))
                                    {
                                        if (words[lastVerbPosition + 2] == possibleDirectObject)
                                        {
                                            //if found idea.eitherIOPorDOP = false
                                            idea.eitherIOPorDOP = false;
                                            idea.directObject = possibleDirectObject;
                                        }
                                    }
                                }
                            }
                        }
                        //if not found look for a DO
                        if (idea.indirectObject == null)
                        {
                            foreach (string possibleDirectObject in dictionary.directObjects.directObjects(Language.english))
                            {
                                if (words[lastVerbPosition + 1] == possibleDirectObject)
                                {
                                    idea.eitherIOPorDOP = false;
                                    idea.directObject = possibleDirectObject;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //look for only a DO in the spot directly following the verb
                    foreach (string possibleDirectObject in dictionary.directObjects.directObjects(Language.english))
                    {
                        if (words[lastVerbPosition + 1] == possibleDirectObject)
                        {
                            idea.eitherIOPorDOP = false;
                            idea.directObject = possibleDirectObject;
                        }
                    }
                }
                //look for subject before verb
                if (idea.ideaType == IdeaType.declarative)
                {
                    for (int wordNum = 0; wordNum < firstVerb.position; wordNum++)
                    {
                        foreach (string subject in dictionary.subjects.subjects(Language.english))
                        {
                            if (words[wordNum].ToLower() == subject.ToLower())
                            {
                                idea.subject = subject;
                            }
                        }
                    }
                }
            }
            if (idea.subject == null)
            {
                idea.ideaType = IdeaType.command;
                idea.subject = "you";
            }
            if (idea.verb.englishInfinitive == "be")
            {
                if (idea.auxilleryVerb != null)
                {
                    //use ester
                    foreach (Verb verb in dictionary.verbs)
                    {
                        if (verb.spanishInfinitive == "eatar")
                        {
                            idea.verb = verb;
                        }
                    }
                }
                else
                {
                    foreach (Verb verb in dictionary.verbs)
                    {
                        if (verb.spanishInfinitive == "ser")
                        {
                            idea.verb = verb;
                            idea.eitherIOPorDOP = false;
                        }
                    }
                }
            }
            return idea;
        }
        public List<string> render(Idea idea, Dictionary dictionary)
        {
            if (idea.verb == null)
            {
                throw new Exception("No verb. You possibly could've made a negative command with pronouns attatched");
            }
            List<string> returnScentences = new List<string>(1);
            if (idea.verbTypes == VerbTypes.infinitive)
            {
                returnScentences.Add("to " + idea.verb.englishInfinitive);
            }
            else
            {
                if (idea.verb.transitivity == Transitivity.ditransitive && idea.eitherIOPorDOP == true && (idea.indirectObject == null ^ idea.directObject == null))
                {
                    Idea tempIdea = new Idea(idea);
                    //if (idea.verb.transitivity == Transitivity.ditransitive)
                    //{
                        if (idea.indirectObject == null)
                        {
                            returnScentences.AddRange(DOPswitch(tempIdea, dictionary));
                            tempIdea = new Idea(idea);
                            tempIdea.indirectObject = idea.directObject;
                            tempIdea.directObject = null;
                            returnScentences.AddRange(DOPswitch(tempIdea, dictionary));
                        }
                        else
                        {
                            returnScentences.AddRange(DOPswitch(tempIdea, dictionary));
                            tempIdea = new Idea(idea);
                            tempIdea.directObject = idea.indirectObject;
                            tempIdea.indirectObject = null;
                            returnScentences.AddRange(DOPswitch(tempIdea, dictionary));
                        }
                    //}
                }
                else
                {
                    returnScentences.AddRange(DOPswitch(idea, dictionary));
                }
            }
            /*
            List<string> tempBigBucket = returnScentences;
            foreach (string scentence in tempBigBucket)
            {
                List<string> newBucket = new List<string>();
                //newBucket = returnScentences;
                newBucket.Remove(scentence);
                foreach (string otherScentence in newBucket)
                {
                    if (otherScentence == scentence)
                    {
                        returnScentences.Remove(scentence);
                    }
                }
            }*/
            return returnScentences;
        }
        List<string> DOPswitch(Idea idea, Dictionary dictionary)
        {
            List<string> returnScentences = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            //just added
            if (tempIdea.verb.transitivity == Transitivity.transitiveIndirect && tempIdea.directObject != null)
            {
                tempIdea.directObject = tempIdea.indirectObject;
            }
            //expiermental
            if (idea.directObject == null)
            {
                returnScentences.AddRange(IOPSwitch(idea, dictionary));
            }
            else
            {
                if (tempIdea.directObject == "him" ||
                    tempIdea.directObject == "her" ||
                    tempIdea.directObject == "it")
                {
                    tempIdea.directObject = "it";
                    returnScentences.AddRange(IOPSwitch(tempIdea, dictionary));
                    tempIdea = new Idea(idea);
                    if (tempIdea.eitherIOPorDOP == false)
                    {
                        if (idea.DOPgender == Gender.masculine)
                        {
                            tempIdea.directObject = "him";
                            returnScentences.AddRange(IOPSwitch(tempIdea, dictionary));
                        }
                        else
                        {
                            tempIdea.directObject = "her";
                            returnScentences.AddRange(IOPSwitch(tempIdea, dictionary));
                        }
                    }
                    else
                    {
                        tempIdea.directObject = "him";
                        returnScentences.AddRange(IOPSwitch(tempIdea, dictionary));
                        tempIdea = new Idea(idea);
                        tempIdea.directObject = "her";
                        returnScentences.AddRange(IOPSwitch(tempIdea, dictionary));
                    }
                }
                else
                {
                    returnScentences.AddRange(IOPSwitch(tempIdea, dictionary));
                }
            }
            return returnScentences;
        }
        List<string> IOPSwitch(Idea idea, Dictionary dictionary)
        {
            List<string> finalScentence = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            //just added
            if (tempIdea.verb.transitivity == Transitivity.transitiveIndirect && tempIdea.directObject != null)
            {
                tempIdea.directObject = tempIdea.indirectObject;
            }
            //expiermental
            if (idea.IOPwasSe == true)
            {
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "it";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "him";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "her";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "them";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
            }
            else if (tempIdea.indirectObject == "it" ||
                tempIdea.indirectObject == "him" ||
                tempIdea.indirectObject == "her")
            {
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "it";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "him";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.indirectObject = "her";
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
            }
            else
            {
                finalScentence.AddRange(SubjectSwitch(tempIdea, dictionary));
            }
            return finalScentence;
        }
        List<string> SubjectSwitch(Idea idea, Dictionary dictionary)
        {

            List<string> returnScentences = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            returnScentences.AddRange(SplitIdeaType(tempIdea, dictionary));
            Person person = dictionary.subjects.findPersonForSubject(tempIdea.subject, Language.english);
            /*if (person == Person.thirdSing || (person == Person.secondSing && idea.possiblyTuCommandOrThirdPeron == true))
            {

            }*/
            if (person == Person.thirdSing &&
                tempIdea.foundSubject == false/* &&
                tempIdea.possiblyTuCommandOrThirdPeron == false*/)
            {
                tempIdea = new Idea(idea);
                tempIdea.subject = "he";
                returnScentences.AddRange(SplitIdeaType(tempIdea, dictionary));
                tempIdea = new Idea(idea);
                tempIdea.subject = "she";
                returnScentences.AddRange(SplitIdeaType(tempIdea, dictionary));
            }
            tempIdea = new Idea(idea);
            if (person == Person.thirdSing &&
                tempIdea.foundSubject == true/* &&
                idea.possiblyTuCommandOrThirdPeron == false*/)
            {
                if (tempIdea.masculineSubject == true)
                {
                    tempIdea.subject = "he";
                }
                else
                {
                    tempIdea.subject = "she";
                }
                returnScentences.AddRange(SplitIdeaType(tempIdea, dictionary));
            }
            return returnScentences;
        }
        List<string> SplitIdeaType(Idea idea, Dictionary dictionary)
        {
            List<string> returnScentences = new List<string>(1);
            Idea tempIdea = new Idea(idea);
            if (tempIdea.ideaType == IdeaType.command)
            {
                returnScentences.Add(command(tempIdea, dictionary));
            }
            else
            {
                returnScentences.Add(declarative(tempIdea, dictionary));
                if (tempIdea.possiblyTuCommandOrThirdPeron == true)
                {
                    tempIdea.subject = "you";
                    returnScentences.Add(command(idea, dictionary));
                }
            }
            return returnScentences;
        }
        string declarative(Idea idea, Dictionary dictionary)
        {
            List<string> commandScentence = new List<string> { idea.subject };
            commandScentence.AddRange(makeGerunPhrase(idea, dictionary));
            return grammer(commandScentence);
        }
        string command(Idea idea, Dictionary dictionary)
        {
            List<string> commandScentence = new List<string>(2);
            Idea tempIdea = new Idea(idea);
            if (dictionary.subjects.findPersonForSubject(tempIdea.subject, Language.english) == Person.thirdSing)
            {
                tempIdea.subject = "you";
            }
            if (tempIdea.subject == "we")
            {
                commandScentence.Add("let's");
            }
            else
            {
                commandScentence.Add("(" + tempIdea.subject + ")");
            }
            commandScentence.AddRange(makeGerunPhrase(tempIdea, dictionary));
            if (tempIdea.subject == "we" && tempIdea.negitive == true)
            {
                commandScentence.Remove("don't");
                commandScentence.Insert(1, "not");
            }
            return grammer(commandScentence);
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
        List<string> makeGerunPhrase(Idea idea, Dictionary dictionary)
        {
            if (idea.indirectObject != null)
            {
                if (dictionary.indirectObjects.findPerson(idea.indirectObject, Language.english) == dictionary.subjects.findPersonForSubject(idea.subject, Language.english))
                {
                    switch (idea.indirectObject)
                    {
                        case "me":
                            idea.indirectObject = "myself";
                            break;
                        case "you":
                            idea.indirectObject = "yourself";
                            break;
                        case "it":
                            if (idea.indirectObject == "it" && idea.subject == "it")
                            {
                                idea.indirectObject = "itself";
                            }
                            break;
                        case "him":
                            if (idea.indirectObject == "him" && idea.subject == "he")
                            {
                                idea.indirectObject = "himself";
                            }
                            break;
                        case "her":
                            if (idea.indirectObject == "her" && idea.subject == "she")
                            {
                                idea.indirectObject = "herself";
                            }
                            break;
                        case "us":
                            idea.indirectObject = "ourselves";
                            break;
                        case "them":
                            idea.indirectObject = "themselves";
                            break;
                    }
                }
            }
            if (idea.directObject != null)
            {
                if (dictionary.directObjects.findPerson(idea.directObject, Language.english) == dictionary.subjects.findPersonForSubject(idea.subject, Language.english))
                {
                    switch (idea.directObject)
                    {
                        case "me":
                            idea.directObject = "myself";
                            break;
                        case "you":
                            idea.directObject = "yourself";
                            break;
                        case "it":
                            if (idea.directObject == "it" && idea.subject == "it")
                            {
                                idea.directObject = "itself";
                            }
                            break;
                        case "him":
                            if (idea.directObject == "him" && idea.subject == "he")
                            {
                                idea.directObject = "himself";
                            }
                            break;
                        case "her":
                            if (idea.directObject == "her" && idea.subject == "she")
                            {
                                idea.directObject = "herself";
                            }
                            break;
                        case "us":
                            idea.directObject = "ourselves";
                            break;
                        case "them":
                            idea.directObject = "themselves";
                            break;
                    }
                }
            }
            Person person = dictionary.subjects.findPersonForSubject(idea.subject, Language.english);
            List<string> gerunPhrase = new List<string>(2);
            if (idea.negitive == false)
            {
                gerunPhrase.Add(idea.verb.englishForms.allForms()[(int)person]);
            }
            else
            {
                if (idea.verb.englishInfinitive == "be" ||
                    idea.verb.englishInfinitive == "can")
                {
                    gerunPhrase.Add(idea.verb.englishForms.allForms()[(int)person]);
                        gerunPhrase.Add("not");
                }
                else
                {
                    gerunPhrase.Add("don't");
                    gerunPhrase.Add(idea.verb.englishForms.allForms()[(int)person]);
                }
            }
            if (idea.auxilleryVerb != null)
            {
                if (idea.verbTypes == VerbTypes.conjugated_participle)
                {
                    gerunPhrase.Add(idea.auxilleryVerb.englishParticiple);
                }
                if (idea.verbTypes == VerbTypes.conjugated_infinitive)
                {
                    gerunPhrase.Add("to");
                    gerunPhrase.Add(idea.auxilleryVerb.englishInfinitive);
                }
            }
            if (idea.directObject != null)
            {
                gerunPhrase.Add(idea.directObject);
            }
            if (idea.indirectObject != null)
            {
                gerunPhrase.Add("to");
                gerunPhrase.Add(idea.indirectObject);
            }
            return gerunPhrase;       //Make infinitvie folow "to" or "a"
        }                             //Make infinitvie folow "to" or "a"
    }
}