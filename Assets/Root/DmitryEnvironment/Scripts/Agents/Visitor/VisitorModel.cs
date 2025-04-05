namespace Root.Rak.Agents.Visitor
{

    public class VisitorModel
    {
        public bool HasTarget { get; private set; }

        public VisitorStatus Status { get; private set; }
        public bool IsLife { get; private set; }
        public bool IsDead { get; set; }

        public IVisitorTarget _target;
        

        public void SelectTarget()
        {
            //TODO: Select Target use Provider

            HasTarget = true;
        }
    }
}