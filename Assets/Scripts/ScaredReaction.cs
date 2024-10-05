using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredReaction : IReactionBehaviour
{
    private EnemySpawnPoint _enemy;
    private ParticleSystem _particleSystem;

    public ScaredReaction(EnemySpawnPoint enemy, ParticleSystem particleSystem)
    {
        _enemy = enemy;
        _particleSystem = particleSystem;
    }

    public void React()
    {
        _particleSystem.Play();
        _enemy.gameObject.SetActive(false);
    }
}
