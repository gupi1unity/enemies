using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidReaction : IBehaviour
{
    private Enemy _enemy;
    private PlayerController _playerController;

    public AvoidReaction(Enemy enemy, PlayerController playerController)
    {
        _enemy = enemy;
        _playerController = playerController;
    }

    public void Update()
    {
        Vector3 direction = _enemy.transform.position - _playerController.transform.position;
        Vector3 moveDirection = new Vector3(direction.x,0,direction.z).normalized;

        _enemy.transform.Translate(moveDirection * Time.deltaTime);

    }
}
