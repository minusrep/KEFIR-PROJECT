using Root.Rak.Tests;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Visitor
{

    [RequireComponent(typeof(NavMeshAgent), typeof(VisitorStomach))]
    public class VisitorAgent : MonoBehaviour
    {
        public VisitorAnimatorHandler AnimHandler;

        private VisitorModel _model;

        private VisitorAnimator _animator;

        private VisitorMotion _motion;

        private VisitorBrain _brain;

        public void Construct(TestVisitorTargetsProvider provider)
        {
            _motion = new VisitorMotion(GetComponent<NavMeshAgent>());

            _animator = new VisitorAnimator(GetComponentInChildren<Animator>(), AnimHandler);

            _model = new VisitorModel(provider, _motion, GetComponent<VisitorStomach>());

            _brain = new VisitorBrain(_animator, _model, _motion, GetComponent<VisitorStomach>());
        }

        private void Update()
        {
            _motion.Update();

            _brain.Update();
        }
    }
}