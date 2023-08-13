using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Accessory
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment/Equipment")]
public class Equipment : ScriptableObject
{
    public string Name { get; private set; }
    public EquipmentType Type { get; private set; }
    public Stats Stats { get; private set; }

    public Equipment(string name, EquipmentType type, Stats stats) {
        Name = name;
        Type = type;
        Stats = stats;
    }
}