using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyMotion
    {
        public bool HasReachedTarget { get; private set; }

        public bool IsFreeze
        {
            get => _controller.isStopped;

            set => _controller.isStopped = value;
        }

        private readonly NavMeshAgent _controller;

        private readonly IEnemyMotionConfig _config;

        private Transform _target;

        public EnemyMotion(NavMeshAgent controller, IEnemyMotionConfig config)
        {
            _controller = controller;

            _config = config;

            InitConfig();
        }

        private void InitConfig()
        {
            _controller.speed = _config.SpeedMotion;

            _controller.stoppingDistance = 2.0f;

            IsFreeze = false;
        }

        public void Update()
        {
            HasReachedTarget = false;

            if (IsFreeze) return;

            if (_target == null) return;

            Move();

            CheckReachedDestination();
        }

        public void ClearTarget()
            => _target = null;

        public void SetTarget(Transform target)
            => _target = target;

        private void Move()
            => _controller.SetDestination(_target.position);

        private void CheckReachedDestination()
            => HasReachedTarget = !_controller.pathPending && _controller.remainingDistance <= _controller.stoppingDistance;
    }
}