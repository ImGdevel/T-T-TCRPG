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
/// Ÿ���� Ÿ��
/// </summary>
public enum TargetType
{
    Friendly, // �Ʊ�
    Enemy // ��
}

/// <summary>
/// ������ Ÿ�� ����
/// </summary>
public enum TargetRange
{
    Single, // ���� Ÿ��
    Multiple, // ���� Ÿ��
    All // Ÿ�� ��ü
}