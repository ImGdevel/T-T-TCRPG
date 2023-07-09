using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public delegate void TurnChangeDelegate(bool isPlayerTurn);
    public static event TurnChangeDelegate OnTurnChange;

    private const float TurnChangeDelay = 1.0f;
    private bool isPlayerTurn = true;
    
    private IEnumerator Start() {
        // ���� ���� �� �ʱ� ���� �����մϴ�.
        yield return StartCoroutine(ChangeTurn());
    }

    public void NextTurn() {
        StartCoroutine(ChangeTurn());
    }

    public IEnumerator ChangeTurn() {
        yield return new WaitForSeconds(TurnChangeDelay); // �� ���� �ð� ����
        Debug.Log("�� ���� ���� �۵�");

        //�� ����
        isPlayerTurn = !isPlayerTurn;

        // �� ���� �̺�Ʈ�� �߻���ŵ�ϴ�. ������ �༮���� ����
        OnTurnChange?.Invoke(isPlayerTurn);

        // �ٸ��������� ��밡���ϵ��� ���뼺�� �����ߴ�.
        if (isPlayerTurn) {
            Debug.Log("Player's Turn");
            // TODO: �÷��̾�� �� ó��

        }
        else {
            Debug.Log("Enemy's Turn");
            // TODO: �� �Ͽ��� ó��

        }

        // TODO: �ʿ��� ��� �߰����� ������ �����մϴ�.
    }

}