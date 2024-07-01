using System.Collections;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Gameover;
    public GameObject Player;
    public GameObject TrapSpawner;
    public GameObject Countdown;
    public GameObject Background;

    private GameSound1 gameSound1;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private int hitCount = 0;
    [SerializeField] private GameObject[] Trap;
    public bool stopTrigger = true;

    // 생명 표시를 위한 이미지 배열과 스프라이트
    public Image[] hearts;
    public Sprite heart_img; // 초기 상태의 하트 이미지
    public Sprite deadHeart_img; // 죽은 하트 이미지

    void Start()
    {
        gameSound1 = FindObjectOfType<GameSound1>();

        gameSound1.PlaySong();

        InitializeHearts();
        Gameover.SetActive(false);

        // TrapSpawner 활성화 확인 및 설정
        if (TrapSpawner != null)
        {
            Debug.Log("TrapSpawner Active in Start: " + TrapSpawner.activeSelf);
            TrapSpawner.SetActive(true);
            Debug.Log("TrapSpawner Active after set active: " + TrapSpawner.activeSelf);

            // TrapSpawner 스크립트 활성화 확인 및 설정
            var trapSpawnerScript = TrapSpawner.GetComponent<TrapSpawner>();
            if (trapSpawnerScript != null)
            {
                Debug.Log("TrapSpawner Script Enabled in Start: " + trapSpawnerScript.enabled);
                trapSpawnerScript.enabled = true;
                Debug.Log("TrapSpawner Script Enabled after set enabled: " + trapSpawnerScript.enabled);
            }
            else
            {
                Debug.LogError("TrapSpawner Script is missing on TrapSpawner GameObject.");
            }
        }
        else
        {
            Debug.LogError("TrapSpawner GameObject is not assigned.");
        }

        GameStart(); // 게임 시작 시 호출
    }

    private void InitializeHearts()
    {
        // 모든 하트 이미지를 초기 상태로 설정
        foreach (Image heart in hearts)
        {
            heart.sprite = heart_img;
        }

    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        gameSound1.PauseSong(); //사운드

        // 게임 오버 로직
        stopTrigger = true;
        Gameover.SetActive(true);

        // 게임 로직 중지
        StopAllCoroutines(); // 게임 로직을 담당하는 모든 코루틴 중지
        Player.GetComponent<Player>().enabled = false; // 플레이어 스크립트 비활성화
        Player.GetComponent<PlayerMove>().enabled = false; // 플레이어 스크립트 비활성화
        Countdown.GetComponent<Countdown>().enabled = false;
        Background.GetComponent<BackgroundScroll>().enabled = false;
    }

    public void GameStart()
    {
        Debug.Log("GameManager GameStart");
        stopTrigger = false;

        // TrapSpawner 활성화 확인 및 설정
        if (TrapSpawner != null)
        {
            TrapSpawner.SetActive(true);
            var trapSpawnerScript = TrapSpawner.GetComponent<TrapSpawner>();
            if (trapSpawnerScript != null)
            {
                trapSpawnerScript.enabled = true;
            }
        }

        StartCoroutine(CreateTrapRoutine());
    }

    public void IncreaseHitCount()
    {
        if (gameSound1 != null)
        {
            gameSound1.PlayHitSound();
        }
        else
        {
            Debug.LogWarning("GameSound1 component not found!");
        }

        hitCount++;
        UpdateHeartDisplay();
        if (hitCount >= 3) // 장애물 3개 충돌 시 게임 오버
        {
            GameOver();
        }
        
    }

    private void UpdateHeartDisplay()
    {
        // hitCount에 따라 해당 하트 이미지를 deadHeart_img로 변경
        if (hitCount - 1 < hearts.Length)
        {
            hearts[hitCount - 1].sprite = deadHeart_img;
        }
    }

    IEnumerator CreateTrapRoutine()
    {
        while (!stopTrigger)
        {
            TrapSpawner.GetComponent<TrapSpawner>().SpawnTrap();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
