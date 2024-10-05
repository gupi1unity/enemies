using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private CharacterController _characterController;
    private Vector3 _inputVector;

    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    public void Initialize(CharacterController characterController)
    {
        _characterController = characterController;
    }

    private void Update()
    {
        HandleMoveDirection();
    }

    private void HandleMoveDirection()
    {
        float horizontal = Input.GetAxisRaw(HorizontalAxisName);
        float vertical = Input.GetAxisRaw(VerticalAxisName);

        _inputVector = new Vector3(horizontal,0,vertical).normalized;
    }

    public void Move()
    {
        _characterController.Move(_inputVector * Time.deltaTime * _speed);
    }
}
