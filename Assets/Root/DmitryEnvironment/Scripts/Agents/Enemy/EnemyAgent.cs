using UnityEngine;
using UnityEngine.AI;

namespace Root.Rak.Agents.Enemy
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class EnemyAgent : MonoBehaviour
    {
        private EnemyAnimator _animator;

        private EnemyMotion _motion;

        private EnemyModel _model;

        private EnemyBrain _brain;

        public void Start()
        {
            _animator = new EnemyAnimator(GetComponent<Animator>(), GetComponentInChildren<ChildrenAnimatorHandler>());

            _motion = new EnemyMotion(GetComponent<NavMeshAgent>(), null);

            _model = new EnemyModel();

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