using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    [SerializeField] string sortingLayerName = "default";

    [SerializeField] Renderer[] frontRanderers;
    [SerializeField] Renderer[] middleRanderers;
    [SerializeField] Renderer[] backRanderers;

    private void Start() {
        SortingLayers();
    }

    public void SortingLayers(int order = 0) 
    {
        int orderPoint = (order*3) + 1;

        foreach (var render in frontRanderers) {
            render.sortingLayerName = sortingLayerName;
            render.sortingOrder = orderPoint + 1;
        }
        foreach (var render in middleRanderers) {
            render.sortingLayerName = sortingLayerName;
            render.sortingOrder = orderPoint;
        }
        foreach (var render in backRanderers) {
            render.sortingLayerName = sortingLayerName;
            render.sortingOrder = orderPoint - 1;
        }
    }
}
