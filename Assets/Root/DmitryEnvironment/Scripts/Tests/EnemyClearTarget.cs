using Root.Rak.Agents.Enemy;
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
}