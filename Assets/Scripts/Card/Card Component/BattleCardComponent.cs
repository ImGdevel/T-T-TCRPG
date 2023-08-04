using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardComponent : HandCardComponent
{
    protected override void UseCard() {
        Debug.Log("카드 사용됨");
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
                Debug.Log("올바른 대상입니다.");
                BattleEventManager.Instance.SelectCardTarget(target, cardTarget);
                isUseable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (isUseable) {
            Debug.Log("선택 헤제됨");
            BattleEventManager.Instance.UnselectCardTarget();
            isUseable = false;
        }
    }
}
