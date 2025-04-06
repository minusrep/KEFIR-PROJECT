using Root.MaximEnvironment;
using Root.Rak.Agents.Enemy;
using Root.Rak.Agents.Visitor;
using Root.Rak.Gameplay.Generators;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestTargetProvider : MonoBehaviour, ITargetProvider
    {
        public CharacterHealth Player;

        public DoorsAdministrator _doorsAdministrator;

        public VisitorAdministrator _visitorsAdministrator;

        public List<VisitorAgent> Visitors;

        public ITarget RequestTarget(Transform enemy)
        {
            ITarget target = Player;
            ITarget newTarget;

            var distanceBetweenPlayer = Vector3.Distance(Player.Position, enemy.position);


            if (CheckDoors(out newTarget, distanceBetweenPlayer, enemy))
                return newTarget;

            if (CheckVisitors(out newTarget, distanceBetweenPlayer, enemy))
                return newTarget;

            return Player;

        }

        private bool CheckDoors(out ITarget newTarget, float distanceBetweenPlayer, Transform enemy)
        {
            newTarget = null;

            if (_doorsAdministrator.GetDoorStatus() == DoorStatus.EMPTY) return false;

            else if (_doorsAdministrator.GetDoorStatus() == DoorStatus.FULL)
            {
                TestDoor doorRight = _doorsAdministrator.GetRightDoor();
                TestDoor doorLeft = _doorsAdministrator.GetLeftDoor();

                var rightDoorToEnemy = Vector3.Distance(enemy.position, doorRight.Position);
                var leftDoorToEnemy = Vector3.Distance(enemy.position, doorLeft.Position);

                float door = rightDoorToEnemy;
                TestDoor current = doorRight;

                if (leftDoorToEnemy < rightDoorToEnemy)
                {
                    door = leftDoorToEnemy;

                    current = doorLeft;
                }

                if (distanceBetweenPlayer > door)
                {
                    newTarget = current;
                    return true;
                }
            }
            else 
            {

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
            }

            return false;
        }

        private bool CheckVisitors(out ITarget newTarget, float distanceBetweenPlayer, Transform enemy)
        {
            newTarget = null;

            var visitors = _visitorsAdministrator.GetVisitors();

            if (visitors.Length == 0) return false;

            foreach (var visitor in visitors)
            {
                if (distanceBetweenPlayer > Vector3.Distance(enemy.position, visitor.Position))
                {
                    newTarget = visitor;

                    return true;
                }
            }

            return false;
        }
    }
}