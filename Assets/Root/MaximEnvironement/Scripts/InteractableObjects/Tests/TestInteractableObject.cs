using UnityEngine;

namespace Root.MaximEnvironment
{
    public class TestInteractableObject : MonoBehaviour, IInteractableObject
    {
        public string Description => _description;

        [SerializeField] private string _description;
        
        [SerializeField] private Outline _outline;
        
        public void Interact()
        {
            Debug.Log("Interacted with " + _description);
        }

        public void Select() 
            => _outline.enabled = true;

        public void Unselect() 
            => _outline.enabled = false;
    }
}