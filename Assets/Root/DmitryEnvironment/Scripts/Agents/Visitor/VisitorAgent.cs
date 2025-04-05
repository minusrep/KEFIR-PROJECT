using Root.Rak.Tests;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Visitor
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class VisitorAgent : MonoBehaviour
    {
        public TestVisitorTargetsProvider _provider;

        private VisitorModel _model;

        private VisitorAnimator _animator;

        private VisitorMotion _motion;

        private VisitorBrain _brain;

        private void Start()
        {
            _motion = new VisitorMotion(GetComponent<NavMeshAgent>());

            _animator = new VisitorAnimator(GetComponentInChildren<Animator>());

            _model = new VisitorModel(_provider, _motion);

            _brain = new VisitorBrain(_animator, _model, _motion);
        }

        private void Update()
        {
            _motion.Update();

            _brain.Update();
        }
    }
}