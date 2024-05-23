using UnityEngine;
using Zenject;

public class Level
{
    private DefeatCondition _defeatCondition;
    private VictoryCondition _victoryCondition;


    [Inject]
    private void Construct(IDefeatCondition defeat, IVictoryCondition victory)
    {
        //defeatCondition.ConditionCompleted += OnDefeat;
        //victoryCondition.ConditionCompleted += OnVictory;
        defeat.ConditionCompleted += OnDefeat;
        victory.ConditionCompleted += OnVictory;

        Debug.Log("asdfasfgasdfgasd");
    }

    private void StartGame()
    {

    }

    private void OnDefeat()
    {
        Debug.Log("Defeat");

    }

    private void OnVictory()
    {
        Debug.Log("Victory");

    }
}

