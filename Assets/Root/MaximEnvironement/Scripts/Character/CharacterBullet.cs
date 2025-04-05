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
            Debug.Log(other.gameObject.name);
            
            if (other.gameObject.TryGetComponent<IEntityAttacked>(out var attacked))
            {
                Debug.Log(attacked);

                if (attacked.ID == TeamID.AGENT)
                {
                    Debug.LogWarning(attacked);
                    attacked.TakeDamage(new TestAttack(10f));
                }
                
            }
        }
    }
}