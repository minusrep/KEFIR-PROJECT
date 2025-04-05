using System.Collections.Generic;

namespace Root.Rak.BT
{
    public class SequenceNode : ACollectionNode
    {
        public SequenceNode() 
            => _children = new List<ABTNode>();

        public SequenceNode(List<ABTNode> nodes) 
            => _children = nodes;

        public override NodeStatus Tick()
        {
            foreach (var node in _children)
            {
                var status = node.Tick();

                if (status == NodeStatus.FAILURE)
                    return NodeStatus.FAILURE;
                
                else if (status == NodeStatus.RUNNING)
                    return NodeStatus.RUNNING;
            }

            return NodeStatus.SUCCESS;
        }
    }
}
