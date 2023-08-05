using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public Target target;
    public abstract void ApplyEffect();
}
