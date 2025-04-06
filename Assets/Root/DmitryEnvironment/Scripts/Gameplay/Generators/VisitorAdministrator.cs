using Root.Rak.Agents.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Root.Rak.Gameplay.Generators
{
    public class VisitorAdministrator : MonoBehaviour
    {
        private List<ITarget> _targets;

        public void Register(ITarget target)
        {
            if (_targets == null)
                _targets = new List<ITarget>();

            _targets.Add(target);
        }

        public void Unregister(ITarget target)
            => _targets.Remove(target); 

        public ITarget[] GetVisitors()
            => _targets.ToArray();
    }
}