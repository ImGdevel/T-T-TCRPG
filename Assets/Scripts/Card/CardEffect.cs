using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CardEffect : ScriptableObject
{
    public abstract void ApplyEffect();
}

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "Card/CardEffect/Damage Effect")]
public class DamageEffect : CardEffect
{
    public int damageAmount;

    public override void ApplyEffect() {
        // 데미지 효과를 적용하는 로직을 작성합니다.
    }
}


[CreateAssetMenu(fileName = "New Buff Effect", menuName = "Card/CardEffect/Buff Effect")]
public class BuffEffect : CardEffect
{
    public int buffAmount;

    public override void ApplyEffect() {
        // 버프 효과를 적용하는 로직을 작성합니다.
    }
}

// 추가적인 효과 클래스들을 정의할 수 있습니다.