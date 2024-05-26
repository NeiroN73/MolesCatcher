using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    private RestartMenuView _restartMenuView;
    private EndGameMessageConfigSO _endGameMessageConfigSO;

    private TimeState _timeState;
    private List<ITickable> _tickables = new();
    private bool _isRestarting;

    public void Initialize(IDefeatCondition defeatCondition, IVictoryCondition victoryCondition,
        RestartMenuView restartMenuView, EndGameMessageConfigSO endGameMessageConfigSO)
    {
        defeatCondition.ConditionCompleted += OnDefeat;
        victoryCondition.ConditionCompleted += OnVictory;
        _restartMenuView = restartMenuView;
        _endGameMessageConfigSO = endGameMessageConfigSO;

        _restartMenuView.RestartClicked += OnLevelRestarted;

        _timeState = new();
    }

    public void InitializeTickables(MolesSpawner molesSpawner, InputSystem inputSystem, Timer timer)
    {
        _tickables.Add(molesSpawner);
        _tickables.Add(inputSystem);

        if(timer != null) 
            _tickables.Add(timer);
    }

    private void OnLevelRestarted()
    {
        if (_isRestarting)
            return;

        _isRestarting = true;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDefeat()
    {
        _restartMenuView.Initialize();
        _restartMenuView.SetEndGameText(_endGameMessageConfigSO.DefeatMessage);
        _timeState.Stop();
    }

    private void OnVictory()
    {
        _restartMenuView.Initialize();
        _restartMenuView.SetEndGameText(_endGameMessageConfigSO.VictoryMessage);
        _timeState.Stop();
    }

    private void OnDisable()
    {
        _restartMenuView.RestartClicked -= OnLevelRestarted;
    }

    private void Update()
    {
        for (int i = 0; i < _tickables.Count; i++)
        {
            _tickables[i].Tick();
        }
    }
}

