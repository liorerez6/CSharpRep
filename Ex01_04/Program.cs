using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex01_04
{
    public class Program
    {

        
        


        public static void Main()
        {
            string stringContiner = "";
            bool isStringANumber = false;
            bool stringIsPalidrom = false;
            bool stringIsNumberDivdedByFour = false;
            int  numberOfLowerCaseCharsInString = 0;

            getInputFromUser(ref stringContiner, ref isStringANumber);
            isStringIsPalindrom(ref stringIsPalidrom, stringContiner);
            stringIsNumberDivdedByFour = isNumberDivideByFour(stringContiner, isStringANumber);
            numberOfLowerCaseCharsInString = amountOfLowerCaseCharsInString(stringContiner, isStringANumber);
            endMessageForUser(stringContiner, stringIsPalidrom, stringIsNumberDivdedByFour, numberOfLowerCaseCharsInString, isStringANumber);
        }

        private static void endMessageForUser(string i_stringContainer, bool i_stringIsPalidrom, bool i_stringIsNumberDivdedByFour , int i_numberOfLowerCaseCharsInString, bool i_isStringANumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("The string you chose is: ");
            stringBuilder.Append(i_stringContainer);
            stringBuilder.AppendLine();

            if (i_stringIsPalidrom)
            {
                stringBuilder.Append("And the string is a palindrom");
            }
            else
            {
                stringBuilder.Append("And the string is not a palindrom");
            }

            stringBuilder.AppendLine();

            if (i_isStringANumber)
            {
                if (i_stringIsNumberDivdedByFour)
                {
                    stringBuilder.Append("And it has dvision by 4");
                }
                else
                {
                    stringBuilder.Append("And it doesn't has dvision by 4");
                }
            }
            else
            {
                stringBuilder.Append("And it has ");
                stringBuilder.Append(i_numberOfLowerCaseCharsInString);
                stringBuilder.Append(" lower case alpha-bet in it");
            }
            stringBuilder.AppendLine();
            string msg = stringBuilder.ToString();
            Console.WriteLine(msg);
        }
        
        private static int amountOfLowerCaseCharsInString(string i_stringContainer, bool i_isStringANumber)
        {
            int counterForLowerCaseLettersInString = 0;

            if (!i_isStringANumber)
            {
                for (int indexInsideString = 0; indexInsideString < i_stringContainer.Length; indexInsideString++)
                {
                    if (char.IsLower(i_stringContainer[indexInsideString]))
                    {
                        counterForLowerCaseLettersInString++;
                    }
                   
                }
            }
            return counterForLowerCaseLettersInString;
        }

        private static bool isNumberDivideByFour(string i_stringContainer, bool i_isStringANumber)
        {
            bool isNumberDivdedByFour = false;
            const int v_NumberForDivision = 4;

            if (i_isStringANumber)
            {
                long numberFromString = long.Parse(i_stringContainer); 
                double fullNumberWithDecimalPoint = ((double)numberFromString / v_NumberForDivision);
                long fullNumberWithoutDecimalPoint = (numberFromString / v_NumberForDivision);
                isNumberDivdedByFour = (fullNumberWithDecimalPoint - fullNumberWithoutDecimalPoint == 0);               
            }
            return isNumberDivdedByFour;
        }

        private static void isStringIsPalindrom(ref bool io_stringIsPalidrom, string i_stringContainer)
        {
            io_stringIsPalidrom = isPalindromRec(0, i_stringContainer.Length - 1, i_stringContainer);
        }

        private static bool isPalindromRec(int left, int right, string i_stringContainer)
        {
            if (left >= right)
            {
                return true;
            }
            if (i_stringContainer[left] != i_stringContainer[right])
            {
                return false;
            }
                
            return isPalindromRec(left + 1, right - 1, i_stringContainer);
        }
        private static void getInputFromUser(ref string io_stringContainer, ref bool io_stringIsANumber)
        {
            Console.WriteLine("enter a 10-chars string that written by english alphabet or digits (not a combination)");
            io_stringContainer = Console.ReadLine();

            while (!(checkForVaildString(io_stringContainer,ref io_stringIsANumber)))
            {
                Console.WriteLine("String is not like instructions! try again");
                io_stringContainer = Console.ReadLine();
            }
        }

        private static bool checkForVaildString(string i_stringContainer, ref bool o_stringIsANumber)
        {
            bool stringIsVaild = false;
            int counterForFullyCompleteNumber = 0;
            bool vailEnglishAlphabet = true;
            const int v_RequiredLengthSizeOfString = 10;

            if (i_stringContainer.Length == v_RequiredLengthSizeOfString)
            {
                for (int indexInsideString = 0; indexInsideString < i_stringContainer.Length; indexInsideString++)
                {

                    if (char.IsDigit(i_stringContainer[indexInsideString]))
                    {
                        counterForFullyCompleteNumber++;
                    }
                    else
                    {
                        if (!(i_stringContainer[indexInsideString] >= 'A' && i_stringContainer[indexInsideString] <= 'z'))
                        {
                            vailEnglishAlphabet = false;
                            break;
                        }
                    }
                }

                if ((counterForFullyCompleteNumber == v_RequiredLengthSizeOfString) || ((counterForFullyCompleteNumber == 0) && (vailEnglishAlphabet == true)))
                {
                    if (counterForFullyCompleteNumber == v_RequiredLengthSizeOfString)
                    {
                        o_stringIsANumber = true;
                    }
                    stringIsVaild = true;
                }
            }

            return stringIsVaild;

        }
    }
}
