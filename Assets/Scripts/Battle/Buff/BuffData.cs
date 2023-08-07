using UnityEngine;
using UnityEngine.Events;

// ���� �̺�Ʈ�� �����մϴ�.
[System.Serializable]
public class BuffEvent : UnityEvent<Character>
{

}

[CreateAssetMenu(fileName = "New Buff", menuName = "Buffs/Buff")]
public class BuffData : ScriptableObject
{
    public BuffType buffType;
    public BuffDebuffType buffDebuffType; // �������� ���������
    public int duration; // ���� ���� �� ��

    public BuffType Name { get { return buffType; } }
    public BuffDebuffType Type { get { return buffDebuffType; } }
    public int Duration { get { return duration; } }

    public BuffEvent onBuffApplied; // ������ ����� �� ȣ��Ǵ� �̺�Ʈ
    public BuffEvent onBuffRemoved; // ������ ���ŵ� �� ȣ��Ǵ� �̺�Ʈ
}


public enum BuffDebuffType
{
    None,
    Buff,
    Debuff,
}

public enum BuffType
{
    Strength,          // �� ��ȭ
    Speed,             // �ӵ� ��ȭ
    Defense,           // ��� ��ȭ
    HealthRegen,       // ����� ȸ�� ����
    ManaRegen,         // ���� ȸ�� ����
    DamageBoost,       // ���ݷ� ����
    Stealth,           // ����
    ReflectDamage,     // �ݻ� ����
    Barrier,           // ��� �庮
    Invincibility,     // ����
    Regeneration,      // ����� ���
    Resistance,        // ���׷� ����
    Elemental,         // �Ӽ� ��ȭ
    DamageReduction,   // ���� ����
    DebuffRemoval      // ����� ����
}

