using System;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            string firstInputBinaryNumber, secondInputBinaryNumber, thirdInputBinaryNumber;
            int avgNumberOfZeros, avgNumberOfOnes, decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber;
            int lowestNumber, highestNumber, middleNumber, amountOfNumbersThatAccedingSeires, poweredByTwoCount;

            inputHandlingFromUser(out firstInputBinaryNumber, out secondInputBinaryNumber, out thirdInputBinaryNumber);
            calculateAvgAmountOfZerosAndOnesInNumbers(firstInputBinaryNumber, secondInputBinaryNumber, thirdInputBinaryNumber, out avgNumberOfZeros, out avgNumberOfOnes);
            convertAllBinaryNumbersIntoDecimal(firstInputBinaryNumber, secondInputBinaryNumber, thirdInputBinaryNumber, out decialValueOfFirstNumber, out decimalValueOfSecondNumber, out decialValueOfThirdNumber);
            poweredByTwoCount = findAmountOfNumbersPoweredByTwo(decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            lowestNumber = FindMinNumber(decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            highestNumber = FindMaxNumber(decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            middleNumber = findMidNumber(lowestNumber, highestNumber, decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            amountOfNumbersThatAccedingSeires = amountOfNumbersThatAreAccendingSeires(decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            staticicsForUser(poweredByTwoCount, amountOfNumbersThatAccedingSeires, avgNumberOfZeros, avgNumberOfOnes, lowestNumber, middleNumber, highestNumber);

            Console.WriteLine("press Any Key to exit");
            Console.ReadLine();
        }

        private static void staticicsForUser(int i_poweredByTwoCount, int i_amountOfNumbersThatAccedingSeires, int i_AvgNumberOfZeros, int i_AvgNumberOfOnes, int i_LowesetNumber, int i_MiddeleNumber, int i_HighestNumber)
        {
            string output = string.Format(@"
The Decimal presentation of the given numbers are: {0}, {1} , {2}
The amount of numbers which are 2 powered is: {3} 
The amount of numbers which are an acceding series is: {4}
The average number of zero digits in all 3 numbers is: {5}
The average number of one digits in all 3 numbers is: {6}
The biggest number of all 3 is: {7}
The smallest number of all 3 is: {8}
",
         i_LowesetNumber, i_MiddeleNumber, i_HighestNumber, i_poweredByTwoCount, i_amountOfNumbersThatAccedingSeires,
         i_AvgNumberOfZeros, i_AvgNumberOfOnes, i_HighestNumber, i_LowesetNumber);

            Console.WriteLine(output);


            
        }
        private static void inputHandlingFromUser(out string o_FirstInputBinaryNumber, out string o_SecondInputBinaryNumber, out string o_ThirdInputBinaryNumber)
        {
            Console.WriteLine("Enter 3 numbers with 9 digits for each number:");
            getInputFromUser(out o_FirstInputBinaryNumber);
            getInputFromUser(out o_SecondInputBinaryNumber);
            getInputFromUser(out o_ThirdInputBinaryNumber);
        }

        private static void getInputFromUser(out string o_InputBinaryNumber)
        {
            o_InputBinaryNumber = Console.ReadLine();
            while (!checkIfInputFromUserIsVaild(o_InputBinaryNumber))
            {
                Console.WriteLine("Invalid input! Numbers should be 9 digits with only zeros and ones");
                o_InputBinaryNumber = Console.ReadLine();
            }
        }
        private static bool checkIfInputFromUserIsVaild(string i_messageForUser)
        {
            bool isInputVaild = false;
            const int v_RequirdedLength = 9;

            if (i_messageForUser.Length == v_RequirdedLength)
            {

                for (int i = 0; i < v_RequirdedLength; i++)
                {
                    if ((i_messageForUser[i] == '0' || i_messageForUser[i] == '1'))
                    {
                        isInputVaild = true;
                    }
                    else
                    {
                        isInputVaild = false;
                        break;
                    }
                }


            }
            return isInputVaild;
        }



        private static bool isNumberIsMiddleNumber(int i_MinNumber,  int i_MaxNumber,  int i_CheckIfNumber)
        {
            
            int tmpMiddleNumber1 = Math.Min(i_CheckIfNumber, i_MaxNumber);
            int tmpMiddleNumber2 = Math.Max(i_CheckIfNumber, i_MinNumber);

            return (tmpMiddleNumber1 == tmpMiddleNumber2);
        }

        private static int findMidNumber(int i_MinNumber, int i_MaxNumber, int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            int middleNumber = 0;

            if (isNumberIsMiddleNumber( i_MinNumber,  i_MaxNumber, i_DecialValueOfFirstNumber))
            {
                middleNumber = i_DecialValueOfFirstNumber;
            }
            else if (isNumberIsMiddleNumber( i_MinNumber,  i_MaxNumber, i_DecimalValueOfSecondNumber))
            {
                middleNumber = i_DecimalValueOfSecondNumber;
            }
            else
            {
                middleNumber = i_DecialValueOfThirdNumber;
            }

            return middleNumber;
        }


        private static int amountOfNumbersThatAreAccendingSeires(int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            int amountOfNumbersThatAccedingSeires = 0;

            amountOfNumbersThatAccedingSeires += isNumbersAreAccendingSeires( i_DecialValueOfFirstNumber);
            amountOfNumbersThatAccedingSeires += isNumbersAreAccendingSeires(i_DecimalValueOfSecondNumber);
            amountOfNumbersThatAccedingSeires += isNumbersAreAccendingSeires(i_DecialValueOfThirdNumber);

            return amountOfNumbersThatAccedingSeires;
        }

        private static int isNumbersAreAccendingSeires(int i_NumbersToCheck)
        {
            int appendToCounterOfAccedingSeires = 1;
            const int v_DivideByTen = 10;

            int tempContainerForDecimalNumber = (i_NumbersToCheck % v_DivideByTen);

            i_NumbersToCheck /= v_DivideByTen;

            while (i_NumbersToCheck > 0)
            {
                if ((i_NumbersToCheck % v_DivideByTen) < tempContainerForDecimalNumber)
                {
                    tempContainerForDecimalNumber = (i_NumbersToCheck % v_DivideByTen);
                    i_NumbersToCheck /= v_DivideByTen;
                }
                else
                {
                    appendToCounterOfAccedingSeires = 0;
                    break;
                }
            }

            return appendToCounterOfAccedingSeires;
        }
             
        private static int FindMaxNumber(int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            int maxNumber;

            maxNumber = (int)Math.Max(i_DecialValueOfFirstNumber, i_DecimalValueOfSecondNumber);
            maxNumber = (int)Math.Max(maxNumber, i_DecialValueOfThirdNumber);

            return maxNumber;
        }

        private static int FindMinNumber(int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            int minNumber;

            minNumber = (int)Math.Min(i_DecialValueOfFirstNumber, i_DecimalValueOfSecondNumber);
            minNumber = (int)Math.Min(minNumber, i_DecialValueOfThirdNumber);

            return minNumber;

        }
        private static void calculateAvgAmountOfZerosAndOnesInNumbers(string i_FirstInputBinaryNumber, string i_SecondInputBinaryNumber, string i_ThirdInputBinaryNumber, out int o_AvgNumberOfZeros, out int o_AvgNumberOfOnes)
        {
            int sumNumbOfZerosInTotalNumbers = 0;
            const int v_TotalNumberOfDigitsInAllNumbers = 27;
            const int v_AmountOfNumbersFromUser = 3;

            sumNumbOfZerosInTotalNumbers += findAmountOfZerosInANumbers(i_FirstInputBinaryNumber);
            sumNumbOfZerosInTotalNumbers += findAmountOfZerosInANumbers(i_SecondInputBinaryNumber);
            sumNumbOfZerosInTotalNumbers += findAmountOfZerosInANumbers(i_ThirdInputBinaryNumber);

            o_AvgNumberOfOnes = ((v_TotalNumberOfDigitsInAllNumbers - sumNumbOfZerosInTotalNumbers) / v_AmountOfNumbersFromUser);
            o_AvgNumberOfZeros = sumNumbOfZerosInTotalNumbers / v_AmountOfNumbersFromUser;
        }
        private static int findAmountOfNumbersPoweredByTwo(int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            int counterOfPoweredByTwoNumbers = 0;
            const int v_BaseOfLog = 2;

            double firstDecimalNum = System.Math.Log(i_DecialValueOfFirstNumber, v_BaseOfLog);
            double secondDecimalNum = System.Math.Log(i_DecimalValueOfSecondNumber, v_BaseOfLog);
            double thirdDecimalNum = System.Math.Log(i_DecialValueOfThirdNumber, v_BaseOfLog);

            isDecimalNumberComplete(firstDecimalNum, ref counterOfPoweredByTwoNumbers);
            isDecimalNumberComplete(secondDecimalNum, ref counterOfPoweredByTwoNumbers);
            isDecimalNumberComplete(thirdDecimalNum, ref counterOfPoweredByTwoNumbers);
            return counterOfPoweredByTwoNumbers;

        }

        private static void isDecimalNumberComplete(double i_notCompleteNumber, ref int counterOfPoweredByTwoNumbers)
        {
            int completeNumber = (int)i_notCompleteNumber;

            if ((i_notCompleteNumber - (double)completeNumber) == 0)
            {
                counterOfPoweredByTwoNumbers++;
            }
        }

        private static int findAmountOfZerosInANumbers(string inputNumberFromUser)
        {
            int countZerosInNumber = 0;

            for (int i = 0; i < 9; i++)
            {

                if (inputNumberFromUser[i] == '0')
                {
                    countZerosInNumber++;
                }

            }
            return countZerosInNumber;
        }

        private static void convertAllBinaryNumbersIntoDecimal(string i_FirstInputBinaryNumber, string i_SecondInputBinaryNumber, string i_ThirdInputBinaryNumber, out int io_DecialValueOfFirstNumber, out int io_DecimalValueOfSecondNumber, out int io_DecialValueOfThirdNumber)
        {

            int firstBinaryNumber = int.Parse(i_FirstInputBinaryNumber);
            int secondBinaryNumber = int.Parse(i_SecondInputBinaryNumber);
            int thirdBinaryNumber = int.Parse(i_ThirdInputBinaryNumber);

            io_DecialValueOfFirstNumber = convertBinaryNumberIntoDecimal(firstBinaryNumber);
            io_DecimalValueOfSecondNumber = convertBinaryNumberIntoDecimal(secondBinaryNumber);
            io_DecialValueOfThirdNumber = convertBinaryNumberIntoDecimal(thirdBinaryNumber);
        }
        private static int convertBinaryNumberIntoDecimal(int i_InputNumber)
        {

            int exponent = 0;
            double resultDecimalNumber = 0;
            int lastDigitOfBinary;
            const int v_DivisionByTen = 10;

            while (i_InputNumber > 0)
            {


                lastDigitOfBinary = i_InputNumber % v_DivisionByTen;

                resultDecimalNumber += (System.Math.Pow(2, exponent)) * lastDigitOfBinary;

                i_InputNumber /= v_DivisionByTen;
                exponent++;
            }
            return (int)resultDecimalNumber;
        }
    }
}
