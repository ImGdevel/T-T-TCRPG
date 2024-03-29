using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] DeckManager deckManager;
    [SerializeField] Transform deckPoint;
    [SerializeField] Transform handPoint;

    
    protected List<GameObject> hands;//핸드
    
    [SerializeField] 
    int maxHandSize; // 최대 손 카드 개수

    // 선택된 Hand 카드
    private GameObject selectedCard;
    public bool isCardSelected = false;

    void Start() {
        handPoint = this.transform;
        hands = new();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DrowCard();
        }
    }

    /// <summary>
    /// 덱에서 카드를 뽑아 플레이어의 손에 추가합니다.
    /// </summary>
    void DrowCard() {
        if (maxHandSize <= hands.Count)
            return;

        GameObject cardInstance = Instantiate(cardPrefab, deckPoint.position, Quaternion.identity, transform);
        HandCardComponent cardComponent = cardInstance.GetComponent<HandCardComponent>();
        Card drawCard = deckManager.DrawCard();
        cardComponent.Setup(drawCard);
        cardComponent.SetParent(this);
        hands.Insert(0, cardInstance);
        SortCards();
    }

    /// <summary>
    /// 플레이어의 손에 있는 카드를 정렬합니다.
    /// </summary>
    public void SortCards() {
        for (int i = 0; i < hands.Count; i++) {
            HandCardComponent cardComponent = hands[i].GetComponent<HandCardComponent>();
            PRS position = CalculateCardPosition(i);
            cardComponent.MoveTransform(position, true, 0.3f);
            cardComponent.SetOriginPosition(position);
            cardComponent.SortingCardLayers(i);
            cardComponent.SetOriginSortingLayer(i);
        }
    }

    /// <summary>
    /// 플레이어의 손에 있는 카드를 선택합니다.
    /// </summary>
    /// <param name="card">선택된 카드 오브젝트</param>
    public void SelectCard(GameObject card) {
        // 이미 카드가 선택된 상태라면 무시합니다.
        if (isCardSelected) { 
            return; 
        }
        isCardSelected = true;
    }

    /// <summary>
    /// 사용된 카드를 플레이어의 손에서 제거합니다.
    /// </summary>
    /// <param name="card">제거할 카드</param>
    public void UseCardRemove(GameObject card) {
        // 사용된 카드를 손에서 제거합니다.
        Destroy(card, 0.1f);
        hands.Remove(card);
        SortCards();
    }

    /// <summary>
    /// 플레이어의 손에 있는 모든 카드를 사용 가능하도록 활성화합니다.
    /// </summary>
    public void EnableAllCards() {
        // 모든 카드를 사용 가능하도록 활성화합니다.
        for (int i = 0; i < hands.Count; i++) {
            HandCardComponent cardComponent = hands[i].GetComponent<HandCardComponent>();
            cardComponent.isMouseClick = true;
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
            HandCardComponent cardComponent = hands[i].GetComponent<HandCardComponent>();
            cardComponent.isMouseClick = false;
        }
    }

    /// <summary>
    /// 인덱스에 따라 플레이어의 손에 있는 카드의 위치, 회전 및 크기를 계산합니다.
    /// </summary>
    /// <param name="index">카드의 인덱스 순서 번호</param>
    /// <returns>카드의 위치, 회전 및 크기 정보인 PRS(PRS(Position, Rotation, Scale)) 값</returns>
    private PRS CalculateCardPosition(int index) {
        float slope = 1f;
        float radius = 25f;
        float count = hands.Count;
        float gapPoint = Mathf.Log(count) * 2f;
        float gap = (10f - gapPoint) / 6f;


        float maxWidth = handPoint.position.x - ((count - 1f) / 2f * gap);
        float xPos = maxWidth + index * gap;
        float yPos = transform.position.y + UMath.Base(radius, xPos)
                     - UMath.Base(radius, maxWidth) - (radius - UMath.Base(radius, maxWidth)) / 2f;

        Quaternion rotation = Quaternion.Slerp(
            Quaternion.Euler(0f, 0f, count * slope),
            Quaternion.Euler(0f, 0f, -count * slope),
            1f / count * index
        );
        return new PRS(new Vector3(xPos, yPos), rotation, Vector3.one);
    }
}
