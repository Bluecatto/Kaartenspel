using System;
using Kaartenspel.classes;

namespace Kaartenspel
{
    class Program
    {
        //Static variables, name and play again.
        static string playerName;
        static bool playAgain = true;

        public static void Main(string[] args)
        {
            //Welcoming the player.
            Console.WriteLine("Hello player, what is your name?");
            playerName = Console.ReadLine();
            Console.WriteLine($"Hello, {playerName}!");

            PlayGame();
        }

        static void PlayGame()
        {
            while (playAgain)
            {
                //Makes a new deck and draws a card from the card class.
                Deck deck = new Deck();
                Card previousCard = deck.DrawCard();
                int score = 0;

                while (deck.RemainingCards() > 0)
                {
                    //Shows on console what the current card is and the player needs to guess it can be lower or higher or the whole suit.
                    Console.WriteLine($"Current card: {previousCard}");
                    string guess = "";
                    while (true)
                    {
                        Console.Write($"Will the next card be higher (h) or lower (l), or do you want to guess the whole suit, {playerName} (s)?: ");
                        guess = Console.ReadLine().ToLower();
                        if (guess == "h" || guess == "l" || guess == "s")
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input. Please enter h, l, or s.");
                    }

                    //Draws the next card.
                    Card nextCard = deck.DrawCard();
                    Console.WriteLine($"Next card: {nextCard}");

                    //If the player guesses right, it goes to the next card.
                    bool correct = false;
                    if (guess == "h")
                    {
                        correct = nextCard.Value > previousCard.Value;
                    }
                    else if (guess == "l")
                    {
                        correct = nextCard.Value < previousCard.Value;
                    }
                    else if (guess == "s")
                    {
                        //If the player guesses the suit if the player selected 's'.
                        string suitGuess = "";
                        while (true)
                        {
                            //Checks if the suit is valid or not, if its not its an invalid suit.
                            Console.Write("Guess the suit (hearts, diamonds, clubs, spades): ");
                            suitGuess = Console.ReadLine().ToLower();
                            if (Enum.TryParse(suitGuess, true, out Card.Suit guessedSuit) &&
                                (guessedSuit == Card.Suit.Hearts || guessedSuit == Card.Suit.Diamonds || guessedSuit == Card.Suit.Clubs || guessedSuit == Card.Suit.Spades))
                            {
                                correct = nextCard.CardSuit == guessedSuit;
                                break;
                            }
                            Console.WriteLine("Invalid suit. Please enter hearts, diamonds, clubs, or spades.");
                        }
                    }

                    //When the player guesses correct the score goes up.
                    if (correct)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect.");
                    }

                    previousCard = nextCard;
                }
                //End score.
                Console.WriteLine($"Game over! Your score is: {score}.");
                PlayAgain();
            }
        }

        static void PlayAgain()
        {
            //Ask if the player wants to play again.
            string response = "";
            while (true)
            {
                Console.Write("Do you want to play again? (y/n): ");
                response = Console.ReadLine().ToLower();
                if (response == "y" || response == "n")
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter y or n.");
            }
            playAgain = (response == "y");

            //when selecting 'n', the game stops.
            if (!playAgain)
            {
                Console.WriteLine("Thank you for playing.");
            }
        }
    }
}