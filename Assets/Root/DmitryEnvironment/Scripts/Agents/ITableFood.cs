using System;
using UnityEngine;

namespace Root.Rak.Agents
{
    public interface ITableFood
    {
        public Vector3 Position { get; }

        bool HasVisitor { get; set; }

        event Action ArriveFoodEvent;

        void ResetVisitor();
    }
}