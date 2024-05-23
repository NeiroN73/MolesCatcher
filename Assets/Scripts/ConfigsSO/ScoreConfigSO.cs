using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/Score Config", fileName = "Score Config")]
public class ScoreConfigSO : ScriptableObject
{
    [field: SerializeField] public int WinningScore { get; private set; }
    [field: SerializeField] public float CatchingRewardCoefficient { get; private set; }
}
