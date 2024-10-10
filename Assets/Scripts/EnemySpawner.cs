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

    private IBehaviour _stateBehaviour;
    private IBehaviour _reactionBehaviour;

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

        DetermineStateBehaviour(spawnPoint.StateBehaviours, enemy);
        DetermineReactionBehaviour(spawnPoint.ReactionBehaviours, enemy);

        enemy.Initialize(_stateBehaviour, _reactionBehaviour);
    }

    private void DetermineStateBehaviour(StateBehaviours stateBehaviours, Enemy enemy)
    {
        switch (stateBehaviours)
        {
            case StateBehaviours.Idle:
                _stateBehaviour = new IdleState();
                break;
            case StateBehaviours.Patrol:
                _stateBehaviour = new PatrolState(_targetPoints, enemy);
                break;
            case StateBehaviours.Random:
                _stateBehaviour = new RandomState(enemy);
                break;
        }
    }

    private void DetermineReactionBehaviour(ReactionBehaviours reactionBehaviours, Enemy enemy)
    {
        switch (reactionBehaviours)
        {
            case ReactionBehaviours.AvoidPlayer:
                _reactionBehaviour = new AvoidReaction(enemy, _playerController);
                break;
            case ReactionBehaviours.Agressive:
                _reactionBehaviour = new AgressiveReaction(enemy, _playerController);
                break;
            case ReactionBehaviours.Scared:
                _reactionBehaviour = new ScaredReaction(enemy, _particleSystem);
                break;
        }
    }
}
