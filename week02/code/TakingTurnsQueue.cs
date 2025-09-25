/// <summary>
/// This queue is circular.  When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO).  When GetNextPerson is called, the next person
/// in the queue is returned and then placed back at the end unless they are out of turns.
/// A turns value of 0 or less means infinite turns. If a person runs out of turns, 
/// they are not added back.
/// </summary>
/// <summary>
/// A class that manages a queue of people taking turns, with each person having a specified number of turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();
    private Person _currentPerson;  // keep track of whose turn it is

    public int Length => _people.Length + (_currentPerson != null ? 1 : 0);

    /// <summary>
    /// Adds a new person to the queue with specified name and number of turns
    /// </summary>
    /// <param name="name">The name of the person to be added</param>
    /// <param name="turns">The number of turns allocated to the person</param>
    public void AddPerson(string name, int turns)
    {
        // Create a new Person object with the provided name and turns
        var person = new Person(name, turns);
        // Enqueue the person object into the people queue
        _people.Enqueue(person);
    }

    /// <summary>
    /// Retrieves the next person in the queue, managing their turns and queue rotation
    /// </summary>
    /// <returns>The next Person object to be processed</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty</exception>
    public Person GetNextPerson()
    {
        // If there's no current person, get the next from the queue
        if (_currentPerson == null)
        {
            if (_people.IsEmpty())
                throw new InvalidOperationException("No one in the queue.");

            _currentPerson = _people.Dequeue();
        }

        Person result = _currentPerson;

        // If finite turns, decrement
        if (_currentPerson.Turns > 0)
            _currentPerson.Turns--;

        // If they’re out of turns, move on
        if (_currentPerson.Turns == 0)
        {
            _currentPerson = null;
        }
        else if (_currentPerson.Turns > 0 || _currentPerson.Turns <= 0)
        {
            // infinite or still has turns left → stay current
        }

        // If currentPerson became null, rotate queue
        if (_currentPerson == null && !_people.IsEmpty())
        {
            _currentPerson = _people.Dequeue();
        }

        return result;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
