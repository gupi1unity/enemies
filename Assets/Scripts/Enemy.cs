using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController _playerController;
    private ParticleSystem _particleSystem;
    private Queue<Vector3> _targetPoints;

    private IBehaviour _currentBehaviour;

    private StateBehaviours _stateBehaviours;
    private ReactionBehaviours _reactionBehaviours;

    public void Initialize(StateBehaviours stateBehaviours, ReactionBehaviours reactionBehaviours, PlayerController playerController, ParticleSystem particleSystem, Queue<Vector3> targetPoints)
    {
        _stateBehaviours = stateBehaviours;
        _reactionBehaviours = reactionBehaviours;
        _playerController = playerController;
        _particleSystem = particleSystem;
        _targetPoints = targetPoints;

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

    private void SetBehaviour(IBehaviour currentBehaviour)
    {
        _currentBehaviour = currentBehaviour;
    }

    private void Update()
    {
        _currentBehaviour.Update();
    }

    private void DetermineStateBehaviour()
    {
        switch (_stateBehaviours)
        {
            case StateBehaviours.Idle:
                SetBehaviour(new IdleState());
                break;
            case StateBehaviours.Patrol:
                SetBehaviour(new PatrolState(_targetPoints, this));
                break;
            case StateBehaviours.Random:
                SetBehaviour(new RandomState(this));
                break;
        }
    }

    private void DetermineReactionBehaviour()
    {
        switch (_reactionBehaviours)
        {
            case ReactionBehaviours.AvoidPlayer:
                SetBehaviour(new AvoidReaction(this, _playerController));
                break;
            case ReactionBehaviours.Agressive:
                SetBehaviour(new AgressiveReaction(this, _playerController));
                break;
            case ReactionBehaviours.Scared:
                SetBehaviour(new ScaredReaction(this, _particleSystem));
                break;
        }
    }
}
