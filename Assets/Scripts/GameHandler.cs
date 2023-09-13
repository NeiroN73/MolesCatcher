using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private MolesSpawner _molesSpawner;
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private Score _score;
    [SerializeField] private Health _health;
    [SerializeField] private Timer _timer;
    [SerializeField] private InputSystem _inputSystem; // think about it
    [SerializeField] private RestartHandler _restartHandler;
    private MolesHandler _molesHandler;
    private MolesCatcher _molesCatcher;
    private TimeState _timeState;

    private List<IUpdateable> _updates = new();

    public void Initialize()
    {
        _mainMenuView.Initialize();
        _restartHandler.Initialize();
        _molesHandler = new();
        _timeState = new();

        _mainMenuView.OnHealthMode += HealthMode;
        _mainMenuView.OnTimeMode += TimeMode;
    }

    private void HealthMode()
    {
        _health.Initialize(_molesHandler, _restartHandler);
        StartGame();
    }

    private void TimeMode()
    {
        _timer.Initialize(_restartHandler, _timeState);
        _updates.Add(_timer);
        StartGame();
    }

    private void StartGame()
    {
        _molesCatcher = new(_inputSystem);
        _gameBoard.Initialize();
        _molesSpawner.Initialize(_gameBoard, _molesHandler);
        _score.Initialize(_molesHandler, _restartHandler);
    }

    private void Start()
    {
        for (int i = 0; i < _updates.Count; i++)
        {
            //_updates[i].CloseUpdate += RemoveUpdate;
        }
    }

    private void Update()
    {
        for(int i = 0; i < _updates.Count; i++)
        {
            _updates[i].Tick();
        }
    }

    private void RemoveUpdate(IUpdateable update)
    {
        _updates.Remove(update);
    }
}