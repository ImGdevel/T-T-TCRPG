using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefeb;
    [SerializeField] DeckManager Mydeck;
    [SerializeField] Transform deckPoint;
    [SerializeField] Transform handsPoint;
    [SerializeField] List<Card> decks;
    [SerializeField] List<GameObject> hands;

    // Hand Setting
    [SerializeField] int maxHandSize; // maximum hand card

    // selcted HandCard
    GameObject selectedCard;
    public bool isCardSelected = false; 


    // Start is called before the first frame update
    void Start()
    {
        handsPoint = this.transform;
        decks = Mydeck.RandomDeck(100); //덱을 가져옵니다.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DrowCard();
        }
    }

    Card PopItem() {
        Card card = decks[0];
        decks.RemoveAt(0);
        return card;
    }

    void DrowCard() {
        if (maxHandSize <= hands.Count) return;

        var cardInstance = Instantiate(cardPrefeb, deckPoint.position, Quaternion.identity, this.transform);
        var cardComponet = cardInstance.GetComponent<HandCardComponent>();
        cardComponet.Setup(PopItem());
        cardComponet.SetParent(this);
        hands.Add(cardInstance);
        SortingCard();
    }

    public void SortingCard() {
        for(int i=0; i< hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            var pos = RadiansPRS(i);
            cardComponet.MoveTransform(pos, true, 0.5f);
            cardComponet.SetOriginPosition(pos);
            cardComponet.SortingCardLayers(i);
            cardComponet.SetOriginSortingLayer(i);
        }
    }

    PRS RadiansPRS(int number) {
        float gap = 1;
        float slope = 1;
        float radius = 25;
        float count = hands.Count;
        float MaxWidth = handsPoint.position.x - ((count-1) / 2  * gap);
        float Xpos = MaxWidth + number * gap;
        float Ypos = this.transform.position.y + UMath.Base(radius, Xpos) 
                     - UMath.Base(radius, MaxWidth) - (radius - UMath.Base(radius, MaxWidth)) / 2;
        var rot = Quaternion.Slerp(Quaternion.Euler(0, 0, count * slope), Quaternion.Euler(0, 0, -count * slope), 1 / count * number);
        
        return new PRS(new Vector3(Xpos, Ypos), rot, Vector3.one);
    }

    public void SelectCard(GameObject card) {
        if (isCardSelected) return;
        isCardSelected = true;
    }

   
    public void UseCardRemove(GameObject card) {
        Destroy(card, .1f);
        hands.Remove(card);
        
        SortingCard();
    }


}
