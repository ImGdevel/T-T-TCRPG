using System.Collections;
using System.Collections.Generic;

public class BuffManager
{
 /*   
    private List<Buff> buffs;

    public BuffManager() {
        buffs = new List<Buff>();
    }

    public List<Buff> GetBuffs() {
        return buffs;
    }

    /// <summary>
    /// 모든 버프들의 지속시간을 감소시키는 함수입니다.
    /// </summary>
    public void DecreaseAllBuffDurations() {
        foreach (Buff buff in buffs) {
            buff.Duration--;
        }

        buffs.RemoveAll(buff => buff.Duration <= 0);
    }

    /// <summary>
    /// 특정 타입에 해당하는 버프들의 지속시간을 감소시키는 함수입니다.
    /// </summary>
    /// <param name="type">지속시간을 감소시킬 버프 타입</param>
    public void DecreaseBuffDurationsByType(BuffType type) {
        foreach (Buff buff in buffs) {
            if (buff.Type == type) {
                buff.Duration--;
            }
        }

        buffs.RemoveAll(buff => buff.Duration <= 0);
    }

    /// <summary>
    /// 특정 타입에 해당하는 버프들을 삭제하는 함수입니다.
    /// </summary>
    /// <param name="type">삭제할 버프 타입</param>
    public void RemoveBuffsByType(BuffType type) {
        buffs.RemoveAll(buff => buff.Type == type);
    }

    public void AddBuff(Buff buff) {
        buffs.Add(buff);
        SortBuffs();
    }

    public void RemoveBuff(Buff buff) {
        buffs.Remove(buff);
    }

    public void SortBuffs() {
        buffs.Sort((buff1, buff2) => buff1.Type.CompareTo(buff2.Type));
    }
    */
}