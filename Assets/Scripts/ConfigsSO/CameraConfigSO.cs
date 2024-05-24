using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/Camera Config", fileName = "Camera Config")]
public class CameraConfigSO : ScriptableObject
{
    [field: SerializeField] public float CameraHeightOffset { get; private set; }
}
