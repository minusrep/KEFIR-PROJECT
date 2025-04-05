using System;

namespace Root.Rak.Agents.Enemy
{
    public class ChildrenAnimatorHandler : IChildrenAnimatorHandler
    {
        public event Action EndAttackEvent;

        public event Action EndDeadEvent;

        public void OnEndAttackHandler()
            => EndAttackEvent?.Invoke();

        public void OnEndDeadHandler()
            => EndDeadEvent?.Invoke();
    }
}