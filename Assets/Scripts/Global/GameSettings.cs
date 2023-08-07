using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public Resolution[] resolutions; // �����ϴ� �ػ� ���
    public int defaultResolutionIndex; // �⺻ �ػ� �ε���

    public KeyCode jumpKey = KeyCode.Space; // ���� Ű ����
    public KeyCode attackKey = KeyCode.Mouse0; // ���� Ű ����

    public enum GraphicsQuality
    {
        Low,
        Medium,
        High
    }
    public GraphicsQuality currentGraphicsQuality = GraphicsQuality.Medium; // ���� �׷��� ǰ��

    private void Awake() {
        // �����ϴ� ��� �ػ� ������ ������ �����մϴ�.
        resolutions = Screen.resolutions;

        // �⺻ �ػ� ����
        if (PlayerPrefs.HasKey("ResolutionIndex")) {
            int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
            SetResolution(resolutionIndex);
        }
        else {
            SetResolution(defaultResolutionIndex);
        }

        // �⺻ �׷��� ǰ�� ����
        if (PlayerPrefs.HasKey("GraphicsQuality")) {
            string qualityStr = PlayerPrefs.GetString("GraphicsQuality");
            currentGraphicsQuality = (GraphicsQuality)System.Enum.Parse(typeof(GraphicsQuality), qualityStr);
            SetGraphicsQuality(currentGraphicsQuality);
        }
        else {
            SetGraphicsQuality(currentGraphicsQuality);
        }

        // �⺻ ���� ��ư ����
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

    // �ػ� ����
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

    // �ػ� �ҷ�����
    public void LoadResolution() {
        int width = PlayerPrefs.GetInt("ScreenWidth", 1920);
        int height = PlayerPrefs.GetInt("ScreenHeight", 1080);
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    // �׷��� ǰ�� ����
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

    // ���� Ű ����
    public void SetJumpKey(KeyCode key) {
        jumpKey = key;
        PlayerPrefs.SetString("JumpKey", key.ToString());
    }

    // ���� Ű ����
    public void SetAttackKey(KeyCode key) {
        attackKey = key;
        PlayerPrefs.SetString("AttackKey", key.ToString());
    }
}
