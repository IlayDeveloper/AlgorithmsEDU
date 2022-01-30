using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = ReadInput();
            var parsedInput = ConvertToIntArray(input);
            BublSorting(parsedInput);

            string result = "";

            for (int i = 0; i < parsedInput.Length; i++)
            {
                result += parsedInput[i].ToString();
            }
            
            WriteOutput(result);
        }

        private static string ReadInput()
        {
            const int maxBufferSize = 100;

            var inputStream = Console.OpenStandardInput();

            var inputBytes = new byte[maxBufferSize];

            int readedBytes = 0;
            var inputData = "";

            do
            {
                readedBytes = inputStream.Read(inputBytes, 0, maxBufferSize);
                inputData += Encoding.UTF8.GetString(inputBytes, 0, readedBytes);
            } while (readedBytes == maxBufferSize);

            return inputData;
        }

        private static void WriteOutput(string answer)
        {
            var outputStream = Console.OpenStandardOutput();
            var bytes = Encoding.UTF8.GetBytes(answer);
            outputStream.Write(bytes, 0, bytes.Length);
        }

        private static int[] ConvertToIntArray(string data)
        {
            //var input = "12\n321\n321";
            var lines = data.Split('\n');
            var digitsArray = new int[lines.Length];
            
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
                Int32.TryParse(lines[i], out var digit);
                digitsArray[i] = digit;
            }

            return digitsArray;
        }

        private static void BublSorting(int[] array)
        {
            var sortedCounter = 0;

            do
            {
                sortedCounter = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i + 1] <= array[i]) continue;

                    array[i + 1] = array[i + 1] + array[i];

                    array[i] = array[i + 1] - array[i];
                    array[i + 1] = array[i + 1] - array[i];

                    sortedCounter++;
                }
            } while (sortedCounter > 0);
        }
    }
}