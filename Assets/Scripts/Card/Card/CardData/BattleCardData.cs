using UnityEngine;

[CreateAssetMenu(fileName = "Battle Card", menuName = "Card/Battle Card")]
public class BattleCardData : CardData
{
    public int cardCost;
    public CardEffect[] effects;
}
