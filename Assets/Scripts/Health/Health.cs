using System;
using UnityEngine;

public class Health : IDisposable, IDefeatCondition
{
    private int _health;

    public event Action<int> HealthChanged;
    public event Action ConditionCompleted;

    public Health(HealthConfigSO healthConfigSO)
    {
        _health = healthConfigSO.StartHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health < 1)
        {
            _health = 0;
            ConditionCompleted?.Invoke();
        }
    }

    public void Dispose()
    {
        //_molesContainer.PlayerDamaged -= OnDamageApplied;
    }
}

public interface IDefeatCondition
{
    public event Action ConditionCompleted;
}

public interface IVictoryCondition
{
    public event Action ConditionCompleted;
}
