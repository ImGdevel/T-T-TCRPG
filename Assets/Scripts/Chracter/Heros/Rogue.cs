using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Hero
{
    public Rogue(string name, Stats stats, int level = 1)
        : base(name, stats, HeroClassType.Rogue, level) {
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
        return new Rogue(name, stats, level);
    }
}
