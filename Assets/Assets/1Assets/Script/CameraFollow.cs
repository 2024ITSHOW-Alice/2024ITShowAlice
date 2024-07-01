using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform�� �����ϱ� ���� ����
    private Vector3 cameraOffset; // ī�޶�� �÷��̾� ������ �Ÿ�
    private float leftBound = -31f;
    private float rightBound = 31f;

    void Start()
    {
        // ī�޶�� �÷��̾��� �ʱ� ��� ��ġ�� ����մϴ�.
        cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // �÷��̾��� �� ��ġ�� ����մϴ�.
        Vector3 newPosition = playerTransform.position + cameraOffset;

        // x�� �̵� ������ -31f���� 31f�� �����մϴ�.
        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);

        // ī�޶��� y�� ��ġ�� ������Ű�� �ʹٸ�, ������ ���� newPosition�� y ���� �����մϴ�.
        // ��: newPosition.y = cameraOffset.y;

        transform.position = newPosition;
    }
}