using Ex01_02; 
using System;

namespace Ex01_03
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Ex01_03: Diamond For Advancers\n");

            getHeightFromUser();

            Console.WriteLine("\nPress enter to exit\n");
            Console.ReadLine();
        }

        private static void getHeightFromUser()
        {
            Console.WriteLine("Please enter the size of the Diamond's height: ");

            string heightOfDiamond = Console.ReadLine();

            while (!isValidHeightInput(heightOfDiamond))
            {
                Console.WriteLine("Invalid input! Use only 0-9 digits (size>0)");
                Console.WriteLine("Please enter the size of the Diamond's height: ");
                heightOfDiamond = Console.ReadLine();
            }

            int convertHeightOfDiamondToInt = int.Parse(heightOfDiamond);

            decreaseOneIfHeightIsEven(ref convertHeightOfDiamondToInt);

            Ex01_02.Program.runProgramEx01_02(convertHeightOfDiamondToInt); 
        }

        private static bool isValidHeightInput(string i_HeightToCheck)
        {
            bool isValidHeight = true;

            foreach (char c in i_HeightToCheck)
            {
                isValidHeight = (c >= '0' && c <= '9');

                if (!isValidHeight)
                {
                    break;
                }
            }

            return isValidHeight;
        }

        private static void decreaseOneIfHeightIsEven(ref int io_HeightOfDiamond)
        {
            if (io_HeightOfDiamond % 2 == 0)
            {
                io_HeightOfDiamond--;
            }
        }
    }
}