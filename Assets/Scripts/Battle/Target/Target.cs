using UnityEngine;

[System.Serializable]
public class Target
{
    [SerializeField] 
    private TargetType targetType;
    public TargetType Type {
        get { return targetType; } 
    }

}

public enum TargetType
{
    IndividualFriendly,
    AllFriendly,
    IndividualEnemy,
    AllEnemy,
}