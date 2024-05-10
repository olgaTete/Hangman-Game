using System;

namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "horse", "chicken", "hen", "pig", "sheep", "cow", "goat", "elephant", "monkey", "snake", "tiger", "lion", "giraffe", "rabbit", "dog" };
            string word = words[new Random().Next(0, words.Length)];
            string guessed = "";
            string allLetters = "";
            int tries = 10;
            bool won = false;

            while (tries > 0 && !won)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine("Category: Animals");
                Console.WriteLine("Guess the word: " + GetWordWithSpaces(word, guessed));
                Console.WriteLine("Tries left: " + tries);
                Console.WriteLine("Incorrect letters: " + allLetters);
                Console.WriteLine(GetHangmanDrawing(tries));

                Console.Write("Enter a letter or the whole word: ");
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    if (!guessed.Contains(input) && !allLetters.Contains(input))
                    {
                        if (word.Contains(input))
                        {
                            guessed += input;
                        }
                        else
                        {
                            tries--;
                            allLetters += input + " ";
                        }
                    }
                    else
                    {
                        Console.WriteLine("You've already guessed this letter.");
                    }
                }
                else if (input.Length > 1)
                {
                    if (word.Equals(input))
                    {
                        guessed = word;
                        won = true;
                    }
                    else
                    {
                        tries--;
                        Console.WriteLine("Incorrect word guess.");
                    }
                }

                if (word.Equals(GetWordWithSpaces(word, guessed).Replace(" ", "")))
                {
                    won = true;
                }
            }

            Console.Clear();
            if (won)
            {
                Console.WriteLine("Congratulations! You guessed the word: " + word);
            }
            else
            {
                Console.WriteLine("Sorry, you ran out of tries. The word was: " + word);
                Console.WriteLine(GetHangmanDrawing(0));
            }

            Console.ReadLine();
        }

        static string GetWordWithSpaces(string word, string guessed)
        {
            string result = "";
            foreach (char c in word)
            {
                result += (guessed.Contains(c.ToString())) ? c + " " : "_ ";
            }
            return result.Trim();
        }

        static string GetHangmanDrawing(int tries)
        {
            switch (tries)
            {
                case 9: return @"
  
      
      
      
  ------
=========";
                case 8: return @"
  
      |
      |
      |
      |
  ------
=========";
                case 7: return @"
  +---+
      |
      |
      |
      |
  ------
=========";
                case 6: return @"
  +---+
  |   |
      |
      |
      |
  ------
=========";

                case 5: return @"
  +---+
  |   |
  O   |
      |
      |
  ------
=========";
                case 4: return @"
  +---+
  |   |
  O   |
  |   |
      |
=========";
                case 3: return @"
  +---+
  |   |
  O   |
 /|   |
      |
  ------
=========";
                case 2: return @"
  +---+
  |   |
  O   |
 /|\  |
      |
  ------
=========";
                case 1: return @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
  ------
=========";
                case 0: return @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
  ------
=========";
                default: return "";
            }
        }
    }
}
