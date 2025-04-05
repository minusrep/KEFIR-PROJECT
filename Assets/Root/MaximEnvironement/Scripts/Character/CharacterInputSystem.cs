using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterInputSystem : MonoBehaviour
    {
        [SerializeField] private CharacterInteraction _characterInteraction;
        
        [SerializeField] private CharacterProvider _characterProvider;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                _characterInteraction.Interact();
            
            if(Input.GetKeyDown(KeyCode.G))
                _characterProvider.SwitchHolstered();
        }
    }
}