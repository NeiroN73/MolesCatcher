using UnityEngine;

[CreateAssetMenu(menuName = "Game Configs/End Game Message Config", fileName = "End Game Message Config")]
public class EndGameMessageConfigSO : ScriptableObject
{
    [field: SerializeField] public string VictoryMessage { get; private set; }
    [field: SerializeField] public string DefeatMessage { get; private set; }

}
