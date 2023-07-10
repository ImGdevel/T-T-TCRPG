using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStatusComponet : MonoBehaviour
{
    [SerializeField] EnergysComponet energysComponet;


    public void UpdateStatus(Character character) {
        //캐릭터 상태 업데이트

        

        DisplayStatus();
    }

    public void DisplayStatus() {
        // 캐릭터 상태 출력
    }
}
