using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{

    public delegate void TurnChangeDelegate(bool isPlayerTurn);
    public static event TurnChangeDelegate OnTurnChange;

    private bool isPlayerTurn = true;

    private IEnumerator Start() {
        // ���� ���� �� �ʱ� ���� �����մϴ�.
        yield return StartCoroutine(ChangeTurn());
    }

    public IEnumerator ChangeTurn() {
        yield return new WaitForSeconds(1f); // �� ���� �ð� ����

        isPlayerTurn = !isPlayerTurn;

        // �� ���� �̺�Ʈ�� �߻���ŵ�ϴ�.
        OnTurnChange?.Invoke(isPlayerTurn);

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

    public void NextTurn() {
        Debug.Log("Ŭ��");
        ChangeTurn();
    }
}