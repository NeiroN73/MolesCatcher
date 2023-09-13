using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour, IUpdateable
{
    private RestartHandler _restartHandler;
    private TimeState _timeState;

    [SerializeField] private TimerView _timerView;

    [SerializeField] private int _gameTime;
    private float _timerProgress;

    public event Action<IUpdateable> CloseUpdate;

    public void Initialize(RestartHandler restartHandler, TimeState timeState)
    {
        _restartHandler = restartHandler;
        _timeState = timeState;

        _timerView.Initialize();

        _timerProgress = _gameTime;
    }

    public void Tick()
    {
        _timerProgress -= Time.deltaTime;
        _timerView.ChangeTime(_timerProgress);

        if (_timerProgress <= 0)
        {
            _restartHandler.LoseGame();
            _timeState.Stop();
            _timerProgress = _gameTime;
        }
    }
}
