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
        // Todo: ���� ���� ���� �߰����� ó��
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

        // ��� ������ ĳ���� ���ȿ� �ݿ�
        stats.ModifyStat(StatsType.Health, equipment.Stats.GetStat(StatsType.Health));
        stats.ModifyStat(StatsType.AttackPower, equipment.Stats.GetStat(StatsType.AttackPower));
        stats.ModifyStat(StatsType.Energy, equipment.Stats.GetStat(StatsType.Energy));
        stats.ModifyStat(StatsType.Speed, equipment.Stats.GetStat(StatsType.Speed));
        // ... (�ٸ� ���ȵ� ���������� �ݿ�)
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
            // ��� ������ ĳ���� ���ȿ��� ����
            stats.ModifyStat(StatsType.Health, -equipment.Stats.GetStat(StatsType.Health));
            stats.ModifyStat(StatsType.AttackPower, -equipment.Stats.GetStat(StatsType.AttackPower));
            stats.ModifyStat(StatsType.Energy, -equipment.Stats.GetStat(StatsType.Energy));
            stats.ModifyStat(StatsType.Speed, -equipment.Stats.GetStat(StatsType.Speed));
            // ... (�ٸ� ���ȵ� ���������� ����)
        }
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