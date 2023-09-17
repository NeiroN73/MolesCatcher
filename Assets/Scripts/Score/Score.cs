using System;
using UnityEngine;

public class Score : MonoBehaviour, IDisposable
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private int _winningScore;
    [SerializeField] private float _catchingRewardCoefficient;

    private MolesContainer _molesContainer;
    private EndGameHandler _endGameHandler;
    private int _score;

    public void Initialize(MolesContainer molesHandler, EndGameHandler restartHandler)
    {
        _molesContainer = molesHandler;
        _endGameHandler = restartHandler;

        _molesContainer.MoleCatchingReward += OnScoreAdded;

        _scoreView.Initialize();
        _scoreView.ChangeScore(_score);
    }

    private void OnScoreAdded(int reward)
    {
        var value = reward * _catchingRewardCoefficient;
        _score += (int)value;
        _scoreView.ChangeScore(_score);

        if (_score >= _winningScore)
        {
            _endGameHandler.WinGame();
        }
    }

    public void Dispose()
    {
        _molesContainer.MoleCatchingReward -= OnScoreAdded;
    }
}