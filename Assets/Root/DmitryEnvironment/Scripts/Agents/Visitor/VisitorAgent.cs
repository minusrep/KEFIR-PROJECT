using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Visitor
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class VisitorAgent : MonoBehaviour
    {
        private VisitorModel _model;

        private VisitorAnimator _animator;

        private VisitorMotion _motion;

        private VisitorBrain _brain;

        private void Start()
        {
            _model = new VisitorModel();

            _animator = new VisitorAnimator(GetComponentInChildren<Animator>());

            _motion = new VisitorMotion(GetComponent<NavMeshAgent>());

            _brain = new VisitorBrain(_animator, _model, _motion);
        }
    }
}