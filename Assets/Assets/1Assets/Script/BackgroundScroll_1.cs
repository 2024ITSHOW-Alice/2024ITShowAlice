using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 20f; // ��ũ�� �ӵ� (�� ������ ����)
    public float tileSizeY = 100f; // Ÿ�� ũ��
    private Vector3 startPosition; // ���� ��ġ

    void Start()
    {
        startPosition = transform.position; // ���� ��ġ �ʱ�ȭ
    }

    void Update()
    {
        if (tileSizeY == 0)
        {
            Debug.LogError("tileSizeY�� 0�� �� �� �����ϴ�. ��ȿ�� ���� �Ҵ����ּ���.");
            return; // tileSizeY�� 0�̸� ���⼭ �Լ� ������ �ߴ��մϴ�.
        }

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);

        if (float.IsNaN(newPosition))
        {
            Debug.LogError("newPosition ��� ����� NaN�Դϴ�. ����� Ȯ�����ּ���.");
            return; // newPosition�� NaN�̸� ���⼭ �Լ� ������ �ߴ��մϴ�.
        }

        // Vector3.down ��� Vector3.up�� ����Ͽ� ����� ���� ��ũ�ѵǵ��� ����
        transform.position = startPosition + Vector3.up * newPosition;
    }
}
