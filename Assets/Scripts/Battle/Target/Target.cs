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
/// Ÿ���� Ÿ��
/// </summary>
public enum TargetType
{
    Enemy, // ��
    Friendly // �Ʊ�
    
}

/// <summary>
/// ������ Ÿ�� ����
/// </summary>
public enum TargetRange
{
    Single, // ���� Ÿ��
    Self,// �ڽ��� Ÿ��
    Multiple, // ���� Ÿ��
    All // Ÿ�� ��ü
}