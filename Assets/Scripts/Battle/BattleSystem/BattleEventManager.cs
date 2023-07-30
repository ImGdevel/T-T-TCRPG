using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    List<Character> friendly;
    List<Character> enemy;

    Character CardUser;
    Character Target;

    bool isUserSelected;
    bool isTargetSelected;

    // 싱글톤
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

        isUserSelected = false;
        isTargetSelected = false;
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
        // 카드를 사용하는 캐릭터 주체를 지정합니다.

        // 플레이턴과 적의 턴을 따로 설정해야함

        if (isPlayerTurn) {
            // 플레이어 턴인경우

            // 해당 사용자에 따라 사용할 수 있는 카드 지정
            

        }

        isUserSelected = true;
    }

    public void SetCardTarget(BattleCharacterComponent target) {




        isTargetSelected = true;
    }

    public void CardUseEvent(BattleCard battleCard) {
        if (!isTargetSelected || !isUserSelected) {
            Debug.LogWarning(" 타겟이 지정되지 않음");
            return;
        }
        // 카드 사용 애니메이션 시행

        // 1. 카드 사용시 카드를 카드 사용화면에 출력
        // 2. 카드를 사용한 주체가 애니메이션 출력
        // 3. 피격 대상도 애니메이션 출력
        // 애니메이션 종료 후 바로 피격 적용
        // 4. 피격 대상이 적군인 경우 피격 애니메이션 출력
        // -> 애니메에션 출력은 애니메이션 매니저에서? 아니면 효과 출력 단계에서?
        // -> 이후 효과 적용
        BattleCard card = battleCard;


        ApplyCardEffectToCharacter(card.Effects);


        isTargetSelected = false;
        isUserSelected = false;
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

            // 캐릭터 애니메이션 추가
        }
    }

    private void ApplyBuffEffect(List<Character> characters, Buff buff) {
        foreach (Character target in characters) {
            target.TakeBuff(buff);

            // 캐릭터 애니메이션 추가
        }
    }
}
