using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities and remove one item.
    // Expected Result: The item with the highest priority is returned.
    // Defect(s) Found:
    // The last item in the queue was not checked when searching for the highest priority.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The item closest to the front of the queue (FIFO) is returned first.
    // Defect(s) Found:
    // The code returned the last item with the highest priority instead of the first.
    public void TestPriorityQueue_FIFOWithSamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Remove an item and verify it is no longer in the queue.
    // Expected Result: The item is removed and the next dequeue reflects the updated queue.
    // Defect(s) Found:
    // The dequeued item was returned but not removed from the queue.
    public void TestPriorityQueue_ItemRemoved()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with the message
    // "The queue is empty."
    // Defect(s) Found:
    // None.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Assert.Fail(
                string.Format(
                    "Unexpected exception of type {0} caught: {1}",
                    ex.GetType(),
                    ex.Message));
        }
    }
}