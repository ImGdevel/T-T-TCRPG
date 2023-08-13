using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDataGenerator
{

    public static List<Character> SAMPLE_CHARACTER {
        get {
            List<Character> sample = new();

            sample.Add(new Warrior("Tain", new Stats(30,5,10)));
            sample.Add(new Mage("Rora", new Stats(30, 5, 10)));

            return sample;
        }
        
    }

    public static List<Character> SAMPLE_ENEMY {
        get {
            List<Character> sample = new();

            sample.Add(new Enemy("Gole", new Stats(30, 5, 10), EnemyClassType.Undead));
            sample.Add(new Enemy("Ghoul", new Stats(30, 5, 10), EnemyClassType.Undead));

            return sample;
        }
    }

}
