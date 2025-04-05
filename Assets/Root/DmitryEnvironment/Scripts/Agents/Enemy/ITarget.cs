using System;
using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public interface ITarget
    {
        public event Action Dead;
        public Vector3 Position { get; }
    }
}