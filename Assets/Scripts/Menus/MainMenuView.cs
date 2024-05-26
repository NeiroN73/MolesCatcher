using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseUI
{
    [SerializeField] private Button _healthModeButton;
    [SerializeField] private Button _timerModeButton;

    public event Action HealthModeSelected;
    public event Action TimerModeSelected;

    public void Start()
    {
        Show();

        _healthModeButton.onClick.AddListener(SetHealthCondition);
        _timerModeButton.onClick.AddListener(SetTimerCondition);
    }

    private void SetHealthCondition()
    {
        HealthModeSelected.Invoke();
        Hide();
    }

    private void SetTimerCondition()
    {
        TimerModeSelected.Invoke();
        Hide();
    }
}
