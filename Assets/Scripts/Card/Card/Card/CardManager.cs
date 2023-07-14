using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card List", menuName = "Card/Card List")]
public class CardList : ScriptableObject
{
    public BattleCardData[] cards;
}
