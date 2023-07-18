using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterManager : MonoBehaviour
{
    [SerializeField] List<Character> originalPlayerList;
    [SerializeField] List<Character> originalEnemyList;

    private List<Character> playerList;
    private List<Character> enemyList;

    [SerializeField] GameObject playerField;
    [SerializeField] GameObject enemyField;
    private List<GameObject> playerCharacterFrameList;
    private List<GameObject> enemyCharacterFrameList;

    [SerializeField] GameObject characterFramePrefab;
    private float characterFrameWidth;
    private float characterFrameHeight;

    [SerializeField] float positionOffset;
    [SerializeField] float heightAdjustment;
    [SerializeField] float fieldSpacing;

    // BattleCharacterManager �̱���
    private static BattleCharacterManager instance;
    public static BattleCharacterManager Instance { get { return instance; } }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start() {
        if (playerField == null) {
            playerField = CreateCharacterField("Player Field");
        }

        if (enemyField == null) {
            enemyField = CreateCharacterField("Enemy Field");
        }

        characterFrameWidth = characterFramePrefab.transform.localScale.x;
        characterFrameHeight = characterFramePrefab.transform.localScale.y;

        playerList = new List<Character>();
        enemyList = new List<Character>();
        playerCharacterFrameList = new List<GameObject>();
        enemyCharacterFrameList = new List<GameObject>();

        SetBattleCharacters();
        SetPlayerCharacterPosition();
        SetEnemyCharacterPosition();
    }

    private GameObject CreateCharacterField(string fieldName) {
        GameObject field = new GameObject(fieldName);
        if (fieldName == "Player Field") {
            field.transform.position = new Vector3(-(fieldSpacing / 2), heightAdjustment, 0f);
        }
        else {
            field.transform.position = new Vector3((fieldSpacing / 2), heightAdjustment, 0f);
        }

        field.transform.SetParent(transform);
        return field;
    }

    private void SetBattleCharacters() {
        // Test Code: ������ ������ ĳ���� ����
        originalPlayerList = SampleDataGenerator.SAMPLE_CHARACTER;
        originalEnemyList = SampleDataGenerator.SAMPLE_ENEMY;
        // ���� ������ ��

        foreach (Character originalPlayer in originalPlayerList) {
            Character player = originalPlayer.Clone();
            playerList.Add(player);
        }

        foreach (Character originalEnemy in originalEnemyList) {
            Character enemy = originalEnemy.Clone();
            enemyList.Add(enemy);
        }
    }


    /// <summary>
    /// �÷��̾� ĳ���͸� �ش� ��ġ�� ��ġ�մϴ�.
    /// </summary>
    public void SetPlayerCharacterPosition() {
        float xPos = playerField.transform.position.x;
        float yPos = playerField.transform.position.y;
        foreach (Character player in playerList) {
            Vector3 position = new Vector3(xPos, yPos, 0f);
            GameObject characterFrameObj = Instantiate(characterFramePrefab, position, Quaternion.identity, playerField.transform);
            BattleCharacterComponent characterComponent = characterFrameObj.GetComponent<BattleCharacterComponent>();
            characterComponent.SetCharacter(player);
            playerCharacterFrameList.Add(characterFrameObj);
            xPos -= characterFrameWidth + positionOffset;
        }
    }

    /// <summary>
    /// �� ĳ���͸� �ش� ��ġ�� ��ġ�մϴ�.
    /// </summary>
    public void SetEnemyCharacterPosition() {
        float xPos = enemyField.transform.position.x;
        float yPos = enemyField.transform.position.y;
        foreach (Character enemy in enemyList) {
            Vector3 position = new Vector3(xPos, yPos, 0f);
            GameObject characterFrameObj = Instantiate(characterFramePrefab, position, Quaternion.identity, enemyField.transform);
            BattleCharacterComponent characterComponent = characterFrameObj.GetComponent<BattleCharacterComponent>();
            characterComponent.SetCharacter(enemy);
            enemyCharacterFrameList.Add(characterFrameObj);
            xPos += characterFrameWidth + positionOffset;
        }
    }

    // �ش� ĳ���Ϳ��� �����Լ�
    public void ApplyCardEffectToCharacter(BattleCard card) {
        // ī�� ������ �ް�  
        // ī���� ����Ʈ�� ��� ������.
        // Ÿ�ٵ鿡�� ����Ʈ�� ��� �����Ѵ�.
        CardEffect[] cardEffect = card.Effects;

        foreach (CardEffect effect in cardEffect) {
            Target targeting = effect.target;

            if(targeting == Target.AllFriendly) {
                foreach (Character characterP in playerList) {
                    // ȿ���� ������ ���� ����
                    // ȿ�� ���뿡 ���� �ִϸ��̼� ��� (�������� ����)
                }
            }

            if (targeting == Target.AllEnemy) {
                foreach (Character characterE in enemyList) {
                    // ȿ���� ������ ���� ����
                    // ȿ�� ���뿡 ���� �ִϸ��̼� ��� (�������� ����)
                }
            }

            
        }

    }
    // 
}