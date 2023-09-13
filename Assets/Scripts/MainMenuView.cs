using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseUI
{
    [SerializeField] private Button _healthModeButton;
    [SerializeField] private Button _timeModeButton;

    public event Action OnHealthMode;
    public event Action OnTimeMode;

    public void Initialize()
    {
        Show();

        _healthModeButton.onClick.AddListener(OnHealthModeClicked);
        _timeModeButton.onClick.AddListener(OnTimeModeClicked);
    }

    private void OnHealthModeClicked()
    {
        OnHealthMode.Invoke();
        Hide();
    }

    private void OnTimeModeClicked()
    {
        OnTimeMode.Invoke();
        Hide();
    }
}
