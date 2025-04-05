using Root.Rak.Tests;

namespace Root.Rak.Agents.Visitor
{
    public class VisitorModel
    {
        public VisitorStatus Status { get; set; }
        public bool IsLife { get; private set; }
        public bool IsDead { get; set; }

        private readonly TestVisitorTargetsProvider _provider;

        private readonly VisitorMotion _motion;
        private readonly VisitorStomach _stomach;

        public VisitorModel(TestVisitorTargetsProvider provider, VisitorMotion motion, VisitorStomach stomach)
        {
            _provider = provider;
            _motion = motion;

            _stomach = stomach;
            
            Status = VisitorStatus.IN;

            IsLife = true;
            IsDead = false;
        }

        public void SelectTarget()
        {
            IVisitorTarget place;

            if (!_provider.CheckPlace(out place)) return ;

            _motion.SetTarget(place);

            place.Table.ArriveFoodEvent += _stomach.Feed;
        }

        public void GoHome()
        {
            IVisitorTarget place = _provider.GetHome();

            if (place == null) return;

            _motion.SetTarget(place);
        }
    }
}