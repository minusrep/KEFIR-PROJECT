using Root.Rak.Agents.Visitor;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestVisitorTarget : MonoBehaviour, IVisitorTarget
    {
        public bool HasReservation { get; set; }

        public Vector3 Position => transform.position;
    }
}