using Root.Rak.Agents;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterHealth : MonoBehaviour, IEntityAttacked
    {
        public TeamID ID => throw new System.NotImplementedException();

        public void TakeDamage(IAttack attack)
        {
            
        }
    }
}