using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected string name;
    protected int maxHealth;
    protected int currentHealth;
    protected int maxEnergy;
    protected int currentEnergy;
    protected int attackPower;
    protected BuffList buffList;

    public string Name { get { return name; } }
    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }
    public int MaxEnergy { get { return maxEnergy; } }
    public int CurrentEnergy { get { return currentEnergy; } }
    public int AttackPower { get { return attackPower; } }
    public BuffList BuffList { get { return buffList; } }

    public abstract void Attack();
    public abstract void Defend();
    public abstract void TakeDamage(int damage);
    public abstract void Die();
    public abstract Character Clone();

    public void TakeBuff(BuffData buff) {
        Buff buffInstance = new Buff(buff);
        buffList.AddBuff(buffInstance);
    }

    public void ApplyBuff() {
        buffList.ApplyBuffs(this);
    }

    /// <summary>
    /// ���� ���� ���۵� �� ȣ��Ǵ� �޼���
    /// </summary>
    public virtual void TurnStart() {
        // �ʿ��� ó������ �����մϴ�.
    }

    // ���� ���� ���� �� ȣ��Ǵ� �޼���
    public virtual void EndTurn() {
        // ���� �� ������� ���� �� ���� ���ҽ�Ű��, ����� ��� �����մϴ�.
        buffList.UpdateBuffs();
        // ���� �Ͽ� �ʿ��� ó������ �����մϴ�.
    }
}