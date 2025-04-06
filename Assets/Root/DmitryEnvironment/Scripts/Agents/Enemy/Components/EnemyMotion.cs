using System;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyMotion
    {
        public bool HasReachedTarget { get; private set; }

        public bool IsFreeze
        {
            get => !_controller.enabled || _controller.isStopped;

            set => _controller.isStopped = value;
        }

        private readonly NavMeshAgent _controller;

        private readonly Collider _collider;

        private ITarget _target;

        public EnemyMotion(NavMeshAgent controller, Collider collider)
        {
            _controller = controller;

            IsFreeze = false;

            _collider = collider;
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

        public void LockNavMesh()
        {
            _controller.enabled = false;

            _collider.enabled = false;
        }
    }
}