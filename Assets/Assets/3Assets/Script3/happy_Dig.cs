using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class happy_Dig: MonoBehaviour
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
                Debug.Log("1���´�");
                Teacher.SetActive(true);
                Player.SetActive(false);
                SetText("��... ���� ���ӿ��� ���ٴ�... ");
                break;
            case 2:
                Debug.Log("1���´�");
                Teacher.SetActive(true);
                Player.SetActive(false);
                SetText("��.. �������� ����ִ� ����̾���");
                break;

            case 3:
                Debug.Log("2");
                Teacher.SetActive(false);
                Player.SetActive(true);
                SetText("���� �����մϴ�");
                break;

            case 4:

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
