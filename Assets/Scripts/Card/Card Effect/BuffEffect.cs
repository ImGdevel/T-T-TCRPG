using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Effect", menuName = "Card/CardEffect/Buff Effect")]
public class BuffEffect : CardEffect
{
    public Target target;
    public int buffAmount;

    public override void ApplyEffect() {
        // ���� ȿ���� �����ϴ� ������ �ۼ��մϴ�.
    }
}