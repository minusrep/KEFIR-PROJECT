using UnityEngine;

namespace Root.MaximEnvironment
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Item : InteractiveObject
    {
        public bool Active => transform.parent == null;
        
        public ItemType ItemType;

        public Sprite ItemIcon;
        
        private Rigidbody _rigidbody;

        private BoxCollider _boxCollider;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _boxCollider = GetComponent<BoxCollider>();
            
            _rigidbody.isKinematic = true;
        }
        
        public void Take(Transform parent)
        {
            _rigidbody.isKinematic = parent != null;
            
            transform.parent = parent;
            
            transform.localPosition = Vector3.zero;
        }

        public void Drop()
        {
            _rigidbody.isKinematic = false;
            
            transform.parent = null;
        }
    }
}