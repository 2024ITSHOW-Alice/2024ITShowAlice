using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 60;
    private SpriteRenderer spriteRenderer;

    public Sprite playerRight1;
    public Sprite playerRight2;
    public Sprite playerLeft1;
    public Sprite playerLeft2;
    public Sprite playerFront;
    public Sprite playerDown;

    private bool isFacingRight = true;
    private bool isKeyDownPressed = false;

    private GameStart GameStart;

    public bool IsKeyDownPressed => isKeyDownPressed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameStart = FindObjectOfType<GameStart>();
    }

    void Update()
    {
        if (GameStart.GameRunning)
        {
            Vector2 position = transform.position;
            float moveInput = 0;

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                isKeyDownPressed = true;
                spriteRenderer.sprite = playerDown;
            }
            else
            {
                isKeyDownPressed = false;

                // 화살표 키와 A, D 키로 입력 받기
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // 오른쪽 화살표 키 또는 D 키
                {
                    moveInput = 1;
                    position.x += speed * Time.deltaTime;
                    if (!isFacingRight)
                    {
                        isFacingRight = true;
                    }
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // 왼쪽 화살표 키 또는 A 키
                {
                    moveInput = -1;
                    position.x -= speed * Time.deltaTime;
                    if (isFacingRight)
                    {
                        isFacingRight = false;
                    }
                }
                else
                {
                    moveInput = 0;
                }

                // x 좌표가 200 이하로 이동하지 못하게 제한
                if (position.x < 200)
                {
                    position.x = 200;
                }

                transform.position = position;

                // 스프라이트 업데이트
                UpdateSprite(moveInput);
            }
        }
    }

    void UpdateSprite(float moveInput)
    {
        if (isKeyDownPressed) // 아래쪽 화살표 키 또는 S 키가 눌려진 동안
        {
            spriteRenderer.sprite = playerDown; // playerDown 스프라이트를 보여줌
        }
        else
        {
            if (moveInput > 0) // 우측 이동
            {
                spriteRenderer.sprite = (Time.time % 0.4f < 0.2f) ? playerRight1 : playerRight2;
            }
            else if (moveInput < 0) // 좌측 이동
            {
                spriteRenderer.sprite = (Time.time % 0.4f < 0.2f) ? playerLeft1 : playerLeft2;
            }
            else // 이동 입력이 없는 경우
            {
                spriteRenderer.sprite = playerFront; // 정면을 보도록 설정
            }
        }
    }
}
