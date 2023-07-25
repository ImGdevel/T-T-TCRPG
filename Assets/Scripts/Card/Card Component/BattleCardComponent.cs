using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardComponent : HandCardComponent
{




    private void OnTriggerEnter2D(Collider2D other) {
        if (isSelected && other.tag == "Character") {
            Debug.Log("카드가 닿았습니다.");
            // 카드를 사용할 캐릭터 지정.
            // 카드에 저장된 타겟에 따라 적절한 대상인지 판별
            isUseable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // 충돌이 끝날 때 호출됩니다.
        // TriggerEnter2D에서 했던 모든 상태 초기화 
        isUseable = false;
    }

}
