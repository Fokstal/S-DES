using System;

namespace ZKI_04
{
    public class Program
    {
        public static int[] lineAfter;
        public static void PrintMas(int[] mas)
        {
            foreach (var e in mas)
                Console.Write(e + " ");

            Console.WriteLine();
        }

        public static int[] TenBitMethod(int[] input)
        {
            int[] tenBit = new int[] { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
            int[] output = new int[input.Length];

            for (int i = 0; i < tenBit.Length; i++)
            {
                output[i] = input[tenBit[i] - 1];
            }

            return output;
        }

        public static int[] EightBitMethod(int[] input)
        {
            int[] eightBit = new int[] { 6, 3, 7, 4, 8, 5, 10, 9 };
            int[] output = new int[input.Length - 2];

            for (int i = 0; i < eightBit.Length; i++)
            {
                output[i] = input[eightBit[i] - 1];
            }

            return output;
        }

        public static int[] Sdfig(int[] input, int step)
        {
            int len = input.Length;
            int pos = 0;
            int[] output = new int[input.Length];

            for (int i = 0; i < len; i++)
            {
                if (i < len - step)
                {
                    pos = i + step;
                }
                else
                {
                    pos = i - len + step;
                }

                output[i] = input[pos];
            }

            return output;
        }
        public static int[] CreateAfterLine(int[] mas1, int[] mas2)
        {
            int[] output = new int[mas1.Length + mas2.Length];

            for (int i = 0; i < output.Length; i++)
            {
                if (i < 5)
                {
                    output[i] = mas1[i];
                }
                else
                {
                    output[i] = mas2[i - 5];
                }
            }

            return output;
        }
        public static int[] MainProcess(int[] input, int step)
        {
            int[] lineTenBit = TenBitMethod(input);

            int len = lineTenBit.Length / 2;
            int[] firstPartB = new int[len];
            int[] secondPartB = new int[len];
            int[] firstPartA = new int[len];
            int[] secondPartA = new int[len];

            for (int i = 0; i < len; i++)
            {
                firstPartB[i] = lineTenBit[i];
                secondPartB[i] = lineTenBit[i + 5];
            }

            firstPartA = Sdfig(firstPartB, step);
            secondPartA = Sdfig(secondPartB, step);

            lineAfter = CreateAfterLine(firstPartA, secondPartA);

            int[] output = new int[input.Length - 2];

            output = EightBitMethod(lineAfter);

            return output;
        }
        public static int[] FinalyProcess(int[] input, int step)
        { 
            int len = input.Length / 2;
            int[] firstPartB = new int[len];
            int[] secondPartB = new int[len];
            int[] firstPartA = new int[len];
            int[] secondPartA = new int[len];

            for (int i = 0; i < len; i++)
            {
                firstPartB[i] = input[i];
                secondPartB[i] = input[i + 5];
            }

            firstPartA = Sdfig(firstPartB, step);
            secondPartA = Sdfig(secondPartB, step);

            lineAfter = CreateAfterLine(firstPartA, secondPartA);

            int[] output = new int[input.Length - 2];

            output = EightBitMethod(lineAfter);

            return output;
        }
        public static void Main(string[] args)
        {
            int[] input = new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 };

            int[] k1 = MainProcess(input, 1);
            int[] k2 = FinalyProcess(lineAfter, 2);
            


            Console.Write("Key 1:   ");
            PrintMas(k1);
            Console.Write("Key 2:   ");
            PrintMas(k2);
        }
    }
}