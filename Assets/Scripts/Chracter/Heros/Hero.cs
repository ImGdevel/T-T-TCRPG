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
    protected HeroClassType classType; // 영웅의 직업 타입
    protected int level; // 영웅의 레벨
    protected bool isMoribund; // 빈사 상태 여부

    public HeroClassType ClassType { get { return classType; } }
    public int Level { get { return level; } }
    public bool IsMoribund { get { return isMoribund; } }

    protected Equipment equippedWeapon;
    protected Equipment equippedArmor;
    protected Equipment equippedAccessory;

    public Equipment EquippedWeapon { get { return equippedWeapon; } }
    public Equipment EquippedArmor { get { return equippedArmor; } }
    public Equipment EquippedAccessory { get { return equippedAccessory; } }

    public Hero(string name, Stats stats, HeroClassType classType, int level)
        : base(name, stats) {
        this.classType = classType;
        this.level = level;
        this.isMoribund = false;
    }

    public void LevelUp() {
        level++;
        // Todo: 레벨 업에 따른 추가적인 처리
    }

    public void Equip(Equipment equipment) {

        switch (equipment.Type) {
            case EquipmentType.Weapon:
                equippedWeapon = equipment;
                break;
            case EquipmentType.Armor:
                equippedArmor = equipment;
                break;
            case EquipmentType.Accessory:
                equippedAccessory = equipment;
                break;
        }

        // 장비 스탯을 캐릭터 스탯에 반영
        stats.ModifyStat(StatsType.Health, equipment.Stats.GetStat(StatsType.Health));
        stats.ModifyStat(StatsType.AttackPower, equipment.Stats.GetStat(StatsType.AttackPower));
        stats.ModifyStat(StatsType.Energy, equipment.Stats.GetStat(StatsType.Energy));
        stats.ModifyStat(StatsType.Speed, equipment.Stats.GetStat(StatsType.Speed));
        // ... (다른 스탯도 마찬가지로 반영)
    }

    public void Unequip(EquipmentType type) {
        Equipment equipment = null;

        switch (type) {
            case EquipmentType.Weapon:
                equipment = equippedWeapon;
                equippedWeapon = null;
                break;
            case EquipmentType.Armor:
                equipment = equippedArmor;
                equippedArmor = null;
                break;
            case EquipmentType.Accessory:
                equipment = equippedAccessory;
                equippedAccessory = null;
                break;
        }

        if (equipment != null) {
            // 장비 스탯을 캐릭터 스탯에서 제거
            stats.ModifyStat(StatsType.Health, -equipment.Stats.GetStat(StatsType.Health));
            stats.ModifyStat(StatsType.AttackPower, -equipment.Stats.GetStat(StatsType.AttackPower));
            stats.ModifyStat(StatsType.Energy, -equipment.Stats.GetStat(StatsType.Energy));
            stats.ModifyStat(StatsType.Speed, -equipment.Stats.GetStat(StatsType.Speed));
            // ... (다른 스탯도 마찬가지로 제거)
        }
    }

    // 메서드
    public abstract override void Attack();
    public abstract override void Defend();

    /// <summary>
    /// 영웅이 피해를 입을 때 호출되는 함수입니다.
    /// </summary>
    /// <param name="damage">입는 피해량</param>
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
    /// 영웅이 빈사 상태할 때 호출되는 함수입니다.
    /// </summary>
    public void EnterMoribundState() {
        // 빈사 상태에 대한 동작 처리
        // 예: 메시지 출력, 특정 효과 발동 등
    }

    /// <summary>
    /// 영웅이 사망할 때 호출되는 함수입니다.
    /// </summary>
    public override void Die() {
        // 사망에 대한 동작 처리
        // 예: 메시지 출력, 리스폰 처리 등
    }

    public abstract override Character Clone();
}