using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public Mage(string name, Stats stats, int level = 1)
        : base(name, stats, HeroClassType.Mage, level) {
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
        return new Mage(name, stats, level);
    }
}