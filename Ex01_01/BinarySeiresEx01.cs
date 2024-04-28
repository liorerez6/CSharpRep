using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ex01_01
{
    public class BinarySeiresEx01
    {



        private string m_FirstInputBinaryNumber;
        private string m_SecondInputBinaryNumber;
        private string m_ThirdInputBinaryNumber;

        private int m_AvgNumberOfZerosInTotalNumbers = 0;
        private int m_AvgNumberOfOnesInTotalNumbers = 0;

        private int m_DecialValueOfFirstNumber = 0;
        private int m_DecialValueOfSecondNumber = 0;
        private int m_DecialValueOfThirdNumber = 0;

        public BinarySeiresEx01()
        {

            RunBinarySeiresEx01();

        }
        private void RunBinarySeiresEx01()
        {


            InputHandlingFromUser();
            CalculateAvgAmountOfZerosAndOnesInNumbers();
            ConvertAllBinaryNumbersIntoDecimal();
            int poweredByTwoCount = FindAmountOfNumbersPoweredByTwo();
            int lowestNum = FindMaxOrMinNumberAccordingToParameter(true);
            int highestNum = FindMaxOrMinNumberAccordingToParameter(false);
            int middleNumber = FindMiddleNumber(lowestNum, highestNum);
            int amountOfNumbersThatAccedingSeires = AmountOfNumbersThatAreAccendingSeires();



            string output = string.Format(@"
The Decimal presentation of the given numbers are: {0}, {1} , {2}
The amount of numbers which are 2 powered is: {3} 
The amount of numbers which are an acceding series is: {4}
The average number of zero digits in all 3 numbers is: {5}
The average number of one digits in all 3 numbers is: {6}
The biggest number of all 3 is: {7}
The smallest number of all 3 is: {8}
",
           lowestNum, middleNumber, highestNum, poweredByTwoCount, amountOfNumbersThatAccedingSeires,
           m_AvgNumberOfZerosInTotalNumbers, m_AvgNumberOfOnesInTotalNumbers, highestNum, lowestNum);

            Console.WriteLine(output);


            Console.WriteLine("press Any Key to exit");
            Console.ReadLine();
        }

        private void InputHandlingFromUser()
        {

            Console.WriteLine("Enter 3 numbers with 9 digits for each number:");
            m_FirstInputBinaryNumber = Console.ReadLine();

            while (!CheckIfInputFromUserIsVaild(m_FirstInputBinaryNumber))
            {
                Console.WriteLine("Numbers should be 9 digits with only zeros and ones");
                m_FirstInputBinaryNumber = Console.ReadLine();
            }

            m_SecondInputBinaryNumber = Console.ReadLine();
            while (!CheckIfInputFromUserIsVaild(m_SecondInputBinaryNumber))
            {
                Console.WriteLine("Numbers should be 9 digits with only zeros and ones");
                m_SecondInputBinaryNumber = Console.ReadLine();
            }

            m_ThirdInputBinaryNumber = Console.ReadLine();
            while (!CheckIfInputFromUserIsVaild(m_ThirdInputBinaryNumber))
            {
                Console.WriteLine("Numbers should be 9 digits with only zeros and ones");
                m_ThirdInputBinaryNumber = Console.ReadLine();
            }





        }

        private bool CheckIfInputFromUserIsVaild(string i_messageForUser)
        {
            bool isInputVaild = false;

            if (i_messageForUser.Length == 9)
            {

                for (int i = 0; i < 9; i++)
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

        private int FindMiddleNumber(int i_biggestNumber, int i_smallestNumber)
        {
            int[] numbers = new int[3];
            numbers[0] = m_DecialValueOfFirstNumber;
            numbers[1] = m_DecialValueOfSecondNumber;
            numbers[2] = m_DecialValueOfThirdNumber;

            int middleNumber = m_DecialValueOfFirstNumber;
            for (int i = 0; i < 3; i++)
            {
                if (numbers[i] != i_biggestNumber && numbers[i] != i_smallestNumber)
                {
                    middleNumber = numbers[i];
                }
            }
            return middleNumber;

        }

        private int AmountOfNumbersThatAreAccendingSeires()
        {
            /* grabge collector in C# ? needed free ? */
            int[] numbers = new int[3];
            numbers[0] = m_DecialValueOfFirstNumber;
            numbers[1] = m_DecialValueOfSecondNumber;
            numbers[2] = m_DecialValueOfThirdNumber;

            int counterForAccedingSeiresNumbers = 0;
            int tempContainerForDecimalNumber;


            for (int i = 0; i < 3; i++)
            {
                bool isNumberAccedingSeires = true;
                tempContainerForDecimalNumber = (numbers[i] % 10);
                numbers[i] /= 10;
                while ((numbers[i] > 0) && isNumberAccedingSeires)
                {
                    if ((numbers[i] % 10) < tempContainerForDecimalNumber)
                    {
                        tempContainerForDecimalNumber = (numbers[i] % 10);
                        numbers[i] /= 10;
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

        private int FindMaxOrMinNumberAccordingToParameter(bool i_biggerOrSmallerSign)
        {
            int[] numbers = new int[3];
            numbers[0] = m_DecialValueOfFirstNumber;
            numbers[1] = m_DecialValueOfSecondNumber;
            numbers[2] = m_DecialValueOfThirdNumber;

            int maxOrMinNumberAccordingToParameter = numbers[0];
            




            for (int i = 1; i < 3; i++)
            {
                if (i_biggerOrSmallerSign == false)
                {
                    if (maxOrMinNumberAccordingToParameter < numbers[i])
                    {
                        maxOrMinNumberAccordingToParameter = numbers[i];
                    }
                }
                else
                {
                    if (maxOrMinNumberAccordingToParameter > numbers[i])
                    {
                        maxOrMinNumberAccordingToParameter = numbers[i];
                    }
                }


            }
            return maxOrMinNumberAccordingToParameter;

        }

        private void CalculateAvgAmountOfZerosAndOnesInNumbers()
        {

            int sumNumbOfZerosInTotalNumbers = 0;


            sumNumbOfZerosInTotalNumbers += FindAmountOfZerosInANumbers(m_FirstInputBinaryNumber);
            sumNumbOfZerosInTotalNumbers += FindAmountOfZerosInANumbers(m_SecondInputBinaryNumber);
            sumNumbOfZerosInTotalNumbers += FindAmountOfZerosInANumbers(m_ThirdInputBinaryNumber);

            m_AvgNumberOfOnesInTotalNumbers = ((27 - sumNumbOfZerosInTotalNumbers) / 3);
            m_AvgNumberOfZerosInTotalNumbers = sumNumbOfZerosInTotalNumbers / 3;

        }

        private int FindAmountOfNumbersPoweredByTwo()
        {
            int counterOfPoweredByTwoNumbers = 0;

            double firstDecimalNum = System.Math.Log(m_DecialValueOfFirstNumber, 2);
            double secondDecimalNum = System.Math.Log(m_DecialValueOfSecondNumber, 2);
            double thirdDecimalNum = System.Math.Log(m_DecialValueOfThirdNumber, 2);


            IsDecimalNumberComplete(firstDecimalNum, ref counterOfPoweredByTwoNumbers);
            IsDecimalNumberComplete(secondDecimalNum, ref counterOfPoweredByTwoNumbers);
            IsDecimalNumberComplete(thirdDecimalNum, ref counterOfPoweredByTwoNumbers);
            return counterOfPoweredByTwoNumbers;

        }

        private void IsDecimalNumberComplete(double i_notCompleteNumber, ref int counterOfPoweredByTwoNumbers)
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

        private void ConvertAllBinaryNumbersIntoDecimal()
        {

            int FirstbinaryNumber = int.Parse(m_FirstInputBinaryNumber);
            int SecondbinaryNumber = int.Parse(m_SecondInputBinaryNumber);
            int ThirdbinaryNumber = int.Parse(m_ThirdInputBinaryNumber);

            m_DecialValueOfFirstNumber = ConvertBinaryNumberIntoDecimal(FirstbinaryNumber);
            m_DecialValueOfSecondNumber = ConvertBinaryNumberIntoDecimal(SecondbinaryNumber);
            m_DecialValueOfThirdNumber = ConvertBinaryNumberIntoDecimal(ThirdbinaryNumber);

        }

        private int ConvertBinaryNumberIntoDecimal(int i_inputNumber)
        {

            int exponent = 0;
            double resultDecimalNumber = 0;
            int lastDigitOfBinary;

            while (i_inputNumber > 0)
            {


                lastDigitOfBinary = i_inputNumber % 10;

                resultDecimalNumber += (System.Math.Pow(2, exponent)) * lastDigitOfBinary;

                i_inputNumber /= 10;
                exponent++;

            }

            return (int)resultDecimalNumber;
        }

    }
}
