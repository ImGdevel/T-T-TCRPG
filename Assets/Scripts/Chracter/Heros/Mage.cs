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
        // Mage의 공격 로직 구현
        // 예: 마법 공격 시전
    }

    public override void Defend() {
        // Mage의 방어 로직 구현
        // 예: 방어막 생성
    }

     public override Character Clone() {
        return new Mage(name, level, stats);
    }
}