using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsType
{
    Health,
    Energy,
    ShieldPoint,
    AttackPower,
    // 여기에 추가적인 스탯들을 나열해주세요.
}

public class CharacterStats
{
    private Dictionary<StatsType, int> stats = new Dictionary<StatsType, int>();

    public CharacterStats(int health, int energy, int attackPower) {
        stats.Add(StatsType.Health, health);
        stats.Add(StatsType.Energy, energy);
        stats.Add(StatsType.AttackPower, attackPower);
        // 여기에 추가적인 스탯들을 초기화해주세요.
    }

    public int GetStat(StatsType type) {
        if (stats.ContainsKey(type)) {
            return stats[type];
        }
        else {
            Debug.LogError($"StatsType {type} not found.");
            return 0;
        }
    }

    public void ModifyStat(StatsType type, int amount) {
        if (stats.ContainsKey(type)) {
            stats[type] += amount;
        }
        else {
            Debug.LogError($"StatsType {type} not found.");
        }
    }
}