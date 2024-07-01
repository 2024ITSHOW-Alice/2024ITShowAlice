using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    public Text TalkTextHat; // 모자 장수 텍스트
    public Text TalkTextPlayer; // 플레이어 텍스트
    private int clickCount = 0; // 대사 업데이트를 위한 클릭 카운트
    public bool Drink; // 선택
    public GameObject Choice; // 선택지
    public GameObject PanelHat; // 모자 장수 대화창
    public GameObject PanelPlayer; // 플레이어 대화창
    public GameObject Background;
    public GameObject BackgroundOverlay;
    public GameObject Hat;
    public GameObject Player;
    public GameObject ShadowPlayer;
    public GameObject ShadowTable;

    public Button ButtonYes;
    public Button ButtonNo;

    public Sprite PlayerDrink1Sprite;
    public Sprite PlayerDrink2Sprite;
    public Sprite PlayerFrontSprite;

    private bool isDrinkAnimationPlaying = false; // DrinkAnimation이 실행 중인지 여부를 나타내는 변수
    private bool isTyping = false; // 대사 타이핑 효과가 실행 중인지 여부를 나타내는 변수

    private TalkSetting talkSetting; // TalkSetting 스크립트 참조

    private void Start()
    {
        if (TalkTextHat == null || TalkTextPlayer == null)
        {
            Debug.LogError("TalkText가 할당되지 않았습니다!");
        }

        // 초기 설정
        Background.SetActive(true);
        Player.SetActive(true);
        Hat.SetActive(false);
        PanelHat.SetActive(false);
        PanelPlayer.SetActive(true);
        Choice.SetActive(false);
        ButtonYes.gameObject.SetActive(false);
        ButtonNo.gameObject.SetActive(false);
        BackgroundOverlay.SetActive(false);
        ShadowTable.SetActive(false);

        // 초기 텍스트 설정
        TalkTextHat.text = "";
        TalkTextPlayer.text = "";

        // 버튼 클릭 리스너 추가
        ButtonYes.onClick.AddListener(ClickYes);
        ButtonNo.onClick.AddListener(ClickNo);

        // TalkSetting 스크립트 찾기
        talkSetting = FindObjectOfType<TalkSetting>();
    }

    void Update()
    {
        // choice가 true일 경우 pauseButton 숨기기
        if (talkSetting != null)
        {
            talkSetting.pauseButton2.gameObject.SetActive(!Choice.activeSelf && !isDrinkAnimationPlaying);
        }

        // 마우스 클릭 또는 Spacebar 또는 EnterKey 누름이 있을 시 함수 호출
        if ((Input.GetMouseButtonUp(0) && !Choice.activeSelf && !isDrinkAnimationPlaying && !isTyping))
        {
            HandleClickCount();
        }
        // Escape 키를 누르면 MainMenuScene으로 돌아감
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    void HandleClickCount()
    {
        // TalkSetting의 menu가 true이거나 choice가 활성화된 상태, 또는 애니메이션 실행 중일 때 클릭 카운트 증가를 방지
        if (talkSetting != null && talkSetting.menu2.activeSelf) return;
        if (Choice.activeSelf) return;
        if (isDrinkAnimationPlaying) return;
        if (isTyping) return;

        clickCount++;
        Debug.Log("클릭 횟수: " + clickCount);

        if (clickCount <= 7) // 선택 이전 대화
        {
            switch (clickCount)
            {
                case 1:
                    StartCoroutine(TypeTextPlayer("휴.. 무사히 착지해서 다행이다.."));
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 2:
                    StartCoroutine(TypeTextPlayer("근데 왜 학교에 굴이 있지..? "));
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 3:
                    StartCoroutine(TypeTextPlayer("아 몰라.. 빨리 학교로 돌아가야 하는데.."));
                    break;
                case 4:
                    StartCoroutine(TypeTextPlayer("너무 배고프고 목이 말라.."));
                    break;
                case 5:
                    StartCoroutine(TypeTextPlayer("어? 여기 차가 있네"));
                    break;
                case 6:
                    StartCoroutine(TypeTextPlayer("마셔도 될까?"));
                    break;
                case 7:
                    Choice.SetActive(true);
                    PanelPlayer.SetActive(false);
                    ButtonYes.gameObject.SetActive(true);
                    ButtonNo.gameObject.SetActive(true);
                    BackgroundOverlay.SetActive(true);
                    break;
                default:
                    Debug.Log("Default case executed");
                    break;
            }
        }
        else if (Drink) // 음료를 마신 경우의 대화
        {
            switch (clickCount)
            {
                case 8:
                    Player.transform.localScale *= 0.2f;
                    Vector3 newPosition = new Vector3(22f, 13.3f, Player.transform.position.z);
                    Player.transform.position = newPosition;
                    PanelPlayer.SetActive(true);
                    StartCoroutine(TypeTextPlayer("뭐야..? 내 몸이.. 작아졌잖아?!"));
                    break;
                case 9:
                    StartCoroutine(TypeTextHat("어? 내가 널 초대한 기억은 없는데?"));
                    PanelHat.SetActive(true);
                    Hat.SetActive(true);
                    break;
                case 10:
                    StartCoroutine(TypeTextHat("허락도 없이 내 차를 마셨다니"));
                    break;
                case 11:
                    StartCoroutine(TypeTextHat("당장 이리 와!"));
                    break;
                case 12:
                    StartCoroutine(TypeTextPlayer("헉! 이게 무슨 일인지는 모르겠지만 일단 모자장수로부터 도망가야겠어!"));
                    PanelHat.SetActive(false);
                    Hat.SetActive(false);
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 13:
                    SceneManager.LoadScene("2GameScene");
                    break;
                default:
                    Debug.Log("Default case executed");
                    break;
            }
        }
        else // 음료를 마시지 않은 경우의 대화
        {
            switch (clickCount)
            {
                case 8:
                    StartCoroutine(TypeTextPlayer("혹시 무슨 문제가 생길 수도 있으니 마시지 않는 게 좋겠어"));
                    PanelPlayer.SetActive(true);
                    break;
                case 9:
                    StartCoroutine(TypeTextHat("어? 처음 보는 사람이네! 나랑 같이 파티하자!"));
                    PanelPlayer.SetActive(false);
                    Player.SetActive(false);
                    PanelHat.SetActive(true);
                    Hat.SetActive(true);
                    break;
                case 10:
                    StartCoroutine(TypeTextPlayer("파티라고? 미안하지만 나는 집으로 돌아갈 방법을 찾아야해"));
                    PanelHat.SetActive(false);
                    Hat.SetActive(false);
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 11:
                    StartCoroutine(TypeTextHat("뭐? 그런게 어디 있어! 나랑 같이 안생일파티 해야지"));
                    PanelHat.SetActive(true);
                    Hat.SetActive(true);
                    PanelPlayer.SetActive(false);
                    Player.SetActive(false);
                    break;
                case 12:
                    StartCoroutine(TypeTextPlayer("아니 나는 가봐야 하는데.."));
                    PanelHat.SetActive(false);
                    Hat.SetActive(false);
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 13:
                    StartCoroutine(TypeTextHat("그래도 차 한 잔은 하고 가"));
                    PanelHat.SetActive(true);
                    Hat.SetActive(true);
                    PanelPlayer.SetActive(false);
                    Player.SetActive(false);
                    break;
                case 14:
                    StartCoroutine(TypeTextPlayer("하..그래 알겠어"));
                    PanelHat.SetActive(false);
                    Hat.SetActive(false);
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 15:
                    DrinkTea(); // 플레이어 크기 조정 함수 호출
                    break;
                case 16:
                    Player.transform.localScale *= 0.2f;
                    Vector3 newPosition = new Vector3(22f, 13.3f, Player.transform.position.z);
                    Player.transform.position = newPosition;
                    StartCoroutine(TypeTextPlayer("어..! 내 몸이 작아졌잖아?!"));
                    break;
                case 17:
                    StartCoroutine(TypeTextHat("맛있지? 자, 한 잔 더 해!"));
                    PanelHat.SetActive(true);
                    Hat.SetActive(true);
                    PanelPlayer.SetActive(false);
                    break;
                case 18:
                    StartCoroutine(TypeTextPlayer("아니, 미안하지만 난 가봐야겠어"));
                    PanelHat.SetActive(false);
                    Hat.SetActive(false);
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 19:
                    StartCoroutine(TypeTextHat("뭐라고?! 지금 내가 주는 차를 거절하는 거야?"));
                    PanelHat.SetActive(true);
                    Hat.SetActive(true);
                    PanelPlayer.SetActive(false);
                    break;
                case 20:
                    StartCoroutine(TypeTextPlayer("헉! 화가 났잖아"));
                    PanelHat.SetActive(false);
                    Hat.SetActive(false);
                    PanelPlayer.SetActive(true);
                    Player.SetActive(true);
                    break;
                case 21:
                    StartCoroutine(TypeTextPlayer("잡히기 전에 도망가야겠어!"));
                    break;
                case 22:
                    SceneManager.LoadScene("2GameScene");
                    break;
                default:
                    Debug.Log("Default case executed");
                    break;
            }
        }
    }

    private void UpdateTalkTextPlayer(string text)
    {
        TalkTextPlayer.text = text;
        Debug.Log("TalkTextPlayer 업데이트: " + TalkTextPlayer.text);
    }


    private void UpdateTalkTextHat(string text)
    {
        TalkTextHat.text = text;
        Debug.Log("TalkTextHat 업데이트: " + TalkTextHat.text);
    }

    private IEnumerator TypeTextPlayer(string text)
    {
        isTyping = true; // 타이핑 시작
        TalkTextPlayer.text = "";
        foreach (char letter in text.ToCharArray())
        {
            TalkTextPlayer.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false; // 타이핑 종료
    }

    private IEnumerator TypeTextHat(string text)
    {
        isTyping = true; // 타이핑 시작
        TalkTextHat.text = "";
        foreach (char letter in text.ToCharArray())
        {
            TalkTextHat.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false; // 타이핑 종료
    }

    private IEnumerator DrinkAnimation()
    {
        isDrinkAnimationPlaying = true;

        PanelPlayer.SetActive(false);
        // 첫 번째 애니메이션 프레임으로 변경
        Player.GetComponent<SpriteRenderer>().sprite = PlayerDrink1Sprite;

        yield return new WaitForSeconds(0.3f);

        // 두 번째 애니메이션 프레임으로 변경
        Player.GetComponent<SpriteRenderer>().sprite = PlayerDrink2Sprite;

        yield return new WaitForSeconds(0.7f);

        // 다시 애니메이션1을 보여줌
        Player.GetComponent<SpriteRenderer>().sprite = PlayerDrink1Sprite;

        yield return new WaitForSeconds(0.5f);

        // 마지막 애니메이션 프레임으로 변경
        Player.GetComponent<SpriteRenderer>().sprite = PlayerFrontSprite;

        isDrinkAnimationPlaying = false;
    }

    private IEnumerator DrinkTeaCoroutine()
    {
        // DrinkAnimation 코루틴을 시작하고, 그 실행이 완료될 때까지 기다립니다.
        yield return StartCoroutine(DrinkAnimation());

        PanelPlayer.SetActive(true);
        StartCoroutine(TypeTextPlayer(" 꽤 맛있는데? "));

        // 코루틴이 완료된 후에 실행될 코드들을 여기에 넣습니다.
        // 플레이어 그림자 변경
        ShadowPlayer.SetActive(false);
        ShadowTable.SetActive(true);

        // 플레이어의 크기를 줄임
//        Player.transform.localScale *= 0.2f;

        // 새로운 위치 설정 x y
        // Vector3 newPosition = new Vector3(22f, 13.3f, Player.transform.position.z);
        // Player.transform.position = newPosition;
    }

    private void DrinkTea()
    {
        // DrinkTeaCoroutine을 StartCoroutine로 실행합니다.
        StartCoroutine(DrinkTeaCoroutine());
    }

    private void ClickYes() // 차를 마실 경우
    {
        Drink = true;
        Choice.SetActive(false);
        BackgroundOverlay.SetActive(false);
        DrinkTea();
    }

    private void ClickNo() // 차를 마시지 않을 경우
    {
        Drink = false;
        Choice.SetActive(false);
        BackgroundOverlay.SetActive(false);
    }

    void ReturnToMainMenu() // 메인메뉴로 돌아감
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
