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
}

/// <summary>
/// 타겟의 타입
/// </summary>
public enum TargetType
{
    Friendly, // 아군
    Enemy // 적
}

/// <summary>
/// 지정할 타겟 범위
/// </summary>
public enum TargetRange
{
    Single, // 단일 타겟
    Multiple, // 다중 타겟
    All // 타겟 전체
}