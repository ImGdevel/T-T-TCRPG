using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public string cardDescription;
}


[CreateAssetMenu(fileName = "New Battle Card", menuName = "Card/Battle Card")]
public class BattleCardData : CardData
{
    public int cost;
    public CardEffect[] effects;
}

[CreateAssetMenu(fileName = "New Exploration Card", menuName = "Card/Exploration Card")]
public class ExplorationCardData : CardData
{
    public int requiredSteps;
    public CardEffect[] effects;
}

[CreateAssetMenu(fileName = "New Artifact Card", menuName = "Card/Artifact Card")]
public class ArtifactCardData : CardData
{
    public CardEffect[] effects;
}