using Root.Rak.Tests;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Enemy
{


    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAgent : MonoBehaviour, IEntityAttacked
    {
        public Animator Anim;

        public ChildrenAnimatorHandler AnimHandler;

        public ChildTriggerHandler AttackTriggerHandler;

        private EnemyAnimator _animator;

        private EnemyAttaker _attacker;

        private EnemyMotion _motion;

        private EnemyModel _model;

        private EnemyBrain _brain;

        public TeamID ID { get; private set; } = TeamID.AGENT;

        public void Construct(TestTargetProvider provider)
        {
            _animator = new EnemyAnimator(Anim, AnimHandler);

            _attacker = new EnemyAttaker(AttackTriggerHandler, ID);

            _motion = new EnemyMotion(GetComponent<NavMeshAgent>(), GetComponent<Collider>());

            _model = new EnemyModel(provider, _motion, transform);

            _brain = new EnemyBrain(_model, _animator, _motion, _attacker);
        }

        public void TakeDamage(IAttack attack)
        {
            if (!_model.IsLife) return;

            _model.TakeDamage(attack.Damage);
        }

        public void Update()
        {
            _motion.Update();

            _brain.Update();
        }

        public void AddListenerDead(Action callback)
            => _model.DeadEvent += callback;

        public void ClearTarget()
        {
            _model.ClearTarget();
        }
    }
}