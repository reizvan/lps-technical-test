## 1

```csharp
return application?.Protected?.ShieldLastRun;
```
Using the null conditional operator (?.) to improve the readability and cleanliness of the code safely access nested properties without worrying about null reference exceptions.

## 2

```csharp
public (string Path, string Name) GetInfo()
{
    var application = new ApplicationInfo
    {
        Path = "C:/apps/",
        Name = "Shield.exe"
    };
    return (application.Path, application.Name);
}
```
The GetInfo() method returns a tuple containing two strings: the application's path and its name. Tuples are generally considered more modern and readable, especially for returning multiple values.

## 3

```csharp
class Laptop
{
    private string _os; // private member

    public Laptop(string os)
    {
        _os = os;
    }

    public string GetOs() // public method to retrieve the value
    {
        return _os;
    }
}
```

### Explanation
Make a private member and provide a public method to retrieve its value to ensure encapsulation and better control over access to the Os property.

## 4

```csharp
while (true)
{               
     ...
     Console.WriteLine(myList.Count);
     myList.Clear(); // Clear the list to release memory
}
```

### Explanation
Memory leak can occur because the myList object keeps growing indefinitely due to the while (true) loop. The list is continuously populated with new Product objects, but there is no mechanism to remove or dispose of the old objects. Clear the list to address this issue after performing operations on it to release the memory occupied by the old objects.

## 5

1. Memory Leak Potential: While(true) loop continuously creates new instances of EventSubscriber without ever disposing.
2. Inefficient Event Handling: The EventPublisher class's RaiseEvent method invokes the event directly. This exposes the event directly to outside callers.

```csharp
using System;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new EventPublisher();
            var subscriber = new EventSubscriber(publisher);
            
            while (true)
            {
                // Do something with the publisher and subscriber objects
                // For demonstration purposes, let's just sleep for a short while
                System.Threading.Thread.Sleep(1000);
            }
        }
    }

    class EventPublisher
    {
        public event EventHandler MyEvent;

        protected virtual void OnMyEvent(EventArgs e)
        {
            MyEvent?.Invoke(this, e);
        }

        public void RaiseEvent()
        {
            OnMyEvent(EventArgs.Empty);
        }
    }

    class EventSubscriber : IDisposable
    {
        private readonly EventPublisher _publisher;

        public EventSubscriber(EventPublisher publisher)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            _publisher.MyEvent += OnMyEvent;
        }

        private void OnMyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("MyEvent raised");
        }

        public void Dispose()
        {
            _publisher.MyEvent -= OnMyEvent;
        }
    }
}

```

### Explanation
1. Disposing EventSubscribers: Introduced IDisposable interface to the EventSubscriber class, allowing proper disposal of the subscriber and unsubscribing from events when the instance is no longer needed.
2. Improved Event Handling: Used a protected virtual method (OnMyEvent) to invoke the event within the EventPublisher class. This follows the best practice of encapsulating event invocation within the class.

## 6
```csharp
using System;
using System.Collections.Generic;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var rootNode = new TreeNode();
                CreateSubtree(rootNode);
                Console.WriteLine("Object graph created.");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void CreateSubtree(TreeNode rootNode)
        {
            for (int i = 0; i < 100; i++) // Limiting to 100 iterations for demonstration
            {
                var newNode = new TreeNode();
                for (int j = 0; j < 100; j++) // Limiting to 100 nodes per level for demonstration
                {
                    var childNode = new TreeNode();
                    newNode.AddChild(childNode);
                }
                rootNode.AddChild(newNode);
            }
        }
    }

    class TreeNode
    {
        private readonly List<TreeNode> _children = new List<TreeNode>();

        public void AddChild(TreeNode child)
        {
            _children.Add(child);
        }
    }
}
```

### Explanation
1. Large Object Graph: Each TreeNode has a list of children (_children). If the loop continues indefinitely, it will keep adding more and more TreeNode objects to the list, creating a large and potentially unbounded object graph.
2. Limited Object Creation: Limited the number of iterations in the loops to create a smaller object graph for demonstration purposes. 
   
## 7

```csharp
using System;
using System.Collections.Generic;

class Cache
{
    private static Dictionary<int, object> _cache = new Dictionary<int, object>();

    public static void Add(int key, object value)
    {
        if (!_cache.ContainsKey(key))
        {
            _cache.Add(key, value);
        }
        else
        {
            // Handle key collision appropriately, e.g., update existing value or throw an exception
            throw new ArgumentException("An item with the same key already exists in the cache.");
        }
    }

    public static bool TryGetValue(int key, out object value)
    {
        return _cache.TryGetValue(key, out value);
    }

    // Additional methods for eviction, expiration, etc. can be added here
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            PopulateCache();
            Console.WriteLine("Cache populated");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.ReadLine();
    }

    static void PopulateCache()
    {
        for (int i = 0; i < 1000000; i++)
        {
            Cache.Add(i, new object());
        }
    }
}

```

### Explanation
1. Error Handling: Error handling has been added to catch any potential exceptions when adding items to the cache, such as when a key already exists.
2. Addition of TryGetValue Method: Added a TryGetValue method to the Cache class to safely retrieve values from the cache without throwing exceptions if the key does not exist.
3. Separation of Concerns: Created a PopulateCache method to handle populating the cache, improving readability and maintainability of the Main method.

## 8
### Acceptence Criteria
1. Upload document byte[] to the database.
2. Validate xlsx and pdf documents.
3. Implement registration feature.
4. Authenticate user uploads as CUSTMER role.
5. Implement password criteria validation.
6. Send notification email upon successful upload.
7. Implement document size limit for uploading.
8. Implement upload as chunk method.
9. Allow viewing list of documents for users with BUSINESS UNIT role.
10. Implement document download feature.
