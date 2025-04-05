using System.Collections.Generic;

namespace Root.Rak.BT
{
    public class SelectorNode : ACollectionNode
    {
        public SelectorNode()
            => _children = new List<ABTNode>();

        public SelectorNode(List<ABTNode> nodes)
            => _children = nodes;

        public override NodeStatus Tick()
        {
            foreach (var node in _children)
            {
                if (node.Tick() == NodeStatus.SUCCESS)
                    return NodeStatus.SUCCESS;

                else if (node.Tick() == NodeStatus.RUNNING)
                    return NodeStatus.RUNNING;
            }

            return NodeStatus.FAILURE;
        }
    }
}
