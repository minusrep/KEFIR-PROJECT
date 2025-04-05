using System.Collections.Generic;

namespace Root.Rak.BT
{
    public abstract class ACollectionNode : ABTNode
    {
        protected List<ABTNode> _children;

        public void AddNode()
            => _children.Add(this);

        public void Remove(ABTNode node)
            => _children.Remove(node);
    }
}
