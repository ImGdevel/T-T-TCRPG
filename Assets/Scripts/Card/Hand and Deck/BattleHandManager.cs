using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandManager : HandManager
{


    /// <summary>
    /// 캐릭터 사용 조건에 맞는 카드만 플레이어의 손에서 사용 가능하도록 활성화합니다.
    /// </summary>
    public void EnableCardsByCondition(Character character) {
        // 조건에 맞는 카드만 사용 가능하도록 활성화합니다.
        // 조건을 인자로 받아와 해당 조건이 충족되면 카드를 활성화합니다.

        // 우선 캐릭터 행동력보다 낮은 카드 비활성화
        // 직업 카드가 아닌경우 비활성화

        foreach (GameObject item in hands) {
            BattleCardComponent card = item.transform.GetComponent<BattleCardComponent>();
            BattleCard battleCard = (BattleCard)(card.CardData);
            int requiredCost = battleCard.Cost;

            if (character.CurrentEnergy < requiredCost) {
                // 조건 성립 활성화
            }
            else {
                card.DisableCard();
            }
        }
    }



}
