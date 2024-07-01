using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Sprite backgroundSprite; // 배경 이미지 변수
    private float backgroundWidth, backgroundHeight; // 배경 이미지의 너비와 높이
    private float leftBound, rightBound, bottomBound, topBound; // 배경 경계 변수

    void Start()
    {
        // 배경 이미지의 너비와 높이를 가져옴
        Texture2D texture = (Texture2D)backgroundSprite.texture;
        backgroundWidth = texture.width;
        backgroundHeight = texture.height;

        // 배경 경계 설정
        leftBound = -backgroundWidth / 2f;
        rightBound = backgroundWidth / 2f;
        bottomBound = -backgroundHeight / 2f;
        topBound = backgroundHeight / 2f;

        // 카메라 위치를 화면 중앙으로 설정
        transform.position = new Vector3(0f, 0f, transform.position.z);
    }

    void Update()
    {
        if (target != null)
        {
            // 타겟의 위치를 배경 경계 내로 제한
            float targetX = Mathf.Clamp(target.position.x, leftBound, rightBound);
            float targetY = Mathf.Clamp(target.position.y, bottomBound, topBound);
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}