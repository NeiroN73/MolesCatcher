using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private LevelHandler _levelHandler;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private ScoreView _scoreView;

    [SerializeField] private MolesSpawnerConfigSO _molesSpawnerConfigSO;
    [SerializeField] private GameboardConfigSO _gameboardConfigSO;
    [SerializeField] private CameraConfigSO _cameraConfigSO;
    [SerializeField] private HealthConfigSO _healthConfigSO;
    [SerializeField] private ScoreConfigSO _scoreConfigSO;
    [SerializeField] private TimerConfigSO _timerConfigSO;

    private ConditionFactory _conditionFactory = new();

    private IDefeatCondition _defeatCondition;
    private IVictoryCondition _victoryCondition;

    public void SetHealthCondition()
    {
        (_defeatCondition, _victoryCondition) = _conditionFactory.CreateHealthCondition(_healthConfigSO, _scoreConfigSO, _healthView, _scoreView);
        InitializeGame();
    }

    public void SetTimerCondition()
    {
        (_defeatCondition, _victoryCondition) = _conditionFactory.CreateTimerCondition(_timerConfigSO, _scoreConfigSO, _timerView, _scoreView);
        InitializeGame();
    }

    private void InitializeGame()
    {
        _gameBoard.Initialize(_gameboardConfigSO);
        var molesSpawner = new MolesSpawner(_gameBoard, _molesSpawnerConfigSO, _defeatCondition as Health, _victoryCondition as Score);
        var inputSystem = new InputSystem();
        new MolesCatcher(inputSystem);
        new CameraHandler(_gameBoard, _cameraConfigSO);

        _levelHandler.Initialize(_defeatCondition, _victoryCondition);
        _levelHandler.InitializeTickables(molesSpawner, inputSystem, _defeatCondition as Timer);
    }
}
