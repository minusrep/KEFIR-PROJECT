using System;

namespace Root.Rak.Agents
{
    public interface ITableFood
    {
        bool HasVisitor { get; }

        event Action ArriveFoodEvent;

        void ResetVisitor();
    }
}