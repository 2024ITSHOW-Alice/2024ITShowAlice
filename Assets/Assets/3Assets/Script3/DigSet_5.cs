using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DigSet_end : MonoBehaviour
{
    public Button set_btn; // 일시 정지 버튼
    public Button x_btn; // 재개 버튼
    public Button return_btn; // 처음으로 가기 버튼

    public GameObject menu;
    public GameObject Dialog;

    private bool isPaused = false; // 게임 상태 플래그

    private void Start()
    {
        set_btn.onClick.AddListener(PauseGame);
        x_btn.onClick.AddListener(ResumeGame);
        return_btn.onClick.AddListener(ReturnGame);
        menu.SetActive(false);
    }

    private void PauseGame()
    {
        menu.SetActive(true);
        isPaused = true;
        Dialog.GetComponent<happy3>().enabled = false;
        Debug.Log("설정창 클릭");

    }

    private void ResumeGame()
    {

        isPaused = false;
        menu.SetActive(false);
        Dialog.GetComponent<happy3>().enabled = true;
        Debug.Log("닫기 버튼 button was clicked!");

    }
    private void ReturnGame()
    {
        Debug.Log("처음으로 돌아가기");

        SceneManager.LoadScene("Main_Scene");
    }
}
