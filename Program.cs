using System;
using System.Collections.Generic;

namespace Counting
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = 1692; // default input number ; 
            if (args.Length > 0)
            {
                inputNumber = CheckInputArgs(args);
                if (inputNumber == -1)
                    return;
            }

            Dictionary<int, int> countedNumbers = new Dictionary<int, int>();
            // init dictionary 
            for (int j = 0; j < 10; j++)
                countedNumbers.Add(j, 0);

            CheckNumberCount(inputNumber, countedNumbers);
        }

        private static void CheckNumberCount(int inputNumber, Dictionary<int, int> countedNumbers)
        {
            int prevValue = inputNumber;

            if (inputNumber == 0)
            {
                // zero check is sufficient , 
                //as any number multiplied by an increasing number will eventually contain all the numbers from 0-9
                Console.WriteLine("INSOMNIA");
                return;
            }


            for (int i = 1; ; i++)
            {
                var countingNumber = inputNumber * i;

                var numbers = Slice(countingNumber);

                for (int l = 0; l < numbers.Length; l++)
                    countedNumbers[numbers[l]]++;

                bool isAsleep = true;
                for (int k = 0; k < 10; k++)
                {
                    if (countedNumbers[k] == 0)
                        isAsleep = false;
                }
                if (isAsleep)
                {
                    Console.WriteLine("asleep when : {0} ios reached", + i * inputNumber );
                    return;
                }
            }
        }

        private static int CheckInputArgs(string[] args )
        {
            int inputNumber;
            if (!int.TryParse(args[0], out inputNumber) || inputNumber < 0 || (inputNumber > 10000000))
            {
                Console.WriteLine("invalid num or invalid num of arguements");
                return -1;
            }
            else
                return inputNumber;
        }

        private static int[] Slice(int num)
        {
            List<int> numbers = new List<int>();
            while (num > 0)
            {
                var remainder = num % 10;
                num = num / 10;
                numbers.Add(remainder);
            }
            return numbers.ToArray();
        }
    }
}
