using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardComponent : HandCardComponent
{




    private void OnTriggerEnter2D(Collider2D other) {
        if (isSelected && other.tag == "Character") {
            Debug.Log("ī�尡 ��ҽ��ϴ�.");
            // ī�带 ����� ĳ���� ����.
            // ī�忡 ����� Ÿ�ٿ� ���� ������ ������� �Ǻ�
            isUseable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // �浹�� ���� �� ȣ��˴ϴ�.
        // TriggerEnter2D���� �ߴ� ��� ���� �ʱ�ȭ 
        isUseable = false;
    }

}
