using System;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            string inputFromUserAsString = "";
            int inputFromUserAsNumber = 0;
            int amountOfDigitsSmallerFromLeastSignificantDigit = 0;
            int amountOfDigitsDivideByThree = 0;
            int biggestDigitInNumber = 0;
            double avgDigitValueInNumber = 0;

            getInputFromUser(ref inputFromUserAsString, ref inputFromUserAsNumber);
            amountOfDigitsSmallerFromLeastSignificantDigit = findAmountOfDigitsSmallerFromLeastSignificantDigit(inputFromUserAsString);
            amountOfDigitsDivideByThree = findAmountOfDigitsDivideByThree(inputFromUserAsString);
            biggestDigitInNumber = findBiggestDigitInNumber(inputFromUserAsString);
            avgDigitValueInNumber = findAvgDigitValueInNumber(inputFromUserAsString);

            statisticsMessageForUser(inputFromUserAsString, amountOfDigitsSmallerFromLeastSignificantDigit, amountOfDigitsDivideByThree, biggestDigitInNumber, avgDigitValueInNumber);

            Console.WriteLine("\nPress enter to exit\n");
            Console.ReadLine();
        }

        private static void statisticsMessageForUser(string i_InputFromUserAsString, int i_AmountOfDigitsSmallerFromLeastSignificantDigit, int i_AmountOfDigitsDivideByThree, int i_BiggestDigitInNumber, double i_AvgDigitValueInNumber)
        {
            string outputMessage = string.Format(@"
The number that you wrote is: {0}
The amount of digits that are smaller then the least sigfinicant digit are: {1}
The amount of digits that divide by three: {2}
The biggest digit is: {3}
The avrage digit value is: {4}
", i_InputFromUserAsString, i_AmountOfDigitsSmallerFromLeastSignificantDigit, i_AmountOfDigitsDivideByThree, i_BiggestDigitInNumber, i_AvgDigitValueInNumber
);           
            Console.WriteLine(outputMessage);
        }
        private static double findAvgDigitValueInNumber(string i_InputFromUserAsString)
        {
            double result = 0;

            for (int indexInsideString = 0; indexInsideString < i_InputFromUserAsString.Length; indexInsideString++)
            {
                int currentDigitInNumber = int.Parse((i_InputFromUserAsString[indexInsideString]).ToString());
                result += currentDigitInNumber;

            }
            return (double)(result/ (double)i_InputFromUserAsString.Length);
        }
        private static int findBiggestDigitInNumber(string i_InputFromUserAsString)
        {
            int biggestDigitInNumber = 0;
            int currentDigitInNumber;

            for (int indexInsideString = 0; indexInsideString < i_InputFromUserAsString.Length; indexInsideString++)
            {
                currentDigitInNumber = int.Parse((i_InputFromUserAsString[indexInsideString]).ToString());
                if (currentDigitInNumber > biggestDigitInNumber)
                {
                    biggestDigitInNumber = currentDigitInNumber;
                }
            }
            return biggestDigitInNumber;
        }
       private static int findAmountOfDigitsDivideByThree(string i_InputFromUserAsString)
        {
            int counterForAmountOfNumbersDivideByThree = 0;
            const int v_DivisionInThree = 3;

            for (int indexInsideString = 0; indexInsideString < i_InputFromUserAsString.Length; indexInsideString++)
            {       
                int currentDigitInNumber = int.Parse((i_InputFromUserAsString[indexInsideString]).ToString());
                if (currentDigitInNumber % v_DivisionInThree == 0)
                {
                    counterForAmountOfNumbersDivideByThree++;
                }
            }
            return counterForAmountOfNumbersDivideByThree;
        }
        private static int findAmountOfDigitsSmallerFromLeastSignificantDigit(string i_InputFromUserAsString)
        {
            int LeastSignificantDigitInNumber = int.Parse((i_InputFromUserAsString[i_InputFromUserAsString.Length - 1]).ToString());
            int counterForAmountOfNumbersSmallerThenLeastSignificant = 0;

            for(int indexInsideString = 0; indexInsideString < i_InputFromUserAsString.Length; indexInsideString++)
            {

                int currentDigitInNumber = int.Parse((i_InputFromUserAsString[indexInsideString]).ToString());
                if(currentDigitInNumber < LeastSignificantDigitInNumber)
                {
                    counterForAmountOfNumbersSmallerThenLeastSignificant++;
                }

            }
            return counterForAmountOfNumbersSmallerThenLeastSignificant;
        }
        private static void getInputFromUser(ref string i_InputFromUserAsString, ref int i_InputFromUserAsNumber)
        {
            Console.WriteLine("please input positive 8 digits number: ");
            string inputFromUser = Console.ReadLine();

            while (!isInputVaild(inputFromUser))
            {
                Console.WriteLine("follow instructions and try again, positive 8 digits number:");
                inputFromUser = Console.ReadLine();
            }

            i_InputFromUserAsString = inputFromUser;
            i_InputFromUserAsNumber = int.Parse(inputFromUser);

        }
        private static bool isInputVaild(string i_StringInput) // vaild - a positive 8 digits number 
        {
            const int v_RequiredLengthForString = 8;
            bool stringIsAVaildNumber = false;

            if(i_StringInput.Length == v_RequiredLengthForString)
            {
                if (int.TryParse(i_StringInput, out int numberFromString))
                {
                    stringIsAVaildNumber = (numberFromString > 0);
                }
            }

            return stringIsAVaildNumber;

        }
    }

}
