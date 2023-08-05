using UnityEngine;

[CreateAssetMenu(fileName = "New Battle Card", menuName = "Card/Battle Card")]
public class BattleCardData : CardData
{
    public int cardCost;
    public Target cardTarget;
    public CardEffect[] effects;
    
}
