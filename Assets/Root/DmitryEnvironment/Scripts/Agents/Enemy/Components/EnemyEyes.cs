using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyEyes
    {
        public bool IsFreeze { get; set; }

        public bool IsDetect { get; private set; }

        private Transform _agent;

        private Transform _targetDetect;

        private float _range;

        private float _angleView;

        public EnemyEyes(Transform agent)
        {
            _agent = agent;

            IsFreeze = false;

            IsDetect = false;

            _range = 20;

            _angleView = 90;
        }

        public void Update()
        {
            Reset();

            if (IsFreeze) return;

            Detecting();
        }

        public void SetSearchTarget(Transform target)
            => _targetDetect = target;

        public void ClearSearchTarget()
            => _targetDetect = null;

        private void Reset()
            => IsDetect = false;

        private void Detecting()
        {
            if (_targetDetect == null) return;

            Debug.DrawRay(_agent.position, ((_targetDetect.position - _agent.position)).normalized * _range, Color.red);

            var directionToTarget = (_agent.position - _targetDetect.position);

            if (directionToTarget.sqrMagnitude < _range * _range)
            {
                var angle = Vector3.Angle(_agent.position, directionToTarget);

                if (angle < (_angleView / 2))
                {
                    IsDetect = true;
                }
            }
        }

    }
}