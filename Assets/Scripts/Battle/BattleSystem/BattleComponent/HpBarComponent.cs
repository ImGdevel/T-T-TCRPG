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
    private float current = 1.0f;

    public float Max //Slider Value MAX
    {
        set {
            if (value > 0) max = value;
            else Debug.LogWarning("Max is zero");
        }
        get { return max; }
    }

    public float Value //Slider Value
    {
        set { 
            if (value > 0) current = value; 
            else current = 0;  
        }
        get { return current; }
    }

    private void Awake() {
        if (background == null || fill == null) {
            Debug.LogError("Background or fill GameObject is not assigned in HpBarComponent.");
            return;
        }
        //HP Bar Setting
        Renderer renderer = fill.GetComponent<Renderer>();
        originPos = new PRS(fill.transform.position, fill.transform.rotation, fill.transform.localScale);
        barStartPoint = renderer.bounds.min;
    }

    /// <summary>
    /// HP bar��������Ʈ �մϴ�.
    /// </summary>
    /// <param name="current">���� HP</param>
    public void UpdateStatus(float current) {
        Value = current;

    }


    /// <summary>
    /// HP bar�� ������Ʈ�մϴ�.
    /// </summary>
    /// <param name="max">�ִ� HP</param>
    /// <param name="current">���� HP</param>
    public void UpdateStatus(float max, float current) {
        Value = current;
        Max = max;

    }

    /// <summary>
    /// HP bar�� ���÷����մϴ�.
    /// </summary>
    public void DisplayStatus() {
        if (max == 0) {
            Debug.LogWarning("Max is zero. Cannot display bar.");
            return;
        }

        PRS currentHpBarState = new PRS(originPos.position, originPos.rotation, originPos.scale);
        Renderer renderer = fill.GetComponent<Renderer>();
        float precent = current / max;

        currentHpBarState.position.x = barStartPoint.x + (fill.transform.position.x - renderer.bounds.min.x) * precent;
        currentHpBarState.scale.x *= precent;

        DoTweenAnimation.MoveTransform(fill.transform, currentHpBarState, 0.25f);
    }
}