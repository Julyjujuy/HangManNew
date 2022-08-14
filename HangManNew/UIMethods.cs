using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManNew
{
    internal class UIMethods
    {
        /// <summary>
        /// Generate a random Number between parameters
        /// </summary>
        /// <param name="min">minimul parameter</param>
        /// <param name="max">maximum parameter</param>
        /// <returns>a random generated number</returns>
        public static int Generatenumber(int min, int max)
        {
            var rand = new Random();
            var number = rand.Next(min, max);
            return number;

        }
        /// <summary>
        /// picks a random word from a string array
        /// </summary>
        /// <param name="words">the random picked word</param>
        /// <returns></returns>
        public static string PickRandomWord(string[] words)
        {
            int number = Generatenumber(0, words.Length - 1);
            return words[number];
        }
        /// <summary>
        /// checks the validity of character imput
        /// </summary>
        /// <param name="singleChar">the char to check</param>
        /// <param name="listOfChars">the allowed chars</param>
        /// <returns>validity with true or false</returns>
        public static bool CheckInCharArray(char singleChar, char[] listOfChars)
        {
            foreach (char c in listOfChars)
            {
                if (c == singleChar)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// displays a hidden word with *, then shows the char if the guess is right
        /// </summary>
        /// <param name="word">the word to display</param>
        /// <param name="chars">the elements of the word to be checked</param>
        public static void DisplayWord(string word, char[] chars)
        {
            //Console.WriteLine(word);
            foreach (char letter in word)
            {
                if (CheckInCharArray(letter, chars))
                {
                    Console.Write(letter);
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// validate the chat imput from user
        /// </summary>
        /// <param name="userChar">imput user</param>
        /// <returns>validity</returns>
        public static bool ValidateCharLenght(string userChar)
        {
            char[] realChar = userChar.ToCharArray();
            if (realChar.Length != 1)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// checks if the imput char is present in the word to guess
        /// </summary>
        /// <param name="userChar">user imput</param>
        /// <param name="word">word to check</param>
        /// <returns>validity</returns>
        public static bool CheckCharInWord(char userChar, string word)
        {
            foreach (char letter in word)
            {
                if (letter == userChar)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// prints the hangman grid if user is incorrect
        /// </summary>
        /// <param name="livesLeft">parameter for which part of the drawning to print</param>
        /// <returns>drawned hangman</returns>
        public static string GallowView(int livesLeft)
        {
            //simple function to print out the hangman

            string drawHangman = "";

            if (livesLeft < 5)
            {
                drawHangman += "--------\n";
            }
            if (livesLeft < 4)
            {
                drawHangman += "       |\n";
            }
            if (livesLeft < 3)
            {
                drawHangman += "       O\n";
            }
            if (livesLeft < 2)
            {
                drawHangman += "      /|\\ \n";
            }
            if (livesLeft == 0)
            {
                drawHangman += "      / \\ \n";
                drawHangman += "      You Lost!\n";
            }
            return drawHangman;
        }
        /// <summary>
        /// checks if the User has guessed all the chars
        /// </summary>
        /// <param name="wordToCheck">parameter to check</param>
        /// <param name="guessesToCheck">user imput</param>
        /// <returns>win or not win</returns>
        public static bool CheckTheWin(string wordToCheck, char[] guessesToCheck)
        {
            foreach (char letter in wordToCheck)
            {
                if (!CheckInCharArray(letter, guessesToCheck))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
