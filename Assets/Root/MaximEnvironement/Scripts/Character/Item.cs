using System;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class Item : MonoBehaviour, IInteractableObject
    {
        public int ItemID;
        public string Description => _description;
        
        [SerializeField] private string _description;
        
        [SerializeField] private Outline _outline;

        public void Interact() 
            => Collect();

        public void Select() 
            => _outline.enabled = true;

        public void Unselect() 
            => _outline.enabled = false;

        public void Put(Vector3 position)
        {
            gameObject.transform.position = position;
            
            gameObject.SetActive(true);
        }

        private void Collect() 
            => gameObject.SetActive(false);
    }
}