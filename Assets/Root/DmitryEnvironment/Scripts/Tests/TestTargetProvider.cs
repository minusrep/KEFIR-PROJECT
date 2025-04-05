using Root.Rak.Agents.Enemy;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestTargetProvider : MonoBehaviour, ITargetProvider
    {
        private bool IsRequestDoor;

        public TestPlayerController Player;

        public TestDoor Door;

        private void Awake()
        {
            IsRequestDoor = true;
        }

        public ITarget RequestTarget()
        {
/*            if (IsRequestDoor)
            {
                IsRequestDoor = false;

                return Door;
            }
*/
            return Player;
        }
    }
}