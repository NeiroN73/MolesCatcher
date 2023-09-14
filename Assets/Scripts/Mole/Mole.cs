﻿using System;
using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private MoleConfig _config;

    private int _currentHealth;

    public event Action<Mole, int> MoleCatched;
    public event Action<Mole, int> MoleEscaped;

    public void Initialize()
    {
        _currentHealth = _config.Health;

        StartCoroutine(Delay());
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            MoleCatched?.Invoke(this, _config.Health);
            Destroy(gameObject);
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_config.Time);
        MoleEscaped?.Invoke(this, _config.Time);
        Destroy(gameObject);
    }
}
