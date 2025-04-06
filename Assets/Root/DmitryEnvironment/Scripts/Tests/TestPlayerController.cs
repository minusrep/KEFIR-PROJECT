using Root.Rak.Agents.Enemy;
using System;
using UnityEngine;

namespace Root.Rak.Tests
{

    public class TestPlayerController : MonoBehaviour, ITarget
    {
        public event Action Dead;
        public Vector3 Position => transform.position;

    }
}