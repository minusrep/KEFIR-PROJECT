using UnityEngine.Events;
using UnityEngine;

namespace Root.Rak.Agents
{
    public class ChildTriggerHandler : MonoBehaviour
    {
        public event UnityAction<Collider> TriggerEnterEvent;

        private void OnTriggerEnter(Collider other)
            => TriggerEnterEvent?.Invoke(other);
    }
}