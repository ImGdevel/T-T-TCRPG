using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Accessory
}

public class Equipment
{
    public string Name { get; }
    public EquipmentType Type { get; }
    public Stats Stats { get; }

    public Equipment(string name, EquipmentType type, Stats stats) {
        Name = name;
        Type = type;
        Stats = stats;
    }
}