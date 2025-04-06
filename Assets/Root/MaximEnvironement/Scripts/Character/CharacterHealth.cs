using System;
using Root.Rak.Agents;
using Root.Rak.Agents.Enemy;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterHealth : MonoBehaviour, IEntityAttacked, ITarget
    {
        public event Action Dead;
        public Vector3 Position => gameObject.transform.position;
        public TeamID ID => PlayerID;

        public TeamID PlayerID;
        
        public float CurrentHealth = 100f;
        
        public float MaxHealth = 100f;

        public void TakeDamage(IAttack attack) 
            => CurrentHealth -= attack.Damage;

    }
}