using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    private PlayerController _playerController;
    private Enemy _enemy;

    private ParticleSystem _particleSystem;

    private StateBehaviours _stateBehaviours;
    private ReactionBehaviours _reactionBehaviours;

    private List<Transform> _targets;
    private Queue<Vector3> _targetPoints;

    public void Initialize(StateBehaviours stateBehaviours, ReactionBehaviours reactionBehaviours, PlayerController playerController, ParticleSystem particleSystem, List<Transform> targets)
    {
        _stateBehaviours = stateBehaviours;
        _reactionBehaviours = reactionBehaviours;

        _playerController = playerController;
        _particleSystem = particleSystem;
        _targets = targets;

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
            case StateBehaviours.Idle:
                _enemy.SetBehaviour(new IdleState());
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
