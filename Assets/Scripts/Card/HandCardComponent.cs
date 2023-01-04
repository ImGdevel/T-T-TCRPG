using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using TMPro;

public class HandCardComponent : CardComponent
{
    HandManager handManager;
    PRS originPosision;
    int originSortingLayer;
    bool activeHandOverAni = true;
    bool isSelected = false;

    public void Update() {
        if (isSelected) {
            // do select card
            if (Input.GetMouseButton(1)) {
                // put down card
                UnselectCard();
            }
            else {
                // picked card
                this.transform.position = Utills.MousePointer;
            }
        }
    }

    public void SetParent(HandManager parent) {
        if(this.handManager == null)
            this.handManager = parent;
    }

    public void SetOriginPosision(PRS origin) {
        this.originPosision = origin;
    }

    public void SetOriginSortingLayer(int origin) {
        this.originSortingLayer = origin;
    }

    private void OnMouseEnter() {
        if (!activeHandOverAni || isSelected) return;
        Vector3 pos = new(transform.position.x, transform.parent.position.y + 1, -5);
        PRS prs = new(pos, Quaternion.identity, Vector3.one * 1.3f);
        MoveTransform(prs, true, 0.1f);
        SortingCardLayers(100);
    }

    private void OnMouseExit() {
        if (!activeHandOverAni || isSelected) return;
        MoveTransform(originPosision, true, 0.1f);
        SortingCardLayers(originSortingLayer);
    }

    private void OnMouseDown() {
        if (!isSelected && !handManager.isCardSelected) {
            isSelected = true;
            this.transform.localScale = Vector3.one;
            handManager.SelectCard(this);
            Debug.Log("Pick card");
        }
        else {
            Debug.Log("card Use");
        }
    }

    public void UnselectCard() {
        isSelected = false;
        handManager.isCardSelected = false;
        MoveTransform(originPosision, false);
        SortingCardLayers(originSortingLayer);
    }
}