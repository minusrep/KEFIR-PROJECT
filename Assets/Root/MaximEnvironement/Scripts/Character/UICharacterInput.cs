using UnityEngine;

namespace Root.MaximEnvironment
{
    public class UICharacterInput : MonoBehaviour
    {
        [SerializeField] private float _interactDistance;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
            
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }

        private IInteractableObject DetectInteractable()
        {
            var camera = Camera.main;
            
            var origin = camera.transform.transform.position;
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            var founded = Physics.Raycast(ray, out RaycastHit hit);
            
            return founded ? hit.collider.GetComponent<IInteractableObject>() : null;
        }
        
        private void Interact()
        {
            
        }
    }
}