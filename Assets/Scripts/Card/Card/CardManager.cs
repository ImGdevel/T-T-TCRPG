using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDatas", menuName = "Card/Cards")]
public class CardManager : ScriptableObject
{
    public BattleCardData[] cards;
}
