public abstract class Buff
{
    public string Name { get; set; }
    public BuffType Type { get; set; }
    public int Duration { get; set; }

    public Buff(string name, BuffType type, int duration) {
        Name = name;
        Type = type;
        Duration = duration;
    }

    public abstract void ApplyBuff(Character target);
    public abstract void RemoveBuff(Character target);
}

public class AttributeBuff : Buff
{
    public AttributeType Attribute { get; set; }
    public int Amount { get; set; }

    public AttributeBuff(string name, AttributeType attribute, int amount, int duration)
        : base(name, BuffType.Attribute, duration) {
        Attribute = attribute;
        Amount = amount;
    }

    public override void ApplyBuff(Character target) {
        // �ɷ�ġ ���� ���� ���� ����
    }

    public override void RemoveBuff(Character target) {
        // �ɷ�ġ ���� ���� ���� ����
    }
}

public class StatusChangeBuff : Buff
{
    public StatusType Status { get; set; }
    public int Amount { get; set; }

    public StatusChangeBuff(string name, StatusType status, int amount, int duration)
        : base(name, BuffType.StatusChange, duration) {
        Status = status;
        Amount = amount;
    }

    public override void ApplyBuff(Character target) {
        // ���� ��ȭ ���� ���� ����
    }

    public override void RemoveBuff(Character target) {
        // ���� ��ȭ ���� ���� ����
    }
}

public class TurnEndBuff : Buff
{
    public TurnEndBuff(string name, int duration)
        : base(name, BuffType.TurnEnd, duration) {
    }

    public override void ApplyBuff(Character target) {
        // �� ���� �� �ߵ� ���� ���� ����
    }

    public override void RemoveBuff(Character target) {
        // �� ���� �� �ߵ� ���� ���� ����
    }
}

public class CrowdControlBuff : Buff
{
    public CrowdControlType ControlType { get; set; }

    public CrowdControlBuff(string name, CrowdControlType controlType, int duration)
        : base(name, BuffType.CrowdControl, duration) {
        ControlType = controlType;
    }

    public override void ApplyBuff(Character target) {
        // ���� ���� ���� ���� ����
    }

    public override void RemoveBuff(Character target) {
        // ���� ���� ���� ���� ����
    }
}

public enum BuffType
{
    Attribute,        // �ɷ�ġ ����
    StatusChange,     // ���� ��ȭ
    TurnEnd,          // �� ���� �� �ߵ�
    CrowdControl      // ���� ����
}

public enum AttributeType
{
    Attack,           // ���ݷ�
    Defense,          // ����
    Healing           // ȸ���� 
}

public enum StatusType
{
    Bleeding,         // ���� ȿ��
    HealingOverTime    // ���� ȸ�� ȿ��
}

public enum CrowdControlType
{
    Stun,             // ����
    Silence           // ħ�� ��
}