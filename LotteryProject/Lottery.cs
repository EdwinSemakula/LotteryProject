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
            List<int> lotteryNums = new List<int>();
            var randNum = new Random();
            bool luckyDip = false;

            //Getting user input
            Console.WriteLine("Welcome to the National Lottery!\nEnter 1 to pick your own numbers, enter 2 for lucky dip.");
            List<int> userNums = new List<int>();
            int luckyDipChoice = int.Parse(Console.ReadLine());
            int validEntries = 0;
            if (luckyDipChoice == 1)
            {
                Console.WriteLine("Please enter your 6 unique numbers from 1 to 59:");
                while (validEntries < 6)
                {
                    var numString = Console.ReadLine();
                    int num;
                    if (int.TryParse(numString, out num) && !userNums.Contains(num) && num > 0 && num < 60)
                    {
                        userNums.Add(num);
                        validEntries++;
                    }
                    else if (userNums.Contains(num))
                        Console.WriteLine("You have already entered that number, please choose a different one");
                    else if (!int.TryParse(numString, out num))
                        Console.WriteLine("Please enter a number!");
                    else
                        Console.WriteLine("The number entered needs to be in the range of 1 to 59");
                }
                userNums.Sort();

                Console.WriteLine("Your numbers are:");
                foreach (int userNum in userNums)
                {
                    Console.Write($"{userNum}|");
                }
            }
            else
                luckyDip = true;

            //Generating lottery numbers
            int lotteryNum;
            int luckyDipNum;
            int bonusBall;
            int attempts = 0;

            while (true)
            {
                if(luckyDip == true)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        do
                        {
                            luckyDipNum = randNum.Next(1, 60);
                        } while (userNums.Contains(luckyDipNum));
                        userNums.Add(luckyDipNum);
                    }
                    userNums.Sort();

                    Console.WriteLine("Your numbers are:");
                    foreach (int userNum in userNums)
                    {
                        Console.Write($"{userNum}|");
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    do
                    {
                        lotteryNum = randNum.Next(1, 60);
                    } while (lotteryNums.Contains(lotteryNum)); //Unique numbers only added
                    lotteryNums.Add(lotteryNum);
                }
                lotteryNums.Sort();

                Console.Write("\nThe National lottery numbers are:\n");
                foreach (int number in lotteryNums)
                    Console.Write($"{number}|");

                //Finding how many matches there are
                int matches = 0;
                foreach (int userElement in userNums)
                {
                    if (lotteryNums.Contains(userElement))
                        matches++;
                }
                Console.WriteLine($"\nYou matched with {matches} numbers!");

                if (matches == 5)
                {
                    winnings += 1750;
                    bonusBall = randNum.Next(1, 60);
                    while (lotteryNums.Contains(bonusBall))
                    {
                        bonusBall = randNum.Next(1, 60);
                    }
                    Console.WriteLine($"The bonus ball is {bonusBall}");
                    if (userNums.Contains(bonusBall))
                    {
                        winnings += 998250; //taken away 1750 from 1 million
                        Console.WriteLine("You matched with the bonus ball and have won £1m pounds!!!");
                    }
                }

                if (luckyDip == true)
                    userNums.Clear();

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
                    }
                    attempts += 1;
                    totalCost += 2;
                    Console.WriteLine($"Attempts: {attempts} | Cost of tickets: £{totalCost} | Total winnings: £{winnings} | Profit: £{winnings - totalCost}");
                    lotteryNums.Clear();
                }
                else
                {
                    attempts += 1;
                    totalCost += 2;
                    winnings += 13000000;
                    Console.WriteLine($"Congratulations, you have won the lottery! It took {attempts} attempts to win.");
                    Console.WriteLine($"You have spent £{totalCost} pounds on tickets and your profit/loss is £{winnings}.");
                    break;
                }
            }
           
        }

    }
}
