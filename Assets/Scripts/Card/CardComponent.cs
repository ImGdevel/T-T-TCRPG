using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using TMPro;

public class CardComponent : MonoBehaviour
{
    [SerializeField] Renderer frontBackgroud;
    [SerializeField] Renderer backBackground;
    [SerializeField] SpriteRenderer cardSprite;
    [SerializeField] TMP_Text cardNameText;
    [SerializeField] TMP_Text cardDescriptcionText;

    [SerializeField] Renderer[] cardRanderers;
    [SerializeField] Renderer[] textRanderers;

    bool doAnimation;
    Card cardInfo;

    public void Start() {
        
    }

    public void SortingCardLayers(int order) {
        int orderPoint = (order * 3) + 1;

        frontBackgroud.sortingOrder = orderPoint;
        cardSprite.sortingOrder = orderPoint - 1;

        foreach (var render in cardRanderers) {
            render.sortingLayerName = "card";
            render.sortingOrder = orderPoint;
        }

        foreach (var render in textRanderers) {
            render.sortingLayerName = "card";
            render.sortingOrder = orderPoint + 1;
        }
    }

    // card setting
    public void Setup(Card card) {
        cardInfo = card;
        cardNameText.text = card.name;
        cardSprite.sprite = card.sprite;
    }

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
}