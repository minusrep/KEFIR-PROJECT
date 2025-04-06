using Root.Rak.Agents.Enemy;
using Root.Rak.Tests;
using TMPro;

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

        private IVisitorTarget _place;

        private float _health;

        public VisitorModel(TestVisitorTargetsProvider provider, VisitorMotion motion, VisitorStomach stomach, ITarget me)
        {
            _provider = provider;
            _motion = motion;

            _stomach = stomach;
            
            Status = VisitorStatus.IN;

            IsLife = true;
            IsDead = false;

            _place = null;

            me.Dead += ResetReservation;

            _health = 100;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health < 0 && IsLife)
            {
                IsLife = false;
            }
        }

        public void SelectTarget()
        {

            if (!_provider.CheckPlace(ref _place)) return ;

            _motion.SetTarget(_place);

            _place.HasReservation = true;

            _place.Table.ArriveFoodEvent += _stomach.Feed;
        }

        public void GoHome()
        {
            IVisitorTarget place = _provider.GetHome();

            if (place == null) return;

            _motion.SetTarget(place);
        }

        public void ResetReservation()
        {
            _place.HasReservation = false;

            _place.Table.ResetVisitor();
        }
    }
}