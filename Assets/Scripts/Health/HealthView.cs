using TMPro;
using UnityEngine;
using Zenject;

public class HealthView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _healthText;

    [Inject] private Health _health;

    public void Initialize()
    {
        Show();
        _health.HealthChanged += OnHealthChanged;
    }

    public void OnHealthChanged(int score)
    {
        Debug.Log("healthChanged");
        _healthText.text = score.ToString();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;

    }
}
