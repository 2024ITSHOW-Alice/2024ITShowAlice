using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class happy1 : MonoBehaviour
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
                Debug.Log("1나온다");
                Teacher.SetActive(true);
                Player.SetActive(false);
                SetText("하하! 역시 내가 이길줄 알았어!");
                break;

            case 2:
                Debug.Log("2");
                Teacher.SetActive(false);
                Player.SetActive(true);
                SetText("안 돼..!");
                break;

            case 3:
                Debug.Log("3");
                Teacher.SetActive(true);
                Player.SetActive(false);
                SetText("너가 졌으니 넌 이제 감옥으로 보내야겠어");
                break;

            case 4:
                Teacher.SetActive(false);
                Player.SetActive(true);
                SetText("저는 집에 꼭 돌아가야해요! 제발 이러지마세요");

                break;

            case 9:
                SceneManager.LoadScene("Ending_happy1");
                break;
        }
    }

    private void SetText(string text)
    {
        TalkPlayer.text = text;
        TalkTeacher.text = text;
    }
}
