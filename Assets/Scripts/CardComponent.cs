using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CardComponent : MonoBehaviour
{
    [SerializeField] Renderer frontBackgroud;
    [SerializeField] Renderer backBackground;

    [SerializeField] SpriteRenderer cardImage;
    //[SerializeField] Renderer cardImage;

    [SerializeField] TMP_Text cardname;
    [SerializeField] TMP_Text descriptcion;

    public Transform originPosision;

    private void Start() {
        
    }

    public void Setup(Card card) {
        this.cardname.text = card.name;
        this.cardImage.sprite = card.sprite;

    }

    public void SetOriginPosision() {

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
}