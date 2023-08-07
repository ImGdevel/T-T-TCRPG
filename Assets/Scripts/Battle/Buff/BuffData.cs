using UnityEngine;
using UnityEngine.Events;

// 버프 이벤트를 정의합니다.
[System.Serializable]
public class BuffEvent : UnityEvent<Character>
{

}

[CreateAssetMenu(fileName = "New Buff", menuName = "Buffs/Buff")]
public class BuffData : ScriptableObject
{
    public BuffType buffType;
    public BuffDebuffType buffDebuffType; // 버프인지 디버프인지
    public int BuffAmount; // 버프 량
    public int duration; // 버프 지속 턴 수

    public BuffEvent onBuffApplied; // 버프가 적용될 때 호출되는 이벤트
    public BuffEvent onBuffRemoved; // 버프가 제거될 때 호출되는 이벤트
}


public enum BuffDebuffType
{
    None,
    Buff,
    Debuff,
}

public enum BuffType
{
    Strength,          // 힘 강화
    Speed,             // 속도 강화
    Defense,           // 방어 강화
    HealthRegen,       // 생명력 회복 증가
    ManaRegen,         // 마나 회복 증가
    DamageBoost,       // 공격력 증가
    Stealth,           // 은신
    ReflectDamage,     // 반사 피해
    Barrier,           // 방어 장벽
    Invincibility,     // 무적
    Regeneration,      // 생명력 재생
    Resistance,        // 저항력 증가
    Elemental,         // 속성 강화
    DamageReduction,   // 피해 감소
    DebuffRemoval      // 디버프 제거
}
