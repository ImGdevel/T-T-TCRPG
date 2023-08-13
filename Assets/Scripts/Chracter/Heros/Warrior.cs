using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior(string name, int level, CharacterStats stats)
        :base(name, HeroClassType.Warrior, level, stats) {
    }

    public Warrior(string name, int level, int maxHealth, int maxEnergy, int attackPower)
        : base(name, HeroClassType.Warrior, level, maxHealth, maxEnergy, attackPower) {
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
        return new Warrior(name, level, stats);
    }
}
