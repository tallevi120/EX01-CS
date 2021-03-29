using System;
namespace B21_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            int     heightForHourglass;
            Console.WriteLine(string.Format("Hello, Please enter integer number for the height of the hourglass :"));
            heightForHourglass = TakeNumberFromTheUser();
            B21_Ex01_2.Program.PrintHourglass(heightForHourglass);
        }
        public static int TakeNumberFromTheUser()
        {
            int    heightForHourglass = default;
            string inputFromUser = default;
            bool   i_IfInputInvalid = false;
            while(i_IfInputInvalid == false)
            {
                inputFromUser = Console.ReadLine();
                i_IfInputInvalid = int.TryParse(inputFromUser, out heightForHourglass);
                if(i_IfInputInvalid == false)
                {
                    Console.WriteLine("Invalid input, please enter only integer :");
                }
            }
            if (CheckIfDouble(heightForHourglass))
            {
                heightForHourglass--;
            }
            return heightForHourglass;
        }
        public static bool CheckIfDouble(int i_InputNumber)
        {
            return (i_InputNumber % 2) == 0;
        }
    }
}
