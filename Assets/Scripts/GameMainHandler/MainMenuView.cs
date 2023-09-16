using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseUI
{
    [SerializeField] private Button _healthModeButton;
    [SerializeField] private Button _timerModeButton;

    public event Action HealthModeSelected;
    public event Action TimerModeSelected;

    public void Initialize()
    {
        Show();

        _healthModeButton.onClick.AddListener(OnHealthModeSelected);
        _timerModeButton.onClick.AddListener(OnTimeModeSelected);
    }

    private void OnHealthModeSelected()
    {
        HealthModeSelected.Invoke();
        Hide();
    }

    private void OnTimeModeSelected()
    {
        TimerModeSelected.Invoke();
        Hide();
    }
}
