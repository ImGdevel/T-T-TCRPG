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
    private GameObject selectedCard;
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
        //현재 선택된 카드
        if (isCardSelected) return;
        isCardSelected = true;
    }

   
    public void UseCardRemove(GameObject card) {
        //사용된 카드 핸드에서 삭제
        Destroy(card, .1f);
        hands.Remove(card);
        
        SortingCard();
    }

    public void EnableAllCards() {
        // 모든 카드 사용 활성화
        for (int i = 0; i < hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            cardComponet.isMouseClick = true;
        }
    }

    public void EnableCardsByCondition() {
        // 조건에 맞는 카드만 활성화
        // 인자로 카드 조건을 받고 조건이 성립하면 카드 활성화
    }

    public void DisableAllCards() {
        // 모든 카드 사용 비활성화
        for (int i = 0; i < hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            cardComponet.isMouseClick = false;
        }
    }
}
