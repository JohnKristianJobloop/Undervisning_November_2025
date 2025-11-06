using System;

namespace StackImplementation_November.Interfaces;

public interface IPoppable<out T>
{
    T Pop();
}
