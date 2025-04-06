using Root.Rak.Agents.Visitor;
using UnityEngine;

namespace Root.Rak.Tests
{

    public class TestVisitorTargetsProvider : MonoBehaviour
    {
        [SerializeField] private TestVisitorTarget[] _targets;


        public TestVisitorTarget Home;

        public IVisitorTarget GetHome()
        {
            return Home;
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

        public bool CheckPlace(IVisitorTarget target)
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