using System;
using Root.Rak.Agents;
using Root.Rak.Agents.Enemy;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterHealth : MonoBehaviour, IEntityAttacked, ITarget
    {
        public event Action Dead;
        
        public bool IsDied => CurrentHealth <= 0f;
        
        public Vector3 Position => gameObject.transform.position;
        
        public PhysicsHead PhysicsHead;        
        
        public TeamID ID => PlayerID;
        

        public TeamID PlayerID;
        
        public float CurrentHealth = 100f;
        
        public float MaxHealth = 100f;

        public void TakeDamage(IAttack attack)
        {
            if (CurrentHealth <= 0f) return;
            
            CurrentHealth -= attack.Damage;

            if (CurrentHealth <= 0f)
                Die();
        }

        [ContextMenu("Die")]
        public void Die()
        {
            Dead?.Invoke();

            PhysicsHead.Die();
        }
    }
}