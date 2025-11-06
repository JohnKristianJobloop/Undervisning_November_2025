using System;
using System.Collections;

namespace StackImplementation_November.Models;

public class ArrayEnumerable<T>(T[] values) : IEnumerable<T>
{
    private int _max = values.Length;
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class ArrayEnumerator(int max, T[] values) : IEnumerator<T>
    {
        private int _max = max;
        private T _current;

        private int _incrementor = 0;
        public T Current => _current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_incrementor < _max)
            {
                _current = values[_incrementor];
                _incrementor++;
                return true;
            }
            return false;
        }

        public void Reset()
        {

        }
    }
}
