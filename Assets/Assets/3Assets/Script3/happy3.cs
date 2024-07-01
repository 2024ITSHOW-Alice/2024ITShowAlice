using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class happy3 : MonoBehaviour
{
    public Text TalkPlayer;
    public Text TalkTeacher;
    public Text Talkfriend;
    private int clickCount = 0;
    public GameObject Opening;
    public GameObject Teacher;
    public GameObject Player;
    public GameObject friend;



    private bool isTyping = false;

    private void Start()
    {
 
        Opening.SetActive(true);
        Teacher.SetActive(false);
        Player.SetActive(false);
        friend.SetActive(true);
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
               
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("�߾� �Ͼ"));
                break;

            case 2:
                friend.SetActive(false); ;
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("��.. ����..?"));
                break;

            case 3:
                friend.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("�����Բ��� �� ������ �ϼ̾�"));
                break;

            case 4:
                friend.SetActive(false);
                Player.SetActive(false);
                Teacher.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("�߾� �����Ŵ� �˰ڴµ� ������� ��������"));
                Debug.Log("�� ");
                break;

            case 5:
                friend.SetActive(false);
                Player.SetActive(true);
                Teacher.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("��..? ���� �и� ��Ʈ�����̶�....�׷� �̰� �� ���̿���??"));
                break;
            case 6:
                friend.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("����;; ���������� �����̳� ���"));
                break;
            case 7:
                SceneManager.LoadScene("Ending_Ani");
                break;

            default:
                SceneManager.LoadScene("Ending_Ani");
                Debug.Log("Default case executed");
                break;
        }
    }

    private IEnumerator TypeTextCoroutine(string text)
    {
        isTyping = true;
        TalkPlayer.text = "";
        Talkfriend.text = "";
        TalkTeacher.text = " ";

        foreach (char c in text)
        {
            TalkPlayer.text += c;
            Talkfriend.text += c;
            TalkTeacher.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }
}