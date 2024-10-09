using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private List<Transform> _targets;
    private Queue<Vector3> _targetPoints = new Queue<Vector3>();

    private void Awake()
    {
        foreach (Transform target in _targets)
        {
            _targetPoints.Enqueue(target.position);
        }

        foreach (EnemySpawnPoint spawnPoint in _spawnPoints)
        {
            SpawnEnemy(spawnPoint);
        }
    }

    private void SpawnEnemy(EnemySpawnPoint spawnPoint)
    {
        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

        enemy.Initialize(spawnPoint.StateBehaviours, spawnPoint.ReactionBehaviours, _playerController, _particleSystem, new Queue<Vector3>(_targetPoints));
    }
}
