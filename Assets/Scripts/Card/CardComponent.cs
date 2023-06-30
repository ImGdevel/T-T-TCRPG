using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CardComponent : MonoBehaviour
{
    [SerializeField] Renderer frontBackground;
    [SerializeField] Renderer backBackground;
    [SerializeField] SpriteRenderer cardSprite;
    [SerializeField] TMP_Text cardNameText;
    [SerializeField] TMP_Text cardDescriptionText;

    [SerializeField] Renderer[] cardRenderers;
    [SerializeField] Renderer[] textRenderers;

    bool doAnimation;
    Card cardInfo;

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

    /// <summary>
    /// 카드 정보를 설정합니다.
    /// </summary>
    /// <param name="card">설정할 카드 정보</param>
    public void Setup(Card card) {
        cardInfo = card;
        cardNameText.text = card.name;
        cardSprite.sprite = card.sprite;
    }

    /// <summary>
    /// 카드를 이동시킵니다.
    /// </summary>
    /// <param name="movePoint">이동할 위치, 회전, 크기 정보</param>
    /// <param name="useDOTween">DOTween을 사용하여 애니메이션을 실행할지 여부</param>
    /// <param name="time">애니메이션에 걸리는 시간</param>
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