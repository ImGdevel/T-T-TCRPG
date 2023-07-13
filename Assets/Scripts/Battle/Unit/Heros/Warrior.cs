using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Hero
{
    public Warrior(string name, int level, int maxHealth, int attackPower)
        : base(name, HeroClassType.Warrior, level, maxHealth, attackPower) {
        // 추가적인 초기화 코드
    }

    public override void Attack() {
        // Warrior의 공격 로직 구현
        // 예: 근접 공격 실행
    }

    public override void Defend() {
        // Warrior의 방어 로직 구현
        // 예: 방어 태세 전환
    }

    public override Character Clone() {
        return new Warrior(name, level, maxHealth, attackPower);
    }
}
