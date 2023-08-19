using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyToken : MonoBehaviour
{
    [SerializeField] Renderer enegyToken;

    private bool active;

    private void Start() {
        if (enegyToken == null) {
            enegyToken = transform.GetComponentInChildren<Renderer>();
        }
        active = false;
    }

    public void UpdateStatus(bool state) {
        active = state;
    }

    public void DisplayStatus() {
        if (enegyToken != null) {
            enegyToken.enabled = active;
        }
    }
}
