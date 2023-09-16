using System;
using UnityEngine;

public class Score : MonoBehaviour, IDisposable
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private int _winningScore;
    [SerializeField] private float _catchingRewardCoefficient;

    private MolesHandler _molesHandler;
    private EndGameHandler _endGameHandler;
    private int _score;

    public void Initialize(MolesHandler molesHandler, EndGameHandler restartHandler)
    {
        _molesHandler = molesHandler;
        _endGameHandler = restartHandler;

        _molesHandler.MoleCatchingReward += OnScoreAdded; //отписку

        _scoreView.Initialize();
        _scoreView.ChangeScore(_score);
    }

    private void OnScoreAdded(int reward)
    {
        var value = reward * _catchingRewardCoefficient;
        _score += (int)value;
        _scoreView.ChangeScore(_score);

        TryWinGame();
    }

    private void TryWinGame()
    {
        if(_score >= _winningScore)
        {
            _endGameHandler.WinGame();
        }
    }

    public void Dispose()
    {
        _molesHandler.MoleCatchingReward -= OnScoreAdded;
    }
}