using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Effect", menuName = "Card/CardEffect/Buff Effect")]
public class BuffEffect : CardEffect
{
    public int buffAmount;
    public Buff buff;

    public override void ApplyEffect() {
        // ���� ȿ���� �����ϴ� ������ �ۼ��մϴ�.
    }
}