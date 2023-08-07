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
        // 능력치 증감 버프 적용 로직
    }

    public override void RemoveBuff(Character target) {
        // 능력치 증감 버프 제거 로직
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
        // 상태 변화 버프 적용 로직
    }

    public override void RemoveBuff(Character target) {
        // 상태 변화 버프 제거 로직
    }
}

public class TurnEndBuff : Buff
{
    public TurnEndBuff(string name, int duration)
        : base(name, BuffType.TurnEnd, duration) {
    }

    public override void ApplyBuff(Character target) {
        // 턴 종료 시 발동 버프 적용 로직
    }

    public override void RemoveBuff(Character target) {
        // 턴 종료 시 발동 버프 제거 로직
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
        // 군중 제어 버프 적용 로직
    }

    public override void RemoveBuff(Character target) {
        // 군중 제어 버프 제거 로직
    }
}

public enum BuffType
{
    Attribute,        // 능력치 증감
    StatusChange,     // 상태 변화
    TurnEnd,          // 턴 종료 시 발동
    CrowdControl      // 군중 제어
}

public enum AttributeType
{
    Attack,           // 공격력
    Defense,          // 방어력
    Healing           // 회복력 
}

public enum StatusType
{
    Bleeding,         // 출혈 효과
    HealingOverTime    // 지속 회복 효과
}

public enum CrowdControlType
{
    Stun,             // 스턴
    Silence           // 침묵 등
}