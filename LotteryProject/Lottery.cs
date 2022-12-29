using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryProject
{
    public class Lottery
    {
        //public List<int> userNumbers;
        public static void simulator()
        {
            int attempts = 0;
            int totalCost = 0;
            int winnings = 0;
            List<int> lottoNums = new List<int>();
            Random num = new Random();

            for(int i = 0; i < 6; i++)
            {
                lottoNums.Add(num.Next(1,60)); //sort out duplicate possibility
            }
            lottoNums.Sort();

            Console.Write("The National lottery numbers are: ");
            foreach(int number in lottoNums)
            Console.Write($"{number}|");
        }

    }
}
