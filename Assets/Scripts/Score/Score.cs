using System;
using UnityEngine;

public class Score : MonoBehaviour, IDisposable
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private int _scoreForWin;
    [SerializeField] private float _catchRewardCoefficient;
    private MolesHandler _molesHandler;
    private EndGameHandler _restartHandler;

    private int _score;

    public void Dispose()
    {
        _molesHandler.MoleReward -= OnScoreAdded;
    }

    public void Initialize(MolesHandler molesHandler, EndGameHandler restartHandler)
    {
        _molesHandler = molesHandler;
        _restartHandler = restartHandler;

        _molesHandler.MoleReward += OnScoreAdded; //отписку

        _scoreView.Initialize();
        _scoreView.ChangeScore(_score);
    }

    private void OnScoreAdded(int reward)
    {
        var value = reward * _catchRewardCoefficient;
        _score += (int)value;
        _scoreView.ChangeScore(_score);

        TryWinGame();
    }

    private void TryWinGame()
    {
        if(_score >= _scoreForWin)
        {
            _restartHandler.WinGame();
        }
    }
}