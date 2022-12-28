using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData 
{
    public string name;
    public Sprite sprite;
}

[System.Serializable]
public class BattleCard : CardData
{
    public int attackpoint;
    public int sepllpoint;
}

[CreateAssetMenu(fileName = "CardData", menuName = "Data/CardData")]
public class CardDataManager : ScriptableObject
{
    public CardData[] cards1;
    public BattleCard[] cards2;
}
