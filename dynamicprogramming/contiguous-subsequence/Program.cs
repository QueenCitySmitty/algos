using System;
using System.Text;

namespace contiguous_subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] {5, 15, -30, 10, -5, 40, 10};

            WriteArray("input", input);

            var result = ContiguousSubsequence(input);

            WriteArray("result", result);

            var expected = new int[] {10, -5, 40, 10};

            WriteArray("expected", expected);

            for(int i = 0; i < expected.Length; ++i)
            {
                if(result[i] != expected[i])
                {
                    throw new Exception();
                }
            }
        }

        public static int[] ContiguousSubsequence(int[] input)
        {
            // idea: if the current position + the last position is greater than just the current position,
            // then add the current to the last.

            // variable declarations.
            var maxSubArrVals = new int[input.Length];
            var sizeOfSubarray = new int[input.Length];

            maxSubArrVals[0] = input[0] >= 0 ? input[0] : 0;
            sizeOfSubarray[0] = input[0] >= 0 ? 1 : 0;

            var maxValIndex = 0;

            // fill arrays.
            for (int i = 1; i < input.Length; ++i)
            {
                var currVal = input[i];
                var prevSubArrVal = maxSubArrVals[i - 1];

                maxSubArrVals[i] = currVal + (prevSubArrVal > 0 ? prevSubArrVal : 0);
                sizeOfSubarray[i] = maxSubArrVals[i] == input[i] ? 1 : sizeOfSubarray[i - 1] + 1;

                maxValIndex = (maxSubArrVals[maxValIndex] >= maxSubArrVals[i]) ? maxValIndex : i;
            }

            var retArr = new int[sizeOfSubarray[maxValIndex]];
            var startingNdx = maxValIndex - retArr.Length + 1;

            for(int j = 0; j < retArr.Length; ++j)
            {
                retArr[j] = input[j + startingNdx];
            }

            return retArr;
        }

        private static void WriteArray(string identifier, int[] input)
        {
            var sb = new StringBuilder();
            sb.Append($"{identifier}: ");
            sb.AppendJoin(", ", input);
            Console.WriteLine(sb.ToString());
        }
    }
}
