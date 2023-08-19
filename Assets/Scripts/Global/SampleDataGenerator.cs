using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDataGenerator
{
    

    public static List<Character> SAMPLE_CHARACTER {
        get {
            List<Character> sample = new();

            Hero hero1 = new Warrior("Tain", new Stats(30, 4, 10,10));
            Hero hero2 = new Rogue("Rosi", new Stats(30,4,10,10));
            Hero hero3 = new Mage("Rora", new Stats(30, 4, 10,10));
            
            sample.Add(hero1);
            sample.Add(hero2);
            sample.Add(hero3);

            Equi_SAMPLE_EQUIPMENT(hero1);
            Equi_SAMPLE_EQUIPMENT(hero2);

            return sample;
        }
    }

    public static List<Character> SAMPLE_ENEMY {
        get {
            List<Character> sample = new();

            sample.Add(new Enemy("Gole", new Stats(30, 4, 10,10), EnemyClassType.Undead));
            sample.Add(new Enemy("Ghoul", new Stats(30, 4, 10, 10), EnemyClassType.Undead));

            return sample;
        }
    }

    public static void Equi_SAMPLE_EQUIPMENT(Hero hero) {
        List<Equipment> SAMPLE_EQUIPMENT = new();

        Equipment newEquipment = ScriptableObject.CreateInstance<Equipment>();
        newEquipment.equipmentName = "Aaomer";
        newEquipment.type = EquipmentType.Armor;
        newEquipment.description = "A powerful Aaomer.";
        newEquipment.stats = new Stats(15, -1, 4, -4);

        Equipment newEquipment2 = ScriptableObject.CreateInstance<Equipment>(); 
        newEquipment2.equipmentName = "Sword"; 
        newEquipment2.type = EquipmentType.Weapon; 
        newEquipment2.description = "A powerful sword."; 
        newEquipment2.stats = new Stats(0, 0, 10, 0); 

        SAMPLE_EQUIPMENT.Add(newEquipment);
        SAMPLE_EQUIPMENT.Add(newEquipment2); 

        foreach (var item in SAMPLE_EQUIPMENT) {
            hero.Equip(item);
        }
    }

}
