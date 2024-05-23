using System;
using UnityEngine;

public class Score : IDisposable, IVictoryCondition
{
    private int _score = 0;

    private ScoreConfigSO _scoreConfigSO;

    public Score(ScoreConfigSO scoreConfigSO)
    {
        _scoreConfigSO = scoreConfigSO;
    }

    public event Action<int> ValueChanged;
    public event Action ConditionCompleted;

    public void AddScore(int reward)
    {
        var value = reward * _scoreConfigSO.CatchingRewardCoefficient;
        _score += Mathf.CeilToInt(value);
        ValueChanged?.Invoke(_score);

        if (_score >= _scoreConfigSO.WinningScore)
        {
            ConditionCompleted?.Invoke();
        }
    }

    public void Dispose()
    {
        //_molesContainer.MoleCatchingReward -= OnScoreAdded;
    }
}
