using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{

    public delegate void TurnChangeDelegate(bool isPlayerTurn);
    public static event TurnChangeDelegate OnTurnChange;

    private bool isPlayerTurn = true;

    private IEnumerator Start() {
        // 게임 시작 시 초기 턴을 설정합니다.
        yield return StartCoroutine(ChangeTurn());
    }

    public IEnumerator ChangeTurn() {
        yield return new WaitForSeconds(1f); // 턴 변경 시간 지연

        isPlayerTurn = !isPlayerTurn;

        // 턴 변경 이벤트를 발생시킵니다.
        OnTurnChange?.Invoke(isPlayerTurn);

        if (isPlayerTurn) {
            Debug.Log("Player's Turn");
            // TODO: 플레이어 턴 처리

        }
        else {
            Debug.Log("Enemy's Turn");
            // TODO: 적 턴 처리

        }

        // TODO: 필요한 경우 추가적인 로직을 구현합니다.
    }

    public void NextTurn() {
        Debug.Log("클릭");
        ChangeTurn();
    }
}