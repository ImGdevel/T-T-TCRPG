using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{

    List<Character> friendly;
    List<Character> enemy;

    public void CardUseEvent() {
        


    }

    public void ApplyCardEffectToCharacter(CardEffect[] cardEffects) {
        foreach (CardEffect effect in cardEffects) {

            if (effect is DamageEffect) {
                DamageEffect ef = (DamageEffect)effect;
                
                ApplyDamageEffect(friendly, ef.damageAmount);
            }
            else if(effect is BuffEffect) {
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
