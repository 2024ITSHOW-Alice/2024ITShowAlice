using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public UnityEngine.UI.Button pauseButton; // 일시 정지 버튼
    public UnityEngine.UI.Button resumeButton; // 재개 버튼
    public UnityEngine.UI.Button returnButton; //처음으로 가기 버튼

    public GameObject menu;

    public GameObject player;
    public GameObject trapSpawner;
    public GameObject countdown;
    public GameObject background;
    public GameObject[] traps; // 장애물 배열

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        returnButton.onClick.AddListener(ReturnGame);
        menu.SetActive(false);
    }

    private bool isPaused = false; // 게임 상태 플래그

    private void PauseGame()
    {
        isPaused = true;
        Debug.Log("설정창 버튼 클릭");
        menu.SetActive(true);

        Time.timeScale = 0f; // 게임 로직 정지
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<PlayerMove>().enabled = false;
        countdown.GetComponent<Countdown>().enabled = false;
        background.GetComponent<BackgroundScroll>().enabled = false;
        trapSpawner.GetComponent<TrapSpawner>().enabled = false;

        foreach (GameObject trap in traps)
        {
            if (trap != null)
            {
                Rigidbody rb = trap.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero; // 속도 0으로 설정
                    rb.angularVelocity = Vector3.zero; // 회전 속도 0으로 설정
                    rb.isKinematic = true; // Rigidbody를 비활성화
                }
            }
        }
    }

    private void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Debug.Log("다시 재개 button was clicked!");
            menu.SetActive(false);

            Time.timeScale = 1f; // 게임 로직 재개
            player.GetComponent<Player>().enabled = true;
            player.GetComponent<PlayerMove>().enabled = true;
            countdown.GetComponent<Countdown>().enabled = true;
            background.GetComponent<BackgroundScroll>().enabled = true;
            trapSpawner.GetComponent<TrapSpawner>().enabled = true;

            foreach (GameObject trap in traps)
            {
                if (trap != null)
                {
                    Rigidbody rb = trap.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false; // Rigidbody를 활성화
                    }
                }
            }
        }
    }

    private void ReturnGame()
    {
        Debug.Log("처음으로 돌아가기 ");
        Time.timeScale = 1f; // 게임 로직 재개
        SceneManager.LoadScene("Main_Scene");
    }
}
