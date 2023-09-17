using UnityEngine;

public class Timer : MonoBehaviour, IUpdateable
{
    [SerializeField] private TimerView _timerView;
    [SerializeField] private int _gameTime;

    private EndGameHandler _endGameHandler;
    private float _timerProgress;

    public void Initialize(EndGameHandler restartHandler)
    {
        _endGameHandler = restartHandler;

        _timerView.Initialize();

        _timerProgress = _gameTime;
    }

    public void Tick()
    {
        _timerProgress -= Time.deltaTime;
        _timerView.ChangeTime(_timerProgress);

        if (_timerProgress < 0)
        {
            _timerProgress = 0;
            _endGameHandler.LoseGame();
        }
    }
}
