using Root.Rak.Tests;
using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAgent : MonoBehaviour
    {
        public TestTargetProvider TargetProvider;

        public Animator Anim;

        public ChildrenAnimatorHandler AnimHandler;

        private EnemyAnimator _animator;

        private EnemyMotion _motion;

        private EnemyModel _model;

        private EnemyBrain _brain;

        public void Start()
        {
            _animator = new EnemyAnimator(Anim, AnimHandler);

            _motion = new EnemyMotion(GetComponent<NavMeshAgent>(), null);

            _model = new EnemyModel(TargetProvider, _motion, transform);

            _brain = new EnemyBrain(_model, _animator, _motion);
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