using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyModel
    {
        public bool IsLife { get; private set; }
        public bool IsDead { get; private set; }
        public bool HasTarget { get; private set; }
        public ITarget CurrentTarget { get; private set; }

        private readonly ITargetProvider _targetProvider;

        private readonly EnemyMotion _motion;
        
        private readonly Transform _me;

        public EnemyModel(ITargetProvider targetProvider, EnemyMotion motion, Transform me)
        {
            _targetProvider = targetProvider;
            
            _motion = motion;
            _me = me;
            
            IsLife = true;

            IsDead = false;

            HasTarget = false;
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
            UnityEngine.Debug.Log("clear target");

            HasTarget = false;

            _motion.ClearTarget();
        }
    }
}