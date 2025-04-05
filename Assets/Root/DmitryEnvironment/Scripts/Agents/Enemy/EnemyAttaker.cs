using Root.Rak.Tests;
using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyAttaker
    {
        public bool IsFreeze { get; set; }

        private readonly ChildTriggerHandler _triggerHandler;

        private readonly TeamID _teamID;

        public EnemyAttaker(ChildTriggerHandler triggerHandler, TeamID teamID)
        {
            _triggerHandler = triggerHandler;
            _teamID = teamID;

            IsFreeze = true;

            _triggerHandler.TriggerEnterEvent += AttackHandler;
        }

        private void AttackHandler(Collider other)
        {
            if (IsFreeze) return;

            IEntityAttacked entity = other.GetComponent<IEntityAttacked>();

            if (entity == null) return;

            if (entity.ID == _teamID) return;


            //TODO: Switch TestAttack
            entity.TakeDamage(new TestAttack(10));

            IsFreeze = true;

        }
    }
}