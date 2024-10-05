using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private List<Transform> _targets;

    [SerializeField] private StateBehaviours _stateBehaviours;
    [SerializeField] private ReactionBehaviours _reactionBehaviours;

    private Queue<Vector3> _targetPoints;

    private IStateBehaviour _stateBehaviour;
    private IReactionBehaviour _reactionBehaviour;

    private PlayerController _playerController;

    public void Start()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

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
            case ReactionBehaviours.Scared:
                _reactionBehaviour = new ScaredReaction(this, _particleSystem);
                break;
            case ReactionBehaviours.Agressive:
                _reactionBehaviour = new AgressiveReaction(this, _playerController);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            _playerController = playerController;
            _reactionBehaviour.React();
        }
    }

    private void Update()
    {
        _stateBehaviour.State();
    }

}
