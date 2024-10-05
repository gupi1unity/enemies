using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover _mover;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = GetComponent<Mover>();
        _mover.Initialize(_characterController);
    }

    private void Update()
    {
        _mover.Move();
    }
}
