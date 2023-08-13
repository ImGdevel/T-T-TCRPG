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

    public Enemy(string name, Stats stats, EnemyClassType enemyClassType)
        :base(name, stats) {
        this.enemyClassType = enemyClassType;
    }

    public EnemyClassType EnemyClassType { get { return enemyClassType; } }

    public override void Attack() {
        // ���� ���� ����
    }

    public override void Defend() {
        // ��� ���� ����
    }

    /// <summary>
    /// ���� ������ ���� �� ȣ��Ǵ� �Լ��Դϴ�.
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
    /// ���� ������ ���� �� ȣ��Ǵ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="buff">�޴� ����</param>


    /// <summary>
    /// ���� ����� �� ȣ��Ǵ� �Լ��Դϴ�.
    /// </summary>
    public override void Die() {
        // ��� ó�� ���� ����
    }

    public override Character Clone() {
        return new Enemy(name, stats, enemyClassType);
    }
}