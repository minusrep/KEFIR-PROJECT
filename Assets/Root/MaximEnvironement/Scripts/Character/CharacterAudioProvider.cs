using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterAudioProvider : MonoBehaviour
    {
        public AudioSource AudioSource;

        public AudioClip InteractionSound;

        public AudioClip CookingSound;
        
        public void PlayInteractionSound() 
            => AudioSource.PlayOneShot(InteractionSound);
        
        public void PlayerCookingSound() 
            => AudioSource.PlayOneShot(CookingSound);
    }
}