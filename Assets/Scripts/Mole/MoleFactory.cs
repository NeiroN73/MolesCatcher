using UnityEngine;

public class MoleFactory
{
    public Mole GetMole(Mole prefab, Vector3 spawnPosition)
    {
        return Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
