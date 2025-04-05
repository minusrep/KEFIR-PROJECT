using UnityEngine.AI;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorMotion
    {
        public bool HasReachedTarget { get; private set; }

        public bool IsFreeze
        {
            get => _controller.isStopped;

            set => _controller.isStopped = value;
        }

        private readonly NavMeshAgent _controller;

        private IVisitorTarget _target;

        public VisitorMotion(NavMeshAgent controller)
        {
            _controller = controller;

            IsFreeze = false;

            //InitConfig();
        }

        private void InitConfig()
        {
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

        public void SetTarget(IVisitorTarget target)
            => _target = target;

        private void Move()
            => _controller.SetDestination(_target.Position);

        private void CheckReachedDestination()
            => HasReachedTarget = !_controller.pathPending && _controller.remainingDistance <= _controller.stoppingDistance;
    }
}