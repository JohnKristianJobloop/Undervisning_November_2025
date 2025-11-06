using System;

namespace StackImplementation_November.Interfaces;

public interface IPushable<in T>
{
    void Push(T obj);
}
