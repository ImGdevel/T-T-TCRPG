using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStatusComponent : MonoBehaviour
{
    [SerializeField] EnergysComponent energysComponet;
    [SerializeField] HpBarComponent hpBarComponent;

    private void Start() {
        if (energysComponet == null) {
            energysComponet = transform.GetComponentInChildren<EnergysComponent>();
        }
        if (hpBarComponent == null) {
            hpBarComponent = transform.GetComponentInChildren<HpBarComponent>();
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
        DisplayStatus();
    }

    /// <summary>
    /// Status UI 출력
    /// </summary>
    public void DisplayStatus() {
        hpBarComponent.DisplayStatus();
        energysComponet.DisplayStatus();
    }
}
