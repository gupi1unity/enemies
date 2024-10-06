using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private StateBehaviours _stateBehaviours;
    [SerializeField] private ReactionBehaviours _reactionBehaviours;

    [SerializeField] private GameObject _enemyPrefab;
    private SwitchBehaviour _switchBehaviour;

    public void InstantiateEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);

        _switchBehaviour = GetComponent<SwitchBehaviour>();

        _switchBehaviour.Initialize(_stateBehaviours, _reactionBehaviours);
    }
}
