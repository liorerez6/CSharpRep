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

        private static void endMessageForUser(string i_StringContainer, bool i_StringIsPalidrom, bool i_StringIsNumberDivdedByFour , int i_NumberOfLowerCaseCharsInString, bool i_IsStringANumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("The string you chose is: ");
            stringBuilder.Append(i_StringContainer);
            stringBuilder.AppendLine();

            if (i_StringIsPalidrom)
            {
                stringBuilder.Append("And the string is a palindrom");
            }
            else
            {
                stringBuilder.Append("And the string is not a palindrom");
            }

            stringBuilder.AppendLine();

            if (i_IsStringANumber)
            {
                if (i_StringIsNumberDivdedByFour)
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
                stringBuilder.Append(i_NumberOfLowerCaseCharsInString);
                stringBuilder.Append(" lower case alpha-bet in it");
            }
            stringBuilder.AppendLine();
            string msg = stringBuilder.ToString();
            Console.WriteLine(msg);
        }
        
        private static int amountOfLowerCaseCharsInString(string i_StringContainer, bool i_IsStringANumber)
        {
            int counterForLowerCaseLettersInString = 0;

            if (!i_IsStringANumber)
            {
                for (int indexInsideString = 0; indexInsideString < i_StringContainer.Length; indexInsideString++)
                {
                    if (char.IsLower(i_StringContainer[indexInsideString]))
                    {
                        counterForLowerCaseLettersInString++;
                    }
                   
                }
            }
            return counterForLowerCaseLettersInString;
        }

        private static bool isNumberDivideByFour(string i_StringContainer, bool i_IsStringANumber)
        {
            bool isNumberDivdedByFour = false;
            const int v_NumberForDivision = 4;

            if (i_IsStringANumber)
            {
                long numberFromString = long.Parse(i_StringContainer); 
                double fullNumberWithDecimalPoint = ((double)numberFromString / v_NumberForDivision);
                long fullNumberWithoutDecimalPoint = (numberFromString / v_NumberForDivision);
                isNumberDivdedByFour = (fullNumberWithDecimalPoint - fullNumberWithoutDecimalPoint == 0);               
            }
            return isNumberDivdedByFour;
        }

        private static void isStringIsPalindrom(ref bool io_StringIsPalidrom, string i_StringContainer)
        {
            io_StringIsPalidrom = isPalindromRec(0, i_StringContainer.Length - 1, i_StringContainer);
        }

        private static bool isPalindromRec(int i_LeftIndexInString, int i_RightIndexInString, string i_StringContainer)
        {
            if (i_LeftIndexInString >= i_RightIndexInString)
            {
                return true;
            }
            if (i_StringContainer[i_LeftIndexInString] != i_StringContainer[i_RightIndexInString])
            {
                return false;
            }
                
            return isPalindromRec(i_LeftIndexInString + 1, i_RightIndexInString - 1, i_StringContainer);
        }
        private static void getInputFromUser(ref string io_StringContainer, ref bool io_StringIsANumber)
        {
            Console.WriteLine("enter a 10-chars string that written by english alphabet or digits (not a combination)");
            io_StringContainer = Console.ReadLine();

            while (!(checkForVaildString(io_StringContainer,ref io_StringIsANumber)))
            {
                Console.WriteLine("String is not like instructions! try again");
                io_StringContainer = Console.ReadLine();
            }
        }

        private static bool checkForVaildString(string i_StringContainer, ref bool o_StringIsANumber)
        {
            bool stringIsVaild = false;
            int counterForFullyCompleteNumber = 0;
            bool vailEnglishAlphabet = true;
            const int v_RequiredLengthSizeOfString = 10;

            if (i_StringContainer.Length == v_RequiredLengthSizeOfString)
            {
                for (int indexInsideString = 0; indexInsideString < i_StringContainer.Length; indexInsideString++)
                {

                    if (char.IsDigit(i_StringContainer[indexInsideString]))
                    {
                        counterForFullyCompleteNumber++;
                    }
                    else
                    {
                        if (!(i_StringContainer[indexInsideString] >= 'A' && i_StringContainer[indexInsideString] <= 'z'))
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
                        o_StringIsANumber = true;
                    }
                    stringIsVaild = true;
                }
            }

            return stringIsVaild;

        }
    }
}
