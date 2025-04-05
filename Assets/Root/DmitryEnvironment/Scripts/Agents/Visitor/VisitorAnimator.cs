using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorAnimator
    {
        public bool IsSidding { get; private set; }
        public bool IsStanding { get; private set; }
        
        private readonly Animator _stateMachine;

        private readonly int IsWalkHash = Animator.StringToHash("IsWalk");
        private readonly int IsSidDownHash = Animator.StringToHash("IsSidDown");
        private readonly int IsStandUpHash = Animator.StringToHash("IsStandUp");
        private readonly int IsDeadHash = Animator.StringToHash("IsDead");

        public VisitorAnimator(Animator stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Walk() 
            => _stateMachine.SetBool(IsWalkHash, true);

        public void Dead() 
            => _stateMachine.SetTrigger(IsDeadHash);

        public void SidDown()
        {
            IsSidding = true;

            _stateMachine.SetTrigger(IsSidDownHash);
        }

        public void StandUp()
        {
            IsStanding = true;

            _stateMachine.SetTrigger(IsStandUpHash);
        }

        public void EndSidDownHandler()
            => IsSidding = false;

        public void EndStandUpHandler()
            => IsStanding = false;
    }
}