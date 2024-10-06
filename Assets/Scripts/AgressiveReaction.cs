using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveReaction : IBehaviour
{
    private EnemySpawnPoint _enemy;
    private PlayerController _playerController;

    public AgressiveReaction(EnemySpawnPoint enemy, PlayerController playerController)
    {
        _enemy = enemy;
        _playerController = playerController;
    }

    public void DoBehaviour()
    {
        Vector3 direction = _playerController.transform.position - _enemy.transform.position;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.z).normalized;

        _enemy.transform.Translate(moveDirection * Time.deltaTime);
    }
}
