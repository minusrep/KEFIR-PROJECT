using System.Collections.Generic;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class DoorAnimator : MonoBehaviour
    {
        public Animator Animator;

        public List<Rigidbody> Elements;

        private void Start()
        {
            Elements = new List<Rigidbody>();
            
            Elements.AddRange( gameObject.GetComponentsInChildren<Rigidbody>());
            
            Elements.ForEach(a => a.isKinematic = true);
        }

        [ContextMenu("Destroy")]
        public void DestroyDoor()
        {
            Elements.ForEach(a => a.gameObject.SetActive(false));
        }

        [ContextMenu("Repair")]
        public void RepairDoor()
        {
            Elements.ForEach(a => a.gameObject.SetActive(true));
            
            Animator.SetTrigger("Repair");
        }
    }
}