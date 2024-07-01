using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove3 : MonoBehaviour
{
    private float speed = 20;
    private SpriteRenderer spriteRenderer;

    public Sprite playerRight1;
    public Sprite playerRight2;
    public Sprite playerLeft1;
    public Sprite playerLeft2;
    public Sprite playerFront;

    public bool trig;

    private bool isFacingRight = true; // 플레이어가 오른쪽을 보고 있는지 여부

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trig = false;
    }

    void Update()
    {
        Vector2 position = transform.position;
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0) // 우측 이동
        {
            position.x += speed * Time.deltaTime;
            if (!isFacingRight)
            {
                isFacingRight = true;
                spriteRenderer.sprite = playerRight1;
            }
            else
            {
                spriteRenderer.sprite = (Time.time % 0.4f < 0.5f) ? playerRight1 : playerRight2;
            }
        }
        else if (moveInput < 0) // 좌측 이동
        {
            position.x -= speed * Time.deltaTime;
            if (isFacingRight)
            {
                isFacingRight = false;
                spriteRenderer.sprite = playerLeft1;
            }
            else
            {
                spriteRenderer.sprite = (Time.time % 0.4f < 0.5f) ? playerLeft1 : playerLeft2;
            }
        }
        else
        {
            spriteRenderer.sprite = playerFront; // 정지 시 이미지 변경
        }

        transform.position = position;
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            trig = true;
        }

        if (trig == true)
        {
            SceneManager.LoadScene("Ending_happy2");
        }
    }
}

