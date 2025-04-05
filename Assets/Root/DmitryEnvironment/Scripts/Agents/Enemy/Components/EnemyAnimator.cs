using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyAnimator
    {
        public bool HasAttackProcessing { get; private set; }
       
        private readonly Animator _stateMachine;

        private readonly int IsRunHash = Animator.StringToHash("IsRun");
        private readonly int IsAttackHash = Animator.StringToHash("IsBaseAttack");
        private readonly int IsDeadHash = Animator.StringToHash("IsDead");

        public EnemyAnimator(Animator stateMachine, IChildrenAnimatorHandler animatorHandler)
        {
            _stateMachine = stateMachine;
            
            RegisterEvents(animatorHandler);
        }

        public void Idle() 
            => _stateMachine.SetBool(IsRunHash, false);

        public void Run()
            => _stateMachine.SetBool(IsRunHash, true);

        public void Attack()
        {
            HasAttackProcessing = true;

            _stateMachine.SetTrigger(IsAttackHash);
        }

        public void Dead() 
            => _stateMachine.SetTrigger(IsDeadHash);

        private void RegisterEvents(IChildrenAnimatorHandler animatorHandler)
            => animatorHandler.EndAttackEvent += EndAttackHandler;

        private void EndAttackHandler()
        {
            Debug.Log("End Attack");
            HasAttackProcessing = false;
        }
    }
}