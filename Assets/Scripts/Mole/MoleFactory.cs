using UnityEngine;

public class MoleFactory
{
    public Mole GetMole(Mole prefab, Vector3 spawnPosition)
    {
        var mole = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
        mole.Initialize();

        return mole;
    }
}
