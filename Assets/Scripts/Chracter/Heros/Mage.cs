using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public Mage(string name, Stats stats, int level = 1)
        : base(name, stats, HeroClassType.Mage, level) {
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
        return new Mage(name, stats, level);
    }
}