using TMPro;
using UnityEngine;

public class ScoreView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Initialize()
    {
        Show();
    }

    public void ChangeScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
