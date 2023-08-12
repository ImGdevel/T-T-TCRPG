using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Buff", menuName = "Buffs/Buff")]
public class BuffData : ScriptableObject
{
    public BuffType buffType;
    public BuffDebuffType buffDebuffType; // �������� ���������
    public Sprite sprite;
    public int BuffAmount; // ���� ��
    public int duration; // ���� ���� �� ��

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
