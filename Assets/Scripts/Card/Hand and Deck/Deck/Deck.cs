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
    /// ���� ī�� �ϳ��� �߰��մϴ�.
    /// </summary>
    /// <param name="card">�߰��� ī��</param>
    public void AddCard(Card card) {
        cards.Add(card);
    }

    /// <summary>
    /// ���� ī�� ��ġ�� �߰��մϴ�.
    /// </summary>
    /// <param name="deck">�߰��� ī�嵦</param>
    public void AddDeck(List<Card> deck) {
        cards.AddRange(deck);
    }

    /// <summary>
    /// �������� ���� �����ϴ�.
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
    /// ī�帮��Ʈ���� �Ǿտ� ī���� �ϳ� �����ɴϴ�.
    /// </summary>
    /// <returns> ����Ʈ ���� ī�� </returns>
    public Card PopCard() {
        if (cards.Count == 0) {
            //Debug.LogWarning("���� �� �̻� ī�尡 �����ϴ�!");
            return null;
        }

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// �� ����
    /// </summary>
    /// <returns>����� ��</returns>
    public object Clone() {
        List<Card> clonedCards = new List<Card>();

        foreach (Card card in cards) {
            clonedCards.Add((Card)card.Clone());
        }

        return new Deck(clonedCards);
    }
}