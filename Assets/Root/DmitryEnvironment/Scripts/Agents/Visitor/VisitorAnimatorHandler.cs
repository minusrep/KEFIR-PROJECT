using System;
using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorAnimatorHandler : MonoBehaviour
    {
        public event Action EndSidDownEvent;

        public event Action EndStandUpEvent;

        private void OnEndSidDownHandler()
            => EndSidDownEvent?.Invoke();

        private void OnEndStandUpHandler()
            => EndStandUpEvent?.Invoke();
    }
}