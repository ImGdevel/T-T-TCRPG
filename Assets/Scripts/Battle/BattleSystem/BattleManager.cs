using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // ���� �ý��ۿ� ���� ������ �Դϴ�.
    // ���� �����ڴ� ���� ������ �����մϴ�.
    // 1. ���� �� ����� ����
    // 2. 
    
    HandManager handManager;



    // TrunManager�� �����ϰ� TrunManager�� ȣ��� �ڵ����� ȣ��ǰڴ� ����
    private void Start() {
        // TurnManager�� �� ���� �̺�Ʈ�� ����
        TurnManager.OnTurnChange += HandleTurnChange;
    }

    private void OnDestroy() {
        // TurnManager�� �� ���� �̺�Ʈ���� ���� ����
        TurnManager.OnTurnChange -= HandleTurnChange;
    }

    private void HandleTurnChange(bool isPlayerTurn) {

        Debug.Log("�� ���� ��Ʋ ���� �۵�");

        if (isPlayerTurn) {
            Debug.Log("�÷��̾� ���Դϴ�.");
            // �÷��̾��� �Ͽ� ���� �߰� ���� ����

            // �� ���� ��ư ��Ȱ��ȭ 
            // ī�� ��Ȱ��ȭ = HnadManager����

        }
        else {
            Debug.Log("�� ���Դϴ�.");
            // ���� �Ͽ� ���� �߰� ���� ����

            // �� ���� ��ư ��Ȱ��ȭ
            // ī�� Ȱ��ȭ = HnadManager���� 

            // �� �� ���� ����...
        }
    }
}

// Comment
/*
 �� �޴����� ��Ʋ �޴����� ������ �����ϴ°�?
1. �÷��̾� �Ͽ����� �÷��̰� ���� �� �� �ֵ��� �ؾ��Ѵ�.
2. ���� �Ͽ����� �Ϻ� �÷��̸� ���� ���Ѿ��Ѵ�. (ī�� ���)
  2.1. ����: ������ �����ϰ� ������ �����ϰ� �� �� �ΰ�?
  2.2. �ֽð��� ������ ��� �� ���ΰ�? ��� �� ��带 ���ϰ� ��� ���ο� ���� �ٸ��� ����
  2.3. ����� ī�� ����� �Ұ����ϰ� �Ѵ�? ���?
  2.4. ī�� ����� �Ұ����ϰ�, ī�� ������ ���� �ְ�, ī�忡 ���� �÷������� ��밡�� ���·� ��ȯ But �� ���� �ƴ϶�� 
       (��, ��� ��� �Ұ��� ���¶��)
  2.5 ī�忡���� ī�� ��밡�� �� �Ұ��� �� �����صΰ�, � ī�尡 ��밡�������� HnadManager���� �����Ѵ�. ���?
  2.6 ��� �Ұ����� ī�嵵 ���� ���̴�. (�̰Ű� ����Ʈ �ε�)

 
 */

