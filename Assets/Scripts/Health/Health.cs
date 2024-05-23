using System;

public class Health : IDefeatCondition
{
    private int _health;

    public HealthConfigSO HealthConfigSO { get; }

    public event Action<int> HealthChanged;
    public event Action ConditionCompleted;

    public Health(HealthConfigSO healthConfigSO)
    {
        _health = healthConfigSO.StartHealth;
        HealthConfigSO = healthConfigSO;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 1)
        {
            _health = 0;
            ConditionCompleted?.Invoke();
        }

        HealthChanged?.Invoke(_health);
    }
}
