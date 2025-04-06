using System;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorMotion
    {
        public bool HasTarget { get; private set; }

        public bool HasReachedTarget { get; private set; }

        public bool IsFreeze
        {
            get => _controller.isStopped;

            set => _controller.isStopped = value;
        }

        private VisitorModel _model;
        private readonly NavMeshAgent _controller;

        private IVisitorTarget _target;

        public VisitorMotion(NavMeshAgent controller)
        {
            _controller = controller;

            IsFreeze = false;
        }

        public void SetModel(VisitorModel model)
        {
            _model = model;
        }

        public void Update()
        {
            HasReachedTarget = false;

            if (IsFreeze) return;

            if (_target == null) return;

            Move();

            if (_model.Status != VisitorStatus.OUT)
                Rotate();

            CheckReachedDestination();
        }

        public void ClearTarget()
        {
            _target = null;

            HasTarget = false;
        }

        public void SetTarget(IVisitorTarget target)
        {
            _target = target;

            HasTarget = true;
        }

        private void Move()
            => _controller.SetDestination(_target.Position);

        private void Rotate()
        {
            Vector3 directionToChair = _model.Table.Position - _controller.transform.position;
            directionToChair.y = 0;  // Игнорируем изменение по оси Y

            Quaternion rotation = Quaternion.LookRotation(directionToChair);
            _controller.transform.rotation = rotation;

        }

        private void CheckReachedDestination()
            => HasReachedTarget = !_controller.pathPending && _controller.remainingDistance <= _controller.stoppingDistance;
    }
}