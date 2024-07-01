using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveDistance = 1f; // 이동 거리

    private Rigidbody2D rb; // Rigidbody2D 컴포넌트 참조 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 시작 시 Rigidbody2D 컴포넌트 가져오기

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D 컴포넌트가 이 게임 오브젝트에 첨부되지 않았습니다.");
        }
        else
        {
            // 중력 적용 및 불필요한 회전을 방지하기 위해 Z축 회전을 고정합니다.
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Update()
    {
        // 오직 위/아래/좌/우 방향키만 이동을 처리합니다.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }
        else
        {
            // A와 D 키를 눌러도 아무런 이벤트가 발생하지 않도록 처리합니다.
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                // 아무 동작도 하지 않습니다.

            }
        }
    }

    void Move(Vector3 direction)
    {
        // 잠재적인 새로운 위치 계산
        Vector3 newPosition = transform.position + direction * moveDistance;

        // 새로운 위치가 화면 경계 내에 있는지 확인
        Vector3 viewPos = Camera.main.WorldToViewportPoint(newPosition);
        viewPos.x = Mathf.Clamp(viewPos.x, -15f, 15f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
        newPosition = Camera.main.ViewportToWorldPoint(viewPos);

        // 실제 위치 업데이트
        transform.position = newPosition;
    }
}
