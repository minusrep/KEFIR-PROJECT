using System;

namespace Root.Rak.Agents.Enemy
{
    public interface IChildrenAnimatorHandler
    {
        event Action EndAttackEvent;
        event Action EndDeadEvent;
    }
}