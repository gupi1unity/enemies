using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] public GameObject _enemyPrefab;

    private IBehaviour _currentBehaviour;

    private void Awake()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
    }

    private void Update()
    {
        _currentBehaviour.DoBehaviour();
    }

    public void SetBehaviour(IBehaviour targetBehaviour)
    {
        _currentBehaviour = targetBehaviour;
    }

}
