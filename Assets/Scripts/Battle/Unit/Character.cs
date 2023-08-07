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

    // 버프 효과를 적용하는 메서드
    public void ApplyBuff(BuffData buffData) {
        Buff buffInstance = new Buff(buffData);

        // 버프의 타입에 따라 버프 또는 디버프 리스트에 추가합니다.
        if (buffData.buffDebuffType == BuffDebuffType.Buff) {
            // 버프 리스트에 추가
            activeBuffs.Add(buffInstance);
        }
        else if (buffData.buffDebuffType == BuffDebuffType.Debuff) {
            // 디버프 리스트에 추가
            activeDebuffs.Add(buffInstance);
        }

        // 버프를 캐릭터에 적용합니다.
        buffInstance.ApplyBuff(this);
    }

    // 버프 효과를 제거하는 메서드
    public void RemoveBuff(Buff buffInstance) {
        // 버프의 타입에 따라 버프 또는 디버프 리스트에서 제거합니다.
        if (buffInstance.BuffDebuffType == BuffDebuffType.Buff) {
            // 버프 리스트에서 제거
            activeBuffs.Remove(buffInstance);
        }
        else if (buffInstance.BuffDebuffType == BuffDebuffType.Debuff) {
            // 디버프 리스트에서 제거
            activeDebuffs.Remove(buffInstance);
        }

        // 버프를 캐릭터에서 제거합니다.
        buffInstance.RemoveBuff(this);
    }

    /// <summary>
    /// 게임 턴이 시작될 때 호출되는 메서드
    /// </summary>
    public virtual void TurnStart() {

    }

    // 게임 턴이 끝날 때 호출되는 메서드
    public virtual void EndTurn() {
        // 버프 및 디버프의 지속 턴 수를 감소시키고, 만료된 경우 제거합니다.
        UpdateBuffs();
        // 다음 턴에 필요한 처리들을 수행합니다.
    }

    // 버프 및 디버프의 지속 턴 수를 업데이트하고 만료된 경우 제거합니다.
    private void UpdateBuffs() {
        UpdateBuffList(activeBuffs);
        UpdateBuffList(activeDebuffs);
    }

    // 버프 리스트를 업데이트하고 만료된 경우 제거합니다.
    private void UpdateBuffList(List<Buff> buffList) {
        for (int i = buffList.Count - 1; i >= 0; i--) {
            Buff buffInstance = buffList[i];
            buffInstance.remainingDuration--;
            if (buffInstance.remainingDuration <= 0) {
                // 버프의 지속 턴 수가 0 이하면 제거합니다.
                buffList.RemoveAt(i);
                RemoveBuff(buffInstance);
            }
        }
    }
}