using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Root.MaximEnvironment;
using Root.Rak.BT;
using UnityEditor;
using UnityEngine;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorBrain
    {
        private readonly VisitorAnimator _animator;
        private readonly VisitorModel _model;
        private readonly VisitorMotion _motion;
        private readonly VisitorStomach _stomach;

        private SelectorNode _root;

        public VisitorBrain(VisitorAnimator animator, VisitorModel model, VisitorMotion motion, VisitorStomach stomach)
        {
            _animator = animator;
            _model = model;
            _motion = motion;

            _stomach = stomach;

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
            var hasNotTarget = new ConditionNode(() => !_motion.HasTarget);

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

            var switchStatus = new ActionNode(() =>
            {
                _model.Status = VisitorStatus.OUT;

                return NodeStatus.SUCCESS;
            });

            var clearTarget = new ActionNode(() =>
            {
                _motion.ClearTarget();

                return NodeStatus.SUCCESS;
            });

            var rotate = new ActionNode(() =>
            {
                _motion.Rotate();

                return NodeStatus.SUCCESS;
            });

            var makeOrder = new ActionNode(() =>
            {
                //TODO: Make Order

                _model.NotifyTable();

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {

                sidDownAnim,
                switchStatus,
                clearTarget,
                makeOrder,
                DebugNode("SidDown")
            });
        }

        private ABTNode BuildOutScenario()
        {
            var checkStatus = new ConditionNode(() => _model.Status == VisitorStatus.OUT);

            var isNotSidding = new ConditionNode(() => !_animator.IsSidding);

            return new SequenceNode(new List<ABTNode>
            {
                checkStatus,
                isNotSidding,
                BuildOutActions(),
            });
        }

        private ABTNode BuildOutActions()
        {
            return new SelectorNode(new List<ABTNode>
            {
                BuildWait(),
                //BuildLeaveTip(),
                BuildStandUp(),
                BuildMoveToHome()
            });
        }

        private ABTNode BuildWait()
        {
            var checkStomach = new ConditionNode(() => _stomach.IsHungry);

            return new SequenceNode(new List<ABTNode>
            {
                checkStomach,
                DebugNode("HUNGRY!")
            });
        }

        private ABTNode BuildLeaveTip()
        {
            throw new NotImplementedException();
        }

        private ABTNode BuildStandUp()
        {
            var isNotStadding = new ConditionNode(() => !_animator.IsStanding);
            
            var hasNotTarget = new ConditionNode(() => !_motion.HasTarget);

            var lockMotion = new ActionNode(() =>
            {
                _motion.IsFreeze = true;

                return NodeStatus.SUCCESS;
            });

            var standUpAnim = new ActionNode(() =>
            {
                _animator.StandUp();

                return NodeStatus.SUCCESS;
            });

            var goHome = new ActionNode(() =>
            {
                _model.GoHome();

                return NodeStatus.SUCCESS;
            });

            var upDollars = new ActionNode(() =>
            {
                CharacterStats.MoneyAmount += UnityEngine.Random.Range(500, 700);

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {
                isNotStadding,
                hasNotTarget,
                standUpAnim,
                lockMotion,
                goHome,
                upDollars
            });
        }


        private ABTNode BuildMoveToHome()
        {
            var hasNotReachedTarget = new ConditionNode(() => !_motion.HasReachedTarget);
            var isNotStadding = new ConditionNode(() => !_animator.IsStanding);

            var resetReservation = new ActionNode(() =>
            {
                _model.ResetReservation();

                return NodeStatus.SUCCESS;
            });

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
                isNotStadding,
                resetReservation,
                runAnimActive,
                motionActivate,
                DebugNode("MoveToHome")
            });
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

            var clearTarget = new ActionNode(() =>
            {
                _motion.ClearTarget();

                _motion.IsFreeze = true;

                return NodeStatus.SUCCESS;
            });

            return new SequenceNode(new List<ABTNode>
            {
                isNotDead,
                deadAction,
                deadAnim,
                clearTarget
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