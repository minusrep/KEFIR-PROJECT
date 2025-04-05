using System;
using Root.Rak.Agents;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterHealth : MonoBehaviour, IEntityAttacked
    {
        public float HealthIncome;
        
        public float MaxHealth;
        
        public float CurrentHealth;

        private void OnEnable() 
            => CurrentHealth = MaxHealth;

        private void Update()
        {
            if (CurrentHealth <= MaxHealth)
                CurrentHealth += HealthIncome * Time.deltaTime;   
        }

        public void TakeDamage(IAttack attack)
        {
            
        }
    }
}