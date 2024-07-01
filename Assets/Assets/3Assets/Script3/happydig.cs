using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class happydig : MonoBehaviour
{
    public Text TalkPlayer;
    public Text TalkTeacher;
    private int clickCount = 0;
    public GameObject Opening;
    public GameObject Teacher;
    public GameObject Player;

    private bool isTyping = false;
    private bool canClick = true;

    private void Start()
    {
        // InitializeScene();
        Opening.SetActive(true);
        Teacher.SetActive(true);
        Player.SetActive(false);
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
                yield return StartCoroutine(TypeTextCoroutine("하... 내가 내기에서 지다니", TalkTeacher));
                break;

            case 2:
                Debug.Log("2");
                Teacher.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("그래.. 뭐 약속은 지켜야지 걸어가다 보면 파란 문이 보일거야. 파란 문은 너가 원하는 곳으로 데려다 줘", TalkTeacher));
                break;

            case 3:
                Teacher.SetActive(false);
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("감사합니다!!", TalkPlayer));
                //SceneManager.LoadScene("Ending_happy1");
                break;

            case 4:
                SceneManager.LoadScene("Ending_happy1");
                Opening.SetActive(false);
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
