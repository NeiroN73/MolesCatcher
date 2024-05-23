using System.ComponentModel;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private MainMenuView _mainMenuView;

    [SerializeField] private MolesSpawnerConfigSO _molesSpawnerConfigSO;
    [SerializeField] private GameboardConfigSO _gameboardConfigSO;

    [SerializeField] private HealthConfigSO _healthConfigSO;
    [SerializeField] private ScoreConfigSO _scoreConfigSO;
    [SerializeField] private TimerConfigSO _timerConfigSO;

    [SerializeField] private HealthView _healthView;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private ScoreView _scoreView;

    private DefeatCondition _defeatCondition;
    private VictoryCondition _victoryCondition;
    private Level _level;

    private Health _health;
    private Score _score;
    private Timer _timer;

    public override void InstallBindings()
    {
        Container.Bind<Level>().AsSingle();
        Container.BindInstance(_gameBoard).AsSingle();
        Container.BindInterfacesAndSelfTo<MolesSpawner>().AsSingle();
        Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle();
        Container.BindInterfacesAndSelfTo<MolesCatcher>().AsSingle();

        Container.BindInstance(_molesSpawnerConfigSO).AsSingle();
        Container.BindInstance(_gameboardConfigSO).AsSingle();
        Container.BindInstance(_healthConfigSO).AsSingle();
        Container.BindInstance(_scoreConfigSO).AsSingle();
        Container.BindInstance(_timerConfigSO).AsSingle();

        Container.BindInterfacesAndSelfTo<Health>().AsSingle();
        Container.BindInterfacesAndSelfTo<Timer>().AsSingle();
        Container.BindInterfacesAndSelfTo<Score>().AsSingle();
    }

    private void OnEnable()
    {
        _mainMenuView.HealthModeSelected += OnSetHealthMode;
        _mainMenuView.TimerModeSelected += OnSetTimerMode;

    }

    private void OnDisable()
    {
        _mainMenuView.HealthModeSelected -= OnSetHealthMode;
        _mainMenuView.TimerModeSelected -= OnSetTimerMode;
    }

    private void OnSetHealthMode()
    {
        StartGame();
        _health = new Health(_healthConfigSO);
        _score = new Score(_scoreConfigSO);
        _healthView.Initialize();
        _scoreView.Initialize();
        //_defeatCondition = _health;
        //_victoryCondition = _score;
        Container.QueueForInject(_health);
        Container.QueueForInject(_score);
    }

    private void OnSetTimerMode()
    {
        StartGame();
        _timer = new Timer(_timerConfigSO);
        _score = new Score(_scoreConfigSO);
        _timerView.Initialize();
        _scoreView.Initialize();
        //_defeatCondition = _timer;
        //_victoryCondition = _score;
        Container.QueueForInject(_timer);
        Container.QueueForInject(_score);
    }

    private void StartGame()
    {
        var level = new Level();
        _gameBoard.Initialize(_gameboardConfigSO);
        var molesSpawner = new MolesSpawner(_gameBoard, _molesSpawnerConfigSO);
        var inputSystem = new InputSystem();
        var molesCatcher = new MolesCatcher(inputSystem);
        var cameraHandler = new CameraHandler(_gameBoard);

    }

    private void SetDefeatCondition(DefeatCondition condition) => _defeatCondition = condition;

    private void SetVictoryCondition(VictoryCondition condition) => _victoryCondition = condition;
}
