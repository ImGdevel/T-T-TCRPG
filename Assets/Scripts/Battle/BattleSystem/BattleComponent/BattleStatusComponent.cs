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
            Debug.LogError("�ʼ� ������Ʈ�� �����ϴ�: HpBarComponent");
        }
        if (energysComponet == null) {
            Debug.LogError("�ʼ� ������Ʈ�� �����ϴ�: EnergysComponent");
        }
        if (buffSlotContainerComponent == null) {
            Debug.LogError("�ʼ� ������Ʈ�� �����ϴ�: BuffSlotContainerComponent ");
        }
    }

    /// <summary>
    /// Status ���� ������Ʈ
    /// </summary>
    /// <param name="character">ĳ���� ����</param>
    public void UpdateStatus(Character character) {
        //ĳ���� ���� ������Ʈ
        hpBarComponent.UpdateStatus(character.MaxHealth, character.CurrentHealth);
        energysComponet.UpdateStatus(character.MaxEnergy, character.CurrentEnergy);
        buffSlotContainerComponent.UpdateStatus(character);
        DisplayStatus();
    }

    /// <summary>
    /// Status UI ���
    /// </summary>
    public void DisplayStatus() {
        hpBarComponent.DisplayStatus();
        energysComponet.DisplayStatus();
        buffSlotContainerComponent.DisplayStatus();
    }
}
