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
        Debug.Log("����!!!");

        InitializeScene();
        Debug.Log("����!!!");
    }

    private void InitializeScene()
    {
        clickCount = 0;  // �ʱ�ȭ
        canClick = true; // �ʱ�ȭ
        isTyping = false; // �ʱ�ȭ

        GameRule.SetActive(false);
        Opening.SetActive(true);
        Teacher.SetActive(false);
        Player.SetActive(true);
        pl.SetActive(false);
        fallpl.SetActive(false);
        Debug.Log("�ʱ�ȭ");
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
                yield return StartCoroutine(TypeTextCoroutine("�� �̰� �ʹ� �����Ф� �����Բ� ���庼��?"));
                break;
            case 2:
                Teacher.SetActive(true);
                Player.SetActive(false);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("�ʾ���!! �̷��ٰ� ȸ�� �����ϰھ�!"));
                break;
            case 3:
                Teacher.SetActive(false);
                Player.SetActive(true);
                pl.SetActive(true);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("��, ���� �����ݾ�!"));
                break;
            case 4:
                Teacher.SetActive(false);
                Player.SetActive(true);
                pl.SetActive(true);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("���� ���󰡾߰ھ�! ��!! ��!"));
                break;
            case 5:
                Teacher.SetActive(true);
                Player.SetActive(false);
                sadpl.SetActive(false);
                pl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine(" �ʾ���, �ʾ���"));
                break;
            case 6:
                Teacher.SetActive(false);
                Player.SetActive(true);
                pl.SetActive(true);
                sadpl.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("�ܽ�!!"));
                break;
            case 7:
                Teacher.SetActive(false);
                Player.SetActive(true);
                sadpl.SetActive(false);
                pl.SetActive(false);
                TalkPlayer.alignment = TextAnchor.MiddleCenter;
                TalkTeacher.alignment = TextAnchor.MiddleCenter;
                yield return StartCoroutine(TypeTextCoroutine("(�����̿� ������ �ȴ�)"));
                break;
            case 8:
                TalkPlayer.alignment = TextAnchor.UpperLeft;
                TalkTeacher.alignment = TextAnchor.UpperLeft;
                Teacher.SetActive(false);
                fallpl.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("����!!"));
                GameRule.SetActive(true);
                
               
                break;
            case 9:
                GameRule.SetActive(true);
                
                Debug.Log("���ӷ� §~");
                break;
            default:

                Debug.Log("Default case executed");
                break;
        }

        yield return new WaitForSeconds(0.5f); // Ŭ�� �� ��� �ð� �߰�
        canClick = true; // Ŭ�� ���� ���·� ����
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
