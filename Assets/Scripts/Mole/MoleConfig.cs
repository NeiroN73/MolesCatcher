using UnityEngine;

[CreateAssetMenu(fileName = "MoleConfig")]
public class MoleConfig : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Time { get; private set; }
    [field: SerializeField] public Mole Prefab { get; private set; }

    public Mole GetMole(Vector3 spawnPosition)
    {
        return Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}
