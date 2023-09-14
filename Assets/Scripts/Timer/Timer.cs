﻿using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour, IUpdateable
{
    private EndGameHandler _restartHandler;

    [SerializeField] private TimerView _timerView;

    [SerializeField] private int _gameTime;
    private float _timerProgress;

    public void Initialize(EndGameHandler restartHandler)
    {
        _restartHandler = restartHandler;

        _timerView.Initialize();

        _timerProgress = _gameTime;
    }

    public void Tick()
    {
        _timerProgress -= Time.deltaTime;
        _timerView.ChangeTime(_timerProgress);

        if (_timerProgress < 0)
        {
            _timerProgress = 0;
            _restartHandler.LoseGame();
        }
    }
}