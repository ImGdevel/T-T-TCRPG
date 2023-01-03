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

    [SerializeField] SpriteRenderer cardImage;
    //[SerializeField] Renderer cardImage;

    [SerializeField] TMP_Text cardname;
    [SerializeField] TMP_Text descriptcion;

    public PRS originPosision;    

    public void Setup(Card card) {
        this.cardname.text = card.name;
        this.cardImage.sprite = card.sprite;
    }

    public void SetOriginPosision(PRS origin) {
        this.originPosision = origin;
    }

    public void MoveTransform(PRS movePoint, bool useDOTween, float time) {
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

    private void OnMouseEnter() {
        Vector3 pos = new(transform.position.x,transform.parent.position.y+1, -5);
        PRS prs = new(pos, Quaternion.identity, Vector3.one * 1.3f);
        MoveTransform(prs, true, 0.1f);

    }

    private void OnMouseExit() {
        MoveTransform(originPosision, true, 0.1f);
    }

    private void OnMouseDown() {
        Debug.Log("!!!");
    }
}