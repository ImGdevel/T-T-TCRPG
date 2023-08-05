using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardComponent : HandCardComponent
{
    protected override void UseCard() {
        BattleEventManager.Instance.CardUseEvent((BattleCard)CardData);
        base.UseCard();
    }

    /// <summary>
    /// 카드 정보를 설정합니다.
    /// </summary>
    /// <param name="card">설정할 카드 정보</param>
    public override void Setup(Card card) {
        base.Setup(card);
        this.card = card as BattleCard;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (isSelected && other.tag == "Character") {
            BattleCharacterComponent target = other.transform.GetComponent<BattleCharacterComponent>();
            Target cardTarget = ((BattleCard)CardData).Target;
            if (cardTarget.Type == target.CharacterType) {
                isUseable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (isUseable) {
            isUseable = false;
        }
    }
}
