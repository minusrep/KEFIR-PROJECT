using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterProvider : MonoBehaviour
    {
        private const string HolsteredName = "Holstered";
    
        public bool Holstered { get; private set; }
        
        [SerializeField] private Animator _characterAnimator;
        
        private void SwitchHolstered()
        {
            Holstered = !Holstered;
        
            _characterAnimator.SetBool(HolsteredName, Holstered);
        }
    }

    public class CharacterHands : MonoBehaviour
    {
        public CharacterProvider _characterProvider;
    }

    public class CharacterInteraction : MonoBehaviour
    {
    }

    public class CharacterInventory : MonoBehaviour
    {
    
    }

    public class CharacterInputSystem : MonoBehaviour
    {
        
    }

    public interface IInteractableObject
    {
        string Description { get; }
        
        void Interact();

        void Interact(IInventory inventory);
    }

    public interface IInventory
    {
        
    }
}

