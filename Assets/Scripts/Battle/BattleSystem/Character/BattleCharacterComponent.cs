using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterComponent : MonoBehaviour
{
    protected Character character;
    public Target characterType;

    [SerializeField] BattleStatusComponent statusComponet;

    private void Start() {
        if (statusComponet == null) {
            statusComponet = transform.GetComponentInChildren<BattleStatusComponent>();
        }
    }

    public void SetCharacter(Character character) {
        this.character = character;
        UpdateStatus();
    }

    public void UpdateStatus() {
        if (character == null) {
            Debug.Log("Character not assigned");
            return;
        }
        statusComponet.UpdateStatus(character);
    }

    private bool isMouseOver = false;

    private void OnMouseEnter() {
        isMouseOver = true;
        StartCoroutine(ShowCharacterStateAfterDelay(2f));
    }

    private void OnMouseExit() {
        isMouseOver = false;
    }

    private System.Collections.IEnumerator ShowCharacterStateAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);

        if (isMouseOver) {
            // 캐릭터 상태를 보여주는 동작을 수행합니다.
            Debug.Log("캐릭터 상태: " + character.Name + " ( " + character.CurrentHealth + "/" + character.CurrentEnergy + ")");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Card") {
            HandCardComponent cardComponent = other.transform.GetComponent<HandCardComponent>();
            if (cardComponent.IsSelected) {
                Debug.Log("캐릭터에게 닿았습니다.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // 충돌이 끝날 때 호출됩니다.
    }
}


