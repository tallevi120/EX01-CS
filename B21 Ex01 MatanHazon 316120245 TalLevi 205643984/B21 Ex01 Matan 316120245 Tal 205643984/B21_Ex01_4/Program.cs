namespace B21_Ex01_4
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string userInputString;
            string typeOfString;
            int numToBeDivided = 4;
            Console.WriteLine("Hello, Please enter string with 10 characters, only digits or only letters :");
            userInputString = TakeNumberFromTheUser(out typeOfString);
            Console.WriteLine(string.Format("The input is a polindrom ? {0}", IsPolindrom(userInputString, 0, userInputString.Length - 1)));
            if(typeOfString == "Numbers")
            {
                Console.WriteLine(string.Format("The input divided by {0} without residue ? {1}", numToBeDivided, IsDividedByNumber(userInputString, numToBeDivided)));
            }

            if(typeOfString == "Letters")
            {
                Console.WriteLine(string.Format("We have {0} uppercase letters in our input.", HowManyUppercase(userInputString)));
            }
        }

        public static string TakeNumberFromTheUser(out string typeOfString)
        {
            string inputFromUser = default;
            int    requiredLength = 10;
            while (true)
            {
                inputFromUser = Console.ReadLine();
                if(inputFromUser.Length == requiredLength)
                {
                    if (CheckIfLettersString(inputFromUser))
                    {
                        typeOfString = "Letters";
                        return inputFromUser;
                    }

                    if (CheckIfNumbersString(inputFromUser))
                    {
                        typeOfString = "Numbers";
                        return inputFromUser;
                    }
                }

                Console.WriteLine("Invalid input, please enter string with 10 characters, only digits or only letters :");
            }
        }

        public static bool CheckIfLettersString(string inputString)
        {
            for (int index = 0; index < inputString.Length; index++)
            {
                if (char.IsLetter(inputString[index]) == false)
                {
                    return false;
                }
            }

            return true;
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

        public static bool IsPolindrom(string inputString, int start, int end)
        {
            if(start >= end)
            {
                return true;
            }

            if(inputString[start] == inputString[end])
            {
                return IsPolindrom(inputString, ++start, --end);
            }

            return false;
        }

        public static bool IsDividedByNumber(string i_UserInputString, int i_NumToBeDivided)
        {
            if (long.Parse(i_UserInputString) % i_NumToBeDivided == 0)
            { 
                return true;
            }

            return false;
        }

        public static int HowManyUppercase(string i_UserInputString)
        {
            int counter = 0;
            for (int index = 0; index < i_UserInputString.Length; index++)
            {
                if (char.IsUpper(i_UserInputString[index])) 
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
