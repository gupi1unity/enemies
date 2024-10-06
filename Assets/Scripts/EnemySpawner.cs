using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

    private void Awake()
    {
        foreach (EnemySpawnPoint spawnPoint in _spawnPoints)
        {
            spawnPoint.InstantiateEnemy();
        }
    }
}
