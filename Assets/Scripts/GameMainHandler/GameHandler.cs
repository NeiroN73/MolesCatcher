using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    None,
    HealthMode,
    TimerMode
}

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private MolesSpawner _molesSpawner;
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private Score _score;
    [SerializeField] private Health _health;
    [SerializeField] private Timer _timer;
    [SerializeField] private EndGameHandler _restartHandler;
    private InputSystem _inputSystem;
    private MolesContainer _molesContainer;
    private MolesCatcher _molesCatcher;
    private TimeState _timeState;
    private CameraHandler _cameraHandler;

    private GameMode _gameMode;

    private List<IUpdateable> _updates = new();
    private List<IDisposable> _disposables = new();

    private IEnumerator Start()
    {
        InitializeApp();
        Subscribes();
        yield return new WaitUntil(SetMode);
        InitializeGameplay();
    }

    private void InitializeApp()
    {
        _mainMenuView.Initialize();
        _timeState = new();
        _restartHandler.Initialize(_timeState);
        _molesContainer = new();
    }

    private void Subscribes()
    {
        _mainMenuView.HealthModeSelected += HealthMode;
        _mainMenuView.TimerModeSelected += TimerMode;
    }

    private bool SetMode()
    {
        switch(_gameMode)
        {
            case GameMode.HealthMode:
                _health.Initialize(_molesContainer, _restartHandler);
                _disposables.Add(_health);
                return true;

            case GameMode.TimerMode:
                _timer.Initialize(_restartHandler);
                _updates.Add(_timer);
                return true;

            default: 
                return false;
        }
    }

    private void HealthMode() => _gameMode = GameMode.HealthMode;
    private void TimerMode() => _gameMode = GameMode.TimerMode;


    private void InitializeGameplay()
    {
        _inputSystem = new();
        _molesCatcher = new(_inputSystem);
        _gameBoard.Initialize();
        _molesSpawner.Initialize(_gameBoard, _molesContainer);
        _score.Initialize(_molesContainer, _restartHandler);
        _cameraHandler = new(_gameBoard);

        _disposables.Add(_score);
        _disposables.Add(_molesCatcher);
        _disposables.Add(_restartHandler);

        _updates.Add(_inputSystem);
    }


    private void Update()
    {
        for(int i = 0; i < _updates.Count; i++)
        {
            _updates[i].Tick();
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < _disposables.Count; i++)
        {
            _disposables[i].Dispose();
        }

        Unsubscribes();
    }

    private void Unsubscribes()
    {
        _mainMenuView.HealthModeSelected -= HealthMode;
        _mainMenuView.TimerModeSelected -= TimerMode;
    }
}