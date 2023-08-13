using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected string name;
    public string Name { get { return name; } }

    private Stats originStats;
    protected Stats stats;

    protected int currentHealth;
    protected int currentEnergy;
    protected int shieldPoint;

    public int MaxHealth { get { return stats.GetStat(StatsType.Health); } }
    public int MaxEnergy { get { return stats.GetStat(StatsType.Energy); } }
    public int CurrentHealth { get { return currentHealth; } }
    public int CurrentEnergy { get { return currentEnergy; } }
    public int ShieldPoint { get { return shieldPoint; } }
    public int AttackPower { get { return stats.GetStat(StatsType.AttackPower); } }

    protected BuffList buffList;
    public BuffList BuffList { get { return buffList; } }
    
    private bool isSturn = false;

    protected Character(string name, Stats characterStats) {
        this.name = name;
        this.stats = characterStats.Clone();
        this.originStats = characterStats.Clone();
        this.currentHealth = stats.GetStat(StatsType.Health);
        this.currentEnergy = stats.GetStat(StatsType.Energy);
        this.buffList = new BuffList();
    }

    protected Character(string name, int maxHealth, int maxEnergy, int attackPower) {
        this.name = name;
        this.stats = new Stats(maxHealth, maxEnergy, attackPower);
        this.originStats = stats.Clone();
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
        // Todo: 필요한 처리들을 수행합니다.
        RecoverEnergyOnTurnStart(); // 에너지 회복
        // Todo: 버프 효과를 적용한다?
    }

    public virtual void EndTurn() {
        buffList.UpdateBuffs();
        // Todo: 다음 턴에 필요한 처리들을 수행합니다.
    }

    private void RecoverEnergyOnTurnStart() {
        int energyRecoveryAmount = 1;
        // Todo: 에너지 회복양이 1이상인 경우 로직 작성
        // stats.ModifyStat(StatsType.Energy, energyRecoveryAmount);

        // 현재 에너지 변경 부분
        // if (CurrentEnergy > MaxEnergy)
        // {
        //     CurrentEnergy = MaxEnergy;
        // }
    }

    //버프관련 코드
    public void TakeBuff(BuffData buff) {
        Buff buffInstance = new Buff(buff);
        buffList.AddBuff(buffInstance);
    }

    public void ApplyBuff() {
        buffList.ApplyBuffs(this);
    }
}
