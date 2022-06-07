using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SaleLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SaleLib.");
            English english = new English();
            Spanish spanish = new Spanish();
            Dictionary dictionary = new Dictionary();
            while (true)
            {
                /*
                Console.Write(">>");
                String scenetence = Console.ReadLine();
                Idea i;
                List<string> allPossibleTranslations = new List<string>();
                //i = s.understand(scenetence, babyWords);
                //i.translate(Language.english, babyWords);
                //allPossibleTranslations = e.render(i, babyWords);
                i = e.understand(scenetence, babyWords);
                i.translate(Language.spanish, babyWords);
                allPossibleTranslations = s.render(i, babyWords);
                foreach (string possibleTranslation in allPossibleTranslations)
                {
                    Console.WriteLine("\"" + possibleTranslation + "\"");
                }
                Console.WriteLine("-----------------------");
                Console.WriteLine("Subject: " + i.subject);
                Console.WriteLine("DOP: " + i.directObject);
                Console.WriteLine("IOP :" + i.indirectObject);
                Console.WriteLine("Possibly Either: " + (i.eitherIOPorDOP ? "true" : "false"));*/

                string scentence = Console.ReadLine();
                List<string> possibleEnglishTranslations = new List<string>();
                List<string> possibleSpanishTranslations = new List<string>();
                Exception error = new Exception();
                try
                {
                    //from english to spanish
                    Idea enI = english.understand(scentence, dictionary);
                    enI.translate(Language.spanish, dictionary);
                    possibleSpanishTranslations.AddRange(spanish.render(enI, dictionary));
                }
                catch (Exception exception)
                {
                    error = exception;
                }
                try
                {
                    //from spanish to english
                    Idea spI = spanish.understand(scentence, dictionary);
                    spI.translate(Language.english, dictionary);
                    possibleEnglishTranslations.AddRange(english.render(spI, dictionary));
                }
                catch (Exception exception)
                {
                    error = exception;
                }
                if (possibleEnglishTranslations.Count == 0 && possibleSpanishTranslations.Count == 0)
                {
                    MessageBox.Show(error.Message, "Oh no! An error occurred");
                }
                else
                {
                    if (possibleEnglishTranslations.Count > 0)
                    {
                        Console.WriteLine("Possible English Translations:" + Environment.NewLine);
                        foreach (string possibleTranslation in possibleEnglishTranslations)
                        {
                            Console.WriteLine(possibleTranslation + Environment.NewLine);
                        }
                    }
                    if (possibleSpanishTranslations.Count > 0)
                    {
                        Console.WriteLine("Possible Spanish Translations:" + Environment.NewLine);
                        foreach (string possibleTranslation in possibleSpanishTranslations)
                        {
                            Console.WriteLine(possibleTranslation + Environment.NewLine);
                        }
                    }
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
