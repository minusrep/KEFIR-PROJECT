using Root.Rak.Agents.Enemy;
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

        private IVisitorTarget _place;

        private ITableFood _table;

        private float _health;

        public VisitorModel(TestVisitorTargetsProvider provider, VisitorMotion motion, VisitorStomach stomach, ITarget me)
        {
            _provider = provider;
            _motion = motion;

            _stomach = stomach;
            
            Status = VisitorStatus.IN;

            IsLife = true;

            _place = null;

            me.Dead += ResetReservation;

            _health = 10;
        }

        public bool TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0 && IsLife)
            {
                IsLife = false;

                _health = 0;

                return false;
            }

            return true;
        }

        public void SelectTarget()
        {

            if (!_provider.CheckPlace(ref _place)) return ;

            _motion.SetTarget(_place);

            _place.HasReservation = true;

            _place.Table.ArriveFoodEvent += _stomach.Feed;

            _table = _place.Table;
        }

        public void GoHome()
        {
            IVisitorTarget place = _provider.GetHome();

            if (place == null) return;

            _motion.SetTarget(place);
        }

        public void NotifyTable()
            => _table.HasVisitor = true;

        public void ResetReservation()
        {
            _place.HasReservation = false;

            _place.Table.ResetVisitor();
        }
    }
}