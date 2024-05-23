using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private RestartMenuView _restartMenuView;
    [SerializeField] private EndGameMessageConfigSO _endGameMessageConfigSO;

    private TimeState _timeState;
    private List<ITickable> _tickables = new();
    private bool _isRestarting;

    public void Initialize(IDefeatCondition defeatCondition, IVictoryCondition victoryCondition)
    {
        defeatCondition.ConditionCompleted += OnDefeat;
        victoryCondition.ConditionCompleted += OnVictory;

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
        if (_tickables.Count <= 0)
            return;

        for (int i = 0; i < _tickables.Count; i++)
        {
            _tickables[i].Tick();
        }
    }
}

