using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergysComponent : MonoBehaviour
{
    [SerializeField] EnergyToken[] energyTokens;

    private void Start() {

    }

    public void UpdateStatus(int currnet_energy) {

        for (int index = 0; index < energyTokens.Length; index++) {
            if (index <= currnet_energy) {
                energyTokens[index].UpdateStatus(true);
            }
            else {
                energyTokens[index].UpdateStatus(false);
            }
        }
    }

    public void UpdateStatus(int max_energy, int currnet_energy) {

        for (int index = 0; index < max_energy; index++) {
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
