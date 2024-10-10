using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehaviour _stateBehaviour;
    private IBehaviour _reactionBehaviour;
    private IBehaviour _currentBehaviour;

    public void Initialize(IBehaviour stateBehaviour, IBehaviour reactionBehaviour)
    {
        _stateBehaviour = stateBehaviour;
        _reactionBehaviour = reactionBehaviour;

        _currentBehaviour = _stateBehaviour;
    }

    private void OnTriggerExit(Collider other)
    {
        _currentBehaviour = _stateBehaviour;
    }

    private void OnTriggerEnter(Collider other)
    {
        _currentBehaviour = _reactionBehaviour;
    }

    private void SetBehaviour(IBehaviour currentBehaviour)
    {
        _currentBehaviour = currentBehaviour;
    }

    private void Update()
    {
        _currentBehaviour.Update();
    }
}
