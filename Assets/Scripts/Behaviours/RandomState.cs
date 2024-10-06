using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomState : IBehaviour
{
    private Enemy _enemy;

    private Vector3 _randomTarget;

    private float _minValue = -10f;
    private float _maxValue = 10f;

    private float _speed = 5f;

    public RandomState(Enemy enemy)
    {
        _enemy = enemy;
        CreateRandomTarget();
    }

    public void Update()
    {
        Vector3 distance = _randomTarget - _enemy.transform.position;
        Vector3 moveDirection = new Vector3(distance.x,0,distance.z);
        Vector3 moveDirectionNormalized = moveDirection.normalized;

        if (moveDirection.magnitude < 0.1f)
        {
            CreateRandomTarget();
        }

        _enemy.transform.Translate(moveDirectionNormalized * _speed * Time.deltaTime);
    }

    private void CreateRandomTarget()
    {
        float randomX = Random.Range(_minValue, _maxValue);
        float randomZ = Random.Range(_minValue, _maxValue);

        _randomTarget = new Vector3(randomX, 0, randomZ);
    }
}
