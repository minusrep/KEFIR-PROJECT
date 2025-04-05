using UnityEngine;
using UnityEngine.Serialization;

namespace Root.MaximEnvironment
{
    public class Item : InteractiveObject
    {
        public bool Active => transform.parent == null;
        
        public ItemType ItemType;
        
        public void Take(Transform parent)
        {
            transform.parent = parent;
            
            transform.localPosition = Vector3.zero;
        }
    }
}