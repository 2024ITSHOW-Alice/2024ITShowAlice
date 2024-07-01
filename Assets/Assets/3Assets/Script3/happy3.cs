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
                yield return StartCoroutine(TypeTextCoroutine("야야 일어나"));
                break;

            case 2:
                friend.SetActive(false); ;
                Player.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("어.. 뭐야..?"));
                break;

            case 3:
                friend.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("선생님께서 너 깨우라고 하셨어"));
                break;

            case 4:
                friend.SetActive(false);
                Player.SetActive(false);
                Teacher.SetActive(true);
                yield return StartCoroutine(TypeTextCoroutine("야야 졸린거는 알겠는데 엎드려서 자지말자"));
                Debug.Log("썜 ");
                break;

            case 5:
                friend.SetActive(false);
                Player.SetActive(true);
                Teacher.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("어..? 나는 분명 하트여왕이랑....그럼 이게 다 꿈이였어??"));
                break;
            case 6:
                friend.SetActive(true);
                Player.SetActive(false);
                yield return StartCoroutine(TypeTextCoroutine("뭐래;; 정신차리고 수업이나 들어"));
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