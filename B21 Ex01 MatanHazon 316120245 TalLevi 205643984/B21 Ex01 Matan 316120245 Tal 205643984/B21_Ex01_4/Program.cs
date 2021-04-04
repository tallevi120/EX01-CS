namespace B21_Ex01_04
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string userInputString;
            string typeOfString;
            int    numToBeDivided = 4;
            bool   isDividedByNumberResult;
            Console.WriteLine("Hello, Please enter string with 10 characters, only digits or only letters :");
            TakeNumberFromTheUser(out typeOfString, out userInputString);
            Console.WriteLine(string.Format("The input is a polindrom ? {0}", 
                IsPolindrom(userInputString, 0, userInputString.Length - 1)));
            if(typeOfString == "Numbers")
            {
                IsDividedByNumber(userInputString, numToBeDivided, out isDividedByNumberResult);
                Console.WriteLine(string.Format("The input divided by {0} without residue ? {1}", 
                    numToBeDivided, isDividedByNumberResult));
            }

            if(typeOfString == "Letters")
            {
                Console.WriteLine(string.Format("We have {0} uppercase letters in our input.", HowManyUppercase(userInputString)));
            }
        }

        public static void TakeNumberFromTheUser(out string o_TypeOfString, out string o_NumberFromTheUser)
        {
            string inputFromUser = default;
            int    requiredLength = 10;
            bool   checkIfLettersStringResult = default;
            bool   checkIfNumbersString = default;
            while(true)
            {
                o_NumberFromTheUser = default;
                inputFromUser = Console.ReadLine();
                if(inputFromUser.Length == requiredLength)
                {
                    CheckIfLettersString(inputFromUser, out checkIfLettersStringResult);
                    if(checkIfLettersStringResult)
                    {
                        o_TypeOfString = "Letters";
                        o_NumberFromTheUser = inputFromUser;
                        break;
                    }

                    CheckIfDigitsString(inputFromUser, out checkIfNumbersString);
                    if(checkIfNumbersString)
                    {
                        o_TypeOfString = "Numbers";
                        o_NumberFromTheUser = long.Parse(inputFromUser).ToString();
                        break;
                    }
                }

                Console.WriteLine("Invalid input, please enter string with 10 characters, only digits or only letters :");
            }
        }

        public static void CheckIfLettersString(string i_InputString, out bool o_IfString)
        {
            o_IfString = true;
            for(int index = 0; index < i_InputString.Length; index++)
            {
                if(char.IsLetter(i_InputString[index]) == false)
                {
                    o_IfString = false;
                }
            }
        }

        public static void CheckIfDigitsString(string i_InputString, out bool o_IfNumber)
        {
            o_IfNumber = true;
            for(int index = 0; index < i_InputString.Length; index++)
            {
                if(char.IsDigit(i_InputString[index]) == false)
                {
                    o_IfNumber = false;
                }
            }
        }

        public static bool IsPolindrom(string i_InputString, int i_Start, int i_End)
        {
            if(i_Start >= i_End)
            {
                return true;
            }

            if(i_InputString[i_Start] == i_InputString[i_End])
            {
                return IsPolindrom(i_InputString, ++i_Start, --i_End);
            }

            return false;
        }

        public static void IsDividedByNumber(string i_UserInputString, int i_NumToBeDivided, out bool o_IfDivided)
        {
            o_IfDivided = false;
            if(long.Parse(i_UserInputString) % i_NumToBeDivided == 0)
            {
                o_IfDivided = true;
            }
        }

        public static int HowManyUppercase(string i_UserInputString)
        {
            int counter = 0;
            for(int index = 0; index < i_UserInputString.Length; index++)
            {
                if(char.IsUpper(i_UserInputString[index])) 
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
