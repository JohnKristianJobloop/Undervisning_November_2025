using System;
using StackImplementation_November.Interfaces;

namespace StackImplementation_November.Services;

public class KhStackService<T>(IKhStack<T> stack)
{
    public bool TryPopFromStack()
    {
        var result = stack.Pop();
        if (result is null) return false;
        return true;
    }
}
