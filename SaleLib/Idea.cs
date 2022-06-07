using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class Idea
    {
        public string subject;
        public Verb verb;
        public string indirectObject;
        public string directObject;
        public Verb auxilleryVerb;
        public IdeaType ideaType;
        public bool negitive;
        public bool IOPwasSe = false;
        public bool eitherIOPorDOP = false;//add dop gender
        //public bool definateDOPgender = false;
        public Gender DOPgender = Gender.masculine;
        public bool DOPisIt = false;
        public bool masculineSubject = true;
        public bool foundSubject = false;
        public bool possiblyInfinitive = false;
        public bool possiblyTuCommandOrThirdPeron = false;
        //public bool definitlyUstedes = false;
        //public bool definitlyThirdPlural = false;
        public VerbTypes verbTypes = VerbTypes.infinitive;

        public Idea(
            string subject, Verb verb,
            string indirectObject, string directObject,
            Verb auxilleryVerb, IdeaType ideaType, bool negitive)
        {
            this.subject = subject;
            this.verb = verb;
            this.indirectObject = indirectObject;
            this.directObject = directObject;
            this.auxilleryVerb = auxilleryVerb;
            this.ideaType = ideaType;
            this.negitive = negitive;
        }
        public Idea(Idea idea)
        {
            this.verb = idea.verb;
            this.DOPisIt = idea.DOPisIt;
            this.subject = idea.subject;
            this.IOPwasSe = idea.IOPwasSe;
            this.ideaType = idea.ideaType;
            this.negitive = idea.negitive;
            this.verbTypes = idea.verbTypes;
            this.DOPgender = idea.DOPgender;
            this.foundSubject = idea.foundSubject;
            this.directObject = idea.directObject;
            this.auxilleryVerb = idea.auxilleryVerb;
            this.indirectObject = idea.indirectObject;
            this.eitherIOPorDOP = idea.eitherIOPorDOP;
            this.masculineSubject = idea.masculineSubject;
            this.possiblyInfinitive = idea.possiblyInfinitive;
            this.possiblyTuCommandOrThirdPeron = idea.possiblyTuCommandOrThirdPeron;
        }
        public void translate(Language destinationLanguage, Dictionary dictionary)
        {
            if (verb.transitivity == Transitivity.transitiveDirect)
            {
                if (directObject == null && indirectObject != null)
                {
                    directObject = indirectObject;
                    indirectObject = null;
                    eitherIOPorDOP = false;
                }
            }
            else if (verb.transitivity == Transitivity.transitiveIndirect)
            {
                if (indirectObject == null && directObject != null)
                {
                    indirectObject = directObject;
                    directObject = null;
                    eitherIOPorDOP = false;
                }
            }
            else if (verb.transitivity == Transitivity.intransitive)
            {
                if (indirectObject != null && directObject != null)
                {
                    indirectObject = null;
                    directObject = null;
                    eitherIOPorDOP = false;
                }
            }
            if (destinationLanguage == Language.spanish && directObject == "it")
            {
                DOPisIt = true;
            }
            if (subject != null)
            {
                subject = dictionary.subjects.translate(subject, destinationLanguage);
            }
            if (indirectObject != null)
            {
                if (indirectObject == "se")
                {
                    IOPwasSe = true;
                    eitherIOPorDOP = false;
                }
                if (indirectObject == "le" || indirectObject == "les")
                {
                    eitherIOPorDOP = false;
                }
                indirectObject = dictionary.indirectObjects.translate(indirectObject, destinationLanguage);
            }
            if (directObject != null)
            {
                if (directObject == "la" || directObject == "her")
                {
                    DOPgender = Gender.feminine;
                }
                if (directObject == "lo" || directObject == "him")
                {
                    DOPgender = Gender.masculine;
                }
                directObject = dictionary.directObjects.translate(directObject, destinationLanguage);
            }
        } 
    }

    public enum IdeaType    
    {                
        declarative, 
        interogitive,
        command,     
        infinitive   
    }                
    public enum VerbTypes
    {
        infinitive,
        conjugated,
        conjugated_infinitive,
        conjugated_participle
    }
}
