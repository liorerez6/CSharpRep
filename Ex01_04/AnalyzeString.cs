using System;
using System.Runtime.InteropServices;

namespace Ex01_04
{
    public class AnalyzeString
    {

        const int requiredLengthSizeOfString = 10;

        string stringContiner;
        bool m_isStringANumber = false;
        bool m_stringIsPalidrom = false;
        bool m_stringIsNumberDivdedByFour = false;
        int m_NumberOfLowerCaseCharsInString = 0;

        public AnalyzeString()
        {

            RunAnalyzeString();

        }
        
        public void RunAnalyzeString()
        {

            getInputFromUser();
            IsStringIsPalindrom();



            
            //IsDivdeByFour()
            //AmountOfLowerCaseCharsInString()

        }


        private void IsStringIsPalindrom()
        {
            m_stringIsPalidrom = IsPalindromRec(0, stringContiner.Length - 1);

        }

        private bool IsPalindromRec(int left, int right)
        {

            // Base case: it's palindrome
            if (left >= right)
                return true;

            // Check if characters at left and right are not equal
            if (stringContiner[left] != stringContiner[right])
                return false;

            
            return IsPalindromRec(left + 1, right - 1);

        }
        private void getInputFromUser()
        {
            Console.WriteLine("enter a 10-chars string that written by english alphabet or digits (not a combination)");
            stringContiner = Console.ReadLine();

            while (!(CheckForVaildString())){
                Console.WriteLine("String its not like instructions! try again");
                stringContiner = Console.ReadLine();
            }


        }

        private bool CheckForVaildString()
        {
            bool stringIsVaild = false;
            int counterForFullyCompleteNumber = 0;
            bool vailEnglishAlphabet = true;

            if(stringContiner.Length == requiredLengthSizeOfString)
            {
                for(int i =0; i < stringContiner.Length; i++)
                {
                    
                    if (char.IsDigit(stringContiner[i]))
                    {
                        counterForFullyCompleteNumber++;
                    }
                    else
                    {
                        if(!(stringContiner[i] >= 'a' && stringContiner[i] <= 'z'))
                        {

                            vailEnglishAlphabet = false;
                            break;

                        }
                    }
                        
                }
                if((counterForFullyCompleteNumber == requiredLengthSizeOfString) || ((counterForFullyCompleteNumber == 0) && (vailEnglishAlphabet == true)))
                {
                    if (counterForFullyCompleteNumber == requiredLengthSizeOfString)
                    {
                        m_isStringANumber = true;

                    }
                    stringIsVaild = true;
                }

            }

            return stringIsVaild;

        }
    }



   
}
