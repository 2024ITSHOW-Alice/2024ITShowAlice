using UnityEngine;

public class HeartController : MonoBehaviour
{

    public Sprite activeHeartImg; // Ȱ��ȭ ������ ��Ʈ �̹���
    public Sprite deadHeartImg; // ��Ȱ��ȭ ������ ��Ʈ �̹���

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetActiveHeart(true); // �⺻������ ��Ʈ�� Ȱ��ȭ ���·� ����
    }

    // ��Ʈ�� Ȱ��ȭ ���¸� �����ϴ� �Լ�
    public void SetActiveHeart(bool isActive)
    {
        if (isActive)
        {
            spriteRenderer.sprite = activeHeartImg;
        }
        else
        {
            spriteRenderer.sprite = deadHeartImg;
        }
    }
}