using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IStateBehaviour
{
    private Queue<Vector3> _targetPoints;
    private Vector3 _currentTarget;

    private EnemySpawnPoint _enemy;

    public PatrolState(Queue<Vector3> targetPoints, EnemySpawnPoint enemy)
    {
        _enemy = enemy;
        _targetPoints = targetPoints;

        _currentTarget = _targetPoints.Dequeue();
    }

    public void State()
    {
        Vector3 distance = _currentTarget - _enemy.transform.position;
        Vector3 moveDireciton = new Vector3(distance.x,0,distance.z);

        if (distance.magnitude < 0.05f)
        {
            SwitchTarget();
        }

        _enemy.transform.Translate(moveDireciton);
    }

    private void SwitchTarget()
    {
        _targetPoints.Enqueue(_currentTarget);

        _currentTarget = _targetPoints.Dequeue();
    }
}
