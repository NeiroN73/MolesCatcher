using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/Gameboard Config", fileName = "Gameboard Config")]
public class GameboardConfigSO : ScriptableObject
{
    [field: SerializeField] public int BoardSize { get; private set; }
    [field: SerializeField] public Hole HolePrefab { get; private set; }
}
