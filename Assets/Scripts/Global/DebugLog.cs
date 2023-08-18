using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog
{
    public static void Print(Character character) {
        string log = DisplayStats(character);
        Debug.Log(log);
    }

    public static void Print(Equipment equipment) {
        string log = DisplayEquipmentStats(equipment);
        Debug.Log(log);
    }

    private static string DisplayStats(Character character) {
        string log = "Character Stats:\n";
        log += $"Name: {character.Name}\n";
        log += $"Max Health: {character.MaxHealth}\n";
        log += $"Max Energy: {character.MaxEnergy}\n";
        log += $"Attack Power: {character.AttackPower}\n";
        // ... (다른 스탯도 추가)

        if (character is Hero hero) {
            if (hero.EquippedWeapon != null) {
                log += $"Equipped Weapon: {hero.EquippedWeapon.Name}\n";
                log += "Weapon Stats:\n";
                log += DisplayEquipmentStats(hero.EquippedWeapon);
            }

            if (hero.EquippedArmor != null) {
                log += $"Equipped Armor: {hero.EquippedArmor.Name}\n";
                log += "Armor Stats:\n";
                log += DisplayEquipmentStats(hero.EquippedArmor);
            }

            if (hero.EquippedAccessory != null) {
                log += $"Equipped Accessory: {hero.EquippedAccessory.Name}\n";
                log += "Accessory Stats:\n";
                log += DisplayEquipmentStats(hero.EquippedAccessory);
            }
        }
        return log;
    }

    private static string DisplayEquipmentStats(Equipment equipment) {
        string log = "";
        log += $"Health: {equipment.Stats.GetStat(StatsType.Health)}\n";
        log += $"Attack Power: {equipment.Stats.GetStat(StatsType.AttackPower)}\n";
        // ... (다른 스탯도 추가)
        return log;
    }
}