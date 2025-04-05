using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Root.MaximEnvironment
{
    public class CharacterInputSystem : MonoBehaviour
    {
        public CharacterProvider CharacterProvider;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
        }

        private void Start() 
            => CharacterProvider.SetHolstered(false);

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.G))
                CharacterProvider.SwitchHolstered();
        }
    }
}