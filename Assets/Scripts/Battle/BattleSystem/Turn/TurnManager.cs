using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public delegate void TurnChangeDelegate(bool isPlayerTurn);
    public static event TurnChangeDelegate OnTurnChange;

    private const float TurnChangeDelay = 1.0f;
    private bool isPlayerTurn = true;

    // TurnManager 싱글톤
    private static TurnManager instance;
    public static TurnManager Instance{ get { return instance; }}

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private IEnumerator Start() {
        // 게임 시작 시 초기 턴을 설정합니다.
        yield return StartCoroutine(ChangeTurn());
    }

    /// <summary>
    /// 다음 턴을 진행합니다.
    /// </summary>
    public void NextTurn() {
        StartCoroutine(ChangeTurn());
    }

    private IEnumerator ChangeTurn() {
        yield return new WaitForSeconds(TurnChangeDelay); // 턴 변경 시간 지연
        Debug.Log("턴 변경 로직 작동");

        // 턴 변경
        isPlayerTurn = !isPlayerTurn;

        // 턴 변경 이벤트를 발생시킵니다. 구독한 녀석에게 전달
        OnTurnChange?.Invoke(isPlayerTurn);

        // 다른 곳에서도 사용 가능하도록 범용성을 가져야 함
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
}