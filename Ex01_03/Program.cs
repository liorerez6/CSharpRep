using Ex01_02; 
using System;

namespace Ex01_03
{
    public class Program
    {
        private static void Main()
        {
            int userChosenHeight = 0;

            Console.WriteLine("Ex01_03: Diamond For Advancers\n");
            userChosenHeight = getHeightFromUser();
            Console.WriteLine("\nPress enter to exit\n");
            Console.ReadLine();
            Ex01_02.Program.RunProgramEx01_02(userChosenHeight); //uses the same function implemented in ex01_02
        }

        private static int getHeightFromUser() // gets the height from the user
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

            return convertHeightOfDiamondToInt;     
        }

        private static bool isValidHeightInput(string i_HeightToCheck) //checks for vail height
        {
            bool isValidHeight = true;

            foreach (char digitInHeightValue in i_HeightToCheck)
            {
                isValidHeight = (digitInHeightValue >= '0' && digitInHeightValue <= '9');

                if (!isValidHeight)
                {
                    break;
                }
            }

            return isValidHeight;
        }

        private static void decreaseOneIfHeightIsEven(ref int io_HeightOfDiamond) // in case user's heigh is even, makes it odd by decreasing one
        {
            if (io_HeightOfDiamond % 2 == 0) // checks if even
            {
                io_HeightOfDiamond--;
            }
        }
    }
}