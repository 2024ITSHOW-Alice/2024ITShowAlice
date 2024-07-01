using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bad : MonoBehaviour
{
    public Text TalkPlayer;
    public Text TalkTeacher;
    private int clickCount = 0;
    public GameObject GameRule;
    public GameObject Opening;
    public GameObject Teacher;
    public GameObject Player;

    private bool isTyping = false;
    private bool canClick = true;
    private GameSound3 gameSound3;    

    private void Start()
    {
        // InitializeScene();

        GameRule.SetActive(false);
        Opening.SetActive(true);
        Teacher.SetActive(true);
        Player.SetActive(false);
        gameSound3 = FindObjectOfType<GameSound3>();
    }

    /*    private void InitializeScene()
        {
            clickCount = 0;  // 초기화
            canClick = true; // 초기화
            isTyping = false; // 초기화

            GameRule.SetActive(false);
            Opening.SetActive(true);
            Teacher.SetActive(false);
            Player.SetActive(true);
            Debug.Log("초기화");
        }*/

    void Update()
    {
        if (canClick && (Input.GetMouseButtonUp(0) || Input.touchCount > 0))
        {
            StartCoroutine(HandleClickCount());
        }
    }

    private IEnumerator HandleClickCount()
    {
        canClick = false;
        clickCount++;
        Debug.Log("Click Count: " + clickCount);

        switch (clickCount)
        {
            case 1:
                Debug.Log("1나온다");
                Teacher.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("하하! 역시 내기에서 내가 이길 줄 알았어", TalkTeacher));
                break;

            case 2:
                Debug.Log("2");
                Teacher.SetActive(false);
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("안 돼..!", TalkPlayer));
                break;

            case 3:
                Debug.Log("3");
                Teacher.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("너가 졌으니 이제 감옥으로 보내야겠어", TalkTeacher));
                break;

            case 4:
                Teacher.SetActive(false);
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("저는 집에 꼭 돌아가야해요! 제발 이러지마세요", TalkPlayer));
              /*  Opening.SetActive(false);
                GameRule.SetActive(true);*/
                break;

            case 5:
                Opening.SetActive(false);
                GameRule.SetActive(true);
                // Bad Ending 사운드 재생
                if (gameSound3 != null)
                {
                    gameSound3.PlayBadEnding();
                }
                Debug.Log("배드배경");
                break;

            default:
                Debug.Log("Default case executed");
                break;
        }

        yield return new WaitForSeconds(0.5f); // 클릭 간 대기 시간 추가
        canClick = true; // 클릭 가능 상태로 변경
    }

    private IEnumerator TypeTextCoroutine(string text, Text textBox)
    {
        isTyping = true;
        textBox.text = "";

        foreach (char c in text)
        {
            textBox.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }
}