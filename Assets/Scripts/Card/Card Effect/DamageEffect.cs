using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "Card/CardEffect/Damage Effect")]
public class DamageEffect : CardEffect
{
    public Target target;
    public int damageAmount;

    public override void ApplyEffect() {
        // ������ ȿ���� �����ϴ� ������ �ۼ��մϴ�.
    }

}
