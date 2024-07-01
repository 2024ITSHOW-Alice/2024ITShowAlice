using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public UnityEngine.UI.Button pauseButton; // �Ͻ� ���� ��ư
    public UnityEngine.UI.Button resumeButton; // �簳 ��ư
    public UnityEngine.UI.Button returnButton; //ó������ ���� ��ư

    public GameObject menu;

    public GameObject player;
    public GameObject trapSpawner;
    public GameObject countdown;
    public GameObject background;
    public GameObject[] traps; // ��ֹ� �迭

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        returnButton.onClick.AddListener(ReturnGame);
        menu.SetActive(false);
    }

    private bool isPaused = false; // ���� ���� �÷���

    private void PauseGame()
    {
        isPaused = true;
        Debug.Log("����â ��ư Ŭ��");
        menu.SetActive(true);

        Time.timeScale = 0f; // ���� ���� ����
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
                    rb.velocity = Vector3.zero; // �ӵ� 0���� ����
                    rb.angularVelocity = Vector3.zero; // ȸ�� �ӵ� 0���� ����
                    rb.isKinematic = true; // Rigidbody�� ��Ȱ��ȭ
                }
            }
        }
    }

    private void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Debug.Log("�ٽ� �簳 button was clicked!");
            menu.SetActive(false);

            Time.timeScale = 1f; // ���� ���� �簳
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
                        rb.isKinematic = false; // Rigidbody�� Ȱ��ȭ
                    }
                }
            }
        }
    }

    private void ReturnGame()
    {
        Debug.Log("ó������ ���ư��� ");
        Time.timeScale = 1f; // ���� ���� �簳
        SceneManager.LoadScene("Main_Scene");
    }
}
