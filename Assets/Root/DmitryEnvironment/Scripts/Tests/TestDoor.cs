using Root.Rak.Agents;
using Root.Rak.Agents.Enemy;
using System;
using UnityEngine;

namespace Root.Rak.Tests
{

    public class TestDoor : MonoBehaviour, ITarget, IEntityAttacked, IDoor
    {
        public event Action Dead;

        public event Action BuildedEvent;
        public event Action DestroyEvent;

        public TeamID ID => _id;
        public Vector3 Position => transform.position;
        public bool IsLife => _isLife;


        [SerializeField] private bool _isLife;

        [SerializeField] private float _health;

        [SerializeField] private TeamID _id;

        private void Start()
        {
            _isLife = true;

            Dead += () => DestroyEvent?.Invoke();
        }

        public void TakeDamage(IAttack attack)
        {
            Debug.Log("Damage DOOR");

            _health -= attack.Damage;

            if (_health <= 0)
            {
                _health = 0;

                _isLife = false;

                Dead?.Invoke();
            }
        }
    }
}