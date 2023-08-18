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

}
