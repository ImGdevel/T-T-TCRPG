using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using DG.Tweening;
using TMPro;

public abstract class CardComponent : MonoBehaviour
{
    [SerializeField] Renderer frontBackground;
    [SerializeField] Renderer backBackground;
    [SerializeField] SpriteRenderer cardSprite;
    [SerializeField] TMP_Text cardNameText;
    [SerializeField] TMP_Text cardDescriptionText;

    [SerializeField] Renderer[] cardRenderers;
    [SerializeField] Renderer[] textRenderers;

    protected Card card;
    protected Card CardData { get {return card; }}

    public bool isMouseClick = true;
    public bool isMouseOver = true;

    protected abstract void OnMouseEnter();
    protected abstract void OnMouseExit();
    protected abstract void OnMouseDown();

    /// <summary>
    /// ī�� ������ �����մϴ�.
    /// </summary>
    /// <param name="card">������ ī�� ����</param>
    public void Setup(Card card) {
        this.card = card;
        this.cardNameText.text = card.Name;
        this.cardSprite.sprite = card.Sprite;
    }

    /// <summary>
    /// ī�带 �̵���ŵ�ϴ�.
    /// </summary>
    /// <param name="movePoint">�̵��� ��ġ, ȸ��, ũ�� ����</param>
    /// <param name="useDOTween">DOTween�� ����Ͽ� �ִϸ��̼��� �������� ����</param>
    /// <param name="time">�ִϸ��̼ǿ� �ɸ��� �ð�</param>
    public void MoveTransform(PRS movePoint, bool useDOTween, float time = 1) {
        var pos = movePoint.position;
        var rot = movePoint.rotation;
        var scl = movePoint.scale;

        if (useDOTween) {
            transform.DOMove(pos, time);
            transform.DORotateQuaternion(rot, time);
            transform.DOScale(scl, time);
        }
        else {
            transform.position = pos;
            transform.rotation = rot;
            transform.localScale = scl;
        }
    }

    /// <summary>
    /// ī�� ���̾� ������ �����մϴ�.
    /// </summary>
    /// <param name="order"> ī�� ���� ���� ��ȣ</param>
    public void SortingCardLayers(int order) {
        int orderPoint = (order * 3) + 1;

        frontBackground.sortingOrder = orderPoint;
        cardSprite.sortingOrder = orderPoint - 1;

        foreach (var renderer in cardRenderers) {
            renderer.sortingLayerName = "card";
            renderer.sortingOrder = orderPoint;
        }

        foreach (var renderer in textRenderers) {
            renderer.sortingLayerName = "card";
            renderer.sortingOrder = orderPoint + 1;
        }
    }
}