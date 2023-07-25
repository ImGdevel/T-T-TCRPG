using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardComponent : HandCardComponent
{
    protected new BattleCard card;
    protected new BattleCard CardData { get { return card; } }

    protected override void UseCard() {
        BattleEventManager.Instance.CardUseEvent(CardData);
        base.UseCard();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (isSelected && other.tag == "Character") {
            isUseable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isUseable = false;
    }
}
