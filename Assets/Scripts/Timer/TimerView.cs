using TMPro;
using UnityEngine;
using Zenject;

public class TimerView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _timerText;

    [Inject] private Timer _timer;

    public void Initialize()
    {
        Show();

        _timer.TimeChanged += OnChangedTime;
    }

    public void OnChangedTime(float time)
    {
        _timerText.text = time.ToString();
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= OnChangedTime;
    }
}