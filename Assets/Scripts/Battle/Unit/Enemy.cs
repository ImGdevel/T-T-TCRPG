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

    public Enemy(string name, EnemyClassType enemyClassType, int maxHealth, int attackPower) {
        this.name = name;
        this.enemyClassType = enemyClassType;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.attackPower = attackPower;
        buffManager = new BuffManager();
    }

    public EnemyClassType EnemyClassType { get { return enemyClassType; } }

    public override void Attack() {
        // ���� ���� ����
    }

    public override void Defend() {
        // ��� ���� ����
    }

    public override void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Die();
        }
    }

    public override void Die() {
        // ��� ó�� ���� ����
    }
}