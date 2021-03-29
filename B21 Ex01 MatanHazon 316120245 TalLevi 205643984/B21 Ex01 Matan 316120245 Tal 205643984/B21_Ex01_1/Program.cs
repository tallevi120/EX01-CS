using System.Text;
using System;

namespace B21_Ex01_1
{
    /*Program class will contain our main class and all methods*/
    public class Program
    {
        public static void Main()
        {
            int           requiredLength = 7;
            int           numOfInputs = 3;
            int           number1, number2, number3;
            StringBuilder sbAllNumbers = new StringBuilder("", requiredLength * numOfInputs);
            Console.WriteLine(string.Format("Hello, Please enter {0} numbers, each number contains {1} digits in binary format:", numOfInputs, requiredLength));
            for (int index = 1; index <= numOfInputs; index++)
            {
                sbAllNumbers.Append(TakeNumberFromTheUser(requiredLength));
            }
            number1 = GetDecimalValue(sbAllNumbers.ToString().Substring(0,7));
            number2 = GetDecimalValue(sbAllNumbers.ToString().Substring(7, 7));
            number3 = GetDecimalValue(sbAllNumbers.ToString().Substring(14, 7));
            Console.WriteLine(string.Format(@"Number 1 decimal value = {0}
Number 2 decimal value = {1}
Number 3 decimal value = {2}", number1, number2, number3));
            Console.WriteLine(string.Format(@"The avarage number '0' in the all inputs = {0}
The avarage number '1' in the all inputs = {1}", CheckAvarageFromThisNumber(sbAllNumbers.ToString(), '0', numOfInputs), CheckAvarageFromThisNumber(sbAllNumbers.ToString(), '1', numOfInputs)));//what if avarage is float?
            Console.WriteLine(string.Format(@"We have {0} numbers that is power of two", HowManyIsPowerOfTwo(number1, number2, number3)));
            Console.WriteLine(string.Format(@"We have {0} numbers that is Acending", HowManyNumbersIsAcending(number1.ToString(), number2.ToString(), number3.ToString())));
            Console.WriteLine(string.Format(@"The smallest number is {0}", FindSmallestNumber(number1, number2, number3)));
            Console.WriteLine(string.Format(@"The biggest number is {0}", FindBiggestNumber(number1, number2, number3)));
        }
        public static string TakeNumberFromTheUser(int i_RequiredLength)
        {
            string io_BinaryNumber = default;
            bool i_IfInputInvalid = false;
            while(i_IfInputInvalid == false)
            {
                io_BinaryNumber = Console.ReadLine();
                i_IfInputInvalid = IsValid(io_BinaryNumber, i_RequiredLength);//Will check if all binary & length is as required
                if(i_IfInputInvalid == false)
                {
                    Console.WriteLine("Invalid input, please enter only 7 binary digits:");
                }
            }
            return io_BinaryNumber;
        }
        public static bool IsValid(string i_InputString, int i_RequiredLength)
        {
            return IsBinary(i_InputString) && CheckLength(i_InputString, i_RequiredLength);
        }
        public static bool IsBinary(string i_InputString)
        {
            foreach(char c in i_InputString)
            {
                if(c != '0' && c != '1')//If recognize one charactar that not 0 or 1, return false. ( means NOT binary)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckLength(string i_InputString, int i_RequiredLength)
        {
            return (i_InputString.Length == i_RequiredLength);//If string length is VALID as required - return true
        }
        public static int GetDecimalValue(string i_InputString)
        {
            int counter = 0;
            int exponent = 0;
            for(int index = i_InputString.Length - 1; index >= 0; index--)
            {
                counter += int.Parse(i_InputString[index].ToString()) * (int)(Math.Pow(2, exponent));
                exponent++;
            }
            return counter;
        }
        public static int CheckAvarageFromThisNumber(string i_InputString, char i_TargetToCheck, int i_NumOfInputs)
        {
            int NumberOfPerformances = CountHowManyFromThisNumber(i_InputString, i_TargetToCheck);
            return NumberOfPerformances / i_NumOfInputs;
        }
        public static int CountHowManyFromThisNumber(string i_InputString, char i_TargetToCheck)
        {
            int counter = 0;
            for(int index = 0; index < i_InputString.Length; index++)
            {
                if(i_InputString[index] == i_TargetToCheck)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int HowManyIsPowerOfTwo(int i_number1, int i_number2, int i_number3)
        {
            int counter = 0;
            if(IsPowerOfTwo(i_number1) == true)
            {
                counter++;
            }
            if(IsPowerOfTwo(i_number2) == true)
            {
                counter++;
            }
            if(IsPowerOfTwo(i_number3) == true)
            {
                counter++;
            }
            return counter;
        }
        public static bool IsPowerOfTwo(int i_NumberToCheck)
        {
            return (i_NumberToCheck & i_NumberToCheck - 1) == 0;
        }
        public static int HowManyNumbersIsAcending(string i_InputStrNum1, string i_InputStrNum2, string i_InputStrNum3)
        {
            int counter = 0;
            if(IsAcendingNumber(i_InputStrNum1) == true)
            {
                counter++;
            }
            if(IsAcendingNumber(i_InputStrNum2) == true)
            {
                counter++;
            }
            if(IsAcendingNumber(i_InputStrNum3) == true)
            {
                counter++;
            }
            return counter;
        }
        public static bool IsAcendingNumber(string i_inputStrNum)
        {
            if(i_inputStrNum.Length == 1)
            {
                return true;//check
            }
            for(int index = 0; index < i_inputStrNum.Length - 1; index++)
            {
                if(i_inputStrNum[index] >= i_inputStrNum[index + 1])
                {
                    return false;
                }
            }
            return true;
        }
        public static int FindSmallestNumber(int i_Number1, int i_Number2, int i_Number3)
        {
            int minNum =  Math.Min(i_Number1, i_Number2);
            minNum = Math.Min(minNum, i_Number3);
            return minNum;
        }
        public static int FindBiggestNumber(int i_Number1, int i_Number2, int i_Number3)
        {
            int maxNum = Math.Max(i_Number1, i_Number2);
            maxNum = Math.Max(maxNum, i_Number3);
            return maxNum;
        }
    }
}
