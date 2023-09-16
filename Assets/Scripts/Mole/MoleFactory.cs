using UnityEngine;

[CreateAssetMenu(fileName = "MoleFactory")]
public class MoleFactory : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Time { get; private set; }
    [field: SerializeField] public Mole Prefab { get; private set; }
    [field: SerializeField] public ParticleSystem EcsapeParticle { get; private set; }
    [field: SerializeField] public ParticleSystem CatchParticle { get; private set; }

    public Mole GetMole(Vector3 spawnPosition)
    {
        return Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}
