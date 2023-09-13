using UnityEngine;

[CreateAssetMenu(fileName = "MoleConfig")]
public class MoleConfig : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _time;
    [SerializeField] private Material _material;

    public int Health { get => _health; }
    public int Time { get => _time; }
    public Material Material { get => _material; }
}
