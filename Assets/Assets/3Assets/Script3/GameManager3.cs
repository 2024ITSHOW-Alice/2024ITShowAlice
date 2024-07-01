using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    public GameObject ball; // 공

    public float rotationSpeed;

    private Transform ballTrans;
    private Rigidbody2D rigid;
    public float power;

    public GameObject arrow;
    private bool ready; // 준비가 되었는지 확인 변수
    private bool isStop; // 공이 멈췄는지

    public Text par; // 플레이어 타수
    public int num; // 일정 타수

    public SpriteRenderer spriteR;
    private bool right;
    public static int ScoreUp = 0;

    private bool happy;
    private bool bad;

    private bool Stopspace;
    private float timer;
    private int waitingTime = 1;
    public GameObject Round1;
    public GameObject panel;

    private int currentRoundIndex = 1;

    private GameObject[] Round;

    private GameSound3 gameSound3;

    void Start()
    {
        gameSound3= FindObjectOfType<GameSound3>();
        gameSound3.PlaySong();
        ballTrans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();

        Round = new GameObject[]{Round1};

        ready = false;
        isStop = true;
        arrow.SetActive(false);
        right = true;
        timer = 0.0f;
        Stopspace = false;

        happy = false;
        bad = false;

        if (Round1 != null)
        {
            ShowImage(Round1);
            ShowImage(panel);
            StartCoroutine(HideImageAfterSeconds(Round1, 1, panel));
            StartCoroutine(HideImageAfterSeconds(panel, 1, panel));

        }
        else
        {
            Debug.LogError("Round1이 설정되지 않았습니다.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        par.text = num.ToString();
        Vector2 ballVelocity = rigid.velocity;

        if (ballVelocity.magnitude < 0.1f)
        {
            isStop = true;
        }

        // 타수가 0이 되면 다음 라운드로 넘어가기
        if (num <= 0)
        {
            bad = true;
        }

        // 화살표 위 아래 포물선
        if (right == true)
        {
            transform.localScale = new Vector3(2.58245f, 2.58245f, 1f);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            }
        }
        else if (right == false)
        {
            transform.localScale = new Vector3(-2.58245f, 2.58245f, 1f);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }

        // 화살표 왼쪽 오른쪽 방향
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            right = false;
            spriteR.flipX = true;
            ballTrans.eulerAngles = new Vector3(0, 0, -45);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right = true;
            spriteR.flipX = false;
            ballTrans.eulerAngles = new Vector3(0f, 0f, 45f);
        }

        if (timer >= waitingTime)
        {
            Stopspace = true;
            if (Stopspace == true)
            {
                // 스페이스 누르면 공 날라감
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    switch (ready)
                    {
                        case true:
                            gameSound3.PlayGolfSound();
                            if (right == true)
                            {
                                rigid.AddForce(transform.right * power, ForceMode2D.Impulse);
                            }
                            else if (right == false)
                            {
                                rigid.AddForce(-transform.right * power, ForceMode2D.Impulse);
                            }
                            arrow.SetActive(false);
                            isStop = false;
                            ready = false;
                            num--;
                            break;
                        case false:
                            if (isStop == true)
                            {
                                ready = true;
                                arrow.SetActive(true);
                                ballTrans.eulerAngles = new Vector3(0, 0, 45);
                            }
                            break;
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }

        if (bad == true)
        {
            SceneManager.LoadScene("Ending_bad");
        }
        else if (happy == true)
        {
            SceneManager.LoadScene("Ending_happy_Dig");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ScoreUp = 300;

        if (other.tag == "Finish")
        {
            if (ScoreUp >= 300)
            {
                happy = true;
            }
            else if(ScoreUp < 300)
            {
                bad = true;
            }
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowNextImage()
    {
        if (currentRoundIndex < Round.Length)
        {
            GameObject image = Round[currentRoundIndex];
            ShowImage(image);
            ShowImage(panel);
            StartCoroutine(HideImageAfterSeconds(image, 1, panel));
            StartCoroutine(HideImageAfterSeconds(panel, 1, panel));
            currentRoundIndex++;
        }
    }

    IEnumerator HideImageAfterSeconds(GameObject image, float seconds, GameObject panel)
    {
        yield return new WaitForSeconds(seconds);
        image.SetActive(false);
        panel.SetActive(false);
    }

    private void ShowImage(GameObject image)
    {
        if (image != null)
        {
            image.SetActive(true);
            panel.SetActive(true);
        }
        else
        {
            Debug.LogError("Image가 설정되지 않았습니다.");
        }
    }

}
