using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public Mage(string name, int level, int maxHealth, int maxEnergy, int attackPower)
        : base(name, HeroClassType.Mage, level, maxHealth, maxEnergy, attackPower) {
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

     public override Character Clone() {
        return new Mage(name, level, maxHealth, maxEnergy, attackPower);
    }
}