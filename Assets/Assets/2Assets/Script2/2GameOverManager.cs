using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverImage;
    public GameObject backgroundOverlay;
    public Button gameOverYesButton;
    public Button gameOverNoButton;

    private GameStart gameStart;
    private GameSound2 gameSound;
    private PlayerHideCheck playerHideCheck;

    void Start()
    {
        gameOverImage.SetActive(false);
        gameOverYesButton.gameObject.SetActive(false);
        gameOverNoButton.gameObject.SetActive(false);

        gameOverYesButton.onClick.AddListener(OnGameOverYes);
        gameOverNoButton.onClick.AddListener(OnGameOverNo);

        gameStart = FindObjectOfType<GameStart>();
        gameSound = FindObjectOfType<GameSound2>();
        playerHideCheck = FindObjectOfType<PlayerHideCheck>();
    }

    public void ShowGameOver()
    {
        // 씬 전환 중이면 게임 오버를 보여주지 않음
        if (playerHideCheck != null && playerHideCheck.IsTransitioning())
        {
            return;
        }

        gameOverImage.SetActive(true);
        backgroundOverlay.SetActive(true);
        gameOverYesButton.gameObject.SetActive(true);
        gameOverNoButton.gameObject.SetActive(true);

        // 게임 오버 시 플레이어 이동 막기
        if (gameStart != null)
        {
            gameStart.GameRunning = false;
            gameSound.PauseSong();
        }

        if (Setting2.instance != null && Setting2.instance.pauseButton2 != null)
        {
            Setting2.instance.pauseButton2.gameObject.SetActive(false);
        }
    }

    private void OnGameOverYes()
    {
        SceneManager.LoadScene("2GameScene");
    }

    private void OnGameOverNo()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
