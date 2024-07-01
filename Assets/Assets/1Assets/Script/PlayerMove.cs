using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveDistance = 1f; // �̵� �Ÿ�

    private Rigidbody2D rb; // Rigidbody2D ������Ʈ ���� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ���� �� Rigidbody2D ������Ʈ ��������

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D ������Ʈ�� �� ���� ������Ʈ�� ÷�ε��� �ʾҽ��ϴ�.");
        }
        else
        {
            // �߷� ���� �� ���ʿ��� ȸ���� �����ϱ� ���� Z�� ȸ���� �����մϴ�.
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Update()
    {
        // ���� ��/�Ʒ�/��/�� ����Ű�� �̵��� ó���մϴ�.
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
            // A�� D Ű�� ������ �ƹ��� �̺�Ʈ�� �߻����� �ʵ��� ó���մϴ�.
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                // �ƹ� ���۵� ���� �ʽ��ϴ�.

            }
        }
    }

    void Move(Vector3 direction)
    {
        // �������� ���ο� ��ġ ���
        Vector3 newPosition = transform.position + direction * moveDistance;

        // ���ο� ��ġ�� ȭ�� ��� ���� �ִ��� Ȯ��
        Vector3 viewPos = Camera.main.WorldToViewportPoint(newPosition);
        viewPos.x = Mathf.Clamp(viewPos.x, -15f, 15f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
        newPosition = Camera.main.ViewportToWorldPoint(viewPos);

        // ���� ��ġ ������Ʈ
        transform.position = newPosition;
    }
}
