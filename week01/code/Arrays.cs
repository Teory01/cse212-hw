public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // PLAN:
        // 1. Create a new array of doubles with the size equal to "length".
        // 2. Use a for loop to fill in the array.
        //    - Start the loop index at 0 and go until length - 1.
        //    - At each index i, calculate the multiple as number * (i + 1).
        //      (i + 1 is used because when i = 0, the first element should be number itself, not 0).
        //    - Assign this value to the array at position i.
        // 3. After the loop finishes, return the array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
         
        // PLAN:
        // 1. Understand what "rotating right" means: the last 'amount' of elements
        //    in the list should move to the front, while the rest shift to the right.
        //
        // 2. Steps to achieve this:
        //    a) Use GetRange to extract the last 'amount' elements from the list.
        //       Example: if data = {1,2,3,4,5,6,7,8,9} and amount = 3,
        //       then we extract {7,8,9}.
        //
        //    b) Remove those last 'amount' elements from the original list.
        //       After removal, data = {1,2,3,4,5,6}.
        //
        //    c) Insert the extracted elements at the beginning (index 0).
        //       Final result = {7,8,9,1,2,3,4,5,6}.
        //
        // 3. This modifies the original list directly (as required).

        // Step a: get the last "amount" elements
        List<int> lastPart = data.GetRange(data.Count - amount, amount);

        // Step b: remove the last "amount" elements
        data.RemoveRange(data.Count - amount, amount);

        // Step c: insert the extracted part at the front
        data.InsertRange(0, lastPart);
    }
}
    

