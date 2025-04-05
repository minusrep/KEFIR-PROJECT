using System;
using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class ChildrenAnimatorHandler : MonoBehaviour, IChildrenAnimatorHandler
    {
        public event Action EndAttackEvent;

        public event Action EndDeadEvent;

        public void OnEndAttackHandler()
            => EndAttackEvent?.Invoke();

        public void OnEndDeadHandler()
            => EndDeadEvent?.Invoke();
    }
}