using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenuView : BaseUI
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _endGameText;

    public event Action RestartClicked;

    public void Initialize()
    {
        Show();
        _restartButton.onClick.AddListener(OnRestartClicked);
    }

    private void OnRestartClicked() => RestartClicked.Invoke();

    public void SetEndGameText(string text) => _endGameText.text = text;
}
