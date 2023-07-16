using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterComponent : MonoBehaviour
{
    protected Character character;

    [SerializeField] BattleStatusComponent statusComponet;

    private Rigidbody2D rb; // Rigidbody2D 컴포넌트 추가

    private void Start() {
        if (statusComponet == null) {
            statusComponet = transform.GetComponentInChildren<BattleStatusComponent>();
        }

        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 할당
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Card") {
            Debug.Log("캐릭터가 닿았습니다.");
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        // 충돌 상태가 유지되는 동안 호출됩니다.
    }

    private void OnTriggerExit2D(Collider2D other) {
        // 충돌이 끝날 때 호출됩니다.
    }
}


