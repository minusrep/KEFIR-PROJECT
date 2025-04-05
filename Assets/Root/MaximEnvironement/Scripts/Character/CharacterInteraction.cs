using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInteraction : MonoBehaviour
    {
        public IInteractableObject CurrentInteractableObject
        {
            get => _currentInteractableObject;

            private set
            {
                if (_currentInteractableObject == value) return;
                
                _currentInteractableObject?.Unselect();
                
                _currentInteractableObject = value;
                
                _currentInteractableObject?.Select();
            }
        }

        private IInteractableObject _currentInteractableObject;
        
        [SerializeField] private float _interactDistance;
        
        [SerializeField] private CharacterInventory _characterInventory;

        private void Update() 
            => CurrentInteractableObject = DetectInteractable();

        public void Interact()
        {
            var interactable = DetectInteractable();
            
            if (interactable == null) return;

            switch (interactable)
            {
                case Item item:
                    
                    if (_characterInventory.TryAddItem(item))
                        
                        item.Interact();
                    
                    break;
                
                case IInteractableWithInventoryObject interactableWithInventoryObject:
                    
                    interactableWithInventoryObject.Interact(_characterInventory);
                    
                    break;
                
                default:
                    
                    interactable.Interact();
                    
                    break;
            }
        }

        private IInteractableObject DetectInteractable()
        {
            var camera = Camera.main;
            
            var origin = camera.transform.transform.position;
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var founded = Physics.Raycast(ray, out RaycastHit hit, _interactDistance);

            if (founded == null) return null;
            
            return founded ? hit.collider.GetComponent<IInteractableObject>() : null;
        }
    }
}