using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDatas", menuName = "Data/Cards")]
public class CardManager : ScriptableObject
{
    public Card[] cards1;
    public BattleCard[] cards;
}
