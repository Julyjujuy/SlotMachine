using System;


namespace SlotMachine
{
    public static class Methods
    {

        /// <summary>
        /// Pick a random number from a list of random generated numbers
        /// </summary>
        /// <param name="min">set minimum parameter</param>
        /// <param name="max">set maximum parameter</param>
        /// <param name="rng">generated random number</param>
        /// <returns>a random generated number</returns>
        public static int GenerateNumber(int min, int max, Random rng)
        {
            var number = rng.Next(min, max);
            return number;
        }
        /// <summary>
        /// Pick a random symbol from a list 
        /// </summary>
        /// <param name="random_Symb">generated random number used to pick a symbol</param>
        /// <returns>a symbol randomly picked</returns>
        public static string RandomSymbol(Random random_Symb)
        {
            string[] symbols = { "   Dice   ", "Watermelon", "  Heart   ", "    7     ", "  Rocket  ", "  Cherry  ", "  Banana  ", "  Ananas  ", "   Coin   " };
            int randomnumber = GenerateNumber(0, symbols.Length, random_Symb);
            return symbols[randomnumber];
        }
        /// <summary>
        /// prints the grid of arrays string
        /// </summary>
        /// <param name="elements2Print"></param>
        
        

        /// <summary>
        /// it checks the matches in each line combination that it's given 
        /// </summary>
        /// <param name="first">first element of the line</param>
        /// <param name="second">second element of the line</param>
        /// <param name="third">third element of the line</param>
        /// <returns>points for matches checked</returns>
        public static int CheckLine(string first, string second, string third)
        {
            if (first == second && second == third)
            {
                return 2;
            }
            if (first == second || first == third || second == third)
            {
                return 1;
            }

            return 0;

        }
        /// <summary>
        /// it checks the matches for the central line using the checkline method
        /// </summary>
        /// <param name="gridToCheck"></param>
        /// <returns></returns>
        public static int CheckCentral(string[,] gridToCheck)
        {
            return CheckLine(gridToCheck[1,0], gridToCheck[1,1], gridToCheck[1,2]);
        }
        /// <summary>
        /// it checks the matches for the horizontal line using the checkline method
        /// </summary>
        /// <param name="gridToCheck"></param>
        /// <returns></returns>
        public static int CheckHorizontal(string[,] gridToCheck)
        {
            int horizontalWins = 0;
            horizontalWins += CheckLine(gridToCheck[0,0], gridToCheck[0,1], gridToCheck[0,2]);
            horizontalWins += CheckLine(gridToCheck[1,0], gridToCheck[1,1], gridToCheck[1,2]);
            horizontalWins += CheckLine(gridToCheck[2,0], gridToCheck[2,1], gridToCheck[2,2]);
            return horizontalWins;
        }
        /// <summary>
        /// it checks the matches for the vertical and diagonal lines using the checkline method
        /// </summary>
        /// <param name="gridToCheck"></param>
        /// <returns></returns>
        public static int CheckVerticalandDiagonal(string[,] gridToCheck)
        {
            int verticalWins = 0;
            verticalWins += CheckLine(gridToCheck[0,0], gridToCheck[1,0], gridToCheck[2,0]);
            verticalWins += CheckLine(gridToCheck[0,1], gridToCheck[1,1], gridToCheck[2,1]);
            verticalWins += CheckLine(gridToCheck[0,2], gridToCheck[1,2], gridToCheck[2,2]);
            verticalWins += CheckLine(gridToCheck[0,0], gridToCheck[1,1], gridToCheck[2,2]);
            verticalWins += CheckLine(gridToCheck[0,2], gridToCheck[1,1], gridToCheck[2,0]);
            return verticalWins;
        }
       



    
      


    }
}
