using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card 
{
    public string name;
    public Sprite sprite;
    public int cost;
}

[System.Serializable]
public class BattleCard : Card
{
    public Description description;
}

[System.Serializable]
public class Description
{
    public int point;
    public int data;
    public string status;

    public string printDescription() {
        return point + "Æ÷ÀÎÆ®";
    }
}


[CreateAssetMenu(fileName = "CardData", menuName = "Data/CardData")]
public class CardData : ScriptableObject
{
    public Card[] cards1;
    public BattleCard[] cards;
}
