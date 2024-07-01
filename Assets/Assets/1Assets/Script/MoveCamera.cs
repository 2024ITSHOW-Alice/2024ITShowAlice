using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Sprite backgroundSprite; // ��� �̹��� ����
    private float backgroundWidth, backgroundHeight; // ��� �̹����� �ʺ�� ����
    private float leftBound, rightBound, bottomBound, topBound; // ��� ��� ����

    void Start()
    {
        // ��� �̹����� �ʺ�� ���̸� ������
        Texture2D texture = (Texture2D)backgroundSprite.texture;
        backgroundWidth = texture.width;
        backgroundHeight = texture.height;

        // ��� ��� ����
        leftBound = -backgroundWidth / 2f;
        rightBound = backgroundWidth / 2f;
        bottomBound = -backgroundHeight / 2f;
        topBound = backgroundHeight / 2f;

        // ī�޶� ��ġ�� ȭ�� �߾����� ����
        transform.position = new Vector3(0f, 0f, transform.position.z);
    }

    void Update()
    {
        if (target != null)
        {
            // Ÿ���� ��ġ�� ��� ��� ���� ����
            float targetX = Mathf.Clamp(target.position.x, leftBound, rightBound);
            float targetY = Mathf.Clamp(target.position.y, bottomBound, topBound);
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}