using Root.Rak.Agents.Enemy;
using Root.Rak.Tests;
using UnityEngine;

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

        public ITableFood Table;

        private float _health;

        private Collider _collider;

        public VisitorModel(TestVisitorTargetsProvider provider, VisitorMotion motion, VisitorStomach stomach, ITarget me, Collider collider)
        {
            _provider = provider;
            _motion = motion;

            _stomach = stomach;

            _collider = collider;
            
            Status = VisitorStatus.IN;

            IsLife = true;

            _place = null;

            me.Dead += ResetReservation;

            _health = 10;

            motion.SetModel(this);
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

            Table = _place.Table;
        }

        public void GoHome()
        {
            IVisitorTarget place = _provider.GetHome();

            if (place == null) return;

            _motion.SetTarget(place);
        }

        public void NotifyTable()
            => Table.HasVisitor = true;

        public void ResetReservation()
        {
            if (_place != null)
            {
                _place.HasReservation = false;

                _place.Table.ResetVisitor();

                _place = null;
            }

            _collider.enabled = false;
        }
    }
}