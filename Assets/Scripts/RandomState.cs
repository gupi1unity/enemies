using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomState : IBehaviour
{
    private EnemySpawnPoint _enemy;

    private Vector3 _moveDirection;

    private float _minValue = -10f;
    private float _maxValue = 10f;

    public RandomState(EnemySpawnPoint enemy)
    {
        _enemy = enemy;
    }

    public void DoBehaviour()
    {
        float randomX = Random.Range(_minValue, _maxValue);
        float randomZ = Random.Range(_minValue, _maxValue);

        _moveDirection = new Vector3(randomX,0,randomZ).normalized;

        _enemy.transform.Translate(_moveDirection * Time.deltaTime);
    }
}
