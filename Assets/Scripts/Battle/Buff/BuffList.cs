using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuffList : IEnumerable<Buff>
{
    private List<Buff> buffs = new List<Buff>();

    /// <summary>
    /// ������ ����Ʈ�� �߰��մϴ�.
    /// </summary>
    /// <param name="buff">�߰��� ����</param>
    public void AddBuff(Buff buff) {
        buffs.Add(buff);
    }

    /// <summary>
    /// ������ ����Ʈ���� �����մϴ�.
    /// </summary>
    /// <param name="buffInstance">������ ���� �ν��Ͻ�</param>
    public void RemoveBuff(Buff buffInstance) {
        buffs.Remove(buffInstance);
    }

    /// <summary>
    /// ���� ����Ʈ�� �����մϴ�.
    /// </summary>
    public void SortBuffs() {
        // TODO: ������ ���ؿ� ���� �����ϴ� ������ �߰��ϼ���.
    }

    /// <summary>
    /// ����ȿ���� ��� ĳ���Ϳ� �����մϴ�.
    /// </summary>
    /// <param name="character">��� ĳ����</param>
    public void ApplyBuffs(Character character) {
        // TODO: ��� ĳ���Ϳ��� ����ȿ���� �����ϴ� ������ �߰��ϼ���.
    }

    /// <summary>
    /// ���� Ȱ��ȭ�� ���� ����Ʈ�� ��ȯ�մϴ�.
    /// </summary>
    /// <returns>Ȱ��ȭ�� ���� ����Ʈ</returns>
    public IEnumerator<Buff> GetEnumerator() {
        return buffs.GetEnumerator();
    }

    // IEnumerable �������̽� ����
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    /// <summary>
    /// ������ ���� �� ���� ������Ʈ�ϰ� ����� ��� �����մϴ�.
    /// </summary>
    public void UpdateBuffs() {
        for (int i = buffs.Count - 1; i >= 0; i--) {
            Buff buffInstance = buffs[i];
            buffInstance.remainingDuration--;
            if (buffInstance.remainingDuration <= 0) {
                // ������ ���� �� ���� 0 ���ϸ� �����մϴ�.
                buffs.RemoveAt(i);
                RemoveBuff(buffInstance);
            }
        }
    }
}