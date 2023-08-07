using UnityEngine;
using UnityEngine.Events;

public enum BuffType
{
    Buff,
    Debuff
}

// ���� �̺�Ʈ�� �����մϴ�.
[System.Serializable]
public class BuffEvent : UnityEvent<Character> { }

[CreateAssetMenu(fileName = "New Buff", menuName = "Buffs/Buff")]
public class BuffData : ScriptableObject
{
    public string buffName;
    public int duration; // ���� ���� �� ��
    public BuffType buffType; // ������ Ÿ�� (�������� ���������)
    public BuffEvent onBuffApplied; // ������ ����� �� ȣ��Ǵ� �̺�Ʈ
    public BuffEvent onBuffRemoved; // ������ ���ŵ� �� ȣ��Ǵ� �̺�Ʈ
}