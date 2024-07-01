using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Happy_set : MonoBehaviour
{
    public Button set_btn3; // 일시 정지 버튼
    public Button x_btn3; // 재개 버튼
    public Button return_btn3; // 처음으로 가기 버튼

    public GameObject menu3;
    public GameObject Opening;

    private bool isPaused = false; // 게임 상태 플래그

    private void Start()
    {
        set_btn3.onClick.AddListener(PauseGame3);
        x_btn3.onClick.AddListener(ResumeGame3);
        return_btn3.onClick.AddListener(ReturnGame3);
        menu3.SetActive(false);
    }

    private void PauseGame3()
    {
        menu3.SetActive(true);
        isPaused = true;
        Opening.GetComponent<Happytalk>().enabled = false;
        Debug.Log("설정창 클릭");

    }

    private void ResumeGame3()
    {

        isPaused = false;
        menu3.SetActive(false);
        Opening.GetComponent<Happytalk>().enabled = true;
        Debug.Log("닫기 버튼 button was clicked!");

    }
    private void ReturnGame3()
    {
        Debug.Log("처음으로 돌아가기");

        SceneManager.LoadScene("Main_Scene");
    }
}
