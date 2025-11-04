using System;

namespace StackImplementation_November.Interfaces;

public interface IKhStack<T>
{
    void Push(T obj);

    T Pop();
}
