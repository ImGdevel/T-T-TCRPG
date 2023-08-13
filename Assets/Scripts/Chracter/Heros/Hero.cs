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
    protected HeroClassType classType; // ������ ���� Ÿ��
    protected int level; // ������ ����
    protected bool isMoribund; // ��� ���� ����

    public Hero(string name, HeroClassType classType, int level, Stats stats)
        : base(name, stats) {
        this.classType = classType;
        this.level = level;
        this.isMoribund = false;
    }

    public Hero(string name, HeroClassType classType, int level, int maxHealth, int maxEnergy, int attackPower)
        : base(name, maxHealth, maxEnergy, attackPower) {
        this.classType = classType;
        this.level = level;
        this.isMoribund = false;
    }

    // �ܺ� ������ (get/set)
    public HeroClassType ClassType { get { return classType; } }
    public int Level { get { return level; } }
    public bool IsMoribund { get { return isMoribund; } }

    public void LevelUp() {
        level++;
        // Todo: ���� ���� ���� �߰����� ó��
        
    }

    // �޼���
    public abstract override void Attack();
    public abstract override void Defend();

    /// <summary>
    /// ������ ���ظ� ���� �� ȣ��Ǵ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="damage">�Դ� ���ط�</param>
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
    /// ������ ������ ���� �� ȣ��Ǵ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="buff">�޴� ����</param>


    /// <summary>
    /// ������ ��� ������ �� ȣ��Ǵ� �Լ��Դϴ�.
    /// </summary>
    public void EnterMoribundState() {
        // ��� ���¿� ���� ���� ó��
        // ��: �޽��� ���, Ư�� ȿ�� �ߵ� ��
    }

    /// <summary>
    /// ������ ����� �� ȣ��Ǵ� �Լ��Դϴ�.
    /// </summary>
    public override void Die() {
        // ����� ���� ���� ó��
        // ��: �޽��� ���, ������ ó�� ��
    }

    

    public abstract override Character Clone();
}