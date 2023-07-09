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

    // Hand 설정
    [SerializeField] int maxHandSize; // 최대 손 카드 개수

    // 선택된 Hand 카드
    private GameObject selectedCard;
    public bool isCardSelected = false;

    void Start() {
        handsPoint = this.transform;
        decks = Mydeck.RandomDeck(100); // 덱을 가져옵니다.
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DrowCard();
        }
    }

    /// <summary>
    /// 덱에서 아이템(카드)을 가져옵니다.
    /// </summary>
    /// <returns> 가져온 카드 </returns>
    Card PopItem() {
        Card card = decks[0];
        decks.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// 덱에서 카드를 뽑아 플레이어의 손에 추가합니다.
    /// </summary>
    void DrowCard() {
        if (maxHandSize <= hands.Count) return;

        var cardInstance = Instantiate(cardPrefeb, deckPoint.position, Quaternion.identity, this.transform);
        var cardComponet = cardInstance.GetComponent<HandCardComponent>();
        cardComponet.Setup(PopItem());
        cardComponet.SetParent(this);
        hands.Add(cardInstance);
        SortingCard();
    }

    /// <summary>
    /// 플레이어의 손에 있는 카드를 정렬합니다.
    /// </summary>
    public void SortingCard() {
        for (int i = 0; i < hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            var pos = RadiansPRS(i);
            cardComponet.MoveTransform(pos, true, 0.5f);
            cardComponet.SetOriginPosition(pos);
            cardComponet.SortingCardLayers(i);
            cardComponet.SetOriginSortingLayer(i);
        }
    }

    /// <summary>
    /// 인덱스에 따라 플레이어의 손에 있는 카드의 위치, 회전 및 크기를 계산합니다.
    /// </summary>
    /// <param name="number">카드의 인덱스 순서 번호</param>
    /// <returns>카드의 위치, 회전 및 크기 정보인 PRS(PRS(Position, Rotation, Scale)) 값</returns>
    PRS RadiansPRS(int number) {
        float gap = 1;
        float slope = 1;
        float radius = 25;
        float count = hands.Count;
        float MaxWidth = handsPoint.position.x - ((count - 1) / 2 * gap);
        float Xpos = MaxWidth + number * gap;
        float Ypos = this.transform.position.y + UMath.Base(radius, Xpos) - UMath.Base(radius, MaxWidth) - (radius - UMath.Base(radius, MaxWidth)) / 2;
        var rot = Quaternion.Slerp(Quaternion.Euler(0, 0, count * slope), Quaternion.Euler(0, 0, -count * slope), 1 / count * number);

        return new PRS(new Vector3(Xpos, Ypos), rot, Vector3.one);
    }

    /// <summary>
    /// 플레이어의 손에 있는 카드를 선택합니다.
    /// </summary>
    /// <param name="card">선택된 카드 오브젝트</param>
    public void SelectCard(GameObject card) {
        // 이미 카드가 선택된 상태라면 무시합니다.
        if (isCardSelected) return;

        isCardSelected = true;
    }

    /// <summary>
    /// 사용된 카드를 플레이어의 손에서 제거합니다.
    /// </summary>
    /// <param name="card">제거할 카드</param>
    public void UseCardRemove(GameObject card) {
        // 사용된 카드를 손에서 제거합니다.
        Destroy(card, .1f);
        hands.Remove(card);

        SortingCard();
    }

    /// <summary>
    /// 플레이어의 손에 있는 모든 카드를 사용 가능하도록 활성화합니다.
    /// </summary>
    public void EnableAllCards() {
        // 모든 카드를 사용 가능하도록 활성화합니다.
        for (int i = 0; i < hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            cardComponet.isMouseClick = true;
        }
    }

    /// <summary>
    /// 조건에 맞는 카드만 플레이어의 손에서 사용 가능하도록 활성화합니다.
    /// </summary>
    public void EnableCardsByCondition() {
        // 조건에 맞는 카드만 사용 가능하도록 활성화합니다.
        // 조건을 인자로 받아와 해당 조건이 충족되면 카드를 활성화합니다.
    }

    /// <summary>
    /// 플레이어의 손에 있는 모든 카드를 사용 불가능하도록 비활성화합니다.
    /// </summary>
    public void DisableAllCards() {
        // 모든 카드를 사용 불가능하도록 비활성화합니다.
        for (int i = 0; i < hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            cardComponet.isMouseClick = false;
        }
    }
}
