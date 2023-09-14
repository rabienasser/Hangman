using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static string correctWord = "hangman";
        static char[] letters;
        static string userName;
        static List<char> guessedLetters = new List<char>();
        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }

        private static void StartGame()
        {
            letters = new char[correctWord.Length];
            for(int i = 0; i < correctWord.Length; i++)
            {
                letters[i] = '-';    
            }
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
            do
            {
                Console.Clear();
                DisplayMaskedWord();
                DisplayGuessedLetters();
                char guessedLetter = AskForLetter();
                CheckLetter(guessedLetter);
            } while (correctWord != new string(letters));

            Console.Clear();
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        static void DisplayGuessedLetters()
        {
            Console.Write("Guessed Letters: ");

            foreach(char c in guessedLetters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        static void CheckLetter(char guessedLetter)
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (correctWord[i] == guessedLetter)
                {
                    letters[i] = guessedLetter;
                }
            }
        }

        static char AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter: ");
                input = Console.ReadLine();
            } while (input.Length != 1);

            var guessedLetter = input[0];

            if(!guessedLetters.Contains(guessedLetter))
            {
                guessedLetters.Add(guessedLetter);
            }

            return guessedLetter;
        }

        private static void EndGame()
        {
            Console.WriteLine($"Thanks for playing, {userName}!");
            Console.WriteLine($"It took you {guessedLetters.Count} to get it right!");
        }
    }
}