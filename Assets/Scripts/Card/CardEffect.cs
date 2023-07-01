using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CardEffect : ScriptableObject
{
    public abstract void ApplyEffect();
}

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "CardEffect/Damage Effect")]
public class DamageEffect : CardEffect
{
    public int damageAmount;

    public override void ApplyEffect() {
        // ������ ȿ���� �����ϴ� ������ �ۼ��մϴ�.
    }
}


[CreateAssetMenu(fileName = "New Buff Effect", menuName = "CardEffect/Buff Effect")]
public class BuffEffect : CardEffect
{
    public int buffAmount;

    public override void ApplyEffect() {
        // ���� ȿ���� �����ϴ� ������ �ۼ��մϴ�.
    }
}

// �߰����� ȿ�� Ŭ�������� ������ �� �ֽ��ϴ�.