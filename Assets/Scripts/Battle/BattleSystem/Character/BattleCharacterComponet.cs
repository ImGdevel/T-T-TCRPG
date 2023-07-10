using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterComponet : MonoBehaviour
{
    protected Character character;

    [SerializeField] BattleStatusComponet statusComponet;

    private void Start() {
        if(statusComponet == null) {
            statusComponet = transform.GetComponentInChildren<BattleStatusComponet>();
        }
    }

    public void SetCharacter(Character character) {
        this.character = character;
    }

    public void UpdateStatus() {
        if (character == null) {
            Debug.Log("Character not assigned");
            return;
        }
        statusComponet.UpdateStatus(character);
    }

}


