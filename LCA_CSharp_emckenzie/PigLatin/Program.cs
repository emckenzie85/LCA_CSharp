using System;

namespace PigLatin
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Aloha Orldway!");
            {
                Console.WriteLine("Enter any word");
                String word = Console.ReadLine();

                Char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

                // find first letter
                String firstLetter = word.Substring(0, 1);
                //find last lettter
                String lastLetter = word.Substring(word.Length - 1);
                // gets the word subtract the first letter
                String newWord = word.Substring(1, word.Length - 1) + firstLetter;

                if (word.IndexOfAny(vowels) == -1) // no vowels exist In the word
                {
                    Console.WriteLine(word + "ay");
                }
                else if (firstLetter.IndexOfAny(vowels) == 0) // first letter Is a vowel
                {
                    // add New ending
                    if (lastLetter.IndexOfAny(vowels) == 0) // last letter Is a vowel
                    {
                        Console.WriteLine(word + "yay");
                    }
                    else
                    {
                        Console.WriteLine(word + "ay");
                    }
                }
                else // first letter Is a consonant
                {
                    Console.WriteLine(newWord + "ay");
                }
            }
        }
    }
}