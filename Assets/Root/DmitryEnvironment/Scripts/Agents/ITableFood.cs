using System;

namespace Root.Rak.Agents
{
    public interface ITableFood
    {
        bool HasVisitor { get; set; }

        event Action ArriveFoodEvent;

        void ResetVisitor();
    }
}