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

        private ITarget _target;

        public EnemyMotion(NavMeshAgent controller, IEnemyMotionConfig config)
        {
            _controller = controller;

            _config = config;


            IsFreeze = false;

            //InitConfig();
        }

        private void InitConfig()
        {
            _controller.speed = _config.SpeedMotion;

            _controller.stoppingDistance = 2.0f;
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

        public void SetTarget(ITarget target)
            => _target = target;

        private void Move()
            => _controller.SetDestination(_target.Position);

        private void CheckReachedDestination()
            => HasReachedTarget = !_controller.pathPending && _controller.remainingDistance <= _controller.stoppingDistance;
    }
}