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

    // ������ ����� �� ȣ��Ǵ� �̺�Ʈ
    public void ApplyBuff(Character character) {
        buffData.onBuffApplied?.Invoke(character);
    }

    // ������ ���ŵ� �� ȣ��Ǵ� �̺�Ʈ
    public void RemoveBuff(Character character) {
        buffData.onBuffRemoved?.Invoke(character);
    }
}