using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform을 참조하기 위한 변수
    private Vector3 cameraOffset; // 카메라와 플레이어 사이의 거리
    private float leftBound = -31f;
    private float rightBound = 31f;

    void Start()
    {
        // 카메라와 플레이어의 초기 상대 위치를 계산합니다.
        cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // 플레이어의 새 위치를 계산합니다.
        Vector3 newPosition = playerTransform.position + cameraOffset;

        // x축 이동 범위를 -31f에서 31f로 제한합니다.
        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);

        // 카메라의 y축 위치를 고정시키고 싶다면, 다음과 같이 newPosition의 y 값을 조정합니다.
        // 예: newPosition.y = cameraOffset.y;

        transform.position = newPosition;
    }
}