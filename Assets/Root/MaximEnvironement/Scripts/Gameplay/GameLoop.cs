using System;
using UnityEngine;

namespace Root.MaximEnvironement
{
    public class GameLoop : MonoBehaviour
    {
        public static event Action OnWinEvent;
        
        public float AllTime;

        public float TimeScale = 2f;

        public float StartTime = 540f;

        public float EndTime = 1200f;
        
        private void Start() 
            => AllTime = StartTime;

        private void Update()
        {
            if (AllTime >= EndTime) return;
            
            AllTime += TimeScale * Time.deltaTime;

            if (AllTime >= EndTime) OnWinEvent?.Invoke();
        }

        public void GlobalInit()
        {
            
        }
    }
}