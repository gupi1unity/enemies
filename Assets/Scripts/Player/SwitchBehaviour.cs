using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private EnemySpawnPoint _enemy;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private StateBehaviours _stateBehaviours;
    [SerializeField] private ReactionBehaviours _reactionBehaviours;

    [SerializeField] private List<Transform> _targets;
    private Queue<Vector3> _targetPoints;

    private void Awake()
    {
        _enemy = GetComponent<EnemySpawnPoint>();

        _targetPoints = new Queue<Vector3>();

        foreach (Transform target in _targets)
        {
            _targetPoints.Enqueue(target.position);
        }

        DetermineStateBehaviour();
    }

    private void OnTriggerEnter(Collider other)
    {
        DetermineReactionBehaviour();
    }

    private void OnTriggerExit(Collider other)
    {
        DetermineStateBehaviour();
    }

    private void DetermineStateBehaviour()
    {
        switch (_stateBehaviours)
        {
            case StateBehaviours.Default:
                _enemy.SetBehaviour(new DefaultState());
                break;
            case StateBehaviours.Patrol:
                _enemy.SetBehaviour(new PatrolState(_targetPoints, _enemy));
                break;
            case StateBehaviours.Random:
                _enemy.SetBehaviour(new RandomState(_enemy));
                break;
        }
    }

    private void DetermineReactionBehaviour()
    {
        switch (_reactionBehaviours)
        {
            case ReactionBehaviours.AvoidPlayer:
                _enemy.SetBehaviour(new AvoidReaction(_enemy, _playerController));
                break;
            case ReactionBehaviours.Agressive:
                _enemy.SetBehaviour(new AgressiveReaction(_enemy, _playerController));
                break;
            case ReactionBehaviours.Scared:
                _enemy.SetBehaviour(new ScaredReaction(_enemy, _particleSystem));
                break;
        }
    }
}
