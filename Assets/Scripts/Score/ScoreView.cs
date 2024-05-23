using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _text;
    [Inject] private Score _score;

    public void Initialize()
    {
        Show();
        _score.ValueChanged += OnValueChanged;
    }

    public void OnValueChanged(int value)
    {
        Debug.Log("view");
        _text.text = value.ToString();
    }

    private void OnDisable()
    {
        _score.ValueChanged -= OnValueChanged;
    }
}
