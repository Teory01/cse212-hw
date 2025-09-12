using System.Diagnostics;

/// <summary>
/// A static class containing different search algorithms and a method to run performance comparisons.
/// </summary>
public static class Search {
    /// <summary>
    /// Main execution method that runs the comparison between two search algorithms.
    /// It displays a formatted table showing the performance metrics of both algorithms.
    /// </summary>
    public static void Run() {
        // Print header row with column names
        // Format: n, sort1-count, sort2-count, sort1-time, sort2-time
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}", "n", "sort1-count", "sort2-count", "sort1-time",
            "sort2-time");
        // Print separator line for the table
        // Each column is separated by 10 dashes
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n <= 25000; n += 1000) {
            var testData = Enumerable.Range(0, n).ToArray();
            // Create test data array with size n
            int count1 = SearchSorted1(testData, n);
            int count2 = SearchSorted2(testData, n, 0, testData.Length - 1);
            double time1 = Time(() => SearchSorted1(testData, n), 100);
            double time2 = Time(() => SearchSorted2(testData, n, 0, testData.Length - 1), 100);
            // Time both algorithms by executing them 100 times each
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15:0.00000}{4,15:0.00000}", n, count1, count2, time1, time2);
        }
            // Print results for current n value
            // Format: n, count1, count2, time1 (5 decimal places), time2 (5 decimal places)
    }

    private static double Time(Action executeAlgorithm, int times) {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i) {
            executeAlgorithm();
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// Search for 'target' in the list 'data'. When its found (or not found) the variable count which represents
    /// the work done in the function is returned.
    /// </summary>
    /// <param name="data">The array of numbers</param>
    /// <param name="target">The number we're looking for</param>
    private static int SearchSorted1(int[] data, int target) {
        var count = 0;
        foreach (var item in data) {
            count += 1;
            if (item == target)
                return count; // Found it
        }

        return count; // Didn't find it
    }

    /// <summary>
    /// Search for 'target' in the list 'data'. When its found (or not found) the variable count which represents
    /// the work done in the function is returned.
    /// </summary>
    /// <param name="data">The array of numbers</param>
    /// <param name="target">The number we're looking for</param>
    /// <param name="start">The index of the starting section of the data to look in</param>
    /// <param name="end">The index of the ending section of the data to look in</param>
    private static int SearchSorted2(int[] data, int target, int start, int end) {
        if (end < start)
            return 1; // All done
        var middle = (end + start) / 2;
        if (data[middle] == target)
            return 1; // Found it
        if (data[middle] < target) // Search in the upper half after index middle
            return 1 + SearchSorted2(data, target, middle + 1, end);
        // Search in the lower half before index middle
        return 1 + SearchSorted2(data, target, start, middle - 1);
    }
}