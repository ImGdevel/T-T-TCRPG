using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using TMPro;

public class HandCardComponent : CardComponent
{
    private HandManager handManager; // �ڵ� �޴���
    private PRS originPosition; // ���� Transform ��ġ
    private int originSortingLayer; // ���� ī�� ��ȣ
    private bool activeHandOverAni = true; // ī�� �ִϸ��̼� �۵� ����
    private bool isSelected = false; // ī�� ���� ����

    public bool IsSelected { get { return isSelected; } }

    public bool IsCardEnabled {
        set { isMouseClick = value; }
        get { return isMouseClick; }
    } // ī�� Ȱ��ȭ ����

    private void Start() {
        isMouseOver = true;
        IsCardEnabled = true;
        isSelected = false;
    }

    private void Update() {
        if (!isSelected) return;
        
        // ī�� ���� ���� ó��
        if (Input.GetMouseButton(1)) {
            // ī�带 ����
            UnselectCard();
        }
        else {
            // ���콺 ��ġ�� ī�� �̵�
            this.transform.position = Utills.MousePointer;
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
        if (!isMouseOver || !activeHandOverAni || isSelected) return;

        Vector3 pos = new Vector3(transform.position.x, transform.parent.position.y + 1, -5);
        PRS prs = new PRS(pos, Quaternion.identity, Vector3.one * 1.3f);
        MoveTransform(prs, true, 0.1f);
        SortingCardLayers(100);
    }

    /// <summary>
    /// ���콺�� ī�忡�� ��� �� ȣ��Ǵ� �޼���
    /// </summary>
    public override void OnMouseExit() {
        if (!isMouseOver || !activeHandOverAni || isSelected) return;

        MoveTransform(originPosition, true, 0.1f);
        SortingCardLayers(originSortingLayer);
    }

    /// <summary>
    /// ���콺�� ī�带 Ŭ������ �� ȣ��Ǵ� �޼���
    /// </summary>
    public override void OnMouseDown() {
        if (!isMouseClick) return;

        if (!isSelected && !handManager.isCardSelected) {
            // �ڵ忡�� ���� 
            isSelected = true;
            this.transform.localScale = Vector3.one;
            handManager.SelectCard(this.gameObject);
        }
        else {
            // ī����
            UseCard();
        }
    }

    /// <summary>
    /// ī�� ���� ����
    /// </summary>
    public void UnselectCard() {
        isSelected = false;
        handManager.isCardSelected = false;
        MoveTransform(originPosition, true, 0.1f);
        SortingCardLayers(originSortingLayer);
    }

    /// <summary>
    /// ī�� ���
    /// </summary>
    public void UseCard() {
        // ������ Ÿ�ٿ��� ȿ���� �ο��Ѵ�.



        isSelected = false;
        handManager.isCardSelected = false;
        handManager.UseCardRemove(this.gameObject);
    }

    /// <summary>
    /// ī�� ��� Ȱ��ȭ
    /// </summary>
    public void EnableCard() {
        IsCardEnabled = true;
        // ī�� ��� Ȱ��ȭ �ִϸ��̼�
    }

    /// <summary>
    /// ī�� ��� ��Ȱ��ȭ
    /// </summary>
    public void DisableCard() {
        IsCardEnabled = false;
        // ī�� ��� �� Ȱ��ȭ �ִϸ��̼�
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (isSelected && other.tag == "Character") {
            Debug.Log("ī�尡 ��ҽ��ϴ�.");
            // ī�带 ����� ĳ���� ����.
            // ī�忡 ����� Ÿ�ٿ� ���� ������ ������� �Ǻ�

            BattleCard BCardData = (BattleCard)CardData;
            BattleCharacterComponent character = other.transform.GetComponent<BattleCharacterComponent>();

            if (BCardData.Target == character.characterType) {

            }
            else {
                // ���� �ʴٸ� �ƹ� �� ����
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // �浹�� ���� �� ȣ��˴ϴ�.
        // TriggerEnter2D���� �ߴ� ��� ���� �ʱ�ȭ 
        UnselectCard();
    }

}