using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject GameRule;
    public GameObject BackgroundOverlay;
    public Button ButtonStart;
    public bool GameRunning;
    public GameSound2 gameSound;

    void Start()
    {
        GameRunning = false;
        BackgroundOverlay.SetActive(true);
        ButtonStart.onClick.AddListener(ClickStart);
        ShowGameRule();
    }

    public void ShowGameRule()
    {
        BackgroundOverlay.SetActive(true);
        GameRule.SetActive(true);
        if (Setting2.instance != null && Setting2.instance.pauseButton2 != null)
        {
            Setting2.instance.pauseButton2.gameObject.SetActive(false);
        }
    }

    public void ClickStart()
    {
        GameRunning = true;
        BackgroundOverlay.SetActive(false);
        GameRule.SetActive(false);
        if (Setting2.instance != null && Setting2.instance.pauseButton2 != null)
        {
            Setting2.instance.pauseButton2.gameObject.SetActive(true);
        }

        // 게임 사운드를 재생
        if (GameRunning)
        {
            Debug.Log("게임 실행, 플레이 송");
            gameSound.PlaySong();
        }
    }

    void Update()
    {
        if (Setting2.instance != null && Setting2.instance.pauseButton2 != null)
        {
            Setting2.instance.pauseButton2.gameObject.SetActive(GameRunning);
        }
    }
}
