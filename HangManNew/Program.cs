using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManNew
{
    internal class Program
    {

        static void Main(string[] args)
        {
            char[] guesses = new char[100];
            Console.WriteLine("Welcome to the Hangman Game. You will have 5 tries to guess my random word. I am benevolent enough to show you how many characters there are. ");
            string[] wordsToGuess = { "eagle", "sun", "history", "tail", "third", "mute", "judge", "exultant", "cars", "bounce", "need" };
            string word = UIMethods.PickRandomWord(wordsToGuess);
            UIMethods.DisplayWord(word, guesses);
            int guessCounter = 0;
            int life = 5;
            while (life > 0)
            {
                Console.WriteLine("Please guess a letter.");
                string userLetter = Console.ReadLine();
                //Console.WriteLine(userLetter);

                if (UIMethods.ValidateCharLenght(userLetter))
                {
                    char userChar = userLetter.ToCharArray()[0];

                    if (UIMethods.CheckCharInWord(userChar, "abcdefghijklmnopqrstuvwyxz"))
                    {
                        if (UIMethods.CheckCharInWord(userChar, word))
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
                UIMethods.DisplayWord(word, guesses);
                Console.WriteLine(UIMethods.GallowView(life));
                if (UIMethods.CheckTheWin(word, guesses))
                {
                    life = 0;
                    Console.WriteLine("You Won!");
                }
            }
            Console.ReadLine();
        }
    }
}