using InfimaGames.LowPolyShooterPack;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterProvider : MonoBehaviour
    {
        private const string HolsteredName = "Holstered";
    
        public bool Holstered { get; private set; }
        
        public int CurrentAmmo => _weapon.CurrentAmmo;
        
        [SerializeField] private Animator _characterAnimator;

        [SerializeField] private Weapon _weapon;
        
        private void Start() 
            => SetHolstered(false);

        public void SetHolstered(bool value)
        {
            Holstered = value;
        
            _characterAnimator.SetBool(HolsteredName, Holstered);
        }
        
        public void SwitchHolstered()
        {
            Holstered = !Holstered;
        
            _characterAnimator.SetBool(HolsteredName, Holstered);
        }
    }
}

