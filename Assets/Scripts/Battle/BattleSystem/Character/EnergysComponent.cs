using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergysComponent : MonoBehaviour
{
    [SerializeField] EnergyToken[] energyTokens;

    private void Start() {

    }

    /// <summary>
    /// ���� �������� ������Ʈ�մϴ�.
    /// </summary>
    /// <param name="currnet_energy">���� ������</param>
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
    /// ���� �������� ������Ʈ�մϴ�.
    /// </summary>
    /// <param name="max_energy">�ִ� ������</param>
    /// <param name="currnet_energy">���� ������</param>
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
    /// ������ ��ū�� ���÷��� �մϴ�.
    /// </summary>
    public void DisplayStatus() {
        foreach (EnergyToken token in energyTokens) {
            token.DisplayStatus();
        }
    }
}
