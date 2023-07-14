using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �����ϰ� �����մϴ�.
/// </summary>
public class DeckManager : MonoBehaviour
{
    public DeckManager Instance { get; private set; }
    public CardList sampleCards;
    private Deck deck;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        deck = new Deck(sampleDeckGenerate());
        deck.Shuffle();
    }

    public List<Card> sampleDeckGenerate() {
        List<Card> cards = new();
        foreach (BattleCardData data in sampleCards.cards) {
            Card newCard = new BattleCard(data);
            cards.Add(newCard);
        }

        return cards;
    }

    public Card DrawCard() {
        return deck.PopCard();
    }
}