using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private DefeatCondition _defeatCondition;
    private VictoryCondition _victoryCondition;

    private Level _level;
    private MainMenuView _mainMenuView;

    private void Start()
    {

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
        //SetDefeatCondition(new Health());
        //SetVictoryCondition(new Score());
        StartGame();
    }

    private void OnSetTimerMode()
    {
        //SetDefeatCondition(new Timer());
        //SetVictoryCondition(new Score());
        StartGame();
    }

    private void StartGame()
    {
        //_level = new();
    }

    private void SetDefeatCondition(DefeatCondition condition) => _defeatCondition = condition;

    private void SetVictoryCondition(VictoryCondition condition) => _victoryCondition = condition;
}
