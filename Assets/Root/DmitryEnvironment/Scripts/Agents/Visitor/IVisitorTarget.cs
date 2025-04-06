using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public interface IVisitorTarget
    {
        public bool HasReservation { get; set; }

        public Vector3 Position { get; }

        public ITableFood Table {  get; }
    }
}