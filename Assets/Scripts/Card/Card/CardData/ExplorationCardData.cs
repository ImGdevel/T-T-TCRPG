using UnityEngine;

[CreateAssetMenu(fileName = "Exploration Card", menuName = "Card/Exploration Card")]
public class ExplorationCardData : CardData
{
    public int requiredSteps;
    public CardEffect[] effects;
}