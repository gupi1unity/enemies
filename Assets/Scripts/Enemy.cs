using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IBehaviour _currentBehaviour;

    public void SetBehaviour(IBehaviour currentBehaviour)
    {
        _currentBehaviour = currentBehaviour;
    }

    private void Update()
    {
        //_currentBehaviour.Update();
    }
}
