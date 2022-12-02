using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKI_6
{
    internal class Lab4
    {
        public static int[] lineAfter;

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
            int len = output.Length / 2;

            for (int i = 0; i < output.Length; i++)
            {
                if (i < len)
                {
                    output[i] = mas1[i];
                }
                else
                {
                    output[i] = mas2[i - len];
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
            int[] firstPartA;
            int[] secondPartA;

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

        
    }
}
