using Root.Rak.Tests;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Enemy
{


    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAgent : MonoBehaviour, IEntityAttacked
    {
        public TestTargetProvider TargetProvider;

        public Animator Anim;

        public ChildrenAnimatorHandler AnimHandler;

        public ChildTriggerHandler AttackTriggerHandler;

        private EnemyAnimator _animator;

        private EnemyAttaker _attacker;

        private EnemyMotion _motion;

        private EnemyModel _model;


        private EnemyBrain _brain;

        public TeamID ID { get; private set; } = TeamID.AGENT;

        public void Start()
        {
            _animator = new EnemyAnimator(Anim, AnimHandler);

            _attacker = new EnemyAttaker(AttackTriggerHandler, ID);

            _motion = new EnemyMotion(GetComponent<NavMeshAgent>(), null);

            _model = new EnemyModel(TargetProvider, _motion, transform);

            _brain = new EnemyBrain(_model, _animator, _motion, _attacker);
        }

        public void TakeDamage(IAttack attack)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            _motion.Update();

            _brain.Update();
        }
    }

/*    public class EnemyAvatar
    {

    }

    public class EnemyAttacker
    {
        
    }*/
}