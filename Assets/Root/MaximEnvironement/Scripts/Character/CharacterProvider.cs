using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterProvider : MonoBehaviour
    {
        private const string HolsteredName = "Holstered";
    
        public bool Holstered { get; private set; }
        
        [SerializeField] private Animator _characterAnimator;
        
        public void SwitchHolstered()
        {
            Holstered = !Holstered;
        
            _characterAnimator.SetBool(HolsteredName, Holstered);
        }
    }
}

