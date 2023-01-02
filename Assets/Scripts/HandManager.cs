using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefeb;
    [SerializeField] DeckManager Mydeck;

    // Hand Setting
    [SerializeField] float handWidth; //핸드 너비
    [SerializeField] int maxCard; //최대로 가질 수 있는 카드 갯수



    [SerializeField] List<Card> decks;
    [SerializeField] List<GameObject> hands;

    [SerializeField] Transform deckPoint;
    [SerializeField] Transform handsPoint;

    int selected; //선택된 카드

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

    // 카드 한장만 뽑기
    void DrowCard() {
        if (maxCard <= hands.Count) return;

        //카드 인스턴스 생성
        var cardInstance = Instantiate(cardPrefeb, deckPoint.position, Quaternion.identity, this.transform);
        var cardComponet = cardInstance.GetComponent<CardComponent>();
        cardComponet.Setup(PopItem());
        
        //핸드에 카드 추가
        hands.Add(cardInstance);
        SortingCard();
    }

    void SortingCard() {
        for(int i=0; i< hands.Count; i++) {
            var layerComponet = hands[i].GetComponent<SortingLayer>();
            var cardComponet = hands[i].GetComponent<CardComponent>();

            cardComponet.MoveTransform(RadiansPRS(i), true, 0.5f);
            layerComponet.SortingLayers(i);
            
        }
    }

    PRS RadiansPRS(int number) {
        float gap = 1f;
        float curve = 3f;
        float count = hands.Count;
        float center = handsPoint.position.x;
        float LPos = center - ((count - 1) / 2) * gap;
        float RPos = center + ((count - 1) / 2) * gap;
        
        float LRot = ((count - 1) / 2) * curve;




        float height = handWidth;
        float Xpos = LPos + number * gap;

        float Ypos = this.transform.position.y + Math.Base(height, Xpos) - Math.Base(height, RPos);
        
        



        float rot = LRot - number * curve;



        PRS pos = new(new Vector3(Xpos,Ypos), Quaternion.Euler(0, 0, rot), Vector3.one);
        return pos;
    }
}
