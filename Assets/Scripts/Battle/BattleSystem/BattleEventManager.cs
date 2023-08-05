using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    Character cardUser;
    List<Character> cardTarget;

    bool isUserSelected;
    bool isTargetSelected;
    private bool isPlayerTurn;

    // �̱���
    private static BattleEventManager instance;
    public static BattleEventManager Instance { get { return instance; } }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start() {
        cardTarget = new List<Character>();
        isUserSelected = false;
        isTargetSelected = false;

        TurnManager.OnTurnChange += CurrentTurn;
    }

    private void OnDestroy() {
        TurnManager.OnTurnChange -= CurrentTurn;
    }

    public void CurrentTurn(bool isPlayerTurn) {
        this.isPlayerTurn = isPlayerTurn;
    }

    public bool IsFriendly(TargetType target) {
        if (isPlayerTurn) {
            return (TargetType.Friendly == target);
        }
        else {
            return (TargetType.Enemy == target);
        }
    }


    public void SetCardUser(BattleCharacterComponent user) {
        // ī�带 ����ϴ� ĳ���� ��ü�� �����մϴ�.
        // �÷����ϰ� ���� ���� ���� �����ؾ���
        if (isPlayerTurn) {
            // �÷��̾� ���ΰ��
            // �ش� ����ڿ� ���� ����� �� �ִ� ī�� ����
        }
        isUserSelected = true;
    }

    public void SelectCardTarget(BattleCharacterComponent targetComponent, Target targetInfo) {
        if (isTargetSelected) {
            Debug.LogWarning("Ÿ���� �ߺ� ������!");
            return;
        }
        BattleCharacterComponent selectedTarget = targetComponent;

        switch (targetInfo.Range) {
            case TargetRange.Single:
                cardTarget.Add(selectedTarget.Character);
                break;

            case TargetRange.All:
                cardTarget.AddRange(selectedTarget.GetSiblingCharacters());
                break;
        }

        isTargetSelected = true;
    }

    public void UnselectCardTarget() {
        Debug.Log("Ÿ�� ��ҵ�");
        cardTarget.Clear();
        isTargetSelected = false;
    }

    public void CardUseEvent(BattleCard battleCard) {
        if (!isTargetSelected) {
            Debug.LogWarning(" Ÿ���� �������� ����");
            return;
        }
        // ī�� ��� �ִϸ��̼� ����

        // 1. ī�� ���� ī�带 ī�� ���ȭ�鿡 ���
        // 2. ī�带 ����� ��ü�� �ִϸ��̼� ���
        // 3. �ǰ� ��� �ִϸ��̼� ���
        // �ִϸ��̼� ���� �� �ٷ� �ǰ� ����
        // 4. �ǰ� ����� ������ ��� �ǰ� �ִϸ��̼� ���
        // -> �ִϸ޿��� ����� �ִϸ��̼� �Ŵ�������? �ƴϸ� ȿ�� ��� �ܰ迡��?
        // -> ���� ȿ�� ����

        Debug.Log("ī�� ����=>");
        BattleCard card = battleCard;

        ApplyCardEffectToCharacter(card.Effects);
        BattleCharacterManager.Instance.clearAllComponentSelections();
        UnselectCardTarget();
        isUserSelected = false;
    }

    // �� ���� ĳ������ Ÿ���� �����ǰ� ī�� Ÿ���� �����ǰ�....
    // ���������� ����ϸ�

    public void ApplyCardEffectToCharacter(CardEffect[] cardEffects) {
        foreach (CardEffect effect in cardEffects) {
            if (effect is DamageEffect) {
                DamageEffect ef = (DamageEffect)effect;

                ApplyDamageEffect(cardTarget, ef.damageAmount);
            }
            else if (effect is BuffEffect) {
                BuffEffect ef = (BuffEffect)effect;

                ApplyBuffEffect(cardTarget, ef.buff);
            }

        }
        BattleCharacterManager.Instance.UptateStatus();
    }

    private void ApplyDamageEffect(List<Character> characters, int damage) {
        foreach (Character target in characters) {

            target.TakeDamage(damage);
            Debug.Log("������ ����!");
            // ĳ���� �ִϸ��̼� �߰�
        }
    }

    private void ApplyBuffEffect(List<Character> characters, Buff buff) {
        foreach (Character target in characters) {
            target.TakeBuff(buff);

            // ĳ���� �ִϸ��̼� �߰�
        }
    }
}
