using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int speed = 18;
    public float minYPosition = 1f;
    public float maxYPosition = 1f;
    public float minXPosition = -13f;
    public float maxXPosition = 13f;


    public Sprite playerBad_img;
    public Sprite deadHeart_img; // ���� ��Ʈ �̹���
    private SpriteRenderer spriteRenderer;
    private Sprite player_img;
    private Rigidbody2D rb;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component is missing from the Player game object.");
        }
        else
        {
            player_img = spriteRenderer.sprite;
        }

        if (playerBad_img == null || deadHeart_img == null)
        {
            Debug.LogError("playerBad_img or deadHeart_img is not assigned in the Player script.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the Player game object.");
        }
        else
        {
            rb.gravityScale = 0; // �߷� ���� ����
            rb.constraints = RigidbodyConstraints2D.FreezePositionY; // y�� ��ġ ����
        }

        // ��Ʈ ������Ʈ�� �Ҵ�Ǿ����� Ȯ��
        if (heart1 == null || heart2 == null || heart3 == null)
        {
            Debug.LogError("One or more heart GameObjects are not assigned.");
        }
    }

    private void Update()
    {
        float playerMoveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float clampedXPosition = Mathf.Clamp(transform.position.x + playerMoveX, minXPosition, maxXPosition);
        transform.position = new Vector3(clampedXPosition, transform.position.y, transform.position.z);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Debug.Log("Collision with Trap detected!");

            if (spriteRenderer == null || playerBad_img == null || deadHeart_img == null)
            {
                Debug.LogError("SpriteRenderer, playerBad_img, or deadHeart_img is not assigned.");
                return;
            }

            spriteRenderer.sprite = playerBad_img;
            StartCoroutine(ChangePlayerSpriteBack());

            ChangeHeartImage(); // ��Ʈ �̹��� ���� �Լ� ȣ��

            if (GameManager.Instance == null)
            {
                Debug.LogError("GameManager.Instance is null.");
                return;
            }

            GameManager.Instance.IncreaseHitCount();

            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ChangePlayerSpriteBack()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = player_img;
    }

    private void ChangeHeartImage() // ��Ʈ �̹��� ���� �Լ�
    {
        ChangeHeartSprite(heart1);
        ChangeHeartSprite(heart2);
        ChangeHeartSprite(heart3);
    }

    private void ChangeHeartSprite(GameObject heart)
    {
        if (heart != null)
        {
            SpriteRenderer heartSpriteRenderer = heart.GetComponent<SpriteRenderer>();
            if (heartSpriteRenderer != null)
            {
                heartSpriteRenderer.sprite = deadHeart_img; // ��Ʈ�� �̹����� ���� ��Ʈ �̹����� ����
                Debug.Log($"{heart.name} sprite changed to deadHeart_img.");
            }
            else
            {
                Debug.LogError($"{heart.name} does not have a SpriteRenderer component.");
            }
        }
        else
        {
            Debug.LogError("Heart GameObject is null.");
        }
    }
}