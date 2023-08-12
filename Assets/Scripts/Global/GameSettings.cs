using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public Resolution[] resolutions; // 지원하는 해상도 목록
    public int defaultResolutionIndex; // 기본 해상도 인덱스

    public KeyCode jumpKey = KeyCode.Space; // 점프 키 설정
    public KeyCode attackKey = KeyCode.Mouse0; // 공격 키 설정

    public enum GraphicsQuality
    {
        Low,
        Medium,
        High
    }
    public GraphicsQuality currentGraphicsQuality = GraphicsQuality.Medium; // 현재 그래픽 품질

    private void Awake() {
        // 지원하는 모든 해상도 정보를 가져와 저장합니다.
        resolutions = Screen.resolutions;

        // 기본 해상도 설정
        if (PlayerPrefs.HasKey("ResolutionIndex")) {
            int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
            SetResolution(resolutionIndex);
        }
        else {
            SetResolution(defaultResolutionIndex);
        }

        // 기본 그래픽 품질 설정
        if (PlayerPrefs.HasKey("GraphicsQuality")) {
            string qualityStr = PlayerPrefs.GetString("GraphicsQuality");
            currentGraphicsQuality = (GraphicsQuality)System.Enum.Parse(typeof(GraphicsQuality), qualityStr);
            SetGraphicsQuality(currentGraphicsQuality);
        }
        else {
            SetGraphicsQuality(currentGraphicsQuality);
        }

        // 기본 조작 버튼 설정
        if (PlayerPrefs.HasKey("JumpKey")) {
            string jumpKeyStr = PlayerPrefs.GetString("JumpKey");
            jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), jumpKeyStr);
        }
        else {
            PlayerPrefs.SetString("JumpKey", jumpKey.ToString());
        }

        if (PlayerPrefs.HasKey("AttackKey")) {
            string attackKeyStr = PlayerPrefs.GetString("AttackKey");
            attackKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), attackKeyStr);
        }
        else {
            PlayerPrefs.SetString("AttackKey", attackKey.ToString());
        }
    }

    // 해상도 변경
    public void SetResolution(int index) {
        if (index >= 0 && index < resolutions.Length) {
            Resolution resolution = resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionIndex", index);
        }
    }

    public void SetResolution(int width, int height) {
        Screen.SetResolution(width, height, Screen.fullScreen);
        PlayerPrefs.SetInt("ScreenWidth", width);
        PlayerPrefs.SetInt("ScreenHeight", height);
    }

    // 해상도 불러오기
    public void LoadResolution() {
        int width = PlayerPrefs.GetInt("ScreenWidth", 1920);
        int height = PlayerPrefs.GetInt("ScreenHeight", 1080);
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    // 그래픽 품질 변경
    public void SetGraphicsQuality(GraphicsQuality quality) {
        switch (quality) {
            case GraphicsQuality.Low:
                QualitySettings.SetQualityLevel(0);
                break;
            case GraphicsQuality.Medium:
                QualitySettings.SetQualityLevel(2);
                break;
            case GraphicsQuality.High:
                QualitySettings.SetQualityLevel(5);
                break;
        }

        PlayerPrefs.SetString("GraphicsQuality", quality.ToString());
    }

    // 점프 키 변경
    public void SetJumpKey(KeyCode key) {
        jumpKey = key;
        PlayerPrefs.SetString("JumpKey", key.ToString());
    }

    // 공격 키 변경
    public void SetAttackKey(KeyCode key) {
        attackKey = key;
        PlayerPrefs.SetString("AttackKey", key.ToString());
    }
}
