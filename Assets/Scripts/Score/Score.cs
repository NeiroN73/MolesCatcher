using System;
using UnityEngine;

public class Score : IVictoryCondition
{
    private int _score = 0;
    public ScoreConfigSO ScoreConfigSO { get; }

    public event Action<int> ScoreChanged;
    public event Action ConditionCompleted;

    public Score(ScoreConfigSO scoreConfigSO)
    {
        ScoreChanged?.Invoke(_score);
        ScoreConfigSO = scoreConfigSO;
    }


    public void AddScore(int reward)
    {
        var value = reward * ScoreConfigSO.CatchingRewardCoefficient;
        _score += Mathf.CeilToInt(value);

        if (_score >= ScoreConfigSO.WinningScore)
        {
            ConditionCompleted?.Invoke();
        }

        ScoreChanged?.Invoke(_score);
    }
}
