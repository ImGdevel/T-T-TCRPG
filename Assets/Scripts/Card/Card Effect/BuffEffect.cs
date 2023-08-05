using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Effect", menuName = "Card/CardEffect/Buff Effect")]
public class BuffEffect : CardEffect
{
    public int buffAmount;
    public Buff buff;

    public override void ApplyEffect() {
        // 버프 효과를 적용하는 로직을 작성합니다.
    }
}