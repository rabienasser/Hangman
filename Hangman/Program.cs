using System;

namespace Hangman
{
    class Program
    {
        static string? correctWord = "hangman";
        static string? userName;
        static int numberOfGuesses = 5;
        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }

        private static void StartGame()
        {
            AskUserForName();
        }

        static void AskUserForName()
        {
            Console.WriteLine("What is your name?");
            var input = Console.ReadLine();

            if (input?.Length >= 2)
                userName = input;
            else
            {
                Console.WriteLine("Username must contain at least two characters");
                AskUserForName();
            }
        }

        private static void PlayGame()
        {
            DisplayMaskedWord();
            AskForLetter();
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in correctWord)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        static void AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter: ");
                input = Console.ReadLine();
            } while (input.Length != 1);
            
            numberOfGuesses++;
        }

        private static void EndGame()
        {
            Console.WriteLine($"Thanks for playing, {userName}!");
            Console.WriteLine($"You had {numberOfGuesses} remaining!");
        }
    }
}