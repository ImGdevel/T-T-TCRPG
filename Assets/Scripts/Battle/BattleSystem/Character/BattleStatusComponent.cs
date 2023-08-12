using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStatusComponent : MonoBehaviour
{
    [SerializeField] HpBarComponent hpBarComponent;
    [SerializeField] EnergysComponent energysComponet;
    [SerializeField] BuffSlotContainerComponent buffSlotContainerComponent;

    private void Start() {
        if (hpBarComponent == null) {
            Debug.LogError("필수 컴포넌트가 없습니다: HpBarComponent");
        }
        if (energysComponet == null) {
            Debug.LogError("필수 컴포넌트가 없습니다: EnergysComponent");
        }
        if (buffSlotContainerComponent == null) {
            Debug.LogError("필수 컴포넌트가 없습니다: BuffSlotContainerComponent ");
        }
    }

    /// <summary>
    /// Status 정보 업데이트
    /// </summary>
    /// <param name="character">캐릭터 정보</param>
    public void UpdateStatus(Character character) {
        //캐릭터 상태 업데이트
        hpBarComponent.UpdateStatus(character.MaxHealth, character.CurrentHealth);
        energysComponet.UpdateStatus(character.MaxEnergy, character.CurrentEnergy);
        buffSlotContainerComponent.UpdateStatus(character);
        DisplayStatus();
    }

    /// <summary>
    /// Status UI 출력
    /// </summary>
    public void DisplayStatus() {
        hpBarComponent.DisplayStatus();
        energysComponet.DisplayStatus();
        buffSlotContainerComponent.DisplayStatus();
    }
}
