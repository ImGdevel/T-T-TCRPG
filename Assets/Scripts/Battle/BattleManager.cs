using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private void Start() {
        // TurnManager의 턴 변경 이벤트에 구독
        TurnManager.OnTurnChange += HandleTurnChange;
    }

    private void OnDestroy() {
        // TurnManager의 턴 변경 이벤트에서 구독 해지
        TurnManager.OnTurnChange -= HandleTurnChange;
    }

    private void HandleTurnChange(bool isPlayerTurn) {
        if (isPlayerTurn) {
            Debug.Log("플레이어 턴입니다.");
            // 플레이어의 턴에 대한 추가 동작 수행
        }
        else {
            Debug.Log("적 턴입니다.");
            // 적의 턴에 대한 추가 동작 수행
        }
    }
}
