namespace B21_Ex01_5
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string userInputString;
            int    numToBeDivided = 3;
            Console.WriteLine("Hello, Please enter number with 6 digits (000005 is also valid) :");
            userInputString = TakeNumberFromTheUser();
            Console.WriteLine(string.Format("The biggest digit in input is: {0}", FindBiggestDigit(userInputString)));
            Console.WriteLine(string.Format("The smallest digit in input is: {0}", FindSmallestDigit(userInputString)));
            Console.WriteLine(string.Format("We have {0} digits that divided by {1} without residue.", HowManyDigitsDivided(userInputString, numToBeDivided), numToBeDivided));
            Console.WriteLine(string.Format("We have {0} digits that bigger than {1}.", HowManyDigitsBiggerThanNumber(userInputString, int.Parse(userInputString) % 10), int.Parse(userInputString) % 10));
        }

        public static string TakeNumberFromTheUser()
        {
            string inputFromUser = default;
            int requiredLength = 6;
            while (true)
            {
                inputFromUser = Console.ReadLine();
                if (inputFromUser.Length == requiredLength)
                {
                    if (CheckIfNumbersString(inputFromUser))
                    {
                        return inputFromUser;
                    }
                }

                Console.WriteLine("Invalid input, please enter number with 6 digits (000005 is also valid) :");
            }
        }

        public static bool CheckIfNumbersString(string inputString)
        {
            for (int index = 0; index < inputString.Length; index++)
            {
                if (char.IsDigit(inputString[index]) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static int FindBiggestDigit(string i_InputString)
        {
            int biggest = 0;
            for(int index = 0; index < i_InputString.Length; index++)
            {
                if(int.Parse(i_InputString[index].ToString()) > biggest)
                {
                    biggest = int.Parse(i_InputString[index].ToString());
                }
            }

            return biggest;
        }

        public static int FindSmallestDigit(string i_InputString)
        {
            int smallest = 9;
            for (int index = 0; index < i_InputString.Length; index++)
            {
                if (int.Parse(i_InputString[index].ToString()) < smallest)
                {
                    smallest = int.Parse(i_InputString[index].ToString());
                }
            }

            return smallest;
        }

        public static bool IsDividedByNumber(int i_Digit, int i_NumToBeDivided)
        {
            if (i_Digit % i_NumToBeDivided == 0)
            {
                return true;
            }

            return false;
        }

        public static int HowManyDigitsDivided(string i_UserInput, int i_NumToBeDivided)
        {
            int counter = 0;
            for (int index = 0; index < i_UserInput.Length; index++)
            {
                if(IsDividedByNumber(int.Parse(i_UserInput[index].ToString()), i_NumToBeDivided))
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int HowManyDigitsBiggerThanNumber(string i_InputString, int i_Number)
        {
            int counter = 0;
            for (int index = 0; index < i_InputString.Length - 1; index++)
            {
                if (int.Parse(i_InputString[index].ToString()) > i_Number)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
