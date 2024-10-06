using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IBehaviour
{
    private Queue<Vector3> _targetPoints;
    private Vector3 _currentTarget;

    private EnemySpawnPoint _enemy;

    private float _speed = 5f;

    public PatrolState(Queue<Vector3> targetPoints, EnemySpawnPoint enemy)
    {
        _enemy = enemy;
        _targetPoints = targetPoints;

        _currentTarget = _targetPoints.Dequeue();
    }

    public void DoBehaviour()
    {
        Vector3 distance = _currentTarget - _enemy.transform.position;
        Vector3 moveDireciton = new Vector3(distance.x,0,distance.z);
        Vector3 moveDirectionNormalized = moveDireciton.normalized;

        if (moveDireciton.magnitude < 0.1f)
        {
            SwitchTarget();
        }

        _enemy.transform.Translate(moveDirectionNormalized * _speed * Time.deltaTime);
    }

    private void SwitchTarget()
    {
        _targetPoints.Enqueue(_currentTarget);

        _currentTarget = _targetPoints.Dequeue();
    }
}
