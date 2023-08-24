using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSlot : MonoBehaviour
{
    Buff buff;
    SpriteRenderer buffRenderer;

    public void Start() {
        buffRenderer = transform.GetComponent<SpriteRenderer>();
    }

    public void UpdateStatus(Buff buff) {
        this.buff = buff;
    }

    public void DisplayStatus() {
        if (buff != null) {
            // ������ ���÷��� �ϴ� ���� �ۼ�
            buffRenderer.sprite = buff.Sprite;
            buffRenderer.enabled = true;
        }
        else {
            buffRenderer.enabled = false;
        }
    }

    public void SlotAcctive() {
        buffRenderer.enabled = true;
    }

    public void SlotUnactive() {
        buffRenderer.enabled = false;
    }

}
