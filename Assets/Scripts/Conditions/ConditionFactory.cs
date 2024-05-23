public class ConditionFactory
{
    public (IDefeatCondition, IVictoryCondition) CreateTimerCondition(TimerConfigSO timerConfigSO, ScoreConfigSO scoreConfigSO,
        TimerView timerView, ScoreView scoreView)
    {
        var timer = new Timer(timerConfigSO);
        var score = new Score(scoreConfigSO);
        timerView.Initialize(timer);
        scoreView.Initialize(score);
        return (timer, score);
    }

    public (IDefeatCondition, IVictoryCondition) CreateHealthCondition(HealthConfigSO healthConfigSO, ScoreConfigSO scoreConfigSO,
        HealthView healthView, ScoreView scoreView)
    {
        var health = new Health(healthConfigSO);
        var score = new Score(scoreConfigSO);
        healthView.Initialize(health);
        scoreView.Initialize(score);
        return (health, score);
    }
}