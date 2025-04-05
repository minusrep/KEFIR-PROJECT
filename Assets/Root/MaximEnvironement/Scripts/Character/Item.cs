using UnityEngine;

namespace Root.MaximEnvironment
{
    public class Item : InteractiveObject
    {
        public ItemType ItemType;
        
        public void Show(Vector3 position)
        {
            gameObject.SetActive(true);
            
            gameObject.transform.position = position;
        }

        public void Hide() 
            => gameObject.SetActive(false);
    }
}