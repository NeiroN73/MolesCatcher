using TMPro;
using UnityEngine;

public class TimerView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void Initialize()
    {
        Show();
    }

    public void ChangeTime(float time)
    {
        _timerText.text = time.ToString(); // use textBuilder
    }
}