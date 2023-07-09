using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    protected CardData cardData;

    public string Name { get { return cardData.cardName; } }
    public Sprite Sprite { get { return cardData.cardImage; } }
    public string Description { get { return cardData.cardDescription; } }

    public abstract void UseCard();
    public abstract Card Clone();
}

public class BattleCard : Card
{
    protected int cost;
    public int Cost { get { return Cost; } }

    public override void UseCard() {
        // ���� ī�带 ����ϴ� ������ �ۼ��մϴ�.
    }

    public override Card Clone() {
        BattleCard clone = new();
        clone.cardData = this.cardData;
        clone.cost = this.cost;
        return clone;
    }

}

public class ExplorationCard : Card
{
    public int requiredSteps;

    public override void UseCard() {
        // Ž�� ī�带 ����ϴ� ������ �ۼ��մϴ�.
    }

    public override Card Clone() {
        ExplorationCard clone = new();
        clone.cardData = this.cardData;
        return clone;
    }
}

public class ArtifactCard : Card
{
    public override void UseCard() {
        // ��Ƽ��Ʈ ī�带 ����ϴ� ������ �ۼ��մϴ�.
    }

    public override Card Clone() {
        ArtifactCard clone = new();
        clone.cardData = this.cardData;
        return clone;
    }
}
