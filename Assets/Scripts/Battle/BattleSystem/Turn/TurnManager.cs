using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public delegate void TurnChangeDelegate(bool isPlayerTurn);
    public static event TurnChangeDelegate OnTurnChange;

    private const float TurnChangeDelay = 1.0f;
    private bool isPlayerTurn = true;

    // TurnManager �̱���
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
        // ���� ���� �� �ʱ� ���� �����մϴ�.
        yield return StartCoroutine(ChangeTurn());
    }

    /// <summary>
    /// ���� ���� �����մϴ�.
    /// </summary>
    public void NextTurn() {
        StartCoroutine(ChangeTurn());
    }

    private IEnumerator ChangeTurn() {
        yield return new WaitForSeconds(TurnChangeDelay); // �� ���� �ð� ����
        Debug.Log("�� ���� ���� �۵�");

        // �� ����
        isPlayerTurn = !isPlayerTurn;

        // �� ���� �̺�Ʈ�� �߻���ŵ�ϴ�. ������ �༮���� ����
        OnTurnChange?.Invoke(isPlayerTurn);

        // �ٸ� �������� ��� �����ϵ��� ���뼺�� ������ ��
        if (isPlayerTurn) {
            Debug.Log("Player's Turn");
            // TODO: �÷��̾� �� ó��

        }
        else {
            Debug.Log("Enemy's Turn");
            // TODO: �� �� ó��

        }

        // TODO: �ʿ��� ��� �߰����� ������ �����մϴ�.
    }
}