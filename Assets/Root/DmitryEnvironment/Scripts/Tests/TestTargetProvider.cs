using Root.Rak.Agents.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestTargetProvider : MonoBehaviour, ITargetProvider
    {
        private bool IsRequestDoor;

        public TestPlayerController Player;

        public List<TestDoor> Doors;

        //public List<TestClient> Clients;

        private void Awake()
        {
            IsRequestDoor = true;
        }

        public ITarget RequestTarget(Transform enemy)
        {
            ITarget target = Player;
            ITarget newTarget;

            var distanceBetweenPlayer = Vector3.Distance(Player.Position, enemy.position);


            if (CheckDoors(out newTarget, distanceBetweenPlayer, enemy))
                return newTarget;

            //TODO: Add Check Client Agents

            return Player;

        }

        private bool CheckDoors(out ITarget newTarget, float distanceBetweenPlayer, Transform enemy)
        {
            newTarget = null;

            foreach (var door in Doors)
            {
                if (distanceBetweenPlayer > Vector3.Distance(enemy.position, door.Position))
                {
                    newTarget = door;

                    return true;
                }
            }

            return false;
        }
    }
}