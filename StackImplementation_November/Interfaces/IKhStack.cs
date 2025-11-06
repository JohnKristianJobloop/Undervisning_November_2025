using System;

namespace StackImplementation_November.Interfaces;

public interface IKhStack<T> : IPushable<T>, IPoppable<T>, IEnumerable<T>
{
}
