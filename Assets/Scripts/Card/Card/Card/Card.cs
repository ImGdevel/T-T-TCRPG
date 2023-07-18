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
    protected new BattleCardData cardData;
    public int Cost { get { return cardData.cardCost; } }
    public Target Target { get { return cardData.cardTarget; } }
    public CardEffect[] Effects { get { return cardData.effects; } }

    public BattleCard(BattleCardData data) 
        : base(data) { }

    public override void UseCard() {
        // ���� ī�带 ����ϴ� ������ �ۼ��մϴ�.
    }

    public override Card Clone() {
        BattleCard clone = new(this.cardData);
        return clone;
    }

}

public class ExplorationCard : Card
{
    protected new ExplorationCardData cardData;
    public int Cost { get { return cardData.requiredSteps; } }

    public ExplorationCard(ExplorationCardData data) 
        : base(data) { }

    public override void UseCard() {
        // Ž�� ī�带 ����ϴ� ������ �ۼ��մϴ�.
    }

    public override Card Clone() {
        ExplorationCard clone = new(this.cardData);
        return clone;
    }
}

public class ArtifactCard : Card
{
    protected new ArtifactCardData cardData;

    public ArtifactCard(ArtifactCardData data) 
        : base(data) { }

    public override void UseCard() {
        // ��Ƽ��Ʈ ī�带 ����ϴ� ������ �ۼ��մϴ�.
    }

    public override Card Clone() {
        ArtifactCard clone = new(this.cardData);
        return clone;
    }
}
