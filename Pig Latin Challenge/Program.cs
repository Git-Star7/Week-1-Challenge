using System;
using System.Text;

namespace Pig_Latin_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's try some Pig Latin!");
            PigLatinTranslator();
        }
        public static void PigLatinTranslator()
        {
            string validInput = "y";
            while (validInput == "y")
            {
                //prompt
                Console.Write("\nEnter a word to translate to Pig Latin: ");

                //input
                string word = Console.ReadLine();
                string wordLower = word.ToLower();
                char firstCharacter = wordLower[0];

                //lower case letter validation
                if (Char.IsLower(firstCharacter) == true)
                {
                    int firstVowelPosition = 0;
                    StringBuilder firstLetters = new StringBuilder("");
                    StringBuilder newWord = new StringBuilder("");

                    if (ContainsVowel(word[0]) == true)
                    {
                        newWord.Append(word + "way");
                    }
                    else
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            if (ContainsVowel(word[i]) == true)
                            {
                                firstVowelPosition = i;
                                firstLetters.Append(word.Substring(0, firstVowelPosition));
                                break;
                            }
                        }
                        newWord.Append(word.Substring(firstVowelPosition) + firstLetters + "ay");
                    }

                    Console.WriteLine($"{newWord} is your new word");
                    validInput = YesOrNo();
                }
            }
        }
        public static bool ContainsVowel(char c)
        {
            bool result = false;
            string vowels = "aeiouAEIOU";
            if (vowels.Contains(c))
            {
                result = true;
            }
            return result;
        }
        public static string YesOrNo()
        {
            string userContinue = "";
            while (userContinue != "y" && userContinue != "n")
            {
                Console.WriteLine("\nWould you like to translate another word? y/n?");
                userContinue = Console.ReadLine().ToLower();

                if (userContinue == "n")
                {
                    Console.WriteLine("Okay!!");
                }
            }
            return userContinue;
        }
    }
}
