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

    private bool isSturn = false;


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
    /// 턴이 시작될 때 캐릭터 행동
    /// </summary>
    public virtual void TurnStart() {
        // Todo: 필요한 처리들을 수행합니다.
        
        RecoverEnergyOnTurnStart(); // 에너지 회복
        

    }

    /// <summary>
    /// 턴이 종료될 때 캐릭터 행동
    /// </summary>
    public virtual void EndTurn() {
        // 버프 및 디버프의 지속 턴 수를 감소시키고, 만료된 경우 제거합니다.
        buffList.UpdateBuffs();
        // 다음 턴에 필요한 처리들을 수행합니다.
    }

    private void RecoverEnergyOnTurnStart() {
        int energyRecoveryAmount = 1;
        // Todo : 에너지 회복양이 1이상인 경우 로직 작성

        currentEnergy += energyRecoveryAmount;
        if (currentEnergy > maxEnergy) {
            currentEnergy = maxEnergy;
        }
    }
}