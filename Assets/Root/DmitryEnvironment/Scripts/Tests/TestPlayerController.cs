using Root.Rak.Agents.Enemy;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestPlayerController : MonoBehaviour, ITarget
    {
        public Vector3 Position => transform.position;
    }
}