using UnityEngine;

[System.Serializable]
public class Target
{
    [SerializeField] 
    private TargetType targetType;
    [SerializeField]
    private TargetRange targetRange;

    public TargetType Type
    {
        get { return targetType; }
    }

    public TargetRange Range
    {
        get { return targetRange; }
    }

    public bool RequiresTarget
    {
        get {
            switch (targetRange) {
                case TargetRange.Single:
                case TargetRange.Multiple:
                    return true;
                case TargetRange.Self:
                case TargetRange.All:
                default:
                    return false;
            }
        }
    }
}

/// <summary>
/// 타겟의 타입
/// </summary>
public enum TargetType
{
    Enemy, // 적
    Friendly // 아군
    
}

/// <summary>
/// 지정할 타겟 범위
/// </summary>
public enum TargetRange
{
    Single, // 단일 타겟
    Self,// 자신이 타겟
    Multiple, // 다중 타겟
    All // 타겟 전체
}