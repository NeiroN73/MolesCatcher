using TMPro;
using UnityEngine;

public class TimerView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimeChanged += OnChangedTime;
        OnChangedTime(_timer.TimerConfigSO.StartTime);
        Show();
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