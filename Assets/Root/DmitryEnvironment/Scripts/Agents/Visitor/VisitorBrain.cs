using Root.Rak.BT;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorBrain
    {
        private SelectorNode _root;

        public void Build()
        {
            _root = new SelectorNode(new List<ABTNode>
            {

            });
        }
    }
}