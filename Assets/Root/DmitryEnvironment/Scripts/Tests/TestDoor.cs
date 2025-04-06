using Root.Rak.Agents;
using Root.Rak.Agents.Enemy;
using System;
using Root.MaximEnvironment;
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

        public float Cost => _cost;

        [SerializeField] private bool _isLife;

        [SerializeField] private float _health;

        [SerializeField] private TeamID _id;
        
        [SerializeField] private float _cost;

        private float _currentHealth;

        private void Start()
        {
            _isLife = true;

            _currentHealth = _health;

            Dead += () => DestroyEvent?.Invoke();
        }

        public void TakeDamage(IAttack attack)
        {
            Debug.Log("Damage DOOR");

            _currentHealth -= attack.Damage;

            if (_health <= 0)
            {
                _currentHealth = 0;

                _isLife = false;

                Dead?.Invoke();
            }
        }

        public void Build()
        {
            if (CharacterStats.MoneyAmount < Cost) return;
            
            CharacterStats.MoneyAmount -= Cost;
            
            _isLife = true;

            _currentHealth = _health;

            BuildedEvent?.Invoke();

            //TODO: Animate Building...
        }
        
        
    }
}