using System;
using System.Collections.Generic;
using System.Linq;

namespace KattisConsole
{
    public class Program
    {
        static List<Card> CardList = new List<Card>();

        public static void Main(string[] args)
        {
            int numCards = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numCards; ++i)
            {
                string[] cardData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);

                int redAngle = Convert.ToInt32(cardData[0]);
                int greenAngle = Convert.ToInt32(cardData[1]);
                int blueAngle = Convert.ToInt32(cardData[2]);

                CardList.Add(new Card()
                {
                    Red = redAngle,
                    //RedQuadrant = GetQuadrant(redAngle),
                    Green = greenAngle,
                    //GreenQuadrant = GetQuadrant(greenAngle),
                    Blue = blueAngle,
                    //BlueQuadrant = GetQuadrant(blueAngle),
                    Id = Convert.ToInt32(cardData[3])
                });
            }

            if (numCards == 1)
            {
                Console.WriteLine(CardList[0].Id);
                return;
            }

            CalculateUniqueness();

            Card min = CardList.OrderBy(p => p.TotalUniqueness).ThenByDescending(p => p.Id).First();

            Console.WriteLine(min.Id);

            CardList.Remove(min);

            while (CardList.Count > 1)
            {
                CalculateUniqueness();

                Card leastUnique = CardList.OrderBy(p => p.TotalUniqueness).ThenByDescending(p => p.Id).First();

                Console.WriteLine(leastUnique.Id);

                CardList.Remove(leastUnique);
            }

            Console.WriteLine(CardList[0].Id);
        }

        public static void CalculateUniqueness()
        {
            foreach (Card c in CardList)
            {
                c.RedUniqueness = GetCounterClockWiseRedUniqueness(c) + GetClockWiseRedUniqueness(c);
                c.GreenUniqueness = GetCounterClockWiseGreenUniqueness(c) + GetClockWiseGreenUniqueness(c);
                c.BlueUniqueness = GetCounterClockWiseBlueUniqueness(c) + GetClockWiseBlueUniqueness(c);

                c.TotalUniqueness = c.RedUniqueness + c.GreenUniqueness + c.BlueUniqueness;
            }
        }

        public static int GetCounterClockWiseRedUniqueness(Card card)
        {
            if (CardList.Exists(p => p.Id != card.Id && p.Red == card.Red))
            {
                return 0;
            }

            if (CardList.Exists(p => p.Id != card.Id && p.Red > card.Red))
            {
                Card counterClockwiseNearest = CardList.Where(p => p.Id != card.Id && p.Red > card.Red).OrderBy(p => p.Red).First();

                return counterClockwiseNearest.Red - card.Red;
            }
            else
            {
                // take the smallest
                Card counterClockwiseNearest = CardList.Where(p => p.Id != card.Id).OrderBy(p => p.Red).First();

                return counterClockwiseNearest.Red + 360 - card.Red;
            }
        }

        public static int GetClockWiseRedUniqueness(Card card)
        {
            if (CardList.Exists(p => p.Id != card.Id && p.Red == card.Red))
            {
                return 0;
            }

            if (CardList.Exists(p => p.Id != card.Id && p.Red < card.Red))
            {
                Card clockwiseNearest = CardList.Where(p => p.Id != card.Id && p.Red < card.Red).OrderByDescending(p => p.Red).First();

                return card.Red - clockwiseNearest.Red;
            }
            else
            {
                // take the largest
                Card clockwiseNearest = CardList.Where(p => p.Id != card.Id).OrderByDescending(p => p.Red).First();

                return card.Red + 360 - clockwiseNearest.Red;
            }
        }

        public static int GetCounterClockWiseGreenUniqueness(Card card)
        {
            if (CardList.Exists(p => p.Id != card.Id && p.Green == card.Green))
            {
                return 0;
            }

            if (CardList.Exists(p => p.Id != card.Id && p.Green > card.Green))
            {
                Card counterClockwiseNearest = CardList.Where(p => p.Id != card.Id && p.Green > card.Green).OrderBy(p => p.Green).First();

                return counterClockwiseNearest.Green - card.Green;
            }
            else
            {
                // take the smallest
                Card counterClockwiseNearest = CardList.Where(p => p.Id != card.Id).OrderBy(p => p.Green).First();

                return counterClockwiseNearest.Green + 360 - card.Green;
            }
        }

        public static int GetClockWiseGreenUniqueness(Card card)
        {
            if (CardList.Exists(p => p.Id != card.Id && p.Green == card.Green))
            {
                return 0;
            }

            if (CardList.Exists(p => p.Id != card.Id && p.Green < card.Green))
            {
                Card clockwiseNearest = CardList.Where(p => p.Id != card.Id && p.Green < card.Green).OrderByDescending(p => p.Green).First();

                return card.Green - clockwiseNearest.Green;
            }
            else
            {
                // take the largest
                Card clockwiseNearest = CardList.Where(p => p.Id != card.Id).OrderByDescending(p => p.Green).First();

                return card.Green + 360 - clockwiseNearest.Green;
            }
        }

        public static int GetCounterClockWiseBlueUniqueness(Card card)
        {
            if (CardList.Exists(p => p.Id != card.Id && p.Blue == card.Blue))
            {
                return 0;
            }

            if (CardList.Exists(p => p.Id != card.Id && p.Blue > card.Blue))
            {
                Card counterClockwiseNearest = CardList.Where(p => p.Id != card.Id && p.Blue > card.Blue).OrderBy(p => p.Blue).First();

                return counterClockwiseNearest.Blue - card.Blue;
            }
            else
            {
                // take the smallest
                Card counterClockwiseNearest = CardList.Where(p => p.Id != card.Id).OrderBy(p => p.Blue).First();

                return counterClockwiseNearest.Blue + 360 - card.Blue;
            }
        }

        public static int GetClockWiseBlueUniqueness(Card card)
        {
            if (CardList.Exists(p => p.Id != card.Id && p.Blue == card.Blue))
            {
                return 0;
            }

            if (CardList.Exists(p => p.Id != card.Id && p.Blue < card.Blue))
            {
                Card clockwiseNearest = CardList.Where(p => p.Id != card.Id && p.Blue < card.Blue).OrderByDescending(p => p.Blue).First();

                return card.Blue - clockwiseNearest.Blue;
            }
            else
            {
                // take the largest
                Card clockwiseNearest = CardList.Where(p => p.Id != card.Id).OrderByDescending(p => p.Blue).First();

                return card.Blue + 360 - clockwiseNearest.Blue;
            }
        }        
    }    

    public class Card
    {
        public int Red { get; set; }

        public int RedUniqueness { get; set; }

        public int Green { get; set; }

        public int GreenUniqueness { get; set; }

        public int Blue { get; set; }

        public int BlueUniqueness { get; set; }

        public int Id { get; set; }

        public int TotalUniqueness { get; set; }
    }    
}