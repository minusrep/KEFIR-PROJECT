using UnityEngine;

namespace Root.MaximEnvironment
{
    public class PhysicsHead : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private Collider _collider;
        
        private AudioListener _audioListener;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            _collider = GetComponent<Collider>();
            
            _audioListener = GetComponent<AudioListener>();
            
            _rigidbody.isKinematic = true;
            
            _collider.enabled = false;
        }

        public void Die()
        {
            _rigidbody.isKinematic = false;
            
            _collider.enabled = true;
            
            _rigidbody.velocity = Physics.gravity;
            
            _audioListener.enabled = false;
        }
    }
}