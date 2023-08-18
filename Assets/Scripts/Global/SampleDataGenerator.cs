using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDataGenerator
{
   
    public static List<Character> SAMPLE_CHARACTER {
        get {
            List<Character> sample = new();

            Hero hero1 = new Warrior("Tain", new Stats(30, 5, 10,10));
            Hero hero2 = new Mage("Rora", new Stats(30, 5, 10,10));
            sample.Add(hero1);
            sample.Add(hero2);
            
            Equi_SAMPLE_EQUIPMENT(hero1);
            Equi_SAMPLE_EQUIPMENT(hero2);

            return sample;
        }
    }

    public static List<Character> SAMPLE_ENEMY {
        get {
            List<Character> sample = new();

            sample.Add(new Enemy("Gole", new Stats(30, 5, 10,10), EnemyClassType.Undead));
            sample.Add(new Enemy("Ghoul", new Stats(30, 5, 10, 10), EnemyClassType.Undead));

            return sample;
        }
    }

    public static void Equi_SAMPLE_EQUIPMENT(Hero hero) {
        List<Equipment> SAMPLE_EQUIPMENT = new();
        Equipment sample1 = new Equipment("Amo", EquipmentType.Armor, new Stats(7,-1,5,-1));
        Equipment sample2 = new Equipment("Wpn", EquipmentType.Weapon, new Stats(0, 0, 10, 0));

        SAMPLE_EQUIPMENT.Add(sample1);
        SAMPLE_EQUIPMENT.Add(sample2);

        foreach (var item in SAMPLE_EQUIPMENT) {
            hero.Equip(item);
        }
    }

}
