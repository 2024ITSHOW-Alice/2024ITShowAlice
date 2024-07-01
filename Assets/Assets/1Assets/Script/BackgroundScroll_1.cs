using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 20f; // 스크롤 속도 (더 빠르게 설정)
    public float tileSizeY = 100f; // 타일 크기
    private Vector3 startPosition; // 시작 위치

    void Start()
    {
        startPosition = transform.position; // 시작 위치 초기화
    }

    void Update()
    {
        if (tileSizeY == 0)
        {
            Debug.LogError("tileSizeY는 0이 될 수 없습니다. 유효한 값을 할당해주세요.");
            return; // tileSizeY가 0이면 여기서 함수 실행을 중단합니다.
        }

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);

        if (float.IsNaN(newPosition))
        {
            Debug.LogError("newPosition 계산 결과가 NaN입니다. 계산을 확인해주세요.");
            return; // newPosition이 NaN이면 여기서 함수 실행을 중단합니다.
        }

        // Vector3.down 대신 Vector3.up을 사용하여 배경이 위로 스크롤되도록 변경
        transform.position = startPosition + Vector3.up * newPosition;
    }
}
