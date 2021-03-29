using System;
namespace B21_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            int height = 5;
            PrintHourglass(height);
        }
        public static void PrintHourglass(int i_HeightOfHourglass, int i_NumOfSpaces = 0)
        {
            if(i_HeightOfHourglass > 0)
            {
                PrintLineInHourglass(i_HeightOfHourglass, i_NumOfSpaces);
                if (i_HeightOfHourglass != 1)
                {
                    PrintHourglass(i_HeightOfHourglass - 2, i_NumOfSpaces + 1);
                    PrintLineInHourglass(i_HeightOfHourglass, i_NumOfSpaces);
                }
            }
        }
        public static void PrintLineInHourglass(int i_HeightOfHourglass, int i_NumOfSpaces = 0)
        {
            int sizeOfLine = i_HeightOfHourglass;
            while (i_NumOfSpaces != 0)
            {
                Console.Write(" ");
                i_NumOfSpaces--;
            }
            while (sizeOfLine != 0)
            {
                Console.Write("*");
                sizeOfLine--;
            }
            Console.Write("\n");
        }
    }
}
