using TMPro;
using UnityEngine;

public class HealthView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _healthText;

    public void Initialize()
    {
        Show();
    }

    public void ChangeHealth(int score)
    {
        _healthText.text = score.ToString();
    }
}
