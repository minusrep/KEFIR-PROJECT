using System;
using Root.Rak.Agents;
using Random = UnityEngine.Random;

namespace Root.MaximEnvironment
{
    public class GuestTable : InteractiveObject, ITableFood
    {
        public bool HasVisitor { get; set; } = false;

        public UnityEngine.Vector3 Position => transform.position;

        public event Action ArriveFoodEvent;

        public void ResetVisitor()
        {
            ArriveFoodEvent = null;

            HasVisitor = false;
        }

        public void SetItem(Item item)
        {
            CharacterStats.MoneyAmount += Random.Range(10, 25f);
            
            Destroy(item.gameObject);
            
            ArriveFoodEvent?.Invoke();
        }
    }
}