using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDataGenerator
{

    public static List<Character> SAMPLE_CHARACTER {
        get {
            List<Character> sample = new();

            sample.Add(new Warrior("Tain", 3, 50, 10));
            sample.Add(new Mage("Rora", 4, 30, 20));

            return sample;
        }
        
    }

    public static List<Character> SAMPLE_ENEMY {
        get {
            List<Character> sample = new();

            sample.Add(new Enemy("Gole", EnemyClassType.Undead, 50, 10));
            sample.Add(new Enemy("Ghoul", EnemyClassType.Undead, 30, 20));

            return sample;
        }
    }

}
