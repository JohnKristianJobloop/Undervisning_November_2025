using System.Collections;
using StackImplementation_November.Interfaces;

namespace StackImplementation_November.Models;

public class KhStack<T> : IKhStack<T>
{
    private T[] _internalCollection = [];

    private int _position = 0;

    
    public void Push(T obj)
    {
        if (_position > _internalCollection.Length - 1)
        {
            _internalCollection = _growInteralCollection();
        }
        /* Her skjer incrementing (++) etter index access */
        _internalCollection[_position++] = obj;
    }

    /* Her skjer decrementing (--) før index access */
    public T Pop(){
        if (_position < 0)
        {
            throw new IndexOutOfRangeException("At the end of the stack");
        }
        return _internalCollection[--_position];
    }

    private T[] _growInteralCollection()
    {
        var counter = Enumerable.Range(0, _position + 1);

        T[] newArray = [.. counter.Select(index => index < _position && _internalCollection[index] is not null ? _internalCollection[index] : default!)];

        return newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var iterator = 0; iterator < _position; iterator++)
        {
            yield return _internalCollection[iterator];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
