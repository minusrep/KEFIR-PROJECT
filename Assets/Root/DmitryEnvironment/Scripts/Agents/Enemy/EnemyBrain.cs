using Root.Rak.BT;
using System.Collections.Generic;
using UnityEngine;

namespace Root.Rak.Agents.Enemy
{
    public class EnemyBrain
    {
        private readonly EnemyModel _model;
        private readonly EnemyAnimator _animator;
        private readonly EnemyMotion _motion;

        private SelectorNode _root;

        public EnemyBrain(EnemyModel model, EnemyAnimator animator, EnemyMotion motion)
        {
            _model = model;
            _animator = animator;
            _motion = motion;

            Build();
        }

        public void Update() 
            => _root.Tick();

        private void Build()
        {
            _root = new SelectorNode(new List<ABTNode>
            {
                BuildLife(),
                //BuildDead()
            });
        }

        private SequenceNode BuildLife()
        {
            var isLife = new ConditionNode(() => _model.IsLife);

            return new SequenceNode(new List<ABTNode>
            {
                isLife,
                BuildLifeAction()
            });
        }

        private SelectorNode BuildLifeAction()
        {
            return new SelectorNode(new List<ABTNode>
            {
                BuildSelectTarget(),
                BuildMoveToTarget(),
                BuildAttack()
            });
        }

        private ABTNode BuildSelectTarget()
        {
            var hasNotTarget = new ConditionNode(() => ! _model.HasTarget);

            var selectTarget = new ActionNode(() =>
            {
                _model.UpdateTarget();

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {
                hasNotTarget,
                selectTarget,
                DebugNode("Select Target")
            });

        }

        private ABTNode BuildMoveToTarget()
        {
            var hasNotReachedTarget = new ConditionNode(() => !_motion.HasReachedTarget);

            var isNotAttackProcess = new ConditionNode(() => !_animator.HasAttackProcessing);
            

            var runAnimActive = new ActionNode(() => 
            {
                _animator.Run();

                return NodeStatus.SUCCESS;
            });

            var motionActivate = new ActionNode(() =>
            {
                _motion.IsFreeze = false;

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {
                hasNotReachedTarget,
                isNotAttackProcess,
                runAnimActive,
                motionActivate,
                DebugNode("Move")
            });
        }

        private ABTNode BuildAttack()
        {
            var isNotAttackProcess = new ConditionNode(() => !_animator.HasAttackProcessing );

            var attackAnimActivate = new ActionNode(() =>
            {
                _animator.Attack();

                return NodeStatus.SUCCESS;
            });

            var motionLock = new ActionNode(() =>
            {
                _motion.IsFreeze = true;

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {
                isNotAttackProcess,
                attackAnimActivate,
                motionLock,
                DebugNode("Attack"),
            });
        }

        private ABTNode BuildDead()
        {
            return default(ABTNode);
        }

        public ActionNode DebugNode(string message)
        {
            return new ActionNode(() =>
            {
                Debug.Log(message);

                return NodeStatus.SUCCESS;
            });
        }
    }
}