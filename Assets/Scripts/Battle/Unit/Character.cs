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
    protected BuffManager buffManager;
    

    public string Name { get { return name; } }
    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }
    public int MaxEnergy { get { return maxEnergy; } }
    public int CurrentEnergy { get { return currentEnergy; } }
    public int AttackPower { get { return attackPower; } }
    public BuffManager BuffManager { get { return buffManager; } }

    public abstract void Attack();
    public abstract void Defend();
    public abstract void TakeDamage(int damage);
    public abstract void TakeBuff(Buff buff);
    public abstract void Die();
    public abstract Character Clone();


    private List<Buff> activeBuffs = new List<Buff>();
    private List<Buff> activeDebuffs = new List<Buff>();

    public List<Buff> buffs = new List<Buff>();

    // ���� ȿ���� �����ϴ� �޼���
    public void ApplyBuff(BuffData buffData) {
        Buff buffInstance = new Buff(buffData);

        // ������ Ÿ�Կ� ���� ���� �Ǵ� ����� ����Ʈ�� �߰��մϴ�.
        if (buffData.buffDebuffType == BuffDebuffType.Buff) {
            // ���� ����Ʈ�� �߰�
            activeBuffs.Add(buffInstance);
        }
        else if (buffData.buffDebuffType == BuffDebuffType.Debuff) {
            // ����� ����Ʈ�� �߰�
            activeDebuffs.Add(buffInstance);
        }

        // ������ ĳ���Ϳ� �����մϴ�.
        buffInstance.ApplyBuff(this);
    }

    // ���� ȿ���� �����ϴ� �޼���
    public void RemoveBuff(Buff buffInstance) {
        // ������ Ÿ�Կ� ���� ���� �Ǵ� ����� ����Ʈ���� �����մϴ�.
        if (buffInstance.BuffDebuffType == BuffDebuffType.Buff) {
            // ���� ����Ʈ���� ����
            activeBuffs.Remove(buffInstance);
        }
        else if (buffInstance.BuffDebuffType == BuffDebuffType.Debuff) {
            // ����� ����Ʈ���� ����
            activeDebuffs.Remove(buffInstance);
        }

        // ������ ĳ���Ϳ��� �����մϴ�.
        buffInstance.RemoveBuff(this);
    }

    /// <summary>
    /// ���� ���� ���۵� �� ȣ��Ǵ� �޼���
    /// </summary>
    public virtual void TurnStart() {

    }

    // ���� ���� ���� �� ȣ��Ǵ� �޼���
    public virtual void EndTurn() {
        // ���� �� ������� ���� �� ���� ���ҽ�Ű��, ����� ��� �����մϴ�.
        UpdateBuffs();
        // ���� �Ͽ� �ʿ��� ó������ �����մϴ�.
    }

    // ���� �� ������� ���� �� ���� ������Ʈ�ϰ� ����� ��� �����մϴ�.
    private void UpdateBuffs() {
        UpdateBuffList(activeBuffs);
        UpdateBuffList(activeDebuffs);
    }

    // ���� ����Ʈ�� ������Ʈ�ϰ� ����� ��� �����մϴ�.
    private void UpdateBuffList(List<Buff> buffList) {
        for (int i = buffList.Count - 1; i >= 0; i--) {
            Buff buffInstance = buffList[i];
            buffInstance.remainingDuration--;
            if (buffInstance.remainingDuration <= 0) {
                // ������ ���� �� ���� 0 ���ϸ� �����մϴ�.
                buffList.RemoveAt(i);
                RemoveBuff(buffInstance);
            }
        }
    }
}