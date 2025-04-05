using Root.Rak.Agents;
using Root.Rak.Agents.Enemy;
using System;
using UnityEngine;

namespace Root.Rak.Tests
{
    public class TestDoor : MonoBehaviour, ITarget, IEntityAttacked
    {
        public event Action Dead;

        public TeamID ID => _id;
        public Vector3 Position => transform.position;

        [SerializeField] private bool _isDead;

        [SerializeField] private float _health;

        [SerializeField] private TeamID _id;

        private void Start()
        {
            _isDead = true;
        }

        public void TakeDamage(IAttack attack)
        {
            _health -= attack.Damage;

            if (_health < 0)
            {
                _health = 0;

                _isDead = false;

                Dead?.Invoke();
            }
        }
    }
}