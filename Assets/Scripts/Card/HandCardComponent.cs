using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using TMPro;

public class HandCardComponent : CardComponent
{
    HandManager handManager;
    PRS originPosition;
    int originSortingLayer;
    bool activeHandOverAni = true;
    bool isSelected = false;

    /// <summary>
    /// �� �����Ӹ��� ȣ��Ǵ� �޼���
    /// </summary>
    void Update() {

        if (isSelected) {
            // ī�� ���� ���� ó��
            if (Input.GetMouseButton(1)) {
                // ī�带 ����
                UnselectCard();
            }
            else {
                // ���콺 ��ġ�� ī�� �̵�
                this.transform.position = Input.mousePosition;
            }
        }
    }

    /// <summary>
    /// HandManager�� ���� ī��� �����մϴ�.
    /// </summary>
    /// <param name="parent">���� HandManager</param>
    public void SetParent(HandManager parent) {
        if (this.handManager == null)
            this.handManager = parent;
    }

    /// <summary>
    /// ���� ��ġ�� �����մϴ�.
    /// </summary>
    /// <param name="origin">���� ��ġ ����</param>
    public void SetOriginPosition(PRS origin) {
        this.originPosition = origin;
    }

    /// <summary>
    /// ���� Sorting Layer�� �����մϴ�.
    /// </summary>
    /// <param name="origin">���� Sorting Layer ��</param>
    public void SetOriginSortingLayer(int origin) {
        this.originSortingLayer = origin;
    }

    /// <summary>
    /// ���콺�� ī�忡 �� �� ȣ��Ǵ� �޼���
    /// </summary>
    public override void OnMouseEnter() {
        
        if (!activeHandOverAni || isSelected) return;

        Vector3 pos = new Vector3(transform.position.x, transform.parent.position.y + 1, -5);
        PRS prs = new PRS(pos, Quaternion.identity, Vector3.one * 1.3f);
        MoveTransform(prs, true, 0.1f);
        SortingCardLayers(100);
    }

    /// <summary>
    /// ���콺�� ī�忡�� ��� �� ȣ��Ǵ� �޼���
    /// </summary>
    public override void OnMouseExit() {
        
        if (!activeHandOverAni || isSelected) return;

        MoveTransform(originPosition, true, 0.1f);
        SortingCardLayers(originSortingLayer);
    }

    /// <summary>
    /// ���콺�� ī�带 Ŭ������ �� ȣ��Ǵ� �޼���
    /// </summary>
    public override void OnMouseDown() {

        if (!isSelected && !handManager.isCardSelected) {
            isSelected = true;
            this.transform.localScale = Vector3.one;
            handManager.SelectCard(this.gameObject);
        }
        else {
            UseCard();
        }
    }

    /// <summary>
    /// ī�� ���� ���� �޼���
    /// </summary>
    public void UnselectCard() {
        isSelected = false;
        handManager.isCardSelected = false;
        MoveTransform(originPosition, false);
        SortingCardLayers(originSortingLayer);
    }

    /// <summary>
    /// ī�� ��� �޼���
    /// </summary>
    public void UseCard() {
        Debug.Log("ī�� ���");
        isSelected = false;
        handManager.isCardSelected = false;
        handManager.UseCardRemove(this.gameObject);
    }
}