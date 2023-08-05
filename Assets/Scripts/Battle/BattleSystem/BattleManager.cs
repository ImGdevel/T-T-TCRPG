using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] TurnManager turnManager;
    [SerializeField] HandManager handManager;
    [SerializeField] BattleCharacterManager battleCharacterManager;


    // BattleManager �̱���
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

    // TrunManager�� �����ϰ� TrunManager�� ȣ��� �ڵ����� ȣ��ǰڴ� ����
    private void Start() {
        // TurnManager�� �� ���� �̺�Ʈ�� ����
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
        // TurnManager�� �� ���� �̺�Ʈ���� ���� ����
        TurnManager.OnTurnChange -= HandleTurnChange;
    }

    private void HandleTurnChange(bool isPlayerTurn) {

        if (isPlayerTurn) {
            // �÷��̾��� �Ͽ� ���� �߰� ���� ����

            // �� ���� ��ư ��Ȱ��ȭ 
            // ī�� ��Ȱ��ȭ = HnadManager����

        }
        else {
            // ���� �Ͽ� ���� �߰� ���� ����

            // �� ���� ��ư ��Ȱ��ȭ
            // ī�� Ȱ��ȭ = HnadManager���� 

            // �� �� ���� ����...
        }
    }
}

// Comment
/*
 �� �޴����� ��Ʋ �޴����� ������ �����ϴ°�?

=> ��Ʋ �Ŵ����� "������"�μ� �����.

1. �÷��̾� �Ͽ����� �÷��̰� ���� �� �� �ֵ��� �ؾ��Ѵ�.
2. ���� �Ͽ����� �Ϻ� �÷��̸� ���� ���Ѿ��Ѵ�. (ī�� ���)
  2.1. ����: ������ �����ϰ� ������ �����ϰ� �� �� �ΰ�?
  2.2. �ֽð��� ������ ��� �� ���ΰ�? ��� �� ��带 ���ϰ� ��� ���ο� ���� �ٸ��� ����
  2.3. ����� ī�� ����� �Ұ����ϰ� �Ѵ�? ���?
  2.4. ī�� ����� �Ұ����ϰ�, ī�� ������ ���� �ְ�, ī�忡 ���� �÷������� ��밡�� ���·� ��ȯ But �� ���� �ƴ϶�� 
       (��, ��� ��� �Ұ��� ���¶��)
  2.5 ī�忡���� ī�� ��밡�� �� �Ұ��� �� �����صΰ�, � ī�尡 ��밡�������� HnadManager���� �����Ѵ�. ���?
  2.6 ��� �Ұ����� ī�嵵 ���� ���̴�. (�̰Ű� ����Ʈ �ε�)

// ī�� ����Ʈ�� ��� �̰��� �����Ѵٸ�?
 
 */

