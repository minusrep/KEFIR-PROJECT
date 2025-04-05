using Root.Rak.Agents.Enemy;
using UnityEngine;

namespace Root.Rak.Tests
{

    public class TestDoor : MonoBehaviour, ITarget
    {
        public Vector3 Position => transform.position;
    }
}