using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    List<Character> friendly;
    List<Character> enemy;

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
    }

    private void OnDestroy() {
        TurnManager.OnTurnChange -= CurrentTurn;
    }

    public void CurrentTurn(bool isPlayerTurn) {
        this.isPlayerTurn = isPlayerTurn;
    }

    

    public void CardUseEvent(BattleCard battleCard) {
        Debug.Log("카드 이벤트 적용");

        // 카드 사용 애니메이션 시행

        // 1. 카드 사용시 카드를 카드 사용화면에 출력
        // 2. 카드를 사용한 주체가 애니메이션 출력
        // 3. 피격 대상도 애니메이션 출력
        // 애니메이션 종료 후 바로 피격 적용
        // 4. 피격 대상이 적군인 경우 피격 애니메이션 출력
        // -> 애니메에션 출력은 애니메이션 매니저에서? 아니면 효과 출력 단계에서?
        // -> 이후 효과 적용


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
