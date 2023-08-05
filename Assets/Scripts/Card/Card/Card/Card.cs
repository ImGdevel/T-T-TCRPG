using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    protected CardData cardData;

    public string Name { get { return cardData.cardName; } }
    public Sprite Sprite { get { return cardData.cardImage; } }

    public Card(CardData data) {
        this.cardData = data;
    }

    public abstract void UseCard();
    public abstract Card Clone();
}

public class BattleCard : Card
{
    public int Cost { get { return ((BattleCardData)cardData).cardCost; } }
    public Target Target { get { return ((BattleCardData)cardData).cardTarget; } }
    public CardEffect[] Effects { get { return ((BattleCardData)cardData).effects; } }

    public BattleCard(BattleCardData data)
        : base(data) { }

    public override void UseCard() {
        // 전투 카드를 사용하는 로직을 작성합니다.
    }

    public override Card Clone() {
        BattleCard clone = new BattleCard((BattleCardData)this.cardData);
        return clone;
    }
}

public class ExplorationCard : Card
{
    public int Cost { get { return ((ExplorationCardData)cardData).requiredSteps; } }

    public ExplorationCard(ExplorationCardData data)
        : base(data) { }

    public override void UseCard() {
        // 탐험 카드를 사용하는 로직을 작성합니다.
    }

    public override Card Clone() {
        ExplorationCard clone = new ExplorationCard((ExplorationCardData)this.cardData);
        return clone;
    }
}

public class ArtifactCard : Card
{
    public ArtifactCard(ArtifactCardData data)
        : base(data) { }

    public override void UseCard() {
        // 아티팩트 카드를 사용하는 로직을 작성합니다.
    }

    public override Card Clone() {
        ArtifactCard clone = new ArtifactCard((ArtifactCardData)this.cardData);
        return clone;
    }
}