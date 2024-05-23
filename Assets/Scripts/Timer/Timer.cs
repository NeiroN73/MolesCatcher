using System;
using UnityEngine;
using Zenject;

public class Timer : ITickable, IDefeatCondition
{
    private float _timerProgress;

    public event Action TimeOver;
    public event Action<float> TimeChanged;
    public event Action ConditionCompleted;

    public Timer(TimerConfigSO timerConfigSO)
    {
        _timerProgress = timerConfigSO.StartTime;
    }

    public void Tick()
    {
        _timerProgress -= Time.deltaTime;
        TimeChanged?.Invoke(_timerProgress);

        if (_timerProgress <= 0)
        {
            _timerProgress = 0;
            TimeOver?.Invoke();
            ConditionCompleted?.Invoke();
        }
    }
}
