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
    public string equipmentName;
    public EquipmentType type;
    public string description;
    public Stats stats;

    public string Name { get { return equipmentName; } }
    public EquipmentType Type { get { return type; } }
    public string Description { get {return description; } }
    public Stats Stats { get { return stats; } }
    
    public Equipment(string name, EquipmentType type, Stats stats, string description = "") {
        this.equipmentName = name;
        this.type = type;
        this.stats = stats;
        this.description = description;
    }
}