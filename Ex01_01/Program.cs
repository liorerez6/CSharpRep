using System;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            string firstInputBinaryNumber = "", secondInputBinaryNumber = "", thirdInputBinaryNumber = "";
            int avgNumberOfZeros = 0, avgNumberOfOnes = 0, decialValueOfFirstNumber = 0, decimalValueOfSecondNumber = 0, decialValueOfThirdNumber = 0;

            inputHandlingFromUser(ref firstInputBinaryNumber, ref secondInputBinaryNumber, ref thirdInputBinaryNumber);
            calculateAvgAmountOfZerosAndOnesInNumbers(firstInputBinaryNumber, secondInputBinaryNumber, thirdInputBinaryNumber, ref avgNumberOfZeros, ref avgNumberOfOnes);
            convertAllBinaryNumbersIntoDecimal(firstInputBinaryNumber, secondInputBinaryNumber, thirdInputBinaryNumber, ref decialValueOfFirstNumber, ref decimalValueOfSecondNumber, ref decialValueOfThirdNumber);
            int poweredByTwoCount = findAmountOfNumbersPoweredByTwo(decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            int lowestNumber = findMaxOrMinNumberAccordingToParameter(true, decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            int highestNumber = findMaxOrMinNumberAccordingToParameter(false, decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            int middleNumber = findMiddleNumber(lowestNumber, highestNumber, decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
            int amountOfNumbersThatAccedingSeires = amountOfNumbersThatAreAccendingSeires(decialValueOfFirstNumber, decimalValueOfSecondNumber, decialValueOfThirdNumber);
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
        private static void inputHandlingFromUser(ref string io_FirstInputBinaryNumber, ref string io_SecondInputBinaryNumber, ref string io_ThirdInputBinaryNumber)
        {

            Console.WriteLine("Enter 3 numbers with 9 digits for each number:");
            io_FirstInputBinaryNumber = Console.ReadLine();

            while (!checkIfInputFromUserIsVaild(io_FirstInputBinaryNumber))
            {
                Console.WriteLine("Numbers should be 9 digits with only zeros and ones");
                io_FirstInputBinaryNumber = Console.ReadLine();
            }

            io_SecondInputBinaryNumber = Console.ReadLine();
            while (!checkIfInputFromUserIsVaild(io_SecondInputBinaryNumber))
            {
                Console.WriteLine("Numbers should be 9 digits with only zeros and ones");
                io_SecondInputBinaryNumber = Console.ReadLine();
            }

            io_ThirdInputBinaryNumber = Console.ReadLine();
            while (!checkIfInputFromUserIsVaild(io_ThirdInputBinaryNumber))
            {
                Console.WriteLine("Numbers should be 9 digits with only zeros and ones");
                io_ThirdInputBinaryNumber = Console.ReadLine();
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
        private static int findMiddleNumber(int i_biggestNumber, int i_smallestNumber, int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            const int v_AmountOFNumbers = 3;

            int[] numbers = new int[v_AmountOFNumbers];
            numbers[0] = i_DecialValueOfFirstNumber;
            numbers[1] = i_DecimalValueOfSecondNumber;
            numbers[2] = i_DecialValueOfThirdNumber;

            int middleNumber = i_DecialValueOfFirstNumber;
            for (int indexAtSpecificNumber = 0; indexAtSpecificNumber < v_AmountOFNumbers; indexAtSpecificNumber++)
            {
                if (numbers[indexAtSpecificNumber] != i_biggestNumber && numbers[indexAtSpecificNumber] != i_smallestNumber)
                {
                    middleNumber = numbers[indexAtSpecificNumber];
                }
            }
            return middleNumber;
        }
        private static int amountOfNumbersThatAreAccendingSeires(int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            const int v_AmountOFNumbers = 3;
            int[] numbers = new int[v_AmountOFNumbers];
            numbers[0] = i_DecialValueOfFirstNumber;
            numbers[1] = i_DecimalValueOfSecondNumber;
            numbers[2] = i_DecialValueOfThirdNumber;

            int counterForAccedingSeiresNumbers = 0;
            int tempContainerForDecimalNumber;
            const int v_DvisionByTen = 10;

            for (int indexAtSpecificNumber = 0; indexAtSpecificNumber < v_AmountOFNumbers; indexAtSpecificNumber++)
            {
                bool isNumberAccedingSeires = true;
                tempContainerForDecimalNumber = (numbers[indexAtSpecificNumber] % v_DvisionByTen);
                numbers[indexAtSpecificNumber] /= v_DvisionByTen;
                while ((numbers[indexAtSpecificNumber] > 0) && isNumberAccedingSeires)
                {
                    if ((numbers[indexAtSpecificNumber] % v_DvisionByTen) < tempContainerForDecimalNumber)
                    {
                        tempContainerForDecimalNumber = (numbers[indexAtSpecificNumber] % v_DvisionByTen);
                        numbers[indexAtSpecificNumber] /= v_DvisionByTen;
                    }
                    else
                    {
                        isNumberAccedingSeires = false;
                    }
                }
                if (isNumberAccedingSeires)
                {
                    counterForAccedingSeiresNumbers++;
                }
            }
            return counterForAccedingSeiresNumbers;
        }
        private static int findMaxOrMinNumberAccordingToParameter(bool i_biggerOrSmallerSign, int i_DecialValueOfFirstNumber, int i_DecimalValueOfSecondNumber, int i_DecialValueOfThirdNumber)
        {
            const int v_AmountOFNumbers = 3;

            int[] numbers = new int[v_AmountOFNumbers];
            numbers[0] = i_DecialValueOfFirstNumber;
            numbers[1] = i_DecimalValueOfSecondNumber;
            numbers[2] = i_DecialValueOfThirdNumber;
            int maxOrMinNumberAccordingToParameter = numbers[0];

            for (int indexAtSpecificNumber = 1; indexAtSpecificNumber < v_AmountOFNumbers; indexAtSpecificNumber++)
            {
                if (i_biggerOrSmallerSign == false)
                {
                    if (maxOrMinNumberAccordingToParameter < numbers[indexAtSpecificNumber])
                    {
                        maxOrMinNumberAccordingToParameter = numbers[indexAtSpecificNumber];
                    }
                }
                else
                {
                    if (maxOrMinNumberAccordingToParameter > numbers[indexAtSpecificNumber])
                    {
                        maxOrMinNumberAccordingToParameter = numbers[indexAtSpecificNumber];
                    }
                }
            }
            return maxOrMinNumberAccordingToParameter;
        }
        private static void calculateAvgAmountOfZerosAndOnesInNumbers(string i_FirstInputBinaryNumber, string i_SecondInputBinaryNumber, string i_ThirdInputBinaryNumber, ref int io_AvgNumberOfZeros, ref int io_AvgNumberOfOnes)
        {
            int sumNumbOfZerosInTotalNumbers = 0;
            const int v_TotalNumberOfDigitsInAllNumbers = 27;
            const int v_AmountOfNumbersFromUser = 3;

            sumNumbOfZerosInTotalNumbers += FindAmountOfZerosInANumbers(i_FirstInputBinaryNumber);
            sumNumbOfZerosInTotalNumbers += FindAmountOfZerosInANumbers(i_SecondInputBinaryNumber);
            sumNumbOfZerosInTotalNumbers += FindAmountOfZerosInANumbers(i_ThirdInputBinaryNumber);

            io_AvgNumberOfOnes = ((v_TotalNumberOfDigitsInAllNumbers - sumNumbOfZerosInTotalNumbers) / v_AmountOfNumbersFromUser);
            io_AvgNumberOfZeros = sumNumbOfZerosInTotalNumbers / v_AmountOfNumbersFromUser;
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

        private static int FindAmountOfZerosInANumbers(string inputNumberFromUser)
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

        private static void convertAllBinaryNumbersIntoDecimal(string i_FirstInputBinaryNumber, string i_SecondInputBinaryNumber, string i_ThirdInputBinaryNumber, ref int io_DecialValueOfFirstNumber, ref int io_DecimalValueOfSecondNumber, ref int io_DecialValueOfThirdNumber)
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
