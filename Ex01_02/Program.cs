using System;

namespace Ex01_02
{
    public class Program
    {
        private static int s_Height;
        protected const int k_DefaultHight = 9;
        protected const char k_DiamondChar = '*';
        protected const char k_SpaceChar = ' ';

        private static void Main()
        {
            Console.WriteLine("Ex01_02: Diamond For Begginers\n");

            runProgramEx01_02();

            Console.WriteLine("\nPress enter to exit\n");
            Console.ReadLine();
        }

        public static void runProgramEx01_02(int i_Height = k_DefaultHight)
        {
            int amountOfDiamondCharPerLine = 1;

            s_Height = i_Height;

            printDiamondForBegginersRecursion(amountOfDiamondCharPerLine);
        }

        private static void printDiamondForBegginersRecursion(int i_CurrAmountOfDiamondCharPerLine)
        {
            if (i_CurrAmountOfDiamondCharPerLine > s_Height)
            {
                return;
            }

            else
            {
                printOneLineOfDiamond(ref i_CurrAmountOfDiamondCharPerLine);
                printDiamondForBegginersRecursion(i_CurrAmountOfDiamondCharPerLine + 2);
            }

            if (i_CurrAmountOfDiamondCharPerLine < s_Height)
            {
                printOneLineOfDiamond(ref i_CurrAmountOfDiamondCharPerLine);
            }
        }

        private static void printOneLineOfDiamond(ref int i_AmountToPrint)
        {
            int amountOfSpacesBeforeDiamondChar = ((s_Height - i_AmountToPrint) / 2);

            for (int i = 0; i < amountOfSpacesBeforeDiamondChar; i++)
            {
                Console.Write(k_SpaceChar);
            }

            for (int i = 0; i < i_AmountToPrint; i++)
            {
                Console.Write(k_DiamondChar);
            }

            Console.Write("\n");
        }
    }

}