using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior(string name, Stats stats, int level = 1)
        :base(name, stats, HeroClassType.Warrior, level) {
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
        return new Warrior(name, stats, level);
    }
}
