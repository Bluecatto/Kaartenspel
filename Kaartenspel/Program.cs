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
                    //Shows on console what the current card is and the player needs to guess it can be lower or higher or thr whole suit.
                    Console.WriteLine($"Current card: {previousCard}");
                    Console.Write($"Will the next card be higher (h) or lower (l), or do you want to guess the whole suit, {playerName}?: ");
                    string guess = Console.ReadLine().ToLower();

                    //Draws the next card.
                    Card nextCard = deck.DrawCard();
                    Console.WriteLine($"Next card: {nextCard}");

                    //If the player guesses right, it goes to the nexcard.
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
                        //If the player the suit if the player selected 's'.
                        Console.Write("Guess the suit (hearts, diamonds, clubs, spades): ");
                        string suitGuess = Console.ReadLine().ToLower();
                        Card.Suit guessedSuit;
                        Enum.TryParse(suitGuess, true, out guessedSuit);
                        correct = nextCard.CardSuit == guessedSuit;
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
            Console.Write("Do you want to play again? (y/n): ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "y");

            //when selecting 'n', the game stops.
            Console.WriteLine("Thank you for playing.");
        }
    }
}