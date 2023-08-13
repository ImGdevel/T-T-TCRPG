using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected string name;
    public string Name { get { return name; } }

    protected CharacterStats stats;

    protected int currentHealth;
    protected int currentEnergy;
    protected int shieldPoint;

    public int MaxHealth { get { return stats.GetStat(StatsType.Health); } }
    public int MaxEnergy { get { return stats.GetStat(StatsType.Energy); } }
    public int CurrentHealth { get { return currentHealth; } }
    public int CurrentEnergy { get { return currentEnergy; } }
    public int ShieldPoint { get { return shieldPoint; } }

    protected BuffList buffList;
    public BuffList BuffList { get { return buffList; } }
    
    private bool isSturn = false;

    /*
    public int CurrentHealth { get { return currentHealth; } }
    public int CurrentEnergy { get { return currentEnergy; } }
    public int ShieldPoint { get { return shieldPoint; } }
    public int AttackPower { get { return attackPower; } }
    */

    protected Character(string name, CharacterStats characterStats) {
        this.name = name;
        this.stats = characterStats;
        this.currentHealth = stats.GetStat(StatsType.Health);
        this.currentEnergy = stats.GetStat(StatsType.Energy);
        this.buffList = new BuffList();
    }

    protected Character(string name, int maxHealth, int maxEnergy, int attackPower) {
        this.name = name;
        this.stats = new CharacterStats(maxHealth, maxEnergy, attackPower);
        this.currentHealth = maxHealth;
        this.currentEnergy = maxEnergy;
        this.buffList = new BuffList();
    }

    public abstract void Attack();
    public abstract void Defend();
    public abstract void TakeDamage(int damage);
    public abstract void Die();
    public abstract Character Clone();

    public virtual void TurnStart() {
        // Todo: �ʿ��� ó������ �����մϴ�.
        RecoverEnergyOnTurnStart(); // ������ ȸ��
        // Todo: ���� ȿ���� �����Ѵ�?
    }

    public virtual void EndTurn() {
        buffList.UpdateBuffs();
        // Todo: ���� �Ͽ� �ʿ��� ó������ �����մϴ�.
    }

    private void RecoverEnergyOnTurnStart() {
        int energyRecoveryAmount = 1;
        // Todo: ������ ȸ������ 1�̻��� ��� ���� �ۼ�
        // stats.ModifyStat(StatsType.Energy, energyRecoveryAmount);

        // ���� ������ ���� �κ�
        // if (CurrentEnergy > MaxEnergy)
        // {
        //     CurrentEnergy = MaxEnergy;
        // }
    }

    //�������� �ڵ�
    public void TakeBuff(BuffData buff) {
        Buff buffInstance = new Buff(buff);
        buffList.AddBuff(buffInstance);
    }

    public void ApplyBuff() {
        buffList.ApplyBuffs(this);
    }
}
