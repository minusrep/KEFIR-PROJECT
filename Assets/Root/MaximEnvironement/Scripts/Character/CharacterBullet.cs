using System;
using InfimaGames.LowPolyShooterPack.Legacy;
using Root.Rak.Agents;
using Root.Rak.Tests;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterBullet : MonoBehaviour
    {
        public Collider Collider;

        private void Awake()
        {
            Collider = GetComponent<Collider>();
            
            Collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var entityAttacked = other.gameObject.GetComponent<IEntityAttacked>();

            if (entityAttacked != null)
            {
                if(entityAttacked.ID == TeamID.AGENT)
                    entityAttacked.TakeDamage(new TestAttack(10f));
            }
        }
    }
}