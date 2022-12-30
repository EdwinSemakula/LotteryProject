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
            //int attempts = 0;
            //int totalCost = 0;
            //int winnings = 0;
            List<int> lottoNums = new List<int>();
            var num = new Random();
            int lotteryNumber;
            for (int i = 0; i < 6; i++)
            {
                do {
                     lotteryNumber = num.Next(1, 60);
                   } while (lottoNums.Contains(lotteryNumber)); //Unique numbers only added
                lottoNums.Add(lotteryNumber);
            }
            lottoNums.Sort();

            Console.Write("The National lottery numbers are: ");
            foreach(int number in lottoNums)
            Console.Write($"{number}|");
        }

    }
}
