using System;
using UnityEngine;

public class Timer : ITickable, IDefeatCondition
{
    private float _timerProgress;

    public TimerConfigSO TimerConfigSO { get; }

    public event Action<float> TimeChanged;
    public event Action ConditionCompleted;

    public Timer(TimerConfigSO timerConfigSO)
    {
        _timerProgress = timerConfigSO.StartTime;
        TimeChanged?.Invoke(_timerProgress);
        TimerConfigSO = timerConfigSO;
    }

    public void Tick()
    {
        _timerProgress -= Time.deltaTime;

        if (_timerProgress <= 0)
        {
            _timerProgress = 0;
            ConditionCompleted?.Invoke();
        }

        TimeChanged?.Invoke(_timerProgress);

    }
}
