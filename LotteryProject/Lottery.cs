using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryProject
{
    public class Lottery
    {
        public static void simulator()
        {
            int totalCost = 0;
            int winnings = 0;
            List<int> lottoNums = new List<int>();
            var num = new Random();
            
            //Getting user input
            Console.WriteLine("Welcome to the National Lottery!\nPlease enter your 6 unique numbers from 1 to 59:");
            List<int> userNums = new List<int>();
            int a = 0;
            while (a < 6)
            {
                userNums.Add(int.Parse(Console.ReadLine()));
                a++;
            }
            userNums.Sort();
            Console.WriteLine("Your numbers are:");
            foreach (int userNum in userNums)
            {
                Console.Write($"{userNum}|");
            }
            
            //Generating lottery numbers
            int lotteryNumber;
            int attempts = 0;
            while (true)
            {
                for (int i = 0; i < 6; i++)
                {
                    do
                    {
                        lotteryNumber = num.Next(1, 60);
                    } while (lottoNums.Contains(lotteryNumber)); //Unique numbers only added
                    lottoNums.Add(lotteryNumber);
                }
                lottoNums.Sort();

                Console.Write("\nThe National lottery numbers are:\n");
                foreach (int number in lottoNums)
                    Console.Write($"{number}|");

                //Finding how many matches there are
                int matches = 0;
                foreach (int userElement in userNums)
                {
                    if (lottoNums.Contains(userElement))
                        matches++;
                }
                Console.WriteLine($"\nYou matched with {matches} numbers!");
              
                if (matches != 6)
                {
                    switch (matches)
                    {
                        case 3:
                            winnings += 30;
                            break;
                        case 4:
                            winnings += 140;
                            break;
                        case 5:
                            winnings += 1750;
                            break;
                    }
                    attempts += 1;
                    totalCost += 2;
                    Console.WriteLine($"Attempts: {attempts} | Cost of tickets: £{totalCost} | Total winnings: £{winnings} | Profit: £{totalCost - winnings}");
                    lottoNums.Clear();
                }

                else
                {
                    attempts += 1;
                    totalCost += 2;
                    winnings += 13000000;
                    Console.WriteLine($"Congratulations, you have won the lottery! It took {attempts} attempts to win.");
                    Console.WriteLine($"You have spent £{totalCost} pounds on tickets.");
                    break;
                }
            }
           
        }

    }
}
