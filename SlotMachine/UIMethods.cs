using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class UIMethods
    {
     
        public static int AskCentralBet(int userCentralBet)
        {
            Console.WriteLine($"How much do you want to bet on the central Line?");
            return userCentralBet;
        }
        public static int AskHorizontalBet(int userHorizontalBet)
        {
            Console.WriteLine("How much do you want to bet on the horizontal Lines?");
            return userHorizontalBet;
        }
        public static int AskVerticalDiagonalBet(int userVerticalDiagonalBet)
        {
            Console.WriteLine("How much do you want to bet on the Vertical and Diagonal Lines?");
            return userVerticalDiagonalBet;
        }
    
    }
}
