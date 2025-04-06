using System;

namespace Root.Rak.Tests
{
    public interface IDoor
    {
        event Action BuildedEvent;

        event Action DestroyEvent;
    }
}