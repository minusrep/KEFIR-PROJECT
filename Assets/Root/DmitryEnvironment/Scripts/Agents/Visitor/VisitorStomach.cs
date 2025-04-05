using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorStomach : MonoBehaviour
    {
        public bool IsHungry => _isHungry;

        public bool _isHungry;

        private void Awake()
        {
            _isHungry = true;
        }

        public void Feed()
        {
            _isHungry = false;
        }
    }
}