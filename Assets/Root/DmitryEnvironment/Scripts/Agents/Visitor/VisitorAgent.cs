using Root.Rak.Agents.Enemy;
using Root.Rak.Tests;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Visitor
{

    [RequireComponent(typeof(NavMeshAgent), typeof(VisitorStomach))]
    public class VisitorAgent : MonoBehaviour, IEntityAttacked, ITarget
    {
        public event Action Dead;

        public event Action OutEvent;

        public event Action<ITarget> DeadForGenerator;

        public TeamID ID => _teamID;
        public Vector3 Position => transform.position;

        public VisitorAnimatorHandler AnimHandler;

        private VisitorModel _model;

        private VisitorAnimator _animator;

        private VisitorMotion _motion;

        private VisitorBrain _brain;

        [SerializeField] private TeamID _teamID;

        public void Construct(TestVisitorTargetsProvider provider)
        {
            _motion = new VisitorMotion(GetComponent<NavMeshAgent>());

            _animator = new VisitorAnimator(GetComponentInChildren<Animator>(), AnimHandler, gameObject);

            _model = new VisitorModel(provider, _motion, GetComponent<VisitorStomach>(), this, GetComponent<Collider>());

            _brain = new VisitorBrain(_animator, _model, _motion, GetComponent<VisitorStomach>(), this);

            Dead += DeadForVisitorHandler;
        }

        private void DeadForVisitorHandler() 
            => DeadForGenerator?.Invoke(this);

        private void Update()
        {
            if (!_model.IsLife && _model.IsDead) return;

            _motion.Update();

            _brain.Update();
        }

        public void TakeDamage(IAttack attack)
        {
            if (!_model.TakeDamage(attack.Damage))
                Dead?.Invoke();
        }

        public void OnOut()
            => OutEvent?.Invoke();
    }
}