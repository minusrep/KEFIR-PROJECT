using Root.Rak.Tests;

namespace Root.Rak.Agents.Visitor
{

    public class VisitorModel
    {
        public bool HasTarget { get; private set; }

        public VisitorStatus Status { get; private set; }
        public bool IsLife { get; private set; }
        public bool IsDead { get; set; }

        private readonly TestVisitorTargetsProvider _provider;

        private readonly VisitorMotion _motion;

        public VisitorModel(TestVisitorTargetsProvider provider, VisitorMotion motion)
        {
            _provider = provider;
            _motion = motion;

            Status = VisitorStatus.IN;

            IsLife = true;
            IsDead = false;
        }

        public void SelectTarget()
        {
            IVisitorTarget place = _provider.RequestTarget();

            if (place == null) return;

            _motion.SetTarget(place);

            HasTarget = true;
        }
    }
}