using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/Health Config", fileName = "Health Config")]
public class HealthConfigSO : ScriptableObject
{
    [field: SerializeField] public int StartHealth { get; private set; }
}
