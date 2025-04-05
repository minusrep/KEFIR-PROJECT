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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<IEntityAttacked>(out var attacked))
                if (attacked.ID == TeamID.AGENT)
                    attacked.TakeDamage(new TestAttack(10f));
        }
    }
}