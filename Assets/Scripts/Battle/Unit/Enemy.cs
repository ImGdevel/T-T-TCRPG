using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyClassType
{
    Human,
    Beast,
    Undead
}

public class Enemy : Character
{
    private EnemyClassType enemyClassType;

    public Enemy(string name, EnemyClassType enemyClassType, int maxHealth, int maxEnergy, int attackPower) {
        this.name = name;
        this.enemyClassType = enemyClassType;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.maxEnergy = maxEnergy;
        this.currentEnergy = maxEnergy;
        this.attackPower = attackPower;
        buffManager = new BuffManager();
    }

    public EnemyClassType EnemyClassType { get { return enemyClassType; } }

    public override void Attack() {
        // 공격 로직 구현
    }

    public override void Defend() {
        // 방어 로직 구현
    }

    /// <summary>
    /// 적이 버프를 받을 때 호출되는 함수입니다.
    /// </summary>
    /// <param name="damage"></param>
    public override void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// 적이 버프를 받을 때 호출되는 함수입니다.
    /// </summary>
    /// <param name="buff">받는 버프</param>


    /// <summary>
    /// 적이 사망할 때 호출되는 함수입니다.
    /// </summary>
    public override void Die() {
        // 사망 처리 로직 구현
    }

    public override Character Clone() {
        return new Enemy(name, enemyClassType, maxHealth, maxEnergy, attackPower);
    }
}