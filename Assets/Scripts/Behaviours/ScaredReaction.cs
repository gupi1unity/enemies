using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredReaction : IBehaviour
{
    private EnemySpawnPoint _enemy;
    private ParticleSystem _particleSystem;

    public ScaredReaction(EnemySpawnPoint enemy, ParticleSystem particleSystem)
    {
        _enemy = enemy;
        _particleSystem = particleSystem;
    }

    public void DoBehaviour()
    {
        _particleSystem.transform.position = _enemy.transform.position;

        _particleSystem.Play();
        _enemy.gameObject.SetActive(false);
    }
}
