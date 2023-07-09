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

    // Hand ����
    [SerializeField] int maxHandSize; // �ִ� �� ī�� ����

    // ���õ� Hand ī��
    private GameObject selectedCard;
    public bool isCardSelected = false;

    void Start() {
        handsPoint = this.transform;
        decks = Mydeck.RandomDeck(100); // ���� �����ɴϴ�.
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
        Card card = decks[0];
        decks.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// ������ ī�带 �̾� �÷��̾��� �տ� �߰��մϴ�.
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
    /// �÷��̾��� �տ� �ִ� ī�带 �����մϴ�.
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
    /// �ε����� ���� �÷��̾��� �տ� �ִ� ī���� ��ġ, ȸ�� �� ũ�⸦ ����մϴ�.
    /// </summary>
    /// <param name="number">ī���� �ε��� ���� ��ȣ</param>
    /// <returns>ī���� ��ġ, ȸ�� �� ũ�� ������ PRS(PRS(Position, Rotation, Scale)) ��</returns>
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
    /// �÷��̾��� �տ� �ִ� ī�带 �����մϴ�.
    /// </summary>
    /// <param name="card">���õ� ī�� ������Ʈ</param>
    public void SelectCard(GameObject card) {
        // �̹� ī�尡 ���õ� ���¶�� �����մϴ�.
        if (isCardSelected) return;

        isCardSelected = true;
    }

    /// <summary>
    /// ���� ī�带 �÷��̾��� �տ��� �����մϴ�.
    /// </summary>
    /// <param name="card">������ ī��</param>
    public void UseCardRemove(GameObject card) {
        // ���� ī�带 �տ��� �����մϴ�.
        Destroy(card, .1f);
        hands.Remove(card);

        SortingCard();
    }

    /// <summary>
    /// �÷��̾��� �տ� �ִ� ��� ī�带 ��� �����ϵ��� Ȱ��ȭ�մϴ�.
    /// </summary>
    public void EnableAllCards() {
        // ��� ī�带 ��� �����ϵ��� Ȱ��ȭ�մϴ�.
        for (int i = 0; i < hands.Count; i++) {
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            cardComponet.isMouseClick = true;
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
            var cardComponet = hands[i].GetComponent<HandCardComponent>();
            cardComponet.isMouseClick = false;
        }
    }
}
