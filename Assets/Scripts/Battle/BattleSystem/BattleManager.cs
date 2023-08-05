using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    [SerializeField] HandManager handManager;
    [SerializeField] BattleCharacterManager battleCharacterManager;


    // BattleManager 싱글톤
    private static BattleManager instance;
    public static BattleManager Instance { get { return instance; } }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // TrunManager와 연결하고 TrunManager가 호출시 자동으로 호출되겠다 선언
    private void Start() {
        // TurnManager의 턴 변경 이벤트에 구독
        TurnManager.OnTurnChange += HandleTurnChange;

        if(battleCharacterManager == null) {
            Debug.LogError("battleCharacterManager is null");
            battleCharacterManager = BattleCharacterManager.Instance;
        }
        if (turnManager == null) {
            Debug.LogError("turnManager is null");
            turnManager = TurnManager.Instance;
        }
        if(handManager == null) {
            Debug.LogError("handManager is null");
        }

    }

    private void OnDestroy() {
        // TurnManager의 턴 변경 이벤트에서 구독 해지
        TurnManager.OnTurnChange -= HandleTurnChange;
    }

    private void HandleTurnChange(bool isPlayerTurn) {

        if (isPlayerTurn) {
            // 플레이어의 턴에 대한 추가 동작 수행

            // 턴 종료 버튼 비활성화 
            // 카드 비활성화 = HnadManager에서

        }
        else {
            // 적의 턴에 대한 추가 동작 수행

            // 턴 종료 버튼 비활성화
            // 카드 활성화 = HnadManager에서 

            // 적 턴 로직 시작...
        }
    }
}

// Comment
/*
 턴 메니저와 배틀 메니저는 무엇을 관리하는가?

=> 배틀 매니저를 "중재자"로서 만든다.

1. 플레이어 턴에서는 플레이가 동작 할 수 있도록 해야한다.
2. 적에 턴에서는 일부 플레이를 금지 시켜야한다. (카드 사용)
  2.1. 논점: 무엇을 금지하고 무엇을 가능하게 할 것 인가?
  2.2. 애시강초 구현은 어떻게 할 것인가? 블락 할 모드를 정하고 블락 여부에 따라 다르게 동작
  2.3. 블락시 카드 사용이 불가능하게 한다? 어떻게?
  2.4. 카드 사용은 불가능하게, 카드 설명은 볼수 있게, 카드에 손을 올려좋으면 사용가능 상태로 전환 But 내 턴이 아니라면 
       (즉, 사드 사용 불가능 상태라면)
  2.5 카드에서는 카드 사용가능 및 불가능 만 저장해두고, 어떤 카드가 사용가능한지는 HnadManager에서 관리한다. 어떤가?
  2.6 사용 불가능한 카드도 있을 것이다. (이거가 베스트 인듯)

// 카드 이펙트가 모두 이것을 구독한다면?
 
 */

