using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterComponent : MonoBehaviour
{
    protected Character character;
    private BattleCharacterManager componentManager;
    private TargetType characterType;
    

    public TargetType CharacterType { get { return characterType; } }
    public Character Character { get { return character; } }

    [SerializeField] BattleStatusComponent statusComponet;
    [SerializeField] Renderer shader;

    private void Start() {
        if (statusComponet == null) {
            statusComponet = transform.GetComponentInChildren<BattleStatusComponent>();
        }
    }

    public void SetCharacter(Character character) {
        this.character = character;
        UpdateStatus();
    }

    public void SetManager(BattleCharacterManager manager) {
        this.componentManager = manager;
    }

    public void SetCharacterType(TargetType targetType) {
        this.characterType = targetType;
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
            // ĳ���� ���¸� �����ִ� ������ �����մϴ�.
            Debug.Log("ĳ���� ����: " + character.Name + " ( " + character.CurrentHealth + "/" + character.CurrentEnergy + ")");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Card") {
            HandCardComponent cardComponent = other.transform.GetComponent<HandCardComponent>();
            if (cardComponent.IsSelected) {
                Debug.Log("ĳ���Ϳ��� ��ҽ��ϴ�.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // �浹�� ���� �� ȣ��˴ϴ�.
        UnsetTargetedByEnemy();
    }

    public void SetTargetedByEnemy() {
        //ĳ���Ͱ� ���õȰ��� ������ UIó��
        Debug.Log("�� ������Ʈ�� ���� �� �Դϴ�.");
        shader.enabled = true;
    }

    public void UnsetTargetedByEnemy() {
        shader.enabled = false;
    }

    public List<BattleCharacterComponent> GetSiblingCharacterComponents() {
        if (characterType == TargetType.Friendly) {
            return componentManager.GetPlayerCharacterCompnenets();
        }
        else {
            return componentManager.GetEnemyCharacterCompnenets();
        }
    }

    public List<Character> GetSiblingCharacters() {
        if (characterType == TargetType.Friendly) {
            return componentManager.GetPlayerCharacters();
        }
        else {
            return componentManager.GetEnemyCharacters();
        }
    }

}


