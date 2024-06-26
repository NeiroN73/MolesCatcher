﻿using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Configs/Mole Config", fileName = "Mole Config")]
public class MoleConfig : ScriptableObject
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Time { get; private set; }
    [field: SerializeField] public ParticleSystem EcsapeParticle { get; private set; }
    [field: SerializeField] public ParticleSystem CatchParticle { get; private set; }
}
