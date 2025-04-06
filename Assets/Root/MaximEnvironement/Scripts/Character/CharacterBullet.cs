using System;
using System.Collections.Generic;
using Root.Rak.Agents;
using Root.Rak.Tests;
using UnityEngine;
using Random = System.Random;

namespace Root.MaximEnvironment
{
    public class CharacterBullet : MonoBehaviour
    {
        public Collider Collider;
        
        public List<Item> Prefabs = new List<Item>();

        private void Awake()
        {
            Collider = GetComponent<Collider>();
            
            Collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var entityAttacked = other.gameObject.GetComponent<IEntityAttacked>();

            if (entityAttacked != null)
            {
                if (entityAttacked.ID == TeamID.AGENT)
                {
                    var index = UnityEngine.Random.Range(0, 10f);

                    Debug.Log(index);
                    
                    if (index < 3f)
                    {
                        var toPosition = other.transform.position;
                        
                        Instantiate(Prefabs[UnityEngine.Random.Range(0, Prefabs.Count)], toPosition, Quaternion.identity);
                    }
                    
                    entityAttacked.TakeDamage(new TestAttack(10f));
                }
            }
        }
    }
}