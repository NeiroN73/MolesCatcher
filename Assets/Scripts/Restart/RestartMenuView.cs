using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenuView : BaseUI
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _endGameText;

    public event Action OnRestartClicked;

    public void Initialize()
    {
        Show();

        _restartButton.onClick.AddListener(OnRestartClick);
    }

    private void OnRestartClick() => OnRestartClicked.Invoke();

    public void SetEndGameText(string text) => _endGameText.text = text;
}
