using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClassType
{
    Warrior,
    Mage
}

public abstract class Hero : Character
{
    protected HeroClassType classType; // 영웅의 직업 타입
    protected int level; // 영웅의 레벨
    protected bool isMoribund; // 빈사 상태 여부

    public Hero(string name, HeroClassType classType, int level, int maxHealth, int attackPower) {
        this.name = name;
        this.classType = classType;
        this.level = level;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.attackPower = attackPower;
        this.isMoribund = false;
        this.buffManager = new BuffManager();
    }

    // 외부 접근자 (get/set)
    public HeroClassType ClassType { get { return classType; } }
    public int Level { get { return level; } }
    public bool IsMoribund { get { return isMoribund; } }

    public void LevelUp() {
        level++;
        // 레벨 업에 따른 추가적인 처리
    }

    // 메서드
    public abstract override void Attack();
    public abstract override void Defend();

    /// <summary>
    /// 영웅이 피해를 입을 때 호출되는 함수입니다.
    /// </summary>
    /// <param name="damage">입는 피해량</param>
    public override void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            currentHealth = 0;
            if (!isMoribund) {
                isMoribund = true;
                EnterMoribundState();
            }
            else {
                Die();
            }
        }
    }

    /// <summary>
    /// 영웅이 빈사 상태할 때 호출되는 함수입니다.
    /// </summary>
    public void EnterMoribundState() {
        // 빈사 상태에 대한 동작 처리
        // 예: 메시지 출력, 특정 효과 발동 등
    }

    /// <summary>
    /// 영웅이 사망할 때 호출되는 함수입니다.
    /// </summary>
    public override void Die() {
        // 사망에 대한 동작 처리
        // 예: 메시지 출력, 리스폰 처리 등
    }

    public abstract override Character Clone();
}