using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    //덱을 생성하고 관리합니다.
    public CardManager datas;

    // Start is called before the first frame update
    void Start() {
        RandomDeck(10);
    }

    // Update is called once per frame
    void Update() {

    }

    public List<Card> RandomDeck(int value) {
        List<Card> cards = new();

        foreach (var dat in datas.cards) {
            Card card = dat;
            for (int i = 0; i < value / datas.cards.Length; i++) {
                cards.Add(card);
            }
        }
        return cards;
    }
}
