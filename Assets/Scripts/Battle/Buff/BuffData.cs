using UnityEngine;
using UnityEngine.Events;

public enum BuffType
{
    Buff,
    Debuff
}

// 버프 이벤트를 정의합니다.
[System.Serializable]
public class BuffEvent : UnityEvent<Character> { }

[CreateAssetMenu(fileName = "New Buff", menuName = "Buffs/Buff")]
public class BuffData : ScriptableObject
{
    public string buffName;
    public int duration; // 버프 지속 턴 수
    public BuffType buffType; // 버프의 타입 (버프인지 디버프인지)
    public BuffEvent onBuffApplied; // 버프가 적용될 때 호출되는 이벤트
    public BuffEvent onBuffRemoved; // 버프가 제거될 때 호출되는 이벤트
}