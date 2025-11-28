using System;
using System.Collections;

namespace StackImplementation_November.Models.LinkedList;

public class LinkedListExample<T> : IEnumerable<T>
{
    public Node<T>? Start;
    public Node<T>? Current;

    public void Add(T data)
    {
        if (Start is null)
        {
            Start = new Node<T>
            {
                Data = data
            };
        return;
        }
        Current = Start;
        while (Current.next is not null)
        {
            Current = Current.next;
        }
        Current.next = new Node<T>
        {
            Data = data
        };
    }

    public void MoveNext()
    {
        if (Current.next is not null)
        {
            Current = Current.next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Current = Start;
        while (Current is not null && Current.next is not null)
        {
            yield return Current.Data;
            Current = Current.next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
