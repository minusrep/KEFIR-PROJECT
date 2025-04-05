using System;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyModel
    {
        public bool IsLife { get; private set; }
        public bool IsDead { get; private set; }
        public bool HasTarget { get; private set; }

        public void UpdateTarget()
        {
            HasTarget = true;
        }
    }
}