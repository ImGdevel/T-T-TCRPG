using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterComponent : MonoBehaviour
{
    private Character character;
    private TargetType characterType;
    private BattleCharacterManager componentManager;

    public Character Character { get { return character; } }
    public TargetType CharacterType { get { return characterType; } }

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

    public void SetCharacterType(TargetType targetType) {
        this.characterType = targetType;
    }

    public void SetManager(BattleCharacterManager manager) {
        this.componentManager = manager;
    }

    public void UpdateStatus() {
        if (character == null) {
            Debug.LogError("Character not assigned");
            return;
        }
        statusComponet.UpdateStatus(character);
    }
    /*
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
    */

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Card") {
            HandCardComponent cardComponent = other.transform.GetComponent<HandCardComponent>();
            if (cardComponent.IsSelected) {
                SetTargetedByEnemy();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        UnsetTargetedByEnemy();
    }

    public void SetTargetedByEnemy() {
        shader.enabled = true;
    }

    public void UnsetTargetedByEnemy() {
        shader.enabled = false;
    }

    public List<Character> GetSiblingCharacters() {
        if (characterType == TargetType.Friendly) {
            return componentManager.GetPlayerCharacters();
        }
        else {
            return componentManager.GetEnemyCharacters();
        }
    }

    public List<BattleCharacterComponent> GetSiblingCharacterComponents() {
        if (characterType == TargetType.Friendly) {
            return componentManager.GetPlayerCharacterCompnenets();
        }
        else {
            return componentManager.GetEnemyCharacterCompnenets();
        }
    }
}


