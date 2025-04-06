using Root.Rak.Agents.Visitor;
using Root.Rak.Tests;
using System.Collections;
using UnityEngine;

namespace Root.Rak.Gameplay.Generators
{

    public class VisitorGenerator : MonoBehaviour
    {
        private const int MAX_RATIO = 60;
        private const int MIN_RATIO = 25;

        [SerializeField] private VisitorAdministrator _administrator;

        [SerializeField] private PointVisualizer _startPoint;

        [SerializeField] private VisitorAgent _visitorPrefab;

        [SerializeField] private float _timeBetweenSpawn;

        [SerializeField] private int _maxAllCount;
        [SerializeField] private int _maxCount;
        [SerializeField] private int _minCount;

        #region Visitor Dependency
        [Header("Visitor Dependency")]
        [SerializeField] private TestVisitorTargetsProvider _visitorProvider;

        #endregion

        private int _count;
        private bool _isActive;

        public void Awake()
        {
            _maxCount = (_maxAllCount * MAX_RATIO) / 100;

            _minCount = (_maxAllCount * MIN_RATIO) / 100;

            Run();
        }

        public void Run()
        {
            _isActive = true;

            StartCoroutine(Generating());
        }

        public void Stop()
        {
            _isActive = false;
        }

        private IEnumerator Generating()
        {
            for (int i = 0; i < _minCount; i++)
            {
                ConfiguratgeVisitor(CreateVisitor());

                yield return null;
            }

            while (_isActive)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);

                if (_count == _maxCount) continue;

                ConfiguratgeVisitor(CreateVisitor());
            }
        }
        private void ConfiguratgeVisitor(VisitorAgent visitor)
        {
            visitor.Construct(_visitorProvider);

            visitor.Dead += DescreaseVisitor;

            _administrator.Register(visitor);
        }

        private VisitorAgent CreateVisitor()
        {
            _count++;

            return Instantiate(_visitorPrefab, _startPoint.Position, Quaternion.identity);
        }

        private void DescreaseVisitor()
        {
            _count--;
        }

    }
}