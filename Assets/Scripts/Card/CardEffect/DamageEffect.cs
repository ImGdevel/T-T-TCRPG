using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "Card/CardEffect/Damage Effect")]
public class DamageEffect : CardEffect
{
    public int damageAmount;

    public override void ApplyEffect() {
        // 데미지 효과를 적용하는 로직을 작성합니다.
    }
}
