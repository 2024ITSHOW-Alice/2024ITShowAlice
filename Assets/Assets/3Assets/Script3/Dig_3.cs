using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dig_3 : MonoBehaviour
{
    public Text TalkPlayer;
    public Text TalkTeacher;
    private int clickCount = 0;
    public GameObject GameRule;
    public GameObject Opening;
    public GameObject Teacher;
    public GameObject Player;



    private bool isTyping = false;

    private void Start()
    {
        GameRule.SetActive(false);
        Opening.SetActive(true);
        Teacher.SetActive(false);
        Player.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
        {
            if (!isTyping)
            {
                StartCoroutine(HandleClickCount());
            }
        }
    }

    private IEnumerator HandleClickCount()
    {
        clickCount++;
        Debug.Log("Click Count: " + clickCount);

        switch (clickCount)
        {
            case 1:
                Teacher.SetActive(false); ;
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("휴.. 이제 못 쫓아오겠지?"));
                break;

            case 2:
                Teacher.SetActive(false); ;
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("다행히도 시간이 지나니까 몸이 원래대로 돌아왔네"));
                break;

            case 3:
                Teacher.SetActive(false); ;
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("아.. 근데 여긴 뭐 하는 곳이지..??"));
                break;

            case 4:
                Teacher.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("누가 감히 하트여왕의 장미 정원에 들어와?!!"));
                break;

            case 5:
                Teacher.SetActive(false); ;
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("엇..! 죄송합니다.. 굴에서 떨어지고.. 모자장수한테 쫓기다가 그만 여기까지.."));
                break;

            case 6:
                Teacher.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("뭐라는거니? 그래도 심심했는데 잘 됐다 나랑 골프대결하자!"));
                break;

            case 7:
                Teacher.SetActive(false);
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("아.. 저는 학교로 얼른 돌아가고 싶어서.. "));
                break;

    
            case 8:
                Teacher.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("흠 그러면 대결말고 나랑 내기하자"));
                break;

            case 9:
                yield return StartCoroutine(TypeTextCoroutine("너가 골프를 10번안에 쳐서 골에 넣으면 내가 학교라는곳으로 갈 수 있게 도와줄게"));
                break;

            case 10:
                yield return StartCoroutine(TypeTextCoroutine("대신 못 넣으면 너를 감옥으로 보낼거야. 알겠지?"));
                break;

            case 11:
                Teacher.SetActive(false);
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("조건이 이상하기는 하지만 선택지가 없으니까... 네 해보겠습니다"));
                break;
           

            case 12:
                GameRule.SetActive(true);
                Debug.Log("게임룰 짠~");
                //Opening.GetComponent<OpeningText>().enabled = false;
                break;

            default:
                Debug.Log("Default case executed");
                break;
        }
    }

    private IEnumerator TypeTextCoroutine(string text)
    {
        isTyping = true;
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