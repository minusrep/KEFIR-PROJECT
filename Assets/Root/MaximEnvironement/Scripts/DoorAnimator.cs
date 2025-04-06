using System.Collections.Generic;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class DoorAnimator : MonoBehaviour
    {
        public Animator Animator;

        public List<GameObject> Elements;


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