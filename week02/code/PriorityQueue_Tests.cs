using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and then dequeue all.
    // Expected Result: Items should be dequeued in order of priority (highest priority first).
    // Test Result: Passed.
    // Defect(s) Found: None.
    public void TestPriorityQueue_DequeueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same priority, then dequeue.
    // Expected Result: Items with the same priority should be dequeued in FIFO order.
    // Test Result: Passed.
    // Defect(s) Found: None.
    public void TestPriorityQueue_FIFOSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Test Result: Passed.
    // Defect(s) Found: None.
    [ExpectedException(typeof(System.InvalidOperationException))]
    public void TestPriorityQueue_DequeueEmpty()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario: Enqueue items, Peek without Dequeue.
    // Expected Result: Peek should return the highest-priority item without removing it.
    // Test Result: Passed.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Peek()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Peek());  // does not remove
        Assert.AreEqual(2, priorityQueue.Count);        // still 2 in queue
    }

    [TestMethod]
    // Scenario: Enqueue items and check Count.
    // Expected Result: Count should update correctly after each enqueue and dequeue.
    // Test Result: Passed.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Count()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual(2, priorityQueue.Count);

        priorityQueue.Dequeue();
        Assert.AreEqual(1, priorityQueue.Count);

        priorityQueue.Dequeue();
        Assert.AreEqual(0, priorityQueue.Count);
    }
}
// Test class for PriorityQueue class