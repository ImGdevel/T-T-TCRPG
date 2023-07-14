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
        // Test Code: 전투를 시작할 캐릭터 세팅
        originalPlayerList = SampleDataGenerator.SAMPLE_CHARACTER;
        originalEnemyList = SampleDataGenerator.SAMPLE_ENEMY;
        // 추후 수정할 것

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
    /// 플레이어 캐릭터를 해당 위치에 배치합니다.
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
    /// 적 캐릭터를 해당 위치에 배치합니다.
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
}