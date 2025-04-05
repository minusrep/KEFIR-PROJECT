using Root.Rak.Agents.Visitor;
using UnityEngine;

namespace Root.Rak.Tests
{

    public class TestVisitorTargetsProvider : MonoBehaviour
    {
        [SerializeField] private TestVisitorTarget[] _targets;

        public IVisitorTarget RequestTarget()
        {
            IVisitorTarget place;

            if (CheckPlace(out place))
                return place;

            place = null;

            return place;
        }

        public bool CheckPlace()
        {
            for (int i = 0; i < _targets.Length; i++)
            {
                if (!_targets[i].HasReservation)
                    return true;
            }

            return false;
        }

        public bool CheckPlace(out IVisitorTarget target)
        {
            target = null;

            for (int i = 0; i < _targets.Length; i++)
            {
                if (!_targets[i].HasReservation)
                {
                    target = _targets[i];

                    return true;
                }
            }

            return false;
        }
    }
}