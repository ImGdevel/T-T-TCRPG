using UnityEngine;
using UnityEngine.Events;

public class Buff
{
    private BuffData buffData;

    public BuffType BuffType { get { return buffData.buffType; } }
    public BuffDebuffType BuffDebuffType { get { return buffData.buffDebuffType; } }
    public Sprite Sprite {get { return buffData.sprite; } }
    public int BuffAmount { get { return buffData.BuffAmount; } }
    public int remainingDuration;

    public Buff(BuffData buffData) {
        this.buffData = buffData;
        this.remainingDuration = buffData.duration;
    }

    // 버프가 적용될 때 호출되는 이벤트
    public void ApplyBuff(Character character) {
        buffData.onBuffApplied?.Invoke(character);
    }

    // 버프가 제거될 때 호출되는 이벤트
    public void RemoveBuff(Character character) {
        buffData.onBuffRemoved?.Invoke(character);
    }
}