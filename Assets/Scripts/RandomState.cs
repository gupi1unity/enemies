using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomState : IStateBehaviour
{
    private EnemySpawnPoint _enemy;

    private Vector3 _moveDirection;

    private float _minValue = 10;
    private float _maxValue = 20;

    public RandomState(EnemySpawnPoint enemy)
    {
        _enemy = enemy;
    }

    public void State()
    {
        float randomX = Random.Range(_minValue, _maxValue);
        float randomZ = Random.Range(_minValue, _maxValue);

        _moveDirection = new Vector3(randomX,0,randomZ).normalized;

        _enemy.transform.Translate(_moveDirection);
    }
}
