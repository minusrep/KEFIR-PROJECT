using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public interface IVisitorTarget
    {
        public bool HasReservation { get; }

        public Vector3 Position { get; }
    }
}