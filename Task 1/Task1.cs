using System;
using System.Collections.Generic;

public class Task1
{
    public static List<int> GetDoubledPositiveEvens(List<object> numberList)
    {
        // Error handling: make sure a list was actually passed in
        if (numberList == null)
        {
            throw new ArgumentNullException(nameof(numberList), "The number list cannot be null.");
        }

        List<int> finalList = new List<int>();

        // Go through each item in the list
        foreach (var item in numberList)
        {
            // Error handling: skip anything that is not an integer (text, null, etc.)
            if (!(item is int number))
            {
                continue;
            }

            // Check if the number is positive and even
            if (number > 0 && number % 2 == 0)
            {
                // Double the number
                int doubledNumber = number * 2;

                // Add it to the final list
                finalList.Add(doubledNumber);
            }
        }

        // Return the list of doubled positive even numbers
        return finalList;
    }

    // Example usage
    static void Main()
    {
        List<object> myNumbers = new List<object> { 1, 2, "hello", -4, 6, null, 8 };
        List<int> result = GetDoubledPositiveEvens(myNumbers);
        Console.WriteLine(string.Join(", ", result)); // Output: 4, 12, 16
    }
}