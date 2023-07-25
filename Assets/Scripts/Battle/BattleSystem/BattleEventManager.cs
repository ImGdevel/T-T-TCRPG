using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    List<Character> friendly;
    List<Character> enemy;

    // �̱���
    private static BattleEventManager instance;
    public static BattleEventManager Instance { get { return instance; } }

    public bool isPlayerTurn;

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
        TurnManager.OnTurnChange += CurrentTurn;
    }

    private void OnDestroy() {
        TurnManager.OnTurnChange -= CurrentTurn;
    }

    public void CurrentTurn(bool isPlayerTurn) {
        this.isPlayerTurn = isPlayerTurn;
    }

    

    public void CardUseEvent(BattleCard battleCard) {
        Debug.Log("ī�� �̺�Ʈ ����");

        // ī�� ��� �ִϸ��̼� ����

        // 1. ī�� ���� ī�带 ī�� ���ȭ�鿡 ���
        // 2. ī�带 ����� ��ü�� �ִϸ��̼� ���
        // 3. �ǰ� ��� �ִϸ��̼� ���
        // �ִϸ��̼� ���� �� �ٷ� �ǰ� ����
        // 4. �ǰ� ����� ������ ��� �ǰ� �ִϸ��̼� ���
        // -> �ִϸ޿��� ����� �ִϸ��̼� �Ŵ�������? �ƴϸ� ȿ�� ��� �ܰ迡��?
        // -> ���� ȿ�� ����


    }

    public void ApplyCardEffectToCharacter(CardEffect[] cardEffects) {
        foreach (CardEffect effect in cardEffects) {
            Target target = effect.target;
            
            TargetType targetType = target.Type;
            TargetRange targetRange = target.Range;



            List<Character> targetList = new();


            if (effect is DamageEffect) {
                DamageEffect ef = (DamageEffect)effect;

                ApplyDamageEffect(friendly, ef.damageAmount);
            }
            else if (effect is BuffEffect) {
                BuffEffect ef = (BuffEffect)effect;

                ApplyBuffEffect(enemy, ef.buff);
            }

        }
    }

    private void ApplyDamageEffect(List<Character> characters, int damage) {
        foreach (Character target in characters) {
            target.TakeDamage(damage);

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
