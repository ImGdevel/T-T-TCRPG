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
    private List<BattleCharacterComponent> playerCharacterFrameList;
    private List<BattleCharacterComponent> enemyCharacterFrameList;

    [SerializeField] GameObject characterFramePrefab;
    private float characterFrameWidth;
    private float characterFrameHeight;

    [SerializeField] float positionOffset;
    [SerializeField] float heightAdjustment;
    [SerializeField] float fieldSpacing;

    // BattleCharacterManager 싱글톤
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
        Vector3 originPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        playerField.transform.position = new Vector3(originPos.x - (fieldSpacing / 2), originPos.y + heightAdjustment, originPos.z);
        enemyField.transform.position = new Vector3(originPos.x + (fieldSpacing / 2), originPos.y + heightAdjustment, originPos.z);

        playerList = new List<Character>();
        enemyList = new List<Character>();
        playerCharacterFrameList = new List<BattleCharacterComponent>();
        enemyCharacterFrameList = new List<BattleCharacterComponent>();
        characterFrameWidth = characterFramePrefab.transform.localScale.x;
        characterFrameHeight = characterFramePrefab.transform.localScale.y;

        SetBattleCharacters();
        SetPlayerCharacterPosition();
        SetEnemyCharacterPosition();
    }

    private GameObject CreateCharacterField(string fieldName) {
        GameObject field = new GameObject(fieldName);
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
            characterComponent.SetManager(this);
            characterComponent.SetCharacter(player);
            characterComponent.SetCharacterType(TargetType.Friendly);
            playerCharacterFrameList.Add(characterComponent);
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
            characterComponent.SetManager(this);
            characterComponent.SetCharacter(enemy);
            characterComponent.SetCharacterType(TargetType.Enemy);
            enemyCharacterFrameList.Add(characterComponent);
            xPos += characterFrameWidth + positionOffset;
        }
    }

    public void UptateStatus() {
        foreach (var component in playerCharacterFrameList) {
            component.UpdateStatus();
        }
        foreach (var component in enemyCharacterFrameList) {
            component.UpdateStatus();
        }
    }

    public List<Character> GetPlayerCharacters() {
        return playerList;
    }

    public List<Character> GetEnemyCharacters() {
        return enemyList;
    }

    public List<BattleCharacterComponent> GetPlayerCharacterCompnenets() {
        return playerCharacterFrameList;
    }

    public List<BattleCharacterComponent> GetEnemyCharacterCompnenets() {
        return enemyCharacterFrameList;
    }

}