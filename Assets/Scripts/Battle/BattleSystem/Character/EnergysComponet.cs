using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergysComponet : MonoBehaviour
{
    [SerializeField] EnergyToken[] energyTokens;

    private int maxiToken;
    private int currnetToken;

    private void Start() {
        this.maxiToken = 6;
    }

    public void UpdateStatus(int currnet_energy) {
        currnetToken = currnet_energy;
        for(int index = 0; index < maxiToken; index++) {
            if (index <= currnet_energy) {
                energyTokens[index].UpdateStatus(true);
            }
            else {
                energyTokens[index].UpdateStatus(false);
            }
        }
    }

    public void DisplayStatus() {
        foreach (EnergyToken token in energyTokens) {
            token.DisplayStatus();
        }
    }
}
