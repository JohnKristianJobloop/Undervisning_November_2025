using System;
using System.Collections;

namespace StackImplementation_November.Models;

public class NumberEnumerable(int Max) : IEnumerable<int>
{
    private int _max = Max;
    public IEnumerator<int> GetEnumerator()
    {
        return new NumberEnumerator(_max);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class NumberEnumerator(int max) : IEnumerator<int>
    {
        private int _max = max;

        private int _current;
        public int Current => _current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current < _max)
            {
                _current++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
