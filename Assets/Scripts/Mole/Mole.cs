using System;
using System.Collections;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] private MoleConfig _config;

    private int _currentHealth;

    public event Action<int> Catched;
    public event Action<int> Escaped;

    public void Initialize()
    {
        _currentHealth = _config.Health;

        StartCoroutine(EscapeTimer());
    }

    public void ApplyDamage()
    {
        _currentHealth--;

        if(_currentHealth <= 0)
        {
            Catched?.Invoke(_config.Health);
            PlayParticle(_config.CatchParticle);
            Destroy(gameObject);
        }
    }

    private IEnumerator EscapeTimer()
    {
        yield return new WaitForSeconds(_config.Time);
        Escaped?.Invoke(_config.Time);
        PlayParticle(_config.EcsapeParticle);
        Destroy(gameObject);
    }

    private void PlayParticle(ParticleSystem particle)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
