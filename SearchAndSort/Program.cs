using System;

namespace SearchAndSort
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] inputArray = new int[100];
           int i;
           MainLoop();///Just a wrapper so we can have a never ending loop when a user finishes with one input and wants to start again
          void MainLoop()
          {
             InputNumbers();
             Console.WriteLine("To start again press Y , otherwise type anything else...");
             var x = Console.ReadLine();
             if (x == "Y" | x == "y") MainLoop();
             else Environment.Exit(1);
          }

          void InputNumbers()////Input number array and redirect to main function
          {
              Console.WriteLine("Please type your inputs segregated by PRESSING ENTER. \nOnce finished write START to start the search menu!\n");
              i = 0;
              inputArray = new int[100];
              while (true)
              {
                  var input = Console.ReadLine();
                  if (input.Equals("START", StringComparison.OrdinalIgnoreCase))
                  {
                      break;
                  }
                  inputArray[i] = int.Parse(input);
                  i++;
              }
              MainFunction(inputArray, i);
          }
          static void MainFunction(int[] inputArray, int i)//all the logic here
          {
              Console.WriteLine("Choose the number for the function you wish to use:\n");
              Console.WriteLine("1.SORTING\n2.SEARCHING");
              var function = Console.ReadLine();
              if (function == "1")
              {
                  Console.WriteLine("Choose the number for the  Sorting algorithm you wish to use:\n");
                  Console.WriteLine("1.BUBBLE SORT\n2.QUICKSORT\n3.MERGE SORT");
                  var sortingAlgorithm = Console.ReadLine();
                  if (sortingAlgorithm == "1")
                  {
                      int temp;
                      for (int j = 0; j <= i - 2; j++)
                      {
                          for (int c = 0; c <= i - 2; c++)
                          {
                              if (inputArray[c] > inputArray[c + 1])
                              {
                                  temp = inputArray[c + 1];
                                  inputArray[c + 1] = inputArray[c];
                                  inputArray[c] = temp;
                              }
                          }
                      }
                      Console.WriteLine("Sorted:");
                      int counter = 0;
                      foreach (int p in inputArray)
                      {

                          if (p != null) Console.Write(p + " ");
                          if (counter == i - 1) break;
                          counter++;
                      }

                  }
                  else if (sortingAlgorithm == "2")
                  {
                      quickSort(inputArray, 0, i - 1);
                      Console.Write("\nSorted Array is: ");
                      for (int j = 0; j < i; j++)
                      {
                          Console.Write(inputArray[j] + " ");
                      }
                  }
                  else if (sortingAlgorithm == "3")
                  {
                      int counter = 0;
                      var sortArray = SortArray(inputArray, 0, i - 1);
                      foreach (int p in inputArray)
                      {

                          if (p != null) Console.Write(p + " ");
                          if (counter == i - 1) break;
                          counter++;
                      }

                  }
              }
              else if (function == "2")
              {
                  Console.WriteLine("Choose the number for the search algorithm you wish to use:\n");
                  Console.WriteLine("1.LINEAR SEARCH\n2.BINARY SEARCH");
                  var searchAlgorithm = Console.ReadLine();
                  if (searchAlgorithm == "1")
                  {
                      Console.WriteLine("Enter a value to search: ");
                      int n = Int32.Parse(Console.ReadLine());
                      int result = LinearSearch(inputArray, n);
                      if (n != -1)
                          Console.WriteLine("The target value " + n + " is found at position " + result);
                      else
                          Console.WriteLine("Target not found!");

                  }
                  else if (searchAlgorithm == "2")
                  {
                      Console.WriteLine("Enter a value to search: ");
                      int n = Int32.Parse(Console.ReadLine());
                      int result = search_value(inputArray, n, i);
                      if (result != -1)
                          Console.WriteLine("The target value " + n + " is found at position " + (result - 1));
                      else
                          Console.WriteLine("Target not found!");
                  }

              }

          }
        }
       

            
           
      
        #region quickSort
        static private int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(arr, pivot + 1, right);
                }
            }
        }
        #endregion
        #region mergeSort
        public static int[] SortArray(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortArray(array, left, middle);
                SortArray(array, middle + 1, right);
                MergeArray(array, left, middle, right);
            }
            return array;
        }
        public static void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
        #endregion
        #region search
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (target == arr[i])
                    return (i + 1);
            }
            return -1;
        }
        public static int search_value(int[] arr, int target,int i)
        {
            int low, high, mid;
            low = 0;
            high = (i-1) - 1;
            mid = (low + high) / 2;
            while (low <= high)
            {
                if (arr[mid] == target)
                    return mid + 1;
                else
                    if (target < arr[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
                mid = (low + high) / 2;
            }
            return -1;
        }
        #endregion
    }

}
