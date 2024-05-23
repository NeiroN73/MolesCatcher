using TMPro;
using UnityEngine;

public class ScoreView : BaseUI
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private Score _score;

    public void Initialize(Score score)
    {
        _score = score;
        _score.ScoreChanged += OnScoreChanged;
        OnScoreChanged(0);
        Show();
    }

    public void OnScoreChanged(int value)
    {
        _scoreText.text = value.ToString();
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }
}
