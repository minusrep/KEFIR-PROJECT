using System;

namespace Root.Rak.Tests
{
    public interface IDoor
    {
        float Cost { get; }

        event Action BuildedEvent;

        event Action DestroyEvent;

        public void Build();
    }
}