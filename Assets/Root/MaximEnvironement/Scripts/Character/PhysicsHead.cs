using UnityEngine;

namespace Root.MaximEnvironment
{
    public class PhysicsHead : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private Collider _collider;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            _collider = GetComponent<Collider>();
            
            _rigidbody.isKinematic = true;
            
            _collider.enabled = false;
        }

        public void Die()
        {
            _rigidbody.isKinematic = false;
            
            _collider.enabled = true;
            
            _rigidbody.velocity = Physics.gravity;
        }
    }
}