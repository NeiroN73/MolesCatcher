using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseUI
{
    [SerializeField] private Installer _installer;

    [SerializeField] private Button _healthModeButton;
    [SerializeField] private Button _timerModeButton;

    public void Start()
    {
        Show();

        _healthModeButton.onClick.AddListener(SetHealthCondition);
        _timerModeButton.onClick.AddListener(SetTimerCondition);
    }

    private void SetHealthCondition()
    {
        _installer.SetHealthCondition();
        Hide();
    }

    private void SetTimerCondition()
    {
        _installer.SetTimerCondition();
        Hide();
    }
}
