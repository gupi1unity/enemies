using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private List<Transform> _targets;

    [SerializeField] private StateBehaviours _stateBehaviours;
    [SerializeField] private ReactionBehaviours _reactionBehaviours;

    private IStateBehaviour _stateBehaviour;
    private IReactionBehaviour _reactionBehaviour;

    private Queue<Vector3> _targetPoints = new Queue<Vector3>();

    private void Awake()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);

        foreach (Transform target in _targets)
        {
            _targetPoints.Enqueue(target.position);
        }

        switch (_stateBehaviours)
        {
            case StateBehaviours.Default:
                _stateBehaviour = new DefaultState();
                break;
            case StateBehaviours.Patrol:
                _stateBehaviour = new PatrolState(_targetPoints, this);
                break;
            case StateBehaviours.Random:
                _stateBehaviour = new RandomState(this);
                break;
        }

        switch (_reactionBehaviours)
        {
            case ReactionBehaviours.AvoidPlayer:
                _reactionBehaviour = new AvoidReaction(this, _playerController);
                break;
            case ReactionBehaviours.Agressive:
                _reactionBehaviour = new AgressiveReaction(this, _playerController);
                break;
            case ReactionBehaviours.Scared:
                _reactionBehaviour = new ScaredReaction(this, _particleSystem);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _reactionBehaviour.React();
    }

    private void Update()
    {
        _stateBehaviour.State();
    }

}
