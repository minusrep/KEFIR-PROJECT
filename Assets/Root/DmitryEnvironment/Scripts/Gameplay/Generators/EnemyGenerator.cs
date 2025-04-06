using Root.Rak.Agents.Enemy;
using Root.Rak.Tests;
using System.Collections;
using UnityEngine;

namespace Root.Rak.Gameplay.Generators
{

    public class EnemyGenerator : MonoBehaviour
    {
        private const int MAX_RATIO = 60;
        private const int MIN_RATIO = 25;

        [SerializeField] private PointVisualizer _leftSpawnPoint;
        [SerializeField] private PointVisualizer _rightSpawnPoint;

        [SerializeField] private EnemyAgent _visitorPrefab;

        [SerializeField] private float _timeBetweenSpawn;

        [SerializeField] private int _maxAllCount;
        [SerializeField] private int _maxCount;
        [SerializeField] private int _minCount;

        #region Visitor Dependency
        [Header("Visitor Dependency")]
        [SerializeField] private TestTargetProvider _targetProvider;
        #endregion

        #region Generator Dependency
        [Header("Generator Dependency")]
        [SerializeField] private DoorsAdministrator _doorsAdministrator;
        #endregion

        private int _count;
        private bool _isActive;

        public void Start()
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
            yield return new WaitForSeconds(_timeBetweenSpawn);

            ConfiguratgeVisitor(CreateEnemy(_leftSpawnPoint.Position));

            ConfiguratgeVisitor(CreateEnemy(_rightSpawnPoint.Position));

            while (_isActive)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);

                for (int i = 0; i < 3; i++)
                {
                    if (_count == _maxCount) continue;

                    var startPosition = _leftSpawnPoint.Position;

                    if (_doorsAdministrator.GetDoorStatus() == DoorStatus.RIGHT)
                        startPosition = _rightSpawnPoint.Position;
                    else if (_doorsAdministrator.GetDoorStatus() == DoorStatus.FULL)
                        startPosition = Random.Range(0, 100) >= 50 ? _rightSpawnPoint.Position : _leftSpawnPoint.Position;

                    ConfiguratgeVisitor(CreateEnemy(startPosition));
                }
            }
        }
        private void ConfiguratgeVisitor(EnemyAgent enemy)
        {
            enemy.Construct(_targetProvider);

            enemy.AddListenerDead(DescreaseEnemy);
        }

        private EnemyAgent CreateEnemy(Vector3 startPosition)
        {
            _count++;

            return Instantiate(_visitorPrefab, startPosition, Quaternion.identity);
        }

        private void DescreaseEnemy()
            => _count--;

    }
}