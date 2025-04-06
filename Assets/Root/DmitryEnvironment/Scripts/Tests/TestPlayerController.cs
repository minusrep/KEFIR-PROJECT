using Root.Rak.Agents.Enemy;
using System;
using UnityEngine;

namespace Root.Rak.Tests
{

    public class EnemyClearTarget : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            EnemyAgent enemyAgent = other.GetComponent<EnemyAgent>();

            if (enemyAgent != null)
            {
                enemyAgent.ClearTarget();
            }
        }
    }

    public class TestPlayerController : MonoBehaviour, ITarget
    {
        public event Action Dead;
        public Vector3 Position => transform.position;

    }
}