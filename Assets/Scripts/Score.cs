using UnityEngine;

public class Score : BaseUI
{
    [SerializeField] private ScoreView _scoreView;
    private MolesHandler _molesHandler;
    private RestartHandler _restartHandler;

    private int _score;

    public void Initialize(MolesHandler molesHandler, RestartHandler restartHandler)
    {
        _molesHandler = molesHandler;
        _restartHandler = restartHandler;

        Show();

        molesHandler.MoleReward += OnScoreAdded; //отписку

        _scoreView.Initialize();
        _scoreView.ChangeScore(_score);
    }

    private void OnScoreAdded(int reward)
    {
        _score += reward;
        _scoreView.ChangeScore(_score);
    }
}
