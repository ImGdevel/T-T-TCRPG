using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChangeButton : MonoBehaviour
{

    [SerializeField] TurnManager turnManager;

    private void Start() {
        turnManager = TurnManager.Instance;
    }

    public void NextTurn() {
        this.turnManager.NextTurn();
        // 턴 변경시 버튼 애니메이션 추가
    }


}
