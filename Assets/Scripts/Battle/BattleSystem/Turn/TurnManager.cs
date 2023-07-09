using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public delegate void TurnChangeDelegate(bool isPlayerTurn);
    public static event TurnChangeDelegate OnTurnChange;

    private const float TurnChangeDelay = 1.0f;
    private bool isPlayerTurn = true;
    
    private IEnumerator Start() {
        // 게임 시작 시 초기 턴을 설정합니다.
        yield return StartCoroutine(ChangeTurn());
    }

    public void NextTurn() {
        StartCoroutine(ChangeTurn());
    }

    public IEnumerator ChangeTurn() {
        yield return new WaitForSeconds(TurnChangeDelay); // 턴 변경 시간 지연
        Debug.Log("턴 변경 로직 작동");

        //턴 변경
        isPlayerTurn = !isPlayerTurn;

        // 턴 변경 이벤트를 발생시킵니다. 구독한 녀석에게 전달
        OnTurnChange?.Invoke(isPlayerTurn);

        // 다른곳에서도 사용가능하도록 범용성을 가져야다.
        if (isPlayerTurn) {
            Debug.Log("Player's Turn");
            // TODO: 플레이어에서 턴 처리

        }
        else {
            Debug.Log("Enemy's Turn");
            // TODO: 적 턴에서 처리

        }

        // TODO: 필요한 경우 추가적인 로직을 구현합니다.
    }

}