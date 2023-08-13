using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public Mage(string name, int level, Stats stats)
        : base(name, HeroClassType.Mage, level, stats) {
    }

    public Mage(string name, int level, int maxHealth, int maxEnergy, int attackPower)
        : base(name, HeroClassType.Mage, level, maxHealth, maxEnergy, attackPower) {
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
        return new Mage(name, level, stats);
    }
}