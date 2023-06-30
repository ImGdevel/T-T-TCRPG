using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public Mage(string name, int level, int maxHealth, int attackPower)
        : base(name, HeroClassType.Mage, level, maxHealth, attackPower) {
        // 추가적인 초기화 코드
    }

    public override void Attack() {
        // Mage의 공격 로직 구현
        // 예: 마법 공격 시전
    }

    public override void Defend() {
        // Mage의 방어 로직 구현
        // 예: 방어막 생성
    }
}