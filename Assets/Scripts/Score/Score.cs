using UnityEngine;

public class Score : BaseUI
{
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private int _scoreForWin;
    private MolesHandler _molesHandler;
    private EndGameHandler _restartHandler;

    private int _score;

    public void Initialize(MolesHandler molesHandler, EndGameHandler restartHandler)
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
