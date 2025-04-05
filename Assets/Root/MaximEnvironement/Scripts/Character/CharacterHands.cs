using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterHands : MonoBehaviour
    {
        public CharacterProvider CharacterProvider;
        
        public CharacterHandsState CharacterHandsState;

        public Transform ItemParent;
        
        public void UpdateState(CharacterHandsState state)
        {
            CharacterHandsState = state;

            switch (CharacterHandsState)
            {
                case CharacterHandsState.Empty:
                    
                    CharacterProvider.SetHolstered(false);
                    
                    break;
                
                case CharacterHandsState.Item:

                    CharacterProvider.SetHolstered(false);
                    
                    break;
                
                case CharacterHandsState.Weapon:

                    CharacterProvider.SetHolstered(true);
                    
                    break;
            }
        }
    }
}