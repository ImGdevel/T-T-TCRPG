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
    /// ��� �������� ���ӽð��� ���ҽ�Ű�� �Լ��Դϴ�.
    /// </summary>
    public void DecreaseAllBuffDurations() {
        foreach (Buff buff in buffs) {
            buff.Duration--;
        }

        buffs.RemoveAll(buff => buff.Duration <= 0);
    }

    /// <summary>
    /// Ư�� Ÿ�Կ� �ش��ϴ� �������� ���ӽð��� ���ҽ�Ű�� �Լ��Դϴ�.
    /// </summary>
    /// <param name="type">���ӽð��� ���ҽ�ų ���� Ÿ��</param>
    public void DecreaseBuffDurationsByType(BuffType type) {
        foreach (Buff buff in buffs) {
            if (buff.Type == type) {
                buff.Duration--;
            }
        }

        buffs.RemoveAll(buff => buff.Duration <= 0);
    }

    /// <summary>
    /// Ư�� Ÿ�Կ� �ش��ϴ� �������� �����ϴ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="type">������ ���� Ÿ��</param>
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