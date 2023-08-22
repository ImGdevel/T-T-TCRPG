using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer indicatorSprite;

    [SerializeField]
    private Color targetedIndicatorColor;
    private Color originIndicatorColor;

    void Start() {
        indicatorSprite = transform.GetComponent<SpriteRenderer>();
        if(indicatorSprite == null) {
            Debug.LogError("No TargetIndicator Sprites");
            return;
        }
        originIndicatorColor = indicatorSprite.color;
    }

    public void ShowIndicator() {
        indicatorSprite.color = targetedIndicatorColor;
    }

    public void HideIndicator() {
        indicatorSprite.color = originIndicatorColor;
    }
}
