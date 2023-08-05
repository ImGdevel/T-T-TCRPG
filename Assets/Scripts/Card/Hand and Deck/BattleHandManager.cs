using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandManager : HandManager
{


    /// <summary>
    /// ĳ���� ��� ���ǿ� �´� ī�常 �÷��̾��� �տ��� ��� �����ϵ��� Ȱ��ȭ�մϴ�.
    /// </summary>
    public void EnableCardsByCondition(Character character) {
        // ���ǿ� �´� ī�常 ��� �����ϵ��� Ȱ��ȭ�մϴ�.
        // ������ ���ڷ� �޾ƿ� �ش� ������ �����Ǹ� ī�带 Ȱ��ȭ�մϴ�.

        // �켱 ĳ���� �ൿ�º��� ���� ī�� ��Ȱ��ȭ
        // ���� ī�尡 �ƴѰ�� ��Ȱ��ȭ

        foreach (GameObject item in hands) {
            BattleCardComponent card = item.transform.GetComponent<BattleCardComponent>();
            BattleCard battleCard = (BattleCard)(card.CardData);
            int requiredCost = battleCard.Cost;

            if (character.CurrentEnergy < requiredCost) {
                // ���� ���� Ȱ��ȭ
            }
            else {
                card.DisableCard();
            }
        }
    }



}
