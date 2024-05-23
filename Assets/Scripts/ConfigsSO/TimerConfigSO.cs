using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/Timer Config", fileName = "Timer Config")]
public class TimerConfigSO : ScriptableObject
{
    [field: SerializeField] public int StartTime { get; private set; }
}
