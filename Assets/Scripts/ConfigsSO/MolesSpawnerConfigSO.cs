using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/Moles Spawner Config", fileName = "Moles Spawner Config")]
public class MolesSpawnerConfigSO : ScriptableObject
{
    [field: SerializeField] public List<Mole> MolePrefabs { get; private set; } = new();
    [field: SerializeField] public int SpawnDelay { get; private set; }
}
