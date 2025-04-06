using System;
using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorAnimatorHandler : MonoBehaviour
    {
        public event Action EndSidDownEvent;

        public event Action EndStandUpEvent;

        public event Action EndDeadEvent;

        private void OnEndSidDownHandler()
            => EndSidDownEvent?.Invoke();

        private void OnEndStandUpHandler()
            => EndStandUpEvent?.Invoke();

        private void OnEndDeadHandler()
            => EndDeadEvent?.Invoke();
    }
}