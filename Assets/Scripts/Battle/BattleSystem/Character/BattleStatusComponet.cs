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
        energysComponet.DisplayStatus();
    }
}
