public class Buff
{
    public BuffData buffData;
    public int remainingTurns; // 남은 지속 턴 수

    public string Name { get; }
    public BuffType Type { get; }
    public int Duration { set; get; }

    public Buff(BuffData buffData) {
        this.buffData = buffData;
        remainingTurns = buffData.duration;
    }
    public void ApplyBuff(Character target) {

    }
}
