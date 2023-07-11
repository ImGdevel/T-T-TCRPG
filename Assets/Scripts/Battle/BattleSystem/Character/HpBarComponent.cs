using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarComponent : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject fill;

    PRS originPos;
    Vector3 barStartPoint;

    private float max = 1.0f;
    private float point = 1.0f;

    private void Start() {
        if (background == null) {
            Debug.LogError("The background of the HpBar component does not exist.");
        }
        if (fill == null) {
            Debug.LogError("The background of the HpBar component does not exist.");
        }
        else {

            originPos = new PRS(fill.transform.position, fill.transform.rotation, fill.transform.localScale);
            Renderer renderer = fill.GetComponent<Renderer>();
            barStartPoint = renderer.bounds.min;
        }
        DisplayStatus();


    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            point -= 0.1f;
            UpdateStatus(point, 1.0f);
        }
    }

    public void UpdateStatus(float point, float max = 1.0f) {
        this.point = point;
        this.max = max;

        DisplayStatus();
    }

    public void DisplayStatus() {
        PRS currentHpBar = new PRS(originPos.position, originPos.rotation, originPos.scale);
        if (max == 0) {
            Debug.LogWarning("Max Hp is Zero");
            return;
        }
        float precent = point / max;
        Renderer renderer = fill.GetComponent<Renderer>();
        float currentBarLegth = (fill.transform.position.x - renderer.bounds.min.x) * precent;
        currentHpBar.scale.x = precent * (originPos.scale.x);
        currentHpBar.position.x = barStartPoint.x + currentBarLegth;

        DoTweenAnimation.MoveTransform(fill.transform, currentHpBar, 0.3f);
    }
}