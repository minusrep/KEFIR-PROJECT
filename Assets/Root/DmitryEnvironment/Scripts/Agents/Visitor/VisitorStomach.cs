namespace Root.Rak.Agents.Visitor
{
    public class VisitorStomach
    {
        public bool IsHungry { get; private set; }

        public void Feed()
        {
            IsHungry = false;
        }
    }
}