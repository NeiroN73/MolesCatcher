using TMPro;
using UnityEngine;

public class HealthView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private Health _health;

    public void Initialize(Health health)
    {
        _health = health;
        _health.HealthChanged += OnHealthChanged;
        OnHealthChanged(_health.HealthConfigSO.StartHealth);
        Show();
    }

    public void OnHealthChanged(int score)
    {
        _healthText.text = score.ToString();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
}
