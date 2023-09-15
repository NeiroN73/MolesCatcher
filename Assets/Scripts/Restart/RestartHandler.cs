using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour, IDisposable
{
    private TimeState _timeState;
    [SerializeField] private RestartMenuView _restartMenuView;
    [SerializeField] private string _winMessage;
    [SerializeField] private string _loseMessage;

    public void Initialize(TimeState timeState)
    {
        _timeState = timeState;

        _restartMenuView.OnRestartClicked += RestartLevel;
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        _restartMenuView.Initialize();
        _restartMenuView.SetEndGameText(_winMessage);
        _timeState.Stop();
    }

    public void LoseGame()
    {
        _restartMenuView.Initialize();
        _restartMenuView.SetEndGameText(_loseMessage);
        _timeState.Stop();
    }

    public void Dispose()
    {
        _restartMenuView.OnRestartClicked -= RestartLevel;
    }
}
