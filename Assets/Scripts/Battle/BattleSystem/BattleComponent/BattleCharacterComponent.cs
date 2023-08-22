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
     

    private bool isComponentSelected;

    [SerializeField] Animator chracterAnimator;
    [SerializeField] BattleStatusComponent statusComponet;
    [SerializeField] TargetIndicator targetIndicator;

    private void Start() {
        if (statusComponet == null) {
            statusComponet = transform.GetComponentInChildren<BattleStatusComponent>();
        }
        if (targetIndicator == null) {
            targetIndicator = transform.GetComponentInChildren<TargetIndicator>();
        }
        if (chracterAnimator == null) {
            chracterAnimator = transform.GetComponentInChildren<Animator>();
        }
        isComponentSelected = false;
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
            DebugLog.Print(character);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Card") {
            BattleCardComponent cardComponent = other.transform.GetComponent<BattleCardComponent>();
            if (cardComponent.IsSelected) {
                SetTargetedByEnemy();
                BattleCard battleCard = (BattleCard)cardComponent.CardData;
                BattleEventManager.Instance.SelectCardTarget(this, battleCard.Target);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (isComponentSelected) {
            UnsetTargetedByEnemy();
            BattleEventManager.Instance.UnselectCardTarget();
        }
    }

    public void SetTargetedByEnemy() {
        isComponentSelected = true;
        targetIndicator.ShowIndicator();
    }

    public void UnsetTargetedByEnemy() {
        isComponentSelected = false;
        targetIndicator.HideIndicator();
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


