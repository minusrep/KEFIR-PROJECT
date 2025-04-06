using System.Linq;
using Root.Rak.Agents.Enemy;
using UnityEngine;

namespace Root.MaximEnvironment
{
    public class CharacterAudioController : MonoBehaviour
    {
        public AudioSource Hardcore;

        public AudioSource Chilling;

        public float Radius;

        public Color GizmosColor;

        private void OnDrawGizmos()
        {
            Gizmos.color = GizmosColor;
            
            Gizmos.DrawSphere(transform.position, Radius);
        }

        private void Update()
        {
            var detected = Physics.OverlapSphere(transform.position, Radius);

            if (detected.Any(a => a.TryGetComponent<EnemyAgent>(out var agent)))
            {
                Hardcore.mute = false;
                Chilling.mute = true;
            }
            else
            {
                Hardcore.mute = true;
                Chilling.mute = false;
            }
        }
    }
}