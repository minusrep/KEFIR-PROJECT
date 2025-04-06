using Root.MaximEnvironment;
using Root.Rak.Agents;
using Root.Rak.Agents.Visitor;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestVisitorTarget : MonoBehaviour, IVisitorTarget
    {
        public bool HasReservation { get; set; }

        public Vector3 Position => transform.position;

        public ITableFood Table => _tableFood;

        public Quaternion Rotation => transform.rotation;

        [SerializeField] private GuestTable _tableFood;

    }
}