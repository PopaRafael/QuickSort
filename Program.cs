using System;

namespace QuickSort
{
    class Program
    {
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition the array and get the pivot index.
                int pivotIndex = Partition(arr, low, high);

                // Recursively sort the sub-arrays on both sides of the pivot.
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            // Choose the rightmost element as the pivot.
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                // If the current element is smaller or equal to the pivot, swap arr[i] and arr[j].
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            // Swap arr[i + 1] and arr[high] (the pivot).
            Swap(arr, i + 1, high);

            // Return the index of the pivot element.
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Main(string[] args)
        {
            // Define the array size and random number range.
            int arraySize = 10;
            int minValue = 10;
            int maxValue = 1000;

            // Generate the random array.
            int[] randomArray = GenerateRandomArray(arraySize, minValue, maxValue);

            // Print the generated array.
            Console.WriteLine("Generated Array:");
            foreach (int num in randomArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Print the sorted array.
            Console.WriteLine("Sorted Array:");
            QuickSort(randomArray, 0, arraySize - 1);
            foreach (int num in randomArray)
            {
                Console.Write(num + " ");
            }
        }
        static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] randomArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue + 1);
            }

            return randomArray;
        }
    }
}
