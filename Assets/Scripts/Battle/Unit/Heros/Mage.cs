using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public Mage(string name, int level, int maxHealth, int attackPower)
        : base(name, HeroClassType.Mage, level, maxHealth, attackPower) {
        // �߰����� �ʱ�ȭ �ڵ�
    }

    public override void Attack() {
        // Mage�� ���� ���� ����
        // ��: ���� ���� ����
    }

    public override void Defend() {
        // Mage�� ��� ���� ����
        // ��: �� ����
    }
}