using Root.Rak.Agents;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterHealth : MonoBehaviour, IEntityAttacked
    {
        public TeamID ID => PlayerID;

        public TeamID PlayerID;
        
        public float CurrentHealth = 100f;
        
        public float MaxHealth = 100f;

        public void TakeDamage(IAttack attack)
        {
            
        }
    }
}