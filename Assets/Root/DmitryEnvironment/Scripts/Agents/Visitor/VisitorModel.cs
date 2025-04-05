using System;
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
            IVisitorTarget place;

            if (!_provider.CheckPlace(out place)) return ;

            _motion.SetTarget(place);
        }

        public void GoHome()
        {
            IVisitorTarget place = _provider.GetHome();

            if (place == null) return;

            _motion.SetTarget(place);
        }
    }
}