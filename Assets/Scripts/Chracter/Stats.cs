using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsType
{
    Health,
    Energy,
    ShieldPoint,
    AttackPower,
    Speed,
    // 여기에 추가적인 스탯들을 나열해주세요.
}

[System.Serializable]
public class Stats
{
    public int Health;
    public int Energy;
    public int ShieldPoint;
    public int AttackPower;
    public int Speed;
    //private Dictionary<StatsType, int> stats = new Dictionary<StatsType, int>();

    public Stats(int health, int energy, int attackPower, int speed) {
        Health = health;
        Energy = energy;
        ShieldPoint = 0;
        AttackPower = attackPower;
        Speed = speed;
    }

    public Stats(int health, int energy, int shieldPoint, int attackPower, int speed) {
        Health = health;
        Energy = energy;
        ShieldPoint = shieldPoint;
        AttackPower = attackPower;
        Speed = speed;
    }

    public Stats(int health, int energy, int attackPower) {
        Health = health;
        Energy = energy;
        ShieldPoint = 0;
        AttackPower = attackPower;
        Speed = 1;
        /*
        stats.Add(StatsType.Health, health);
        stats.Add(StatsType.Energy, energy);
        stats.Add(StatsType.AttackPower, attackPower);
        stats.Add(StatsType.ShieldPoint, 0);
        stats.Add(StatsType.Speed, attackPower);
        */
        // 여기에 추가적인 스탯들을 초기화해주세요.
    }

    public int GetStat(StatsType type) {
        switch (type) {
            case StatsType.Health:
                return Health;
            case StatsType.Energy:
                return Energy;
            case StatsType.ShieldPoint:
                return ShieldPoint;
            case StatsType.AttackPower:
                return AttackPower;
            case StatsType.Speed:
                return Speed;
            default:
                Debug.LogError($"StatsType {type} not found.");
                return 0;
        }
    }

    public void ModifyStat(StatsType type, int amount) {
        switch (type) {
            case StatsType.Health:
                Health += amount; 
                break;
            case StatsType.Energy:
                Energy += amount;
                break;
            case StatsType.ShieldPoint:
                ShieldPoint += amount;
                break;
            case StatsType.AttackPower:
                AttackPower += amount;
                break;
            case StatsType.Speed:
                Speed += amount;
                break;
            default:
                Debug.LogError($"StatsType {type} not found.");
                break;
        }
    }

    public Stats Clone() {
        return new Stats(Health, Energy, ShieldPoint, AttackPower, Speed);
    }
}