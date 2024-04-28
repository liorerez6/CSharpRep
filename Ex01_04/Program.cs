using System;

namespace Ex01_04
{
    public class Program
    {

        const int requiredLengthSizeOfString = 10;

        

        public static void Main()
        {
            string stringContiner = "";
            bool m_isStringANumber = false;
            bool m_stringIsPalidrom = false;
            bool m_stringIsNumberDivdedByFour = false;
            int m_NumberOfLowerCaseCharsInString = 0;

            getInputFromUser(ref stringContiner, ref m_isStringANumber);
            IsStringIsPalindrom(ref m_stringIsPalidrom, stringContiner);

        }

        private static void IsStringIsPalindrom(ref bool i_stringIsPalidrom, string i_stringContainer)
        {
            i_stringIsPalidrom = IsPalindromRec(0, i_stringContainer.Length - 1, i_stringContainer);

        }

        private static bool IsPalindromRec(int left, int right, string i_stringContainer)
        {

            // Base case: it's palindrome
            if (left >= right)
                return true;

            // Check if characters at left and right are not equal
            if (i_stringContainer[left] != i_stringContainer[right])
                return false;


            return IsPalindromRec(left + 1, right - 1, i_stringContainer);

        }
        private static void getInputFromUser(ref string i_stringContainer, ref bool i_stringIsANumber)
        {
            Console.WriteLine("enter a 10-chars string that written by english alphabet or digits (not a combination)");
            i_stringContainer = Console.ReadLine();

            while (!(CheckForVaildString(i_stringContainer,ref i_stringIsANumber)))
            {
                Console.WriteLine("String its not like instructions! try again");
                i_stringContainer = Console.ReadLine();
            }


        }

        private static bool CheckForVaildString(string i_stringContainer, ref bool i_stringIsANumber)
        {
            bool stringIsVaild = false;
            int counterForFullyCompleteNumber = 0;
            bool vailEnglishAlphabet = true;

            if (i_stringContainer.Length == requiredLengthSizeOfString)
            {
                for (int i = 0; i < i_stringContainer.Length; i++)
                {

                    if (char.IsDigit(i_stringContainer[i]))
                    {
                        counterForFullyCompleteNumber++;
                    }
                    else
                    {
                        if (!(i_stringContainer[i] >= 'a' && i_stringContainer[i] <= 'z'))
                        {

                            vailEnglishAlphabet = false;
                            break;

                        }
                    }

                }
                if ((counterForFullyCompleteNumber == requiredLengthSizeOfString) || ((counterForFullyCompleteNumber == 0) && (vailEnglishAlphabet == true)))
                {
                    if (counterForFullyCompleteNumber == requiredLengthSizeOfString)
                    {
                        i_stringIsANumber = true;

                    }
                    stringIsVaild = true;
                }

            }

            return stringIsVaild;

        }
    }

}
