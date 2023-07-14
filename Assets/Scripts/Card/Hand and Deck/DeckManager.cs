using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �����ϰ� �����մϴ�.
/// </summary>
public class DeckManager : MonoBehaviour
{
    public DeckManager Instance { get; private set; }
    [SerializeField] List<Card> initialDeck;
    private Deck deck;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
    }



    private void Start() {
        deck = new Deck(initialDeck);
        deck.Shuffle();
    }

    public Card DrawCard() {
        return deck.PopCard();
    }
}