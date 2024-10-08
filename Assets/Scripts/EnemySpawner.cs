using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private List<Transform> _targets;

    private void Awake()
    {
        foreach (EnemySpawnPoint spawnPoint in _spawnPoints)
        {
            SpawnEnemy(spawnPoint);
        }
    }

    private void SpawnEnemy(EnemySpawnPoint spawnPoint)
    {
        GameObject enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

        SwitchBehaviour switchBehaviour = enemy.GetComponent<SwitchBehaviour>();

        switchBehaviour.Initialize(spawnPoint.StateBehaviours, spawnPoint.ReactionBehaviours, _playerController, _particleSystem, _targets);
    }
}
