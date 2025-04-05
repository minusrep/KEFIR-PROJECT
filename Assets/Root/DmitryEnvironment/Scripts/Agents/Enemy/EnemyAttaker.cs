using Root.Rak.Tests;
using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyAttaker
    {
        private readonly ChildTriggerHandler _triggerHandler;

        private readonly TeamID _teamID;

        public EnemyAttaker(ChildTriggerHandler triggerHandler, TeamID teamID)
        {
            _triggerHandler = triggerHandler;
            _teamID = teamID;

            _triggerHandler.TriggerEnterEvent += Attack;
        }

        public void Attack(Collider other)
        {
            IEntityAttacked entity = other.GetComponent<IEntityAttacked>();

            if (entity == null) return;

            if (entity.ID == _teamID) return;


            //TODO: Switch TestAttack
            entity.TakeDamage(new TestAttack(10));

        }
    }
}