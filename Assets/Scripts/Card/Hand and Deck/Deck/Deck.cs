using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Card> cards;

    public Deck() {
        cards = cards = new List<Card>();
    }

    public Deck(List<Card> initialCards) {
        cards = initialCards;
    }

    /// <summary>
    /// 덱에 카드 하나를 추가합니다.
    /// </summary>
    /// <param name="card">추가할 카드</param>
    public void AddCard(Card card) {
        cards.Add(card);
    }

    /// <summary>
    /// 덱에 카드 뭉치를 추가합니다.
    /// </summary>
    /// <param name="deck">추가할 카드덱</param>
    public void AddDeck(List<Card> deck) {
        cards.AddRange(deck);
    }

    /// <summary>
    /// 무작위로 덱을 섞습니다.
    /// </summary>
    public void Shuffle() {
        int n = cards.Count;
        System.Random random = new System.Random();

        for (int i = 0; i < n - 1; i++) {
            int j = random.Next(i, n);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    /// <summary>
    /// 카드리스트에서 맨앞에 카드을 하나 가져옵니다.
    /// </summary>
    /// <returns> 리스트 선입 카드 </returns>
    public Card PopCard() {
        if (cards.Count == 0) {
            //Debug.LogWarning("덱에 더 이상 카드가 없습니다!");
            return null;
        }

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// 덱 복사
    /// </summary>
    /// <returns>복사된 덱</returns>
    public object Clone() {
        List<Card> clonedCards = new List<Card>();

        foreach (Card card in cards) {
            clonedCards.Add((Card)card.Clone());
        }

        return new Deck(clonedCards);
    }
}