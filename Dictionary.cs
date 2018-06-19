using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleLib
{
    public class Dictionary
    {
        public Subject subjects = new Subject(
            "I", "you", "it", "we", "y'all", "they",
            "yo", "tú", "él", "nosotros", "ustedes", "ellos");//need to accent the tu and el
        public List<Verb> verbs = new List<Verb>();
        public IndirectObject indirectObjects = new IndirectObject(
            "me", "you", "it", "us", "y'all", "them",
            "me", "te", "le", "nos", "XX", "les");
        public DirectObject directObjects = new DirectObject(
            "me", "you", "it", "us", "y'all", "them",
            "me", "te", "lo", "nos", "XX", "los");
        public List<Contraction> englishContractions = new List<Contraction>();
        public List<Contraction> spanishContractions = new List<Contraction>();


        public Dictionary()
        {
            subjects.addSubject("ellas", Person.thirdPlural, Language.spanish, Gender.feminine);
            subjects.addSubject("ella", Person.thirdSing, Language.spanish, Gender.feminine);
            subjects.addSubject("he", Person.thirdSing, Language.english, Gender.masculine);
            subjects.addSubject("she", Person.thirdSing, Language.english, Gender.feminine);
            subjects.addSubject("ud.", Person.secondSing, Language.spanish, Gender.masculine);
            subjects.addSubject("usted", Person.secondSing, Language.spanish, Gender.masculine);
            subjects.addSubject("uds.", Person.secondPlural, Language.spanish, Gender.masculine);
            subjects.addSubject("ustedes", Person.secondPlural, Language.spanish, Gender.masculine);
            indirectObjects.addIndirectObject("him", Person.thirdSing, Language.english);
            indirectObjects.addIndirectObject("her", Person.thirdSing, Language.english);
            indirectObjects.addIndirectObject("se", Person.thirdSing, Language.spanish);
            directObjects.addDirectObject("him", Person.thirdSing, Language.english);
            directObjects.addDirectObject("her", Person.thirdSing, Language.english);
            directObjects.addDirectObject("la", Person.thirdSing, Language.spanish);
            directObjects.addDirectObject("las", Person.thirdPlural, Language.spanish);
            indirectObjects.addIndirectObject("myself", Person.firstSing, Language.english);
            indirectObjects.addIndirectObject("yourself", Person.secondSing, Language.english);
            indirectObjects.addIndirectObject("itself", Person.thirdSing, Language.english);
            indirectObjects.addIndirectObject("himself", Person.thirdSing, Language.english);
            indirectObjects.addIndirectObject("herself", Person.thirdSing, Language.english);
            indirectObjects.addIndirectObject("ourselves", Person.firstPlural, Language.english);
            indirectObjects.addIndirectObject("ourself", Person.firstPlural, Language.english);
            indirectObjects.addIndirectObject("themselves", Person.secondPlural, Language.english);
            indirectObjects.addIndirectObject("themself", Person.secondPlural, Language.english);
            indirectObjects.addIndirectObject("yourselves", Person.secondPlural, Language.english);
            indirectObjects.addIndirectObject("themselves", Person.thirdPlural, Language.english);
            indirectObjects.addIndirectObject("themself", Person.thirdPlural, Language.english);

            englishContractions.AddRange(new Contraction[11]{
                new Contraction("don't", "do", "not"),
                new Contraction("can't", "can", "not"),
                new Contraction("let's", "let", "us"),
                new Contraction("isn't", "is", "not"),
                new Contraction("he's","he","is"),
                new Contraction("she's","she","is"),
                new Contraction("it's","it","is"),
                new Contraction("i'm","I","am"),
                new Contraction("you're","you","are"),
                new Contraction("we're","we","are"),
                new Contraction("they're","they","are")});
            spanishContractions.AddRange(new Contraction[2]{
                new Contraction("del", "de", "el"),
                new Contraction("al", "a", "el")});

            verbs.Add(
                new Verb(new TenseArray("am", "are", "is", "are", "are", "are"), "be", "being",
                         new TenseArray("estoy", "estás", "está", "estamos", "están", "están"), "estar", "estando",
                         new CommandForms("esta", "estés", "esté", "estemos", "estén"), Transitivity.ditransitive));
            verbs.Add(
                new Verb(new TenseArray("am", "are", "is", "are", "are", "are"), "be", "being",
                         new TenseArray("soy", "eres", "es", "somos", "sois", "son"), "ser", "siendo",
                         new CommandForms("sé NEVERMIND", "seas 😃", "sea 😃", "seamos 😃", "sean 😃"), Transitivity.transitiveDirect)); //this might cause problems
            verbs.Add(
                new Verb(new TenseArray("let", "lets"), "let", "letting",
                         new TenseArray("permitir"), "permitir", "permitiendo",
                         new CommandForms("permite", "permita", "permitamos", "permitan", "permitas", "permita", "permitamos", "permitan"), Transitivity.ditransitive));
            verbs.Add(
                new Verb(new TenseArray("know", "knows"), "know", "knowing",
                         new TenseArray("sé", "sabes", "sabe", "sabemos", "sabéis", "saben"), "saber", "sabiendo",
                         new CommandForms("sabe", "sepas", "sape", "sapemos", "sapen"), Transitivity.transitiveDirect));
            verbs.Add(
                new Verb(new TenseArray("put", "puts"), "put", "putting",
                         new TenseArray("pongo", "pones", "pone", "ponemos", "ponen", "ponen"), "poner", "poniendo",
                         new CommandForms("pon", "pongas", "ponga", "pongamos", "pongan"), Transitivity.transitiveDirect));
            verbs.Add(
                new Verb(new TenseArray("place", "places"), "place", "placing",
                         new TenseArray("pongo", "pones", "pone", "ponemos", "ponen", "ponen"), "poner", "poniendo",
                         new CommandForms("pon", "pongas", "ponga", "pongamos", "pongan"), Transitivity.transitiveDirect));
            verbs.Add(
                new Verb(new TenseArray("give", "gives"), "give", "giving",
                         new TenseArray("doy", "das", "da", "damos", "dan", "dan"), "dar", "dando",
                         new CommandForms("da", "de", "demos", "den", "des", "de", "demos", "den"), Transitivity.ditransitive));
            verbs.Add(
                new Verb(new TenseArray("go", "goes"), "go", "going",
                         new TenseArray("voy", "vas", "va", "vamos", "van", "van"), "ir", "yendo",
                         new CommandForms("ve", "vaya", "vayamos", "vayan", "vayas", "vaya", "vayamos", "vayan"), Transitivity.transitiveIndirect));
            verbs.Add(
                new Verb(new TenseArray("talk", "talks"), "talk", "talking",
                         new TenseArray("hablo", "hablas", "habla", "hablamos", "hablan", "hablan"), "hablar", "hablando",
                         new CommandForms("habla", "hables", "hable", "hablamos", "hablan"), Transitivity.transitiveIndirect)); //I need to make intransitive, transitiveDO, transitiveIO, and ditransitive
            verbs.Add(
                new Verb(new TenseArray("leave", "leaves"), "leave", "leaving",
                         new TenseArray("salgo", "sales", "sale", "salemos", "salen", "salen"), "salir", "saliendo",
                         new CommandForms("sal", "salgas", "salga", "salgamos", "salid"), Transitivity.transitiveDirect));
        }
    }
}
