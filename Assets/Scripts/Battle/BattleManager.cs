using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private void Start() {
        // TurnManager�� �� ���� �̺�Ʈ�� ����
        TurnManager.OnTurnChange += HandleTurnChange;
    }

    private void OnDestroy() {
        // TurnManager�� �� ���� �̺�Ʈ���� ���� ����
        TurnManager.OnTurnChange -= HandleTurnChange;
    }

    private void HandleTurnChange(bool isPlayerTurn) {
        if (isPlayerTurn) {
            Debug.Log("�÷��̾� ���Դϴ�.");
            // �÷��̾��� �Ͽ� ���� �߰� ���� ����
        }
        else {
            Debug.Log("�� ���Դϴ�.");
            // ���� �Ͽ� ���� �߰� ���� ����
        }
    }
}
