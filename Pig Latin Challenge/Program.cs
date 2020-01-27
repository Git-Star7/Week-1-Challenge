using System;
using System.Text;

namespace Pig_Latin_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's try some Pig Latin!");
            //call translator method
            PigLatinTranslator();
        }
        public static void PigLatinTranslator()
        {
            string validInput = "y";
            while (validInput == "y")
            {
                //prompt
                Console.Write("\nEnter a word or sentence to translate to Pig Latin: ");
                
                //input and sentence separator
                string sentence = Console.ReadLine();
                StringBuilder newSentence = new StringBuilder("");
                string[] words = sentence.Split(" ");

                //words loop
                for (int i = 0; i < words.Length; i++)
                {
                    //letters loop
                    bool isLetterBoolCheck = true;
                    foreach (char c in words[i])
                    {
                        //checks if any character in the word has a number or symbol then skips the IsLetter method if true and appends
                        if (Char.IsDigit(c) == true || Char.IsSymbol(c) == true || c == '@')
                        {
                            isLetterBoolCheck = false;
                            newSentence.Append(words[i]);
                            break;
                        }
                    }
                    //uses IsLetter method on any remaining words and appends
                    if (isLetterBoolCheck == true)
                    {
                        newSentence.Append(Translate(words[i]));
                    }
                    //adds spaces up to the last word
                    if (i < words.Length)
                    {
                        newSentence.Append(" ");
                    }
                }
                //output
                Console.WriteLine(newSentence);
                //continue y/n
                validInput = YesOrNo();
            }
        }
        public static string Translate(string word)
        {
            //converts to lower caps and builds new word based on if it has a vowel or not
            string wordLower = word.ToLower();
            int firstVowelPosition = 0;
            StringBuilder firstLetters = new StringBuilder("");
            StringBuilder newWord = new StringBuilder("");

            //leave word as is if it starts with a vowel and add "way"
            if (ContainsVowel(wordLower[0]) == true)
            {
                newWord.Append(word + "way");
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    //finds the first vowel position and appends all consonants up to it
                    if (ContainsVowel(wordLower[i]) == true)
                    {
                        firstVowelPosition = i;
                        firstLetters.Append(word.Substring(0, firstVowelPosition));
                        break;
                    }
                }
                //reassemble word with "ay"
                newWord.Append(word.Substring(firstVowelPosition) + firstLetters + "ay");
            }
            //return new word
            return newWord.ToString();
        }
        public static bool ContainsVowel(char c)
        {
            //checks if character input is a vowel and returns a bool
            bool result = false;
            string vowels = "aeiou";
            if (vowels.Contains(c))
            {
                result = true;
            }
            return result;
        }
        public static string YesOrNo()
        {
            //sets continue status to null and repeats question until valid input is entered
            string userContinue = "";
            while (userContinue != "y" && userContinue != "n")
            {
                Console.Write("\nWould you like to translate another word? (y/n): ");
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
