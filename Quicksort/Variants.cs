namespace Algorithms
{
    public class Quicksort
    {
        public static int Swaps = 0;
        private static int PartitionRandom(int[] array, int lowIndex, int highIndex, int pivot)
        {
            int leftPointer = lowIndex;
            int rightPointer = highIndex;

            while (leftPointer < rightPointer)
            {
                while (array[leftPointer] <= pivot && leftPointer < rightPointer)
                {
                    leftPointer++;
                }

                while (array[rightPointer] >= pivot && leftPointer < rightPointer)
                {
                    rightPointer--;
                }

                (array[leftPointer], array[rightPointer]) = (array[rightPointer], array[leftPointer]);
            }

            if (array[leftPointer] > array[highIndex])
            {
                (array[leftPointer], array[highIndex]) = (array[highIndex], array[leftPointer]);
            }
            else
            {
                leftPointer = highIndex;
            }

            return leftPointer;
        }

        private static int PartitionMedian(int[] array, int leftIndex, int rightIndex)
        {
            int pivot = array[(int)Math.Ceiling((double)leftIndex + rightIndex) / 2];

            while (leftIndex <= rightIndex)
            {
                while (array[leftIndex] < pivot)
                {
                    leftIndex++;
                }

                while (array[rightIndex] > pivot)
                {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex)
                {
                    (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
                    leftIndex++;
                    rightIndex--;
                    Swaps++;
                }
            }

            return leftIndex;
        }

        public static int[] RandomPivot(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex >= highIndex)
            {
                return array;
            }

            int pivotIndex = new Random().Next(highIndex - lowIndex) + lowIndex;
            int pivot = array[pivotIndex];

            (array[pivotIndex], array[highIndex]) = (array[highIndex], array[pivotIndex]);

            int leftPointer = PartitionRandom(array, lowIndex, highIndex, pivot);

            RandomPivot(array, lowIndex, leftPointer - 1);
            RandomPivot(array, leftPointer + 1, highIndex);

            return array;
        }

        public static int[] FirstPivot(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex + 1;
            int j = rightIndex;
            int pivot = leftIndex;

            while (i <= j)
            {
                while (i <= rightIndex && array[i] <= array[pivot])
                {
                    i++;
                }

                while (array[j] > array[pivot])
                {
                    j--;
                }

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    Swaps++;
                }
            }

            (array[j], array[pivot]) = (array[pivot], array[j]);

            if (leftIndex < j - 1)
            {
                LastPivot(array, leftIndex, j - 1);
            }

            if (j + 1 < rightIndex)
            {
                LastPivot(array, j + 1, rightIndex);
            }

            return array;
        }

        public static int[] MedianPivot(int[] array, int leftIndex, int rightIndex)
        {
            int partitionIndex = PartitionMedian(array, leftIndex, rightIndex);

            if (leftIndex < partitionIndex - 1)
            {
                MedianPivot(array, leftIndex, partitionIndex - 1);
            }

            if (partitionIndex < rightIndex)
            {
                MedianPivot(array, partitionIndex, rightIndex);
            }

            return array;
        }

        public static int[] LastPivot(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex - 1;
            int pivot = rightIndex;

            while (i <= j)
            {
                while (array[i] < array[pivot])
                {
                    i++;
                }

                while (j >= leftIndex && array[j] >= array[pivot])
                {
                    j--;
                }

                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    Swaps++;
                }
            }

            (array[i], array[pivot]) = (array[pivot], array[i]);

            if (leftIndex < i - 1)
            {
                LastPivot(array, leftIndex, i - 1);
            }

            if (i + 1 < rightIndex)
            {
                LastPivot(array, i + 1, rightIndex);
            }

            return array;
        }
    }
}