using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInteraction : MonoBehaviour
    {
        public float InteractionDistance;

        public InteractiveObject CurrentInteractiveObject;
        
        private void Update() 
            => CurrentInteractiveObject = DetectInteractiveObject();
        
        private InteractiveObject DetectInteractiveObject()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var results = new RaycastHit[1];
            
            var foundedCount = Physics.RaycastNonAlloc(ray, results, InteractionDistance, LayerMask.GetMask("Interactable"));

            if (foundedCount == 0) return null;
            
            return results[0].collider.gameObject.GetComponent<InteractiveObject>();
        }
    }
}