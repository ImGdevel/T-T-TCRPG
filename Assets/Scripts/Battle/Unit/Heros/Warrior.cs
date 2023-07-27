using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior(string name, int level, int maxHealth, int maxEnergy, int attackPower)
        : base(name, HeroClassType.Warrior, level, maxHealth, maxEnergy, attackPower) {
        // �߰����� �ʱ�ȭ �ڵ�
    }

    public override void Attack() {
        // Warrior�� ���� ���� ����
        // ��: ���� ���� ����
    }

    public override void Defend() {
        // Warrior�� ��� ���� ����
        // ��: ��� �¼� ��ȯ
    }

    public override Character Clone() {
        return new Warrior(name, level, maxHealth, maxHealth, attackPower);
    }
}
