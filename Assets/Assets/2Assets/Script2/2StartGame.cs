using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton; // 시작 버튼
    public Button gameRuleButton; // 게임 규칙 버튼
    public Image ruleImage1; // 규칙 1 이미지
    public Image ruleImage2; // 규칙 2 이미지
    public Image ruleImage3; // 규칙 3 이미지
    public Button nextButton1; // 규칙 1의 다음 버튼
    public Button nextButton2; // 규칙 2의 다음 버튼
    public Button goBackButton2; // 규칙 2의 돌아가기 버튼
    public Button goBackButton3; // 규칙 3의 돌아가기 버튼
    public Button startButtonPage3; // 3페이지 전용 시작하기 버튼


    private int currentRulePage = 1;

    void Start()
    {
        // 시작 버튼에 클릭 리스너 추가
        startButton.onClick.AddListener(OnStartButtonClick);

        // 게임 규칙 버튼에 클릭 리스너 추가
        gameRuleButton.onClick.AddListener(OnGameRuleButtonClick);

        // 규칙 1의 다음 버튼에 클릭 리스너 추가
        nextButton1.onClick.AddListener(OnNextButtonClick);

        // 규칙 2의 다음 버튼과 돌아가기 버튼에 클릭 리스너 추가
        nextButton2.onClick.AddListener(OnNextButtonClick);
        goBackButton2.onClick.AddListener(OnGoBackButtonClick);

        // 규칙 3의 돌아가기 버튼과 시작하기 버튼에 클릭 리스너 추가
        goBackButton3.onClick.AddListener(OnGoBackButtonClick);
        startButtonPage3.onClick.AddListener(OnStartButtonClick);

        // 초기 상태: 규칙 이미지는 모두 숨기기
        ruleImage1.gameObject.SetActive(false);
        ruleImage2.gameObject.SetActive(false);
        ruleImage3.gameObject.SetActive(false);
        nextButton1.gameObject.SetActive(false);
        nextButton2.gameObject.SetActive(false);
        goBackButton2.gameObject.SetActive(false);
        goBackButton3.gameObject.SetActive(false);
        startButtonPage3.gameObject.SetActive(false);
    }

    void OnStartButtonClick()
    {
        // 게임 시작 Scene으로 전환
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene("Opening_Scene");
    }

    void OnGameRuleButtonClick()
    {
        // 첫 번째 규칙 이미지와 Next 버튼 표시
        currentRulePage = 1;
        UpdateRuleImages();
    }

    void OnNextButtonClick()
    {
        // 다음 페이지로 전환
        if (currentRulePage < 3)
        {
            currentRulePage++;
            UpdateRuleImages();
        }
    }

    void OnGoBackButtonClick()
    {
        // 이전 페이지로 전환
        if (currentRulePage > 1)
        {
            currentRulePage--;
            UpdateRuleImages();
        }
    }

    void UpdateRuleImages()
    {
        // 모든 규칙 이미지와 버튼 숨기기
        ruleImage1.gameObject.SetActive(false);
        ruleImage2.gameObject.SetActive(false);
        ruleImage3.gameObject.SetActive(false);
        nextButton1.gameObject.SetActive(false);
        nextButton2.gameObject.SetActive(false);
        goBackButton2.gameObject.SetActive(false);
        goBackButton3.gameObject.SetActive(false);
        startButtonPage3.gameObject.SetActive(false);

        // 현재 페이지에 따라 이미지와 버튼 표시
        switch (currentRulePage)
        {
            case 1:
                ruleImage1.gameObject.SetActive(true);
                nextButton1.gameObject.SetActive(true);
                break;
            case 2:
                ruleImage2.gameObject.SetActive(true);
                nextButton2.gameObject.SetActive(true);
                goBackButton2.gameObject.SetActive(true);
                break;
            case 3:
                ruleImage3.gameObject.SetActive(true);
                goBackButton3.gameObject.SetActive(true);
                startButtonPage3.gameObject.SetActive(true);
                break;
        }
    }
}