using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuffList : IEnumerable<Buff>
{
    private List<Buff> buffs = new List<Buff>();

    /// <summary>
    /// 버프를 리스트에 추가합니다.
    /// </summary>
    /// <param name="buff">추가할 버프</param>
    public void AddBuff(Buff buff) {
        buffs.Add(buff);
    }

    /// <summary>
    /// 버프를 리스트에서 제거합니다.
    /// </summary>
    /// <param name="buffInstance">제거할 버프 인스턴스</param>
    public void RemoveBuff(Buff buffInstance) {
        buffs.Remove(buffInstance);
    }

    /// <summary>
    /// 버프 리스트를 정렬합니다.
    /// </summary>
    public void SortBuffs() {
        // TODO: 버프를 기준에 맞춰 정렬하는 로직을 추가하세요.
    }

    /// <summary>
    /// 버프효과를 대상 캐릭터에 적용합니다.
    /// </summary>
    /// <param name="character">대상 캐릭터</param>
    public void ApplyBuffs(Character character) {
        // TODO: 대상 캐릭터에게 버프효과를 적용하는 로직을 추가하세요.
    }

    /// <summary>
    /// 현재 활성화된 버프 리스트를 반환합니다.
    /// </summary>
    /// <returns>활성화된 버프 리스트</returns>
    public IEnumerator<Buff> GetEnumerator() {
        return buffs.GetEnumerator();
    }

    // IEnumerable 인터페이스 구현
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    /// <summary>
    /// 버프의 지속 턴 수를 업데이트하고 만료된 경우 제거합니다.
    /// </summary>
    public void UpdateBuffs() {
        for (int i = buffs.Count - 1; i >= 0; i--) {
            Buff buffInstance = buffs[i];
            buffInstance.remainingDuration--;
            if (buffInstance.remainingDuration <= 0) {
                // 버프의 지속 턴 수가 0 이하면 제거합니다.
                buffs.RemoveAt(i);
                RemoveBuff(buffInstance);
            }
        }
    }
}