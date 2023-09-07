
SingleLinkedList<int> linkedList = new();
linkedList.AddLast(10);
linkedList.AddLast(20);
linkedList.AddLast(30);
linkedList.AddLast(40);

foreach(int item in linkedList)
{
    Console.WriteLine(item);
}

DoubleLinkedList<int> doubleLinkedList= new();
doubleLinkedList.AddLast(10);
doubleLinkedList.AddLast(20);
doubleLinkedList.AddLast(30);
doubleLinkedList.AddLast(40);

foreach(int item in doubleLinkedList)
{
    Console.WriteLine(item);
}


public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}

public sealed class SingleLinkedList<T> : IEnumerable<T>
{
    public Node<T>? Head { get; set; }
    public int Count { get; set; }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? thisNode = Head;
        while (thisNode is not null)
        {
            yield return thisNode.Value;
            thisNode = thisNode.Next;
        }
    }

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
	}

    public void AddFirst(T item)
    {
        Node<T> newHeadNode = new(item);

        if (Head is null)
        {
            Head = newHeadNode;
        }
        else
        {
            newHeadNode.Next = Head;
            Head = newHeadNode;
        }

        Count++;
    }

    public void AddLast(T item)
    {
        Node<T> newLastNode = new(item);
        if (Head is null)
        {
            Head = newLastNode;
            return;
        }

        Node<T> lastNode = GetLastNode();
        lastNode.Next = newLastNode;

        Count++;
    }

    private Node<T> GetLastNode()
    {
        Node<T> lastNode = Head;

        while(lastNode.Next is not null)
        {
            lastNode = lastNode.Next;
        }

        return lastNode;
    }
}







public class Node2<T>
{
    public T Value { get; set; }
    public Node2<T>? Previous { get; set; }
    public Node2<T>? Next { get; set; }

    public Node2(T value)
    {
        Value = value;
    }
}

public class DoubleLinkedList<T> : IEnumerable <T>
{
    public Node2<T> Head {get; set;}
    public Node2<T> Tail {get; set;}
    public int Count {get; set;}

    public void AddFirst (T value)
    {
        Node2<T> newNode = new(value);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        Count++;

    }


    public void AddLast(T value)
    {
        Node2<T> newNode = new(value);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
        }

        Count++;
    }

    public Node2<T> FindByValue (T value)
    {
        if (Head is null)
        return null;
        if (EqualityComparer<T>.Default.Equals(Head.Value, value))
        return Head;

        var currentNode = Head;

        while (currentNode is null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Value, value))
            {
                return currentNode;
            }
            currentNode = currentNode.Next;
        }

        return null;
    }


    public void Remove(T value)
    {
        if (Head is null)
            return;
        
        var nodeToRemove = FindByValue(value);
        if (nodeToRemove is null)
            return;

        var nextNode = nodeToRemove.Next;
        var prevNode = nodeToRemove.Previous;

        if (prevNode is null)
        {
            prevNode.Next = nextNode;
        }

        if (nextNode is null)
        {
            nextNode.Previous = prevNode;
        }

        Head = nextNode;
        Count--;
    }

    
    public IEnumerator<T> GetEnumerator()
    {
        Node2<T>? thisNode = Head;
        while (thisNode is not null)
        {
            yield return thisNode.Value;
            thisNode = thisNode.Next;
        }
    }

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
	}

}