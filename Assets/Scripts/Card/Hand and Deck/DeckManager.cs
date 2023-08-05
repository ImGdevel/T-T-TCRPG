using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 덱을 생성하고 관리합니다.
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
        SetDeck();
    }

    public List<Card> sampleDeckGenerate() {
        List<Card> cards = new();
        foreach (BattleCardData data in sampleCards.cards) {
            Card newCard = new BattleCard(data);
            cards.Add(newCard);
        }

        return cards;
    }

    public void SetDeck() {
        deck = new Deck(sampleDeckGenerate());
        deck.Shuffle();
    }

    public Card DrawCard() {
        Card drawingCard = deck.PopCard();
        if (drawingCard == null) {
            SetDeck();
            drawingCard = deck.PopCard();
        }
        return drawingCard;
    }
}