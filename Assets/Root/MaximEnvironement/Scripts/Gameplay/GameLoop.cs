using System;
using UnityEngine;

namespace Root.MaximEnvironement
{
    public class GameLoop : MonoBehaviour
    {
        public float AllTime;

        public float TimeScale = 1f;

        public float StartTime = 540f;

        private void Start() 
            => AllTime = StartTime;

        private void Update() 
            => AllTime += TimeScale * Time.deltaTime;

        public void GlobalInit()
        {
            
        }
    }
}