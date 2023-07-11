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
    /// Status ���� ������Ʈ
    /// </summary>
    /// <param name="character">ĳ���� ����</param>
    public void UpdateStatus(Character character) {
        //ĳ���� ���� ������Ʈ

        energysComponet.UpdateStatus(character.CurrentEnergy, character.MaxEnergy);
        DisplayStatus();
    }

    /// <summary>
    /// Status UI ���
    /// </summary>
    public void DisplayStatus() {
        hpBarComponent.DisplayStatus();
        energysComponet.DisplayStatus();
    }
}
