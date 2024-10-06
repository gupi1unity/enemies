using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredReaction : IBehaviour
{
    private Enemy _enemy;
    private ParticleSystem _particleSystem;

    public ScaredReaction(Enemy enemy, ParticleSystem particleSystem)
    {
        _enemy = enemy;
        _particleSystem = particleSystem;
    }

    public void Update()
    {
        _particleSystem.transform.position = _enemy.transform.position;

        _particleSystem.Play();
        _enemy.gameObject.SetActive(false);
    }
}
