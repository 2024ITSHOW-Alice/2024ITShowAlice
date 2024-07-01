using UnityEngine;

public class HeartController : MonoBehaviour
{

    public Sprite activeHeartImg; // 활성화 상태의 하트 이미지
    public Sprite deadHeartImg; // 비활성화 상태의 하트 이미지

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetActiveHeart(true); // 기본적으로 하트를 활성화 상태로 설정
    }

    // 하트의 활성화 상태를 설정하는 함수
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