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
    [SerializeField] List<Card> deck;
    [SerializeField] List<GameObject> hands;

    // Hand ����
    [SerializeField] int maxHandSize; // �ִ� �� ī�� ����

    // ���õ� Hand ī��
    private GameObject selectedCard;
    public bool isCardSelected = false;

    void Start() {
        handPoint = this.transform;
        //deck = deckManager.RandomDeck(100); // ���� �����ɴϴ�.
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DrowCard();
        }
    }

    /// <summary>
    /// ������ ������(ī��)�� �����ɴϴ�.
    /// </summary>
    /// <returns> ������ ī�� </returns>
    Card PopItem() {
        Card card = deck[0];
        deck.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// ������ ī�带 �̾� �÷��̾��� �տ� �߰��մϴ�.
    /// </summary>
    void DrowCard() {
        if (maxHandSize <= hands.Count)
            return;

        GameObject cardInstance = Instantiate(cardPrefab, deckPoint.position, Quaternion.identity, transform);
        HandCardComponent cardComponent = cardInstance.GetComponent<HandCardComponent>();
        cardComponent.Setup(PopItem());
        cardComponent.SetParent(this);
        hands.Add(cardInstance);
        SortCards();
    }

    /// <summary>
    /// �÷��̾��� �տ� �ִ� ī�带 �����մϴ�.
    /// </summary>
    public void SortCards() {
        for (int i = 0; i < hands.Count; i++) {
            HandCardComponent cardComponent = hands[i].GetComponent<HandCardComponent>();
            PRS position = CalculateCardPosition(i);
            cardComponent.MoveTransform(position, true, 0.5f);
            cardComponent.SetOriginPosition(position);
            cardComponent.SortingCardLayers(i);
            cardComponent.SetOriginSortingLayer(i);
        }
    }

    /// <summary>
    /// �ε����� ���� �÷��̾��� �տ� �ִ� ī���� ��ġ, ȸ�� �� ũ�⸦ ����մϴ�.
    /// </summary>
    /// <param name="index">ī���� �ε��� ���� ��ȣ</param>
    /// <returns>ī���� ��ġ, ȸ�� �� ũ�� ������ PRS(PRS(Position, Rotation, Scale)) ��</returns>
    PRS CalculateCardPosition(int index) {
        float gap = 1f;
        float slope = 1f;
        float radius = 25f;
        float count = hands.Count;

        float maxWidth = handPoint.position.x - ((count - 1f) / 2f * gap);
        float xPos = maxWidth + index * gap;
        float yPos = transform.position.y + UMath.Base(radius, xPos)
                     - UMath.Base(radius, maxWidth) - (radius - UMath.Base(radius, maxWidth)) / 2f;

        Quaternion rotation = Quaternion.Slerp(
            Quaternion.Euler(0f, 0f, count * slope),
            Quaternion.Euler(0f, 0f, -count * slope),
            1f / (count * index)
        );

        return new PRS(new Vector3(xPos, yPos), rotation, Vector3.one);
    }

    /// <summary>
    /// �÷��̾��� �տ� �ִ� ī�带 �����մϴ�.
    /// </summary>
    /// <param name="card">���õ� ī�� ������Ʈ</param>
    public void SelectCard(GameObject card) {
        // �̹� ī�尡 ���õ� ���¶�� �����մϴ�.
        if (isCardSelected) { 
            return; 
        }
        isCardSelected = true;
    }

    /// <summary>
    /// ���� ī�带 �÷��̾��� �տ��� �����մϴ�.
    /// </summary>
    /// <param name="card">������ ī��</param>
    public void UseCardRemove(GameObject card) {
        // ���� ī�带 �տ��� �����մϴ�.
        Destroy(card, 0.1f);
        hands.Remove(card);
        SortCards();
    }

    /// <summary>
    /// �÷��̾��� �տ� �ִ� ��� ī�带 ��� �����ϵ��� Ȱ��ȭ�մϴ�.
    /// </summary>
    public void EnableAllCards() {
        // ��� ī�带 ��� �����ϵ��� Ȱ��ȭ�մϴ�.
        for (int i = 0; i < hands.Count; i++) {
            HandCardComponent cardComponent = hands[i].GetComponent<HandCardComponent>();
            cardComponent.isMouseClick = true;
        }
    }

    /// <summary>
    /// ���ǿ� �´� ī�常 �÷��̾��� �տ��� ��� �����ϵ��� Ȱ��ȭ�մϴ�.
    /// </summary>
    public void EnableCardsByCondition() {
        // ���ǿ� �´� ī�常 ��� �����ϵ��� Ȱ��ȭ�մϴ�.
        // ������ ���ڷ� �޾ƿ� �ش� ������ �����Ǹ� ī�带 Ȱ��ȭ�մϴ�.
    }

    /// <summary>
    /// �÷��̾��� �տ� �ִ� ��� ī�带 ��� �Ұ����ϵ��� ��Ȱ��ȭ�մϴ�.
    /// </summary>
    public void DisableAllCards() {
        // ��� ī�带 ��� �Ұ����ϵ��� ��Ȱ��ȭ�մϴ�.
        for (int i = 0; i < hands.Count; i++) {
            HandCardComponent cardComponent = hands[i].GetComponent<HandCardComponent>();
            cardComponent.isMouseClick = false;
        }
    }
}
