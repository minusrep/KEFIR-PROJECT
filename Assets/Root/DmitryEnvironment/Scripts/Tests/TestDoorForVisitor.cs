using Root.Rak.Agents.Visitor;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestDoorForVisitor : MonoBehaviour
    {
        private Animation _animator;

        [SerializeField] private AnimationClip _openDoor;

        [SerializeField] private AnimationClip _closeDoor;

        private void Awake()
        {
            _animator = GetComponent<Animation>();
        }

        private void OnTriggerEnter(Collider other)
        {
            VisitorAgent agent = other.GetComponent<VisitorAgent>();

            if (agent == null) return;

            _animator.clip = _openDoor;

            _animator.Play();
        }

        private void OnTriggerExit(Collider other)
        {
            VisitorAgent agent = other.GetComponent<VisitorAgent>();

            if (agent == null) return;

            _animator.clip = _closeDoor;

            _animator.Play();
        }

    }
}