using System;
using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyModel
    {
        public event Action DeadEvent;

        public bool IsLife { get; private set; }
        public bool IsDead { get; private set; }
        public bool HasTarget { get; private set; }
        public ITarget CurrentTarget { get; private set; }

        private readonly ITargetProvider _targetProvider;

        private readonly EnemyMotion _motion;
        
        private readonly Transform _me;

        private float _health;

        public EnemyModel(ITargetProvider targetProvider, EnemyMotion motion, Transform me)
        {
            _targetProvider = targetProvider;
            
            _motion = motion;
            _me = me;
            
            IsLife = true;

            IsDead = false;

            HasTarget = false;

            _health = 100;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0 && IsLife)
            {
                IsLife = false;

                _health = 0;
            }
        }

        public void Dead()
        {
            IsDead = true;

            DeadEvent?.Invoke();
        }

        public void UpdateTarget()
        {
            ITarget target = _targetProvider.RequestTarget(_me);

            target.Dead += ClearTarget;

            _motion.SetTarget(target);
            
            HasTarget = true;

        }

        private void ClearTarget()
        {
            HasTarget = false;

            _motion.ClearTarget();
        }
    }
}