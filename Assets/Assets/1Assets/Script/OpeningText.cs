using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningText : MonoBehaviour
{
    public Text TalkPlayer;
    public Text TalkTeacher;
    private int clickCount = 0;
    public GameObject GameRule;
    public GameObject Opening;
    public GameObject Teacher;
    public GameObject Player;
    public GameObject sadpl;
    public GameObject fallpl;
    public GameObject pl;

    private bool isTyping = false;
    private bool canClick = true;

    public void Start()
    {
        Debug.Log("시작!!!");

        InitializeScene();
        Debug.Log("시작!!!");
    }

    private void InitializeScene()
    {
        clickCount = 0;  // 초기화
        canClick = true; // 초기화
        isTyping = false; // 초기화

        GameRule.SetActive(false);
        Opening.SetActive(true);
        Teacher.SetActive(false);
        Player.SetActive(true);
        pl.SetActive(false);
        fallpl.SetActive(false);
        Debug.Log("초기화");
    }

    void Update()
    {
        if (canClick && (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            StartCoroutine(HandleClickCount());
            canClick = false;
        }
    }

    private IEnumerator HandleClickCount()
    {
        clickCount++;
        Debug.Log("Click Count: " + clickCount);

        switch (clickCount)
        {
            case 1:
                Teacher.SetActive(false);
                Player.SetActive(true);
                sadpl.SetActive(true);
                pl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("아 이거 너무 어려운데ㅠㅠ 선생님께 여쭤볼까?"));
                break;
            case 2:
                Teacher.SetActive(true);
                Player.SetActive(false);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("늦었다!! 이러다가 회의 지각하겠어!"));
                break;
            case 3:
                Teacher.SetActive(false);
                Player.SetActive(true);
                pl.SetActive(true);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("엇, 저기 쌤이잖아!"));
                break;
            case 4:
                Teacher.SetActive(false);
                Player.SetActive(true);
                pl.SetActive(true);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("쌤을 따라가야겠어! 쌤!! 쌤!"));
                break;
            case 5:
                Teacher.SetActive(true);
                Player.SetActive(false);
                sadpl.SetActive(false);
                pl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine(" 늦었다, 늦었어"));
                break;
            case 6:
                Teacher.SetActive(false);
                Player.SetActive(true);
                pl.SetActive(true);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("쌤쌤!!"));
                break;
            case 7:
                Teacher.SetActive(false);
                Player.SetActive(true);
                sadpl.SetActive(false);
                pl.SetActive(false);
                TalkPlayer.alignment = TextAnchor.MiddleCenter;
                TalkTeacher.alignment = TextAnchor.MiddleCenter;
                yield return StartCoroutine(TypeTextCoroutine("(구덩이에 빠지게 된다)"));
                break;
            case 8:
                TalkPlayer.alignment = TextAnchor.UpperLeft;
                TalkTeacher.alignment = TextAnchor.UpperLeft;
                Teacher.SetActive(false);
                fallpl.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("으악!!"));
                GameRule.SetActive(true);
                
               
                break;
            case 9:
                GameRule.SetActive(true);
                
                Debug.Log("게임룰 짠~");
                break;
            default:

                Debug.Log("Default case executed");
                break;
        }

        yield return new WaitForSeconds(0.5f); // 클릭 간 대기 시간 추가
        canClick = true; // 클릭 가능 상태로 변경
    }

    private IEnumerator TypeTextCoroutine(string text)
    {
        //isTyping = true;
        TalkPlayer.text = "";
        TalkTeacher.text = "";

        foreach (char c in text)
        {
            TalkPlayer.text += c;
            TalkTeacher.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }
}
