using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Counting_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Kelime Sayma Aracına Hoşgeldiniz *****\n");

            Console.WriteLine("Kelimesi sayılacak metin belgesinin uzantısını yapıştırın...");
            string text_path = Console.ReadLine();
            string text = File.ReadAllText(text_path);

            string textdef = NoktalamaSilme(text);

            List<string> charHold = new List<string>();

            foreach (char karakter in textdef)
            {
                if (!char.IsLetterOrDigit(karakter) && !char.IsWhiteSpace(karakter))
                {
                    charHold.Add(karakter.ToString());
                }
            }
            if (charHold.Count > 1)
            {
                Console.WriteLine("\nTanım dışı özel karakter kullanımı hatası!!!");

                Console.WriteLine("Lütfen (.) (,) (;) (:) (!) (?) (...) (-) karakterleri dışında özel karakter kullanmayınız");
                Console.WriteLine("Kullandığınız özel karakterler: ");
                charHold = charHold.Distinct().ToList();

                foreach (string x in charHold)
                {
                    Console.WriteLine(x);
                }
            }
            else
            {
                int kelimeSayisi = 0;
                bool kelimeBaslangici = true;

                foreach (char karakter in textdef)
                {
                    if (char.IsLetterOrDigit(karakter))
                    {
                        if (kelimeBaslangici)
                        {
                            kelimeSayisi++;
                            kelimeBaslangici = false;
                        }
                    }
                    else if (char.IsWhiteSpace(karakter))
                    {
                        kelimeBaslangici = true;
                    }
                }

                Console.WriteLine("\nKelime sayısı: " + kelimeSayisi);
            }

            Console.ReadLine();
        }

        static string NoktalamaSilme(string textdef)
        {
            textdef = textdef.Replace(".", " ");
            textdef = textdef.Replace(",", " ");
            textdef = textdef.Replace(";", " ");
            textdef = textdef.Replace(":", " ");
            textdef = textdef.Replace("!", " ");
            textdef = textdef.Replace("?", " ");
            textdef = textdef.Replace("...", " ");
            textdef = textdef.Replace("-", " ");

            return textdef;
        }
    }
    
}
