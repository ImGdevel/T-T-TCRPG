using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergysComponent : MonoBehaviour
{
    [SerializeField] EnergyToken[] energyTokens;

    private void Start() {

    }

    /// <summary>
    /// 현제 에너지를 업데이트합니다.
    /// </summary>
    /// <param name="currnet_energy">현제 에너지</param>
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

    /// <summary>
    /// 현제 에너지를 업데이트합니다.
    /// </summary>
    /// <param name="max_energy">최대 에너지</param>
    /// <param name="currnet_energy">현제 에너지</param>
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

    /// <summary>
    /// 에너지 토큰을 디스플레이 합니다.
    /// </summary>
    public void DisplayStatus() {
        foreach (EnergyToken token in energyTokens) {
            token.DisplayStatus();
        }
    }
}
