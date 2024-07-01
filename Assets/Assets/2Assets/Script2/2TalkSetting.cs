using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkSetting : MonoBehaviour
{
    public Button pauseButton2; // 일시 정지 버튼
    public Button resumeButton2; // 재개 버튼
    public Button returnButton2; // 처음으로 가기 버튼
    public GameObject menu2;
    public GameObject Dialog;

    private Image panelHatImage; // PanelHat의 이미지 컴포넌트
    private Image panelPlayerImage; // PanelPlayer의 이미지 컴포넌트

    private void Start()
    {
        menu2.SetActive(false);
        pauseButton2.onClick.AddListener(PauseGame2);
        resumeButton2.onClick.AddListener(ResumeGame2);
        returnButton2.onClick.AddListener(ReturnGame2);

        // PanelHat, PanelPlayer의 이미지 컴포넌트 가져오기
        panelHatImage = Dialog.GetComponent<Conversation>().PanelHat.GetComponent<Image>();
        panelPlayerImage = Dialog.GetComponent<Conversation>().PanelPlayer.GetComponent<Image>();
    }

    private void PauseGame2()
    {
        Debug.Log("설정창 클릭");
        menu2.SetActive(true);
        Dialog.GetComponent<Conversation>().enabled = false;
        pauseButton2.gameObject.SetActive(false);

        // PanelHat, PanelPlayer 이미지의 색상을 어둡게 설정
        Color originalColor = panelHatImage.color;
        float darkenFactor = 0.5f; // 어둡게 할 정도를 결정하는 요소 (예시로 0.5 사용)
        panelHatImage.color = new Color(originalColor.r * darkenFactor, originalColor.g * darkenFactor, originalColor.b * darkenFactor, originalColor.a);

        Color originalColorP = panelPlayerImage.color;
        panelPlayerImage.color = new Color(originalColorP.r * darkenFactor, originalColorP.g * darkenFactor, originalColorP.b * darkenFactor, originalColorP.a);

    }


    private void ResumeGame2()
    {
        Debug.Log("닫기 버튼 클릭!");
        menu2.SetActive(false);
        Dialog.GetComponent<Conversation>().enabled = true;
        pauseButton2.gameObject.SetActive(true);

        // PanelHat, PanelPlayer 이미지의 색상을 원래대로 복원
        panelHatImage.color = Color.white;
        panelPlayerImage.color = Color.white;
    }

    private void ReturnGame2()
    {
        Debug.Log("처음으로 돌아가기");
        SceneManager.LoadScene("Main_Scene");
    }
}
