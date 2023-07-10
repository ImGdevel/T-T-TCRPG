using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyToken : MonoBehaviour
{
    [SerializeField] Renderer enegyToken;

    private bool active;

    private void Start() {
        active = false;
    }

    public void Update(bool state) {
        active = state;
    }

    public void Display() {
        enegyToken.enabled = active;
    }

}
