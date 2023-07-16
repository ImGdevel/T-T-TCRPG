using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterComponent : MonoBehaviour
{
    protected Character character;

    [SerializeField] BattleStatusComponent statusComponet;

    private Rigidbody2D rb; // Rigidbody2D ������Ʈ �߰�

    private void Start() {
        if (statusComponet == null) {
            statusComponet = transform.GetComponentInChildren<BattleStatusComponent>();
        }

        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ �Ҵ�
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
            Debug.Log("ĳ���Ͱ� ��ҽ��ϴ�.");
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        // �浹 ���°� �����Ǵ� ���� ȣ��˴ϴ�.
    }

    private void OnTriggerExit2D(Collider2D other) {
        // �浹�� ���� �� ȣ��˴ϴ�.
    }
}


