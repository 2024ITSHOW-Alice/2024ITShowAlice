using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Happytalk : MonoBehaviour
{
    public Text TalkPlayer;
    public Text TalkTeacher;
    private int clickCount = 0;
    public GameObject Opening;
    public GameObject Teacher;
    public GameObject Player;

    private void Start()
    {
        Opening.SetActive(true);
        Teacher.SetActive(true);
        Player.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
        {
            HandleClickCount();
        }
    }

    private void HandleClickCount()
    {
        clickCount++;
        Debug.Log("Click Count: " + clickCount);

        switch (clickCount)
        {
            case 1:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "누가 감히 하트여왕의 장미 정원에 들어와?!";
                TalkPlayer.text = "";
                break;

            case 2:
                Teacher.SetActive(false);
                Player.SetActive(true);
                TalkPlayer.text = "죄송해요 저는 앨미림인데요..";
                TalkTeacher.text = "";
                break;

            case 3:
                Teacher.SetActive(false);
                Player.SetActive(true);
                TalkPlayer.text = "그냥 저는 학교로 돌아가고 싶을 뿐이에요";
                TalkTeacher.text = "";
                break;

            case 4:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "학교? 무슨 말을 하는 지 모르겠네 여긴 내 장미정원이야";
                TalkPlayer.text = "";
                break;

            case 5:
                Teacher.SetActive(false);
                Player.SetActive(true);
                TalkPlayer.text = "저는 정말 학교로 돌아가야해요. 저를 도와주실 수 있나요?";
                TalkTeacher.text = "";
                break;

            case 6:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "너가 내 장미정원으로 들어온 이상 내 골프 점수를 넘겨야만 살아나갈 수 있단다";
                TalkPlayer.text = "";
                break;

            case 7:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "싫다고 해도 선택지는 없단다 얘야^^";
                TalkPlayer.text = "";
                break;

            case 8:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "내 최대 점수는 600점이야. 자, 게임을 시작하지";
                TalkPlayer.text = "";
                break;

            case 9:
                Opening.SetActive(false);
                Debug.Log("게임룰 짠~");
                break;

            default:
                Debug.Log("Default case executed");
                break;
        }
    }
}
