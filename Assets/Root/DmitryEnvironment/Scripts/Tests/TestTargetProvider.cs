using Root.MaximEnvironment;
using Root.Rak.Agents.Enemy;
using Root.Rak.Agents.Visitor;
using Root.Rak.Gameplay.Generators;
using System.Collections.Generic;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestTargetProvider : MonoBehaviour, ITargetProvider
    {
        public CharacterHealth Player;

        public DoorsAdministrator _doorsAdministrator;

        public List<VisitorAgent> Visitors;

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

            if (_doorsAdministrator.GetDoorStatus() == DoorStatus.EMPTY) return false;

            TestDoor door = _doorsAdministrator.GetRightDoor();

            if (_doorsAdministrator.GetDoorStatus() == DoorStatus.LEFT)
            {
                door = _doorsAdministrator.GetLeftDoor();
            }

            if (door.IsLife)
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