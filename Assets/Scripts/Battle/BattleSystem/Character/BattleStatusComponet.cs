using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStatusComponet : MonoBehaviour
{
    [SerializeField] EnergysComponet energysComponet;

    private void Start() {
        if (energysComponet == null) {
            energysComponet = transform.GetComponentInChildren<EnergysComponet>();
        }
        
    }

    /// <summary>
    /// Status 정보 업데이트
    /// </summary>
    /// <param name="character">캐릭터 정보</param>
    public void UpdateStatus(Character character) {
        //캐릭터 상태 업데이트
        
        energysComponet.UpdateStatus(character.CurrentEnergy, character.MaxEnergy);
        DisplayStatus();
    }

    /// <summary>
    /// Status UI 출력
    /// </summary>
    public void DisplayStatus() {
        energysComponet.DisplayStatus();
    }
}
