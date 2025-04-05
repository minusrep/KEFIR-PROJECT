using System;

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

        public EnemyModel(ITargetProvider targetProvider, EnemyMotion motion)
        {
            _targetProvider = targetProvider;
            
            _motion = motion;
            
            IsLife = true;

            IsDead = false;

            HasTarget = false;
        }

        public void UpdateTarget()
        {
            HasTarget = true;

            _motion.SetTarget(_targetProvider.RequestTarget());
        }
    }
}