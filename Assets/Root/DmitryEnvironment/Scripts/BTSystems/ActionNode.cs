using System;

namespace Root.Rak.BT
{
    public class ActionNode : ABTNode
    {
        private Func<NodeStatus> _action;

        public ActionNode(Func<NodeStatus> action) 
            => _action = action;

        public override NodeStatus Tick()
            => _action.Invoke();
    }
}
