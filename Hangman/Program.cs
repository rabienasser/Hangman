using System;

namespace Hangman
{
    class Program
    {
        static string? correctWord = "hangman";
        static char[] letters;
        static string? userName;
        static int numberOfGuesses = 0;
        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }

        private static void StartGame()
        {
            letters = new char[correctWord.Length];
            for (int i = 0; i < letters.Length; i++)
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
                char guessedLetter = AskForLetter();
                CheckLetter(guessedLetter);
            } while (new string(letters) != correctWord);

            Console.Clear();
        }

        private static void CheckLetter(char guessedLetter)
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if(correctWord[i] == guessedLetter)
                {
                    letters[i] = guessedLetter;
                }
            }
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
            {
                Console.Write(c);
            }

            Console.WriteLine();
        }

        static char AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter: ");
                input = Console.ReadLine();
            } while (input.Length != 1);

            numberOfGuesses++;

            return input[0];
        }

        private static void EndGame()
        {
            Console.WriteLine($"The correct word was: {correctWord}");
            Console.WriteLine($"Thanks for playing, {userName}!");
            Console.WriteLine($"Guesses: {numberOfGuesses}");
        }
    }
}