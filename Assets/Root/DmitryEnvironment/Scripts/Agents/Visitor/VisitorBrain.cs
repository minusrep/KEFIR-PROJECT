using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Root.Rak.BT;
using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorBrain
    {
        private readonly VisitorAnimator _animator;
        private readonly VisitorModel _model;
        private readonly VisitorMotion _motion;

        private SelectorNode _root;

        public VisitorBrain(VisitorAnimator animator, VisitorModel model, VisitorMotion motion)
        {
            _animator = animator;
            _model = model;
            _motion = motion;

            Build();
        }

        public void Update()
        {
            _root.Tick();
        }

        public void Build()
        {
            _root = new SelectorNode(new List<ABTNode>
            {
                BuildLife(),
                BuildDeath()
            });
        }

        public ABTNode BuildLife()
        {
            var isLife = new ConditionNode(() => _model.IsLife);

            return new SequenceNode(new List<ABTNode> 
            {
                isLife,
                BuildLifeAction(),
            });
        }

        public ABTNode BuildLifeAction()
        {
            return new SelectorNode(new List<ABTNode>
            {
                BuildInScenario(),
                BuildOutScenario()
            });
        }

        private ABTNode BuildInScenario()
        {
            var isInActive = new ConditionNode(() => _model.Status == VisitorStatus.IN);

            return new SequenceNode(new List<ABTNode>
            {
                isInActive,
                BuildInActions()
            });
        }

        private ABTNode BuildInActions()
        {
            return new SelectorNode(new List<ABTNode>
            {
                BuildSelectTarget(),
                BuildMoveToTarget(),
                BuildSidDown()
            });
        }

        private ABTNode BuildSelectTarget()
        {
            var hasNotTarget = new ConditionNode(() => !_model.HasTarget);

            var selectTarget = new ActionNode(() =>
            {
                _model.SelectTarget();

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

            var runAnimActive = new ActionNode(() =>
            {
                _animator.Walk();

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
                runAnimActive,
                motionActivate,
                DebugNode("Move")
            });
        }


        private ABTNode BuildSidDown()
        {
            var isNotSidding = new ConditionNode(() => !_animator.IsSidding);

            var sidDownAnim = new ActionNode(() =>
            {
                _animator.SidDown();

                return NodeStatus.SUCCESS;
            });

            var makeOrder = new ActionNode(() =>
            {
                //TODO: Make Order

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {

                sidDownAnim,
                makeOrder
            });
        }

        private ABTNode BuildOutScenario()
        {
            throw new NotImplementedException();
        }

        public ABTNode BuildDeath()
        {
            var isNotDead = new ConditionNode(() => !_model.IsLife && !_model.IsDead);

            var deadAction = new ActionNode(() => 
            {
                _model.IsDead = true;
                
                return NodeStatus.SUCCESS;
            });

            var deadAnim = new ActionNode(() => 
            {
                _animator.Dead();
                
                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {
                isNotDead,
                deadAction,
                deadAnim,
            });
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