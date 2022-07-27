using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManNew
{
    internal class Program
    {
        static int Generatenumber(int min, int max)
        {
            var rand = new Random();
            var number = rand.Next(min, max);
            return number;

        }
        static string PickRandomWord(string[] words)
        {
            int number = Generatenumber(0, 11);
            return words[number];

        }

        static bool CheckInCharArray(char singleChar, char[] listOfChars)
        {
            foreach (char c in listOfChars)
            {
                if (c == singleChar)
                    return true;
            }
            return false;
        }

        static void DisplayWord(string word, char[] chars)
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

        static bool ValidateCharLentgh(string userChar)
        {
            char[] realChar = userChar.ToCharArray();
            if (realChar.Length != 1)
            {
                return false;
            }
            return true;
        }

        static bool CheckCharInWord(char userChar, string word)
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


        static string GallowView(int livesLeft)
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
        static bool CheckTheWin(string wordToCheck, char[] guessesToCheck)
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


        static void Main(string[] args)
        {

            char[] guesses = new char[100];

            Console.WriteLine("Welcome to the Hangman Game. You will have 5 tries to guess my random word. I am benevolent enough to show you how many characters there are. ");



            string[] wordsToGuess = { "eagle", "sun", "history", "tail", "third", "mute", "judge", "exultant", "cars", "bounce", "need" };
            string word = PickRandomWord(wordsToGuess);
            DisplayWord(word, guesses);
            int guessCounter = 0;

            int life = 5;
            while (life > 0)
            {
                Console.WriteLine("Please guess a letter.");
                string userLetter = Console.ReadLine();
                //Console.WriteLine(userLetter);

                if (ValidateCharLentgh(userLetter))
                {
                    char userChar = userLetter.ToCharArray()[0];

                    if (CheckCharInWord(userChar, "abcdefghijklmnopqrstuvwyxz"))
                    {
                        if (CheckCharInWord(userChar, word))
                        {
                            Console.WriteLine("Bingo!");
                            guesses[guessCounter] = userChar;
                            //Console.WriteLine(string.Join(", ", guesses));
                            guessCounter++;



                        }
                        else
                        {
                            life--;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Sorry but I only process letters of the alphabet!");

                    }
                }
                else
                {
                    Console.WriteLine("Sorry but I only process single letters");

                }

                DisplayWord(word, guesses);
                Console.WriteLine(GallowView(life));
                if (CheckTheWin(word, guesses))
                    {
                    life = 0;
                    Console.WriteLine("You Won!");
                }



            }





            Console.ReadLine();

        }

    }
}