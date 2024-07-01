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
                TalkTeacher.text = "���� ���� ��Ʈ������ ��� ������ ����?!";
                TalkPlayer.text = "";
                break;

            case 2:
                Teacher.SetActive(false);
                Player.SetActive(true);
                TalkPlayer.text = "�˼��ؿ� ���� �ٹ̸��ε���..";
                TalkTeacher.text = "";
                break;

            case 3:
                Teacher.SetActive(false);
                Player.SetActive(true);
                TalkPlayer.text = "�׳� ���� �б��� ���ư��� ���� ���̿���";
                TalkTeacher.text = "";
                break;

            case 4:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "�б�? ���� ���� �ϴ� �� �𸣰ڳ� ���� �� ��������̾�";
                TalkPlayer.text = "";
                break;

            case 5:
                Teacher.SetActive(false);
                Player.SetActive(true);
                TalkPlayer.text = "���� ���� �б��� ���ư����ؿ�. ���� �����ֽ� �� �ֳ���?";
                TalkTeacher.text = "";
                break;

            case 6:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "�ʰ� �� ����������� ���� �̻� �� ���� ������ �Ѱܾ߸� ��Ƴ��� �� �ִܴ�";
                TalkPlayer.text = "";
                break;

            case 7:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "�ȴٰ� �ص� �������� ���ܴ� ���^^";
                TalkPlayer.text = "";
                break;

            case 8:
                Teacher.SetActive(true);
                Player.SetActive(false);
                TalkTeacher.text = "�� �ִ� ������ 600���̾�. ��, ������ ��������";
                TalkPlayer.text = "";
                break;

            case 9:
                Opening.SetActive(false);
                Debug.Log("���ӷ� §~");
                break;

            default:
                Debug.Log("Default case executed");
                break;
        }
    }
}
